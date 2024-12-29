
using Microsoft.AspNetCore.Mvc;

public class Clientscontroller:Controller{

    public Clientscontroller(){
        
    }

    [HttpPost("addclient")]
    public IActionResult action(Client client){
      
      Clidb.AddItem(client);

      return Ok();

    }

    [HttpGet("getclient")]
    public IActionResult next(string id){

      var hello = Clidb.findclient(id);
      
      return Ok(hello);

    }

     [HttpGet("getallclient")]
    public IActionResult nextall(){

      var hello = Clidb.allclient();
      
      return Ok(hello);

    }


}