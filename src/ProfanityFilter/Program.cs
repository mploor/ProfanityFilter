using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfanityFilter
{
    static class Utility
    {
        public static string Cleaner(this String input)
        {
            var badWords = new Dictionary<string, string>();
            badWords.Add("darn", "d**n");
            badWords.Add("gosh", "g**h");
            badWords.Add("yuck", "y**k");

            string original = input;
            string lowerOriginal = input;
            lowerOriginal = lowerOriginal.ToLower();
            foreach (string badWord in badWords.Keys)
            {
                input = input.ToLower().Replace(badWord, badWords[badWord]);
            }

            for (int i = 0; i < original.Length; i++)
            {
                if (lowerOriginal[i] == input[i])
                {
                    input = input.Remove(i, 1).Insert(i, original[i].ToString());
                }

            }
            return input;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter your profanity-laden statement");
            string input = Console.ReadLine();

            Console.WriteLine(input.Cleaner());
            Console.ReadLine();
        }
    }
}
