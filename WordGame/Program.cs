using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary dictionary = new Dictionary("C:\\Users\\Asus\\Documents\\Dictionary.txt");
            if (dictionary.IsDictionaryFound())
            {
                Game game1 = new Game(dictionary);
                Game game2 = new Game(dictionary, Level.Easy, "Jhon");
            }
        }
    }
}
