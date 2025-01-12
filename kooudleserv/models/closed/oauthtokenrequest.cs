

using Microsoft.AspNetCore.Mvc;

public class TokenRequest
{
        [FromQuery(Name = "authorization_code")]
        public string GrantType { get; set; } = string.Empty;

        [FromQuery(Name = "code")]
        public string Code { get; set; } = string.Empty;

        [FromQuery(Name = "redirect_uri")]
        public string RedirectUri { get; set; } = string.Empty;
    
        [FromQuery(Name = "client_id")]
        public string ClientId { get; set; } = string.Empty;
    
        [FromQuery(Name = "client_secret")]
        public string ClientSecret { get; set; } = string.Empty;
    
        [FromQuery(Name = "state")]
        public string? CodeVerifier { get; set; }

}