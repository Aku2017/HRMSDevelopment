using HRMScore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.AuthenticateRefreshToken
{
    public class AuthenticateRefreshTokenResponse
    {
        public bool IsAuthenticate { get; set; }
        public string? AccessToken { get; set; }
    }
}
