using Microsoft.AspNetCore.Mvc;

[Route("testing")]
public class Contoll_test:Controller{


  [HttpGet("events")]

   public async Task<ActionResult> eventtester(string name){

      CustomEvents.evlist.TryGetValue(name, out var events);
    
      var result = 0;
      
      if(events != null){

       result = await events("hello");

      }
      
      return Ok(result);

   }

   [HttpGet("mfa")]
   public IActionResult action(string mfa,string result){
     
     //get client mfa_options
     string[] mfa_options = ["email","otp","sms"];

     
     
     
     //create verification handler function

     //verification result handler function
     
     //return the verification page for user input or action
     return Redirect($"http://127.0.0.1:5500/src/Ui-layer/interotion.html");
     
   }

   [HttpGet("login")]
    public IActionResult login_action(string email,string password){

    var user = UserDb.Getobject(email,password);
    
    if(user == null){
        return BadRequest("user doesnt exist");
    }

    return Redirect("mfa");
     
   }

   [HttpGet("session")]
   public IActionResult session_action(){

    throw new NotImplementedException();

   }

}