using System;
using System.Text;

/// <summary>
/// Hangman v.1.00
/// By Janne Kähkönen
/// </summary>
class Hangman
{
    private static string[] arr1 = new string[] { "mouse", "loop", "computer",
                                                  "interface", "internet",
                                                  "machine", "debian", "web",
                                                  "windows", "syntax", "irc",
                                                  "python", "java", "binary" };

    // Set the score variable.
    private static int score = 0;

    // Set the width for the game.
    private static int x = 30;

    // Random number for picking the word.
    private static int randomNumber;

    // StringBuilders to store information.
    private static StringBuilder builder = new StringBuilder();
    private static StringBuilder word = new StringBuilder();
    private static StringBuilder guessed = new StringBuilder();
    private static StringBuilder reader = new StringBuilder();

    /// <summary>
    /// The entry point for the app.
    /// </summary>
    static void Main(string[] args)
    {

        // Set the cursor visible and set the title.
        Console.CursorVisible = true;
        Console.Title = "Hangman";

        // Pick random word.
        Random random = new Random();
        randomNumber = random.Next(0, arr1.Length);
        string str = arr1[randomNumber];

        // Insert the picked word to StringBuilder.
        word.Insert(0, str);

        // Make copy with chars hidden.
        for (int i = 0; i < str.Length; i++) {
            builder.Insert(i, "_");
        }

        // Start the MainLoop.
        MainLoop();
    }

    /// <summary>
    /// The main gameloop.
    /// </summary>
    static void MainLoop()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("YOUR GUESSES  : "+ guessed);
            Console.Write("\nWRONG GUESSES : "+score*(-1));
            CreateUI();
        }
    }

    /// <summary>
    /// Create UI.
    /// </summary>
    private static void CreateUI()
    {
        Console.Write("\n");

        DrawX();

        DrawRope();
        DrawHanged();

        string s = builder.ToString();

        if (s.IndexOf("_") == -1)
        {
            DrawX();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nTHE WORD WAS: "+ word);
            Console.Write("\nYOU SURVIVE!\n");
            DrawX();
            Console.Write("\n\n\n\n");

            Console.ResetColor();
            Environment.Exit(0);
        }

        DrawX();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("\n\nWORD : ");

        Console.Write(builder);
        Console.Write("\n");

        DrawX();

        // Read input.
        Console.Write("\n\n\n\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("GUESS : ");
        string read = Console.ReadLine();
        reader.Append(read);
        guessed.Append(read);

        // Roll turn.
        score = score-1;

        // Check Letter.
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == reader[reader.Length-1])
            {
                builder[i] = word[i];
            }
        }

        // Check if correct guess and give free turn.
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == reader[reader.Length-1])
            {
                score = score + 1;
                break;
            }
        }
    }

    /// <summary>
    /// Draw some Gui.
    /// </summary>
    private static void DrawX()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;

        for (int a = 0; a < x; a++)
        {
            Console.Write("=");
        }
        Console.Write(">");
    }

    /// <summary>
    /// Draw Rope and pole.
    /// </summary>
    private static void DrawRope()
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("\n");
        Console.Write("   ");

        for (int a = 0; a < x-8; a++)
        {
            Console.Write("=");
        }

        Console.Write(@"
     |                  |
                        |
                        |
                        |
                        |
                        |
                        |
                        |
                        |
                        |
                       / \");
    }

    /// <summary>
    /// Draw the dude.
    /// </summary>
    private static void DrawHanged()
    {
        Console.ForegroundColor = ConsoleColor.Green;

        Console.SetCursorPosition(5, 5);

        if (score >= 0)
        {
            Console.Write(@"





            ");
        }

        else if (score == -1)
        {
            Console.Write(@"O





            ");
        }

        else if (score == -2)
        {
            Console.Write(@"O
     |




            ");
        }

        else if (score == -3)
        {
             Console.Write(@"O
     |
   d-|-b



            ");
        }

        else if (score == -4)
        {
             Console.Write(@"O
     |
   d-|-b
     |


            ");
        }

        else if (score == -5)
        {
             Console.Write(@"O
     |
   d-|-b
     |
    | |

            ");
        }

        else if (score == -6)
        {
             Console.Write(@"O
     |
   d-|-b
     |
    | |
   <   >



            ");

            Console.Write("\n");
            DrawX();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nTHE WORD WAS: "+ word);
            Console.Write("\nGAME OVER!\n");
            DrawX();
            Console.Write("\n\n\n\n");

            Console.ResetColor();
            Environment.Exit(0);

        }

        Console.Write("\n\n\n\n");
    }

}
