using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class Accountcontroller:Controller{

   [Route("sign-in")]
   [HttpGet]
   public ActionResult login(string? RetunUrl = null){
    
    List<Claim> claim = new(){
        new Claim(ClaimTypes.Name,"evan"),
        new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString())
    };
    var claimid = new ClaimsIdentity(claim,CookieAuthenticationDefaults.AuthenticationScheme){};

    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimid));
   
    return Ok("logged-in");

   }


   [Route("register")]
   [HttpGet]
   public ActionResult register(){
    
    return Ok("registered");

   }
   
   [Route("sign-out")]
   [HttpGet]
   public ActionResult logout(){
    
    HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

    return Ok("off");

   }

   [Authorize]
   [Route("test")]
   [HttpGet]
   public ActionResult test(){
    
    return Ok("tested");

   }



}