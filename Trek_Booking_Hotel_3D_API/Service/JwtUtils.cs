﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Trek_Booking_DataAccess;
using Trek_Booking_Hotel_3D_API.Helper;

namespace Trek_Booking_Hotel_3D_API.Service
{
    public class JwtUtils : IJwtUtils
    {
        private readonly APISettings _appSettings;

        public JwtUtils(IOptions<APISettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public string GenerateTokenClient(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("userId", user.UserId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateTokenSupplier(Supplier supplier)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("supplierId", supplier.SupplierId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public int? ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey); // Chuyển đổi secret key sang dạng byte array
            try
            {
                // Thiết lập các thuộc tính của xác thực token
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero // Không cho phép độ lệch thời gian
                };

                // Xác thực token và lấy thông tin về xác thực (Claims)
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
                var userId = int.Parse(principal.Claims.FirstOrDefault(c => c.Type == "userId")?.Value);

                return userId; // Trả về userid
                /*return true;*/ // Token hợp lệ
            }
            catch
            {
                return 0; // Token không hợp lệ
            }
        }
    }
}
