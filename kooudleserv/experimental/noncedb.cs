

using System.Collections.Generic;

public class Noncedatastore(){

    private static Dictionary<string,string> nstore = new();

    public static Task<string> CreateAuthorizationCodeAsync(string nonce)
    {
        var codeString = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        nstore[codeString] = nonce;
        return Task.FromResult(codeString);
    }

    public static Task<string> GetAuthorizationCodeAsync(string code)
    {
        nstore.TryGetValue(code, out var authCode);
        return Task.FromResult(authCode);
    }

    public static Task RemoveAuthorizationCodeAsync(string code)
    {
        nstore.Remove(code);
        return Task.CompletedTask;
    }


}