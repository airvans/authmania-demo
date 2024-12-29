using Microsoft.AspNetCore.Mvc;

public class AuthorizeRequest
{
        [FromQuery(Name = "response_type")]
        public string ResponseType { get; set; } = string.Empty;

        [FromQuery(Name = "client_id")]
        public string ClientId { get; set; } = string.Empty;

        [FromQuery(Name = "redirect_uri")]
        public string RedirectUri { get; set; } = string.Empty;

        [FromQuery(Name = "state")]
        public string? State { get; set; }

        [FromQuery(Name = "scope")]
        public string? Scope { get; set; }

        [FromQuery(Name = "code_challenge")]
        public string? CodeChallenge { get; set; }
        
        [FromQuery(Name = "nonce")]
        public string nonce{get;set;} = string.Empty;
        public string? CodeChallengeMethod { get; set; }
}