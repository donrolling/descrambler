using System;

namespace descrambler
{
    class Program
    {
        private const string Exit = "exit";

        static void Main(string[] args)
        {
            DoStuff();
        }

        private static void DoStuff()
        {
            var input = "NDV EDA SNT TER VBR LWO KXY\nEIO MTH SOE\nMJP SAC NCA EHN IXQ NHS RED OES";
            var outputs = Descrambler.Descramble(input);
            for (int i = 0; i < outputs.Count; i++)
            {
                Console.WriteLine($"Line { i } Options");
                var options = outputs[i];
                foreach (var option in options)
                {
                    Console.WriteLine(option);
                }
            }

            var x = AwaitCommand();
            if (x != Exit)
            {
                DoStuff();
            }
        }

        private static string AwaitCommand()
        {
            Console.WriteLine($"Enter '{ Exit }' to quit.");
            var x = Console.ReadLine();
            return x;
        }
    }
}
