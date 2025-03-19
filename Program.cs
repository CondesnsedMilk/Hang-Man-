using System.ComponentModel;
using System.Xml;

namespace Hang_Man_;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Hang Man!");
        Console.WriteLine("You are to choose letters one at a time or guess the entire word to figure out the hidden word BEFORE you hang our man.");
        Console.WriteLine("You have 10 chances");
        while (true)
        {
            bool play = Play();

            if (!play)
            {
                Console.WriteLine("That's okay!");
                break;
            }

            var wordInList = ChooseWord();
            List<char> memory = new List<char>();

            var input = TakeUsrInput(wordInList);
        }
    }

    static bool Play()
    {
        string input; 
        
        Console.WriteLine("Would you like to play? y/n");

        while(true)
        {
            input = Console.ReadLine()!.Trim().ToLower();;

            if(input == "y")
            {
                return true;
            }
            else if(input == "n")
            {
                return false;
            }

            Console.WriteLine("Sorry! Invalid input. Enter y or n");

        }
    }

    static List<char> TakeUsrInput(List<char> hint, List<char> memory)
    {
        string reducedInput;
        char[] input;

        Console.WriteLine();
        Console.WriteLine("What is your letter!");
        reducedInput = Console.ReadLine()!.Trim().ToLower();
        input = reducedInput.ToCharArray();

        if(input.Length < 2)
        {
            for(int j = 0; j < memory.Count; j++)
            {
                if(input[0] == memory[j])
                {
                    Console.WriteLine("Sorry! You've already inputted this letter. Try again!");
                }
            }
        }
        else
        {
            Console.WriteLine("Sorry! Invalid input. Please enter in only ONE letter!");
        } 
    }

    static void CheckAnswer(List<char> wordList, List<char> hint, char[] input, List<char> memory, int counter)
    {
        bool correctLetter = false;

        for(int i=0; i < wordList.Count; i++)
        { 
            Console.Write($"{wordList[i]} " );
        }

        memory.Add(input[0]);
        for(int i = 0; i < wordList.Count; i++)
        {
            if (wordList[i] == input[0])
            {
                hint.RemoveAt(i);
                hint.Insert(i, input[0]);
                correctLetter = true;
            }
        }
        
        if(correctLetter)
        {
            counter--;
        }

        counter++;

        Console.WriteLine(counter);
        
        bool done = false; 

        if (wordList == hint)
        {
            done = Win(counter);
        }
        else if (10 - counter == 0)
        {
            done = Lose();
        }

        PrintHint(done, wordList, hint, input, memory, counter);
    }

    static void PrintHint(bool done, List<char> wordList, List<char> hint, char[] input, List<char> memory, int counter)
    {
            if(!done)
            {
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

    }

    static bool Win(int counter)
    {
        Console.WriteLine($"Nice work! You were able to save the man in {counter} attempts!");
        Console.WriteLine("Would you like to play again? y/n");
        Play();
        return false;
    }

    static bool Lose()
    {
        Console.WriteLine("Uh oh... You have lost...");
        Console.WriteLine("Would you like to play again? y/n");
        Play();
        return true;
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
