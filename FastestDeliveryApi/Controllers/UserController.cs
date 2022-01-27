using FastestDeliveryApi.database;
using FastestDeliveryApi.model;
using FastestDeliveryApi.model.user;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Test2_API.Auth;

namespace FastestDeliveryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private EfModel _efModel;
        
        public UserController(EfModel model)
        {
            _efModel = model;
        }

        [HttpPost("/Registration")]
        public async Task<ActionResult<User>> PostSchol(User user)
        {
            _efModel.users.Add(user);
            await _efModel.SaveChangesAsync();

            return CreatedAtAction(nameof(PostSchol), new { id = user.Id }, user);
        }


        [HttpPost("/Authorization")]
        public ActionResult<object> Token(User user)
        {
            var indentity = GetIdentity(user.Email, user.Password);

            if (indentity == null)
            {
                return BadRequest();
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    audience: TokenBaseOptions.AUDIENCE,
                    issuer: TokenBaseOptions.ISSUER,
                    notBefore: now,
                    claims: indentity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(TokenBaseOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(TokenBaseOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = indentity.Name
            };

            return response;
        }

        [NonAction]
        private ClaimsIdentity GetIdentity(string email, string password)
        {
            User user = _efModel.users.FirstOrDefault(x => x.Email == email && x.Password == password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.FIO),
                    new Claim("Id", user.Id.ToString())
                };

                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);

                return claimsIdentity;
            }
            return null;
        }
    }
}
