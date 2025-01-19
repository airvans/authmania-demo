using Microsoft.AspNetCore.Mvc;

[Route("oidc")]
public class Oidccontoller:Controller{

    [Route(".well-known/openid-configuration")]
    [HttpGet]
    public IActionResult index(){
        return Ok();
    }

    [Route("userinfo")]
    [HttpGet]
    public IActionResult get(){
        return Ok();
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