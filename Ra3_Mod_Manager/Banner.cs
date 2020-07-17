using System;
using System.Collections.Generic;
using System.Text;

namespace CNCLauncher
{
    class Banner
    {
        
        public const string BLANK = @"                                                                                      ";

        public static void Print()
        {

            Console.WriteLine(@"");
            Console.WriteLine(@"");
            Console.WriteLine(@"                                                                                      "); Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"  ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ "); Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@" |______|______|______|______|______|______|______|______|______|______|______|______|"); Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"  ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ "); Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@" |______|______|______|______|______|______|______|______|______|______|______|______|"); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"  ______     | |  | |                | |            / _ \ / _ \__ \|___ \      ______ "); Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@" |______|    | |__| | __ _  ___      | |_   _ _ __ | | | | (_) | ) | __) |    |______|"); Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"  ______     |  __  |/ _` |/ _ \ _   | | | | | '_ \| | | |> _ < / / |__ <      ______ "); Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@" |______|    | |  | | (_| | (_) | |__| | |_| | | | | |_| | (_) / /_ ___) |    |______|"); Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"             |_|  |_|\__,_|\___/ \____/ \__,_|_| |_|\___/ \___/____|____/             "); Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"  ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ "); Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@" |______|______|______|______|______|______|______|______|______|______|______|______|"); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@" |______|______|______|______|______|______|______|______|______|______|______|______|"); Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"  ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ "); Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@" |______|______|______|______|______|______|______|______|______|______|______|______|"); Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"                                                                                      ");
            Console.WriteLine(@"                                                                                      ");
            Console.WriteLine(@"                                                                                      ");
            Console.WriteLine(@"");
            Console.WriteLine(@"");


            Console.ForegroundColor = ConsoleColor.Red;
            MiddlePrint(@"========START========");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            MiddlePrint(@"Welcome to the program!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            MiddlePrint(@"Author: HaoJun0823");
            Console.ForegroundColor = ConsoleColor.Green;
            MiddlePrint(@"Today is: " + DateTime.Now.ToString());
            Console.ForegroundColor = ConsoleColor.Cyan;
            MiddlePrint(@"Want to know more?");
            Console.ForegroundColor = ConsoleColor.Blue;
            MiddlePrint(@"Please visit:https://blog.haojun0823.xyz");
            Console.ForegroundColor = ConsoleColor.Magenta;
            MiddlePrint(@"Smile To Every :)");
            Console.ForegroundColor = ConsoleColor.Red;
            MiddlePrint(@"=========END=========");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(@"                                                                                      ");
        }

        private static void MiddlePrint(string str)
        {

            int Head = (BLANK.Length - str.Length) / 2;

            for (int i = 0; i < Head; i++)
            {
                Console.Write(" ");
            }
            Console.Write(str);

            for (int i = 0; i < Head - str.Length; i++)
            {
                Console.Write(" ");
            }

            Console.WriteLine();

        }


        

    }
}
