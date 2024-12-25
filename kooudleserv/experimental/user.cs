using System.Dynamic;

public class User : DynamicObject{

    public string id{get; set; } = Guid.NewGuid().ToString();
    public string uername{get; set; } = string.Empty;
    public string fullname{get; set; } = string.Empty;

    private readonly Dictionary<string, object> identities = new Dictionary<string, object>(){
        {"email","test@gmail.com"},{"age","12-test"}
    };

    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
        if (identities.ContainsKey(binder.Name))
        {
            result = identities[binder.Name];
            return true;
        }
        return base.TryGetMember(binder, out result);
    }

    public override bool TrySetMember(SetMemberBinder binder, object value)
    {
        identities[binder.Name] = value;
        return true;
    }

    public override IEnumerable<string> GetDynamicMemberNames()
    {
        return identities.Keys;
    }


}