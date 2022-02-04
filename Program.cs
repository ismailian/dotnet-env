using System;

namespace Env
{
    class Program
    {

        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Usage();
                return;
            }

            /* add new variable */
            if (args[0] == "add")
            {
                if (args.Length == 1)
                {
                    Console.WriteLine("[!] Please provide key:value data to add.");
                    return;
                }

                /**/
                if (!args[1].Contains("="))
                {
                    Console.WriteLine("Please provide data in this format: key=value");
                    return;
                }

                var pair = args[1].Split('=');
                Set(pair[0], pair[1]);

                Console.Write("[+] ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Variable successfully added!");
                Console.ResetColor();
            }

            /* get a variable */
            if (args[0] == "get")
            {
                if (args.Length == 1)
                {
                    Console.WriteLine("[!] Please provide key data to fetch.");
                    return;
                }

                var value = Get(args[1]);

                Console.Write($"[+] {args[1]}:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(value);
                Console.ResetColor();
            }

            /* delete a variable */
            if (args[0] == "delete")
            {
                if (args.Length == 1)
                {
                    Console.WriteLine("[!] Please provide key data to delete.");
                    return;
                }

                Delete(args[1]);

                Console.Write($"[+] ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Variable deleted successfully.");
                Console.ResetColor();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        private static void Usage()
        {
            Console.WriteLine("");
            Console.WriteLine(" +++++++++++++++++++++++++++++");
            Console.Write(" +   ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Environment Variables");
            Console.ResetColor();
            Console.WriteLine("   +");
            Console.WriteLine(" +++++++++++++++++++++++++++++\n");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n  [!] It adds / gets / deletes environment variables from this user.\n");
            Console.ResetColor();

            Console.WriteLine("  $ env add key=value \t # To add a new variable.");
            Console.WriteLine("  $ env get key \t # To get a variable.");
            Console.WriteLine("  $ env delete key \t # To remove a variable.");
        }

        /// <summary>
        /// Set a new environment variable to this user.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private static void Set(string key, string value)
        {
            Environment.SetEnvironmentVariable(key, value, EnvironmentVariableTarget.User);
        }

        /// <summary>
        /// Get an environment variable from this user.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string Get(string key)
            => Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.User);

        /// <summary>
        /// Delete an environment variable from this user.
        /// </summary>
        /// <param name="key"></param>
        private static void Delete(string key)
        {
            Environment.SetEnvironmentVariable(key, null, EnvironmentVariableTarget.User);
        }
    }
}
