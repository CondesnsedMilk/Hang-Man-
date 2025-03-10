namespace Hang_Man_;

class Program
{
    static void Main(string[] args)
    {
        

        Console.WriteLine("We");
    }

    public void Initialize()
    {
        new string = chooseWord;
        var rand = new Random();
        List<string> wordList = new List<string>{"pumpkin", "flamingo", "sophia", "kaz", "thy", "linh", "computer", "creative", "blasphemy", "stocking"};
        
        chooseWord = wordList[rand.Next(0, wordList.Count)];
    }
}
