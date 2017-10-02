using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame
{
    public class Dictionary
    {
        List<String> words;
        bool isFound = false;

        public Dictionary(string filePath)
        {
            words = ReadDictionary.ReadDictionaryFromFile(filePath);
            if (words != null) isFound = true;
        }

        public bool IsDictionaryFound()
        {
            return isFound;
        }

        public string GetRandomWord(int minLenght, int maxLength)
        {
            int index;
            string word=null;
            Random rnd = new Random();
            while(true)
            {
                index = rnd.Next(words.Count);
                int count = words[index].Length;
                //Console.WriteLine("WORD: " + words[index] + " LENGTH: " + count);
                if (count >= minLenght && count <= maxLength)
                {
                    word = words[index];
                    break;
                }
            }
            return word;
        }

        public bool isInDictionary(string word)
        {
            if (words.Contains(word)) return true;
            else return false;
        }
    }

    public static class ReadDictionary
    {
        public static List<String> ReadDictionaryFromFile(string filePath)
        {
            List<String> words=new List<String>();
            String word;
            try
            {
                StreamReader streamReader = new StreamReader(filePath);
                while ((word = streamReader.ReadLine()) != null)
                {
                    words.Add(word);

                }
                return words;
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
            return null;

        }
    }
}
