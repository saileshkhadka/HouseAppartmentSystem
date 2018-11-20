using HouseApartment.Crypto;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace HouseApartment.Authorization
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); 
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var checkuser = CheckUser.IsUserExist(context.UserName);
            if (checkuser!=null){
                var password = CryptoMethod.Hash(context.Password);
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                if (context.UserName == checkuser.Username && password == checkuser.Password)
                {
                    if (checkuser.RoleName == "Admin")
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, checkuser.RoleName));
                        identity.AddClaim(new Claim(checkuser.Username,checkuser.RoleName));
                        identity.AddClaim(new Claim(ClaimTypes.Name, checkuser.FirstName));
                        identity.AddClaim(new Claim(ClaimTypes.Email, checkuser.EmailID));
                        context.Validated(identity);
                    }

                    else if(checkuser.RoleName=="User")
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, checkuser.RoleName));
                        identity.AddClaim(new Claim(checkuser.Username, checkuser.RoleName));
                        identity.AddClaim(new Claim(ClaimTypes.Name, checkuser.FirstName + " " + checkuser.LastName));
                        identity.AddClaim(new Claim(ClaimTypes.Email, checkuser.EmailID));
                        context.Validated(identity);

                        context.Validated(identity);
                    }
                }
                

            }
            else
            {
                context.SetError("Invalid Grant", "Provided username and password is incorrect");
            }
        }
    }
}