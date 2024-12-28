using System.Dynamic;

public class User{

    private string id{get; set; } = Guid.NewGuid().ToString();
    public string username{get; set; } = string.Empty;
    public string email{get; set; } = string.Empty;
    public string password{get; set; } = string.Empty;


    // private readonly Dictionary<string, object> identities = new Dictionary<string, object>(){
    //     {"email","test@gmail.com"},{"age","12-test"}
    // };

    // public override bool TryGetMember(GetMemberBinder binder, out object result)
    // {
    //     if (identities.ContainsKey(binder.Name))
    //     {
    //         result = identities[binder.Name];
    //         return true;
    //     }
    //     return base.TryGetMember(binder, out result);
    // }

    // public override bool TrySetMember(SetMemberBinder binder, object value)
    // {
    //     identities[binder.Name] = value;
    //     return true;
    // }

    // public override IEnumerable<string> GetDynamicMemberNames()
    // {
    //     return identities.Keys;
    // }

}