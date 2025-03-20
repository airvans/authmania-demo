
public delegate void OnPropertyChangedEventHandler(object sender,EventArgs args);
public class CustomEvents{
 
    public static readonly Dictionary<string,Func<string,Task<int>>> evlist = new();
    //public static readonly Dictionary<string,OnPropertyChangedEventHandler> evlist2 = new();


    static CustomEvents(){

        evlist.Add("func1",callhere1);
        evlist.Add("func2",callhere2);
        evlist.Add("func3",callhere3);
    }


    private static Task<int> callhere1(string enter){

        return Task.FromResult(1);

    }

    private static Task<int> callhere2(string enter){

        return Task.FromResult(2);

    }

    private static Task<int> callhere3(string enter){

        return Task.FromResult(3);
    }


}

