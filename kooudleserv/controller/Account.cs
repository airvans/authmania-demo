using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

public class Accountcontroller:Controller{
    
    [Route("login")]
    [HttpGet]
    public ActionResult viewlogin(){

        return View("login");

    }

    [Route("registerview")]
    [HttpGet]
    public ActionResult viewregister(){

        return View("register");

    }

   [Route("sign-in")]
   [HttpGet]
   public ActionResult login(string email,string password){

    string? RetunUrl = HttpContext.Request.Query["ReturnUrl"];

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
   [HttpGet]
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
   public async Task<ActionResult> token(){
    
     var token = await HttpContext.GetTokenAsync("custom","access_token");
     var token2 = await HttpContext.GetTokenAsync("next","access_token");
     var token3 = await HttpContext.GetTokenAsync(CookieAuthenticationDefaults.AuthenticationScheme,"access_token");

     return Ok(new{welcome = "shithead",token,token2,token3});

   }

   [Route("getuser")]
   [HttpGet]
   public ActionResult getusertest(){
    
    var name = User.FindFirstValue(ClaimTypes.Name);
    var email = User.FindFirstValue(ClaimTypes.Email);
    var userId = User.FindFirst("sub")?.Value;

    var user = HttpContext.User;  
    var userId2 = user.FindFirst("sub")?.Value;  // Get the 'sub' claim (subject)
    var userName = user.FindFirst("name")?.Value;  // Get the 'name' claim
    var userEmail = user.FindFirst("email")?.Value;  // Get the 'email' claim


    return Ok(new{elseits = "bullshit",name,email,userId,userId2,userName,userEmail});

   }





}