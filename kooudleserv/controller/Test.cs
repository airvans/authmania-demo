using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

public class Testcontroller:Controller{


   [HttpGet("oauth.test")]
   public ActionResult test(){

    var auth =new AuthenticationProperties{
        RedirectUri = "/"
    };
    
    return Challenge(auth,authenticationSchemes:"custom");

   }

   [HttpGet("/callback-test")]
   public ActionResult callback(){
 
    return Ok();

   }


}