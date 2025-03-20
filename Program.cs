using System.ComponentModel;
using System.Diagnostics.Metrics;
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
            bool win = false;
            int lives = 10;
            bool correct = false;

            if (!play)
            {
                Console.WriteLine("That's okay!");
                break;
            }

            var wordInList = ChooseWord();
            var hint = Hint(wordInList);
            char[] memory;
            
            while(!win)
            {
                var input = TakeUsrInput(memory);
                correct = CheckAnswer(wordInList, hint, input);

                if(!correct)
                {
                    lives--;
                }

                if(lives == 0)
                {
                    Lose();
                    break;
                }
                else if (hint == wordInList)
                {
                    Win(lives);
                    break;
                }

                PrintHint(hint, memory, lives);
            }

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

    static char[] TakeUsrInput(char[] memory)
    {
        string reducedInput;
        char[] input;

        Console.WriteLine();
        Console.WriteLine("What is your letter!");
        reducedInput = Console.ReadLine()!.Trim().ToLower();
        input = reducedInput.ToCharArray();

        if(input.Length < 2)
        {
            memory.Append(input[0]);
            for(int j = 0; j < memory.Length; j++)
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
        return new char[] (input, memory);
    }

    static bool CheckAnswer(List<char> wordList, List<char> hint, char[] input)
    {
        bool correctLetter = false;

        for(int i=0; i < wordList.Count; i++)
        { 
            Console.Write($"{wordList[i]} " );
        }

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
            return true;
        }

        return false;

    }

    static void PrintHint(List<char> hint, char[] memory, int lives)
    {
        for(int i=0; i < hint.Count; i++)
        {
            Console.Write($"{hint[i]} " );
        }

        Console.WriteLine();

        Console.Write("Your letters are: " );

        for(int i=0; i < memory.Length; i++)
        { 
            Console.Write($"{memory[i]} ");
        }
        Console.Write($"You have {lives} lives left!" );
    }

    static void Win(int counter)
    {
        Console.WriteLine($"Nice work! You were able to save the man in {counter} attempts!");
    }

    static void Lose()
    {
        Console.WriteLine("Uh oh... You have lost...");
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
