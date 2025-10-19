using BLL.IService;
using BLL.Service;
using DAL.IRepository;
using DAL.Model;
using DAL.Model.Momo;
using DAL.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Quiz.Server;
using Quiz.Server.TokenHandler;
using Share;
using System.Text;
using Npgsql.EntityFrameworkCore.PostgreSQL; // enable UseNpgsql extension

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddHttpClient();
builder.Logging.AddConsole();

// 🔹 Database - switched to PostgreSQL (Npgsql)
builder.Services.AddDbContext<QuizDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 Authentication setup (JWT + GoogleAccessToken)
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    builder.Configuration["Jwt:Key"]
                    ?? throw new Exception("❌ Missing Jwt:Key in configuration")
                )
            ),
            ClockSkew = TimeSpan.Zero
        };

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine($"❌ JWT authentication failed: {context.Exception.Message}");
                if (context.Exception.InnerException != null)
                    Console.WriteLine($"🔍 Inner: {context.Exception.InnerException.Message}");
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine($"✅ Token validated for user: {context.Principal?.Identity?.Name}");
                return Task.CompletedTask;
            },
            OnChallenge = context =>
            {
                context.HandleResponse();
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                var result = System.Text.Json.JsonSerializer.Serialize(new
                {
                    errorCode = "PR40101",
                    message = "Authentication error: Invalid or missing token"
                });
                return context.Response.WriteAsync(result);
            },
            OnForbidden = context =>
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Response.ContentType = "application/json";
                var result = System.Text.Json.JsonSerializer.Serialize(new
                {
                    errorCode = "PR40301",
                    message = "Access denied: You do not have permission for this resource"
                });
                return context.Response.WriteAsync(result);
            }
        };
    })
    .AddScheme<AuthenticationSchemeOptions, GoogleAccessTokenAuthencationHandler>(
        Constant.Scheme, options => { })
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Google:ClientId"]!;
        options.ClientSecret = builder.Configuration["Google:ClientSecret"]!;
        options.CallbackPath = new PathString("/authorize/callback");
    });

// 🔹 Identity setup
builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<QuizDBContext>()
.AddDefaultTokenProviders();

// 🔹 Email & Momo
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.Configure<MomoOption>(builder.Configuration.GetSection("MomoAPI"));
builder.Services.AddScoped<IMomoService, MomoService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

// 🔹 DI Services
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IGoogleAuthorizationService, GoogleAuthorizationService>();
builder.Services.AddScoped<IGoogleAuthHelperService, GoogleAuthHelperService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISupscriptionRepository, SupscriptionRepository>();
builder.Services.AddScoped<ISupscriptionService, SupscriptionService>();
builder.Services.AddScoped<ISetQuizService, SetQuizService>();
builder.Services.AddScoped<ISetQuizRepository, SetQuizRepository>();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7102")
});

// 🔹 Swagger setup
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Nhập JWT token (vd: Bearer eyJhbGc...)"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// ✅ CORS trước Authentication
app.UseCors(builder =>
{
    builder.AllowAnyHeader()
           .AllowAnyMethod()
           .WithOrigins("https://localhost:7078");
});

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ✅ Middleware thứ tự đúng
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
