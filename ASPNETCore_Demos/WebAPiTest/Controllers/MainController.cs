using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace WebAPiTest.Controllers
{

    [Route("api/main")]
    [ApiController]
    public class MainController : ControllerBase
    {
        [HttpGet("gettoken")]
        public Object GetToken()
        {
            string key = "my_secret_key_12345";
            var issuer = "http://mysite.com";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("valid", "1"));
            permClaims.Add(new Claim("userid", "1"));
            permClaims.Add(new Claim("name", "bilal"));

            var token = new JwtSecurityToken(issuer,
                            issuer,
                            permClaims,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return new { data = jwt_token };


        }


        [HttpPost("getname1")]
        public ActionResult<String> GetName1()
        {
            if (User.Identity.IsAuthenticated)
            {
                var claims = User.Claims;
                return "Valid";
            }
            else
            {
                return "Invalid";
            }
        }

        [Authorize]
        [HttpPost("getname2")]
        public ActionResult<String> GetName2()
        {
            var claims = User.Claims;
            return "";
        }


        [Authorize(Policy = "IsValid")]
        [HttpPost("getname3")]
        public ActionResult<String> GetName3()
        {
            var claims = User.Claims;
            foreach (var claim in claims)
            {
                if (claim.Type == "name")
                {
                    return claim.Value;
                }
            }
            return "";
        }

        [ClaimDTOAttribute]
        [Authorize(Policy = "IsValid")]
        [HttpPost("getname4")]
        public Object GetName4([FromHeader] ClaimDTO claimDto)
        {
            String name = "";
            if (claimDto != null)
                name = claimDto.FullName;

            return new
            {
                data = name
            };
        }
    }

    public class ClaimDTO
    {
        public int UserID { get; set; }
        public String FullName { get; set; }
    }
    public class ClaimDTOAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var dto = ((ClaimDTO)context.ActionArguments["claimDto"]);
            var claimsIdentity = context.HttpContext.User.Identity as ClaimsIdentity;
            dto.UserID = Convert.ToInt32(claimsIdentity.Claims.FirstOrDefault(c => c.Type == "userid")?.Value);
            dto.FullName = claimsIdentity.Claims.FirstOrDefault(c => c.Type == "name").Value;
        }
    }
}