using Core;
using System;

namespace Sentiment
{
    class Program
    {
        static void Main(string[] args)
        {
            double result = 0;
            Console.WriteLine("Do you wann to use ANEW? y/n");
            string r = Console.ReadLine();

            if (r == "y" || r == "yes")
            {
                Console.WriteLine("Entere the text");
                while (true)
                {
                    result = SentenceHelper.UseANEW(Console.ReadLine());
                    Console.WriteLine(result);
                }
            } else
            {
                Console.WriteLine("How much sentence?");
                int p = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the text and sentimental");
                for(int i = 0; i < p; i++)
                {
                    SentenceHelper.UpdateData(Console.ReadLine(), Console.ReadLine());
                }

                Console.WriteLine("Enter your text!!!");
                while(true)
                {
                    result = SentenceHelper.UseSenDb(Console.ReadLine());
                    Console.WriteLine(result);
                }
            }
        }
    }
}
