namespace Hang_Man_;

class Program
{
    static void Main(string[] args)
    {
        string input;

        Console.WriteLine("Welcome to Hang Man!");
        Console.WriteLine("You are to choose letters one at a time to guess the hidden word BEFORE you hang our man.");
        Console.WriteLine("You have 10 chances");
        Console.WriteLine("Would you like to play? y/n");
        input = Console.ReadLine();

    }  

    static void IntialList()
    {
        var wordInList = ChooseWord();
        var hint = Hint(wordInList);

        for(int i=0; i < hint.Count; i++)
        {
            Console.Write($"{hint[i]} ");
        }

    }

    static void PlayGame()
    {

    }

    static List<char> ChooseWord()
    {
        var rand = new Random();
        List<string> wordList = new List<string>{"pumpkin", "flamingo", "sophia", "kaz", "thy", "linh", "computer", "creative", "blasphemy", "stocking", "stoichiometry"};
        
        List<char> wordInList = new List<char>();
        char[] chars = wordList[rand.Next(0, wordList.Count)].ToCharArray();

        for(int i=0; i < chars.Length; i++)
        {
            wordInList.Add(chars[i]);
        }

        return wordInList;
    }

    static List<char> Hint(List<char> wordInList)
    {
        List<char> hint = new List<char>();

        for(int i=0; i < wordInList.Count; i++)
        {
            hint.Add('_');
        }

        return hint;
    }
    
        
}
