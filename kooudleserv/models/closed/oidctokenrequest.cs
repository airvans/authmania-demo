using Microsoft.AspNetCore.Mvc;

public class IdtokenRequest
{
        [FromForm(Name = "grant_type")]
        public string GrantType { get; set; } = string.Empty;

        [FromForm(Name = "code")]
        public string Code { get; set; } = string.Empty;

        [FromForm(Name = "redirect_uri")]
        public string RedirectUri { get; set; } = string.Empty;
    
        [FromForm(Name = "client_id")]
        public string ClientId { get; set; } = string.Empty;
    
        [FromForm(Name = "client_secret")]
        public string ClientSecret { get; set; } = string.Empty;
    
        [FromForm(Name = "state")]
        public string? CodeVerifier { get; set; }

}