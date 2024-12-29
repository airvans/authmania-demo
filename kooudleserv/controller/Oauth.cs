using System.ComponentModel;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("oauth")]
public class Oauthcontroller:Controller{
   
   [Authorize]
   [HttpGet("authorize")]
   public async Task<IActionResult> Authorize([FromQuery] AuthorizeRequest request){
        
        Client? client = Clidb.findclient(request.ClientId);

        if (client == null)
        {
            return BadRequest("Invalid client_id");
        }

        var redirectUri = new UriBuilder(request.RedirectUri);

        var query = HttpUtility.ParseQueryString(redirectUri.Query);

        query["code"] = $"{Guid.NewGuid().ToString()}{Guid.NewGuid().ToString()}";

        if (!string.IsNullOrEmpty(request.State))
        {
            query["state"] = request.State;
        }

        redirectUri.Query = query.ToString();

        return Redirect(redirectUri.Query);
        
    }
    
    [Authorize]
    [HttpPost("token")]
    public async Task<ActionResult<string>> Token([FromForm] TokenRequest request){

        var response = new
        {
            access_token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
            expires_in = 3600,
            token_type = "Bearer",
            refresh_token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
            scope = string.Join(" ", Array.Empty<string>())
        };
        
        return Ok(response);

    }

  
   [HttpGet("test")]
   public ActionResult test(){
    
    return Ok(UserDb.ReadItems());

   }

}