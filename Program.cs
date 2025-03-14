using System.Xml;

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
        while(true)
        {
            input = Console.ReadLine()!.Trim().ToLower();;

            if(input == "y")
            {
                IntialList();
                break; // To stop the entire loop.
            }
            else if(input == "n")
            {
                Console.WriteLine("Thanks for playing!");
                break;
            }
            else
            {
                Console.WriteLine("Sorry! Invalid input. Enter y or n");
            }
        }

    }  

    static void IntialList()
    {
        int counter = 0;
        var wordInList = ChooseWord();
        var hint = Hint(wordInList);
        List<char> memory = new List<char>();

        TakeUsrInput(wordInList, hint, memory, counter);
    }

    static void TakeUsrInput(List<char> wordList, List<char> hint, List<char> memory, int counter)
    {
        string reducedInput;

        Console.WriteLine();
        Console.WriteLine("What is your letter!");
        while(true)
        {
            reducedInput = Console.ReadLine()!.Trim().ToLower();
            char[] input = reducedInput.ToCharArray();

            if(input.Length < 2)
            {
                for(int j = 0; j < memory.Count; j++)
                {
                    if(input[0] == memory[j])
                    {
                        Console.WriteLine("Sorry! You've already inputted this letter. Try again!");
                        TakeUsrInput(wordList, hint, memory, counter);
                    }
                }
                CheckAnswer(wordList, hint, input, memory, counter);
                break; // To stop the entire loop.
            }
            else
            {
                Console.WriteLine("Sorry! Invalid input. Please enter in only ONE letter!");
            } 
        }

    }

    static void CheckAnswer(List<char> wordList, List<char> hint, char[] input, List<char> memory, int counter)
    {
        bool correct = false;

        memory.Add(input[0]);
        for(int i = 0; i < wordList.Count; i++)
        {
            if (wordList[i] == input[0])
            {
                hint.RemoveAt(i);
                hint.Insert(i, input[0]);
                correct = true;
            }
        }
        
        if(correct)
        {
            counter--;
        }

        counter++;

        for(int i=0; i < hint.Count; i++)
        {
            Console.Write($"{hint[i]} " );
        }

        Console.WriteLine();

        Console.Write("Your letters are: " );

        for(int i=0; i < memory.Count; i++)
        { 
            Console.Write($"{memory[i]} " );
        }
        Console.Write($"You have {10 - counter} lives left!" );
        
        TakeUsrInput(wordList, hint, memory, counter);
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
