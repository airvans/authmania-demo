using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

[Route("oauth")]
public class Oauthcontroller:Controller{
  
   [HttpGet("authorize")]
   public async Task<IActionResult> Authorize(){
        
        await Task.CompletedTask;
        return Redirect(string.Empty);
        
    }
  
    [HttpPost("token")]
    public async Task<ActionResult<string>> Token(){
        
        await Task.CompletedTask;
        return Redirect(string.Empty);

    }

  
   [HttpGet("test")]
   public ActionResult test(){
    
    return Ok(Db.ReadItems());

   }

}