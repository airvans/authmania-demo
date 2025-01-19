using System.ComponentModel;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("oauth")]
public class Oauthcontroller:Controller{


    // [HttpGet("oauthcocsent")]
    // public ActionResult viewregister(){

    //  return View("consentview");

    // }
   
   [Authorize]
   [HttpGet("authorize")]
   public IActionResult Authorize([FromQuery] AuthorizeRequest request){
        
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

        return Redirect(redirectUri.ToString());
        
    }
    

    [HttpPost("token")]
    public ActionResult Token([FromForm] TokenRequest request){
        
         Console.WriteLine("someone came here");

        var response = new
        {
        access_token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
        token_type = "Bearer",
        expires_in = 3600,
        refresh_token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
        scope = "read write"
       };
        
        
        return Ok(response);

    }

  
   [HttpGet("test")]
   public ActionResult test(){
    
    return Ok(UserDb.ReadItems());

   }

}