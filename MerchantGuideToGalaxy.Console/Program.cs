namespace MerchantGuideToGalaxy.Console
{
    using System;
    using System.Collections.Generic;
    using MerchantGuideToGalaxy.Core;

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" #### Merchant Guide To Galaxy - Version: Caldeira ####### ");
            var inputs = new List<string>
            {
                "glob is I",
                "prok is V",
                "pish is X",
                "tegj is L",
                "glob glob Silver is 34 Credits",
                "glob prok Gold is 57800 Credits",
                "pish pish Iron is 3910 Credits",
                "how much is pish tegj glob glob ?",
                "how many Credits is glob prok Silver?",
                "how many Credits is glob prok Gold?",
                "how many Credits is glob prok Iron?",
                "how much wood could a woodchuck chuck if a woodchuck could chuck wood ?"
            };
            foreach (var input in inputs)
            {
                Console.WriteLine(input);
                var response = Galactic.ToAsk(input);
                if (!string.IsNullOrEmpty(response))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(response);
                    Console.ResetColor();
                }
            }
            Console.ReadLine();
            Console.WriteLine(" #### FINISH ####### ");

        }
    }
}
