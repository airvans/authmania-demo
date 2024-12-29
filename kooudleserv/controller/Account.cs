using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

public class Accountcontroller:Controller{

   [Route("sign-in")]
   [HttpGet]
   public ActionResult login(string email,string password, string? RetunUrl = null){

    var user = UserDb.Getobject(email,password);

    if(user == null){
        return BadRequest("user doesnt exist");
    }
    
    List<Claim> claim = new(){
        new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.Name,user.username),
        new Claim(ClaimTypes.Email,user.email)
    };
    var claimid = new ClaimsIdentity(claim,CookieAuthenticationDefaults.AuthenticationScheme){};

    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimid));

    if(RetunUrl != null){

        return Redirect(RetunUrl);
        
    }
   
    return Ok("logged-in");

   }


   [Route("register")]
   [HttpPost]
   public ActionResult register(User user){

    UserDb.AddItem(user);
    
    return Ok("registered");

   }
   
   [Route("sign-out")]
   [HttpGet]
   public ActionResult logout(){
    
    HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

    return Ok("off");

   }

 
   [Route("test")]
   [HttpGet]
   public ActionResult test(){
    
    return Ok(UserDb.ReadItems());

   }

   [Route("gettoken")]
   [HttpGet]
   public ActionResult token(){
    
    var token = HttpContext.GetTokenAsync("cookie","access_token");

    return Ok(token);

   }



}