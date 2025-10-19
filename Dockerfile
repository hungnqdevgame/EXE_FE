# Backend API build - Optimized for Render deployment
# - Builds Quiz.Server (ASP.NET Core API) with dependencies: BLL, DAL, Share, Quiz
# - Quiz project included only for DTOs (shared models between API and Blazor client)

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project files in dependency order for better layer caching
COPY ["Share/Share.csproj", "Share/"]
COPY ["DAL/DAL.csproj", "DAL/"]
COPY ["BLL/BLL.csproj", "BLL/"]
COPY ["Quiz/Quiz.csproj", "Quiz/"]
COPY ["Quiz.Server/Quiz.Server.csproj", "Quiz.Server/"]

# Restore dependencies
RUN dotnet restore "Quiz.Server/Quiz.Server.csproj"

# Copy source code (.dockerignore excludes bin/obj/cache/user files)
COPY . .

# Publish API server
WORKDIR /src/Quiz.Server
RUN dotnet publish "Quiz.Server.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

# Runtime stage - minimal ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copy published output
COPY --from=build /app/publish .

# Configure runtime (bind to Render's PORT if provided, else 8080 for local)
ENV ASPNETCORE_URLS="http://0.0.0.0:${PORT:-8080}"
ENV ASPNETCORE_ENVIRONMENT="Development"
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED="true"

EXPOSE 8080

# Local usage:
#   docker build -t quiz-api .
#   docker run -p 8080:8080 \
#     -e ConnectionStrings__DefaultConnection="Server=host.docker.internal;Database=QuizDB;User Id=sa;Password=0123456789;TrustServerCertificate=True;" \
#     quiz-api
#
# Access:
#   - Swagger: http://localhost:8080/swagger
#   - API: http://localhost:8080/api/*
#
# Render environment variables:
#   - ConnectionStrings__DefaultConnection (required - Azure SQL/SQL Server connection)
#   - Google__ClientId, Google__ClientSecret, Google__RedirectUri
#   - Jwt__Key, Jwt__Issuer, Jwt__Audience
#   - MomoAPI__* (payment gateway settings)
#   - ASPNETCORE_ENVIRONMENT=Production (disable Swagger in production)

ENTRYPOINT ["dotnet", "Quiz.Server.dll"]
