
public class Client
{
    public string Id {get;set;} = Guid.NewGuid().ToString();
    public string ClientSecret { get; set; } = $"{Guid.NewGuid().ToString()}{Guid.NewGuid().ToString()}";
    public string security {get;set;} = string.Empty;
    public string[] RedirectUris { get; set; } = Array.Empty<string>();
    public string[] AllowedScopes { get; set; } = Array.Empty<string>();
    public string[] Events {get;set;} = Array.Empty<string>();
 
    public Client()
    {
        
    }

}