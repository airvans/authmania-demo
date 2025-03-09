using System.Web;
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
            issuer = "http://localhost:5112/oidc",
            authorization_endpoint = "http://localhost:5112/oidc/oidccocsent",
            token_endpoint = "http://localhost:5112/oidc/token",
            userinfo_endpoint = "http://localhost:5112/oidc/userinfo",
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
   public async Task<IActionResult> Authorize([FromQuery] AuthorizeRequest request){

        Client? client = Clidb.findclient(request.ClientId);

        if (client == null)
        {
            return BadRequest("Invalid client_id");
        }
   
        var redirectUri = new UriBuilder(request.RedirectUri);

        var query = HttpUtility.ParseQueryString(redirectUri.Query);
        
        var code = await Noncedatastore.CreateAuthorizationCodeAsync(request.nonce);

        query["code"] = code;

        if (!string.IsNullOrEmpty(request.State))
        {
            query["state"] = request.State;
        }

        redirectUri.Query = query.ToString();

        return Redirect(redirectUri.ToString());

   }
  
    [HttpPost("token")]
    public async Task<ActionResult> Token([FromForm] IdtokenRequest request){
         
        var nonce = await Noncedatastore.GetAuthorizationCodeAsync(request.Code);
        var idtoken =await Tokens.GenerateidTokenAsync(request.ClientId,"http://localhost:5112/oidc",nonce);

        var response = new
        {
            access_token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
            id_token = idtoken,
            token_type = "Bearer",
            expires_in = 3600,
            refresh_token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
            scope = string.Join(" ",Array.Empty<string>())
        };
        
        await Noncedatastore.RemoveAuthorizationCodeAsync(request.Code);
        return Ok(response);

    }


}