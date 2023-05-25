using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    static class GetWord
    {
        public static string WordGetter()
        {
            string unsortedWords = "Abalone, Abandon, Ability, Abolish, Abdomen, Abraham, Abyssal, Academy, Account";
            //string unsortedWords = "";
            List<string> sortedWords = unsortedWords.Split(',').ToList();

            int index = new Random().Next(sortedWords.Count);
            string secretWord = sortedWords[index];

            return secretWord;
        }


    }
}
