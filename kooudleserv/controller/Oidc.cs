using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("oidc")]
public class Oidccontoller:Controller{

    [Authorize]
    [HttpGet("oidccocsent")]
    public ActionResult viewregister(){

     return View("consentviewoidc");

    }

    [Route(".well-known/openid-configuration")]
    [HttpGet]
    public IActionResult index(){
        return Ok(new{          
            issuer = "http://localhost:5264",
            authorization_endpoint = "http://localhost:5264/oauth/authorize",
            token_endpoint = "http://localhost:5264/oauth/token",
            userinfo_endpoint = "http://localhost:5264/userinfo",
            id_token_signing_alg_values_supported = new[] {"HS256"}
        });
    }

    [Route("userinfo")]
    [HttpGet]
    public IActionResult get(){
        return Ok(new
    {
        sub = "demo-user123", 
        email = "test@gmail.com",
        email_verified = true,
        name = "demo-user",
        given_name = "Demo",
        family_name = "User",
        preferred_username = "demo-user",
        kooudle = "yes-it-works"
    });
    }

   [HttpGet("authorize")]
   public IActionResult Authorize(){
        
    return Redirect(string.Empty);

   }
  
    [HttpPost("token")]
    public ActionResult Token(){

      return Redirect(string.Empty);

    }


}