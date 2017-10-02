using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame
{
    public enum Level { Easy, Medium, Hard};
    
    public class Game
    { 
        private string player;
        private int score;
        Level gameLevel;
        Dictionary dictionary;
        private string gameWord;
        static int highestScore = 0;

        Game(Dictionary gameDictionary)
        {
            int score = 0;
            gameLevel = Level.Medium;
            dictionary = gameDictionary;

        }
        public Game(Dictionary gameDictionary, string playerName="Unknown")
            :this(gameDictionary)
        {
            player = playerName;
            CreateGame();
        }
        public Game(Dictionary gameDictionary, Level level, string playerName="Unknown")
            :this(gameDictionary)
        {
            player = playerName;
            gameLevel = level;
            CreateGame();
        }

        private void CreateGame()
        {
            int minLength=0;
            int maxLength=0;
            if(gameLevel==Level.Easy)
            {
                minLength = 10;
                maxLength = 20;
            }
            if (gameLevel==Level.Medium)
            {
                minLength = 8;
                maxLength = 12;
            }
            if (gameLevel==Level.Hard)
            {
                minLength = 5;
                maxLength = 8;
            }

            gameWord = dictionary.GetRandomWord(minLength, maxLength);
            Play();
        }

        private void Play()
        {
            List<String> answerSet = new List<String>();
            string input;
            Console.WriteLine("GAMEWORD: " + gameWord);
            while(true)
            {
                Console.Write("Input word: ");
                input = GameAdditions.ReadWord();
                if (GameAdditions.DoContain(gameWord, input) && !gameWord.Equals(input) && dictionary.isInDictionary(input))
                {
                    if (!answerSet.Contains(input))
                    {
                        Console.WriteLine("Good!");
                        score += input.Length;
                        answerSet.Add(input);
                        Console.WriteLine("SCORE: " + score);
                    }
                    else Console.WriteLine("You have already used this word.");
                }
                else Console.WriteLine("Retry.");
                if(GameAdditions.isFinishGame()) { Finish(); return; }      
            }

        }

        public int GetScore()
        {
            return score;
        }
        public string GetPlayerName()
        {
            return player;
        }

        private void Finish()
        {
            if(score>highestScore)
            {
                highestScore = score;
            }
            PrintStatistics();
        }

        public void PrintStatistics()
        {
            Console.WriteLine(GetPlayerName() +"--->"+ GetScore()+"\n");
        }
    }

    public static class GameAdditions
    {
        public static bool DoContain(string container, string str)
        {
            container = container.ToLower();
            str = str.ToLower();
            StringBuilder cont = new StringBuilder(container);
            int index;
            foreach (char s in str)
            {
                if ((index = container.IndexOf(s)) != -1)
                {
                    cont = cont.Remove(index, 1);
                    container = cont.ToString();
                }
                else
                {
                    return false;
                }

            }
            return true;
        }

        public static string ReadWord()
        {
            return Console.ReadLine();
        }

        public static bool isFinishGame()
        {
            while (true)
            {
                Console.Write("Do you want to continue? y/n --- ");
                char choice = (Console.ReadKey()).KeyChar;
                Console.WriteLine();
                if (choice == 'y') return false;
                else if (choice == 'n') {return true;}
            }

        }
    }



}
