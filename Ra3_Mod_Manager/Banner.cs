using System;
using System.Collections.Generic;
using System.Text;

namespace CNCLauncher
{
    class Banner
    {
        
        public const string BLANK = @"                                                                              ";

        public static void Print()
        {
            
            Console.WriteLine(@"                                                                              "); Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"  _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____     "); Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@" |_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|    "); Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@" |_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|    "); Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"  _____       |  _ \ __ _ _ __   __| | ___ _ __(_) ___  _ __        _____     "); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@" |_____|      | |_) / _` | '_ \ / _` |/ _ \ '__| |/ _ \| '_ \      |_____|    "); Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@" |_____|      |  _ < (_| | | | | (_| |  __/ |  | | (_) | | | |     |_____|    "); Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"         _   _|_| \_\__,_|_| |_|\__,_|\___|_| _|_|\___/|_|_|_|_____           "); Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"        | | | | __ _  ___     | |_   _ _ __  / _ \ ( _ )___ \|___ /           "); Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"        | |_| |/ _` |/ _ \ _  | | | | | '_ \| | | |/ _ \ __) | |_ \           "); Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"        |  _  | (_| | (_) | |_| | |_| | | | | |_| | (_) / __/ ___) |          "); Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"        |_| |_|\__,_|\___/ \___/ \__,_|_| |_|\___/ \___/_____|____/           "); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"  _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____ _____     "); Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@" |_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|    "); Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@" |_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|    "); Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@" |_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|    ");
            Console.WriteLine(@"                                                                              ");Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(@"                        http://blog.haojun0823.xyz                            ");
            Console.WriteLine(@"                                                                              ");

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
            MiddlePrint(@"Please visit:http://blog.haojun0823.xyz");
            Console.ForegroundColor = ConsoleColor.Magenta;
            MiddlePrint(@"Smile To Every :)");
            Console.ForegroundColor = ConsoleColor.Red;
            MiddlePrint(@"=========END=========");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(@"                                                                              ");
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
