﻿using DAL.Repository;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    
    public class GoogleAuthHelperService(IConfiguration _configuration ) : IGoogleAuthHelperService
    {
        public ClientSecrets GetClientSecrets()
        {
            string clientId = _configuration["Google:ClientId"]!;
            string clientSecret = _configuration["Google:ClientSecret"]!;
            return new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            };
        }

        public string[] GetScopes()
        {
            var scopes = new[]
            {
                Oauth2Service.Scope.Openid,
                Oauth2Service.Scope.UserinfoEmail,
                Oauth2Service.Scope.UserinfoProfile
            };
            return scopes;
        }

        public string ScopeToString() => string.Join(" ", GetScopes());

    }
}
