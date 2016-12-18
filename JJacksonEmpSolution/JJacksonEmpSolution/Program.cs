using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Word = Microsoft.Office.Interop.Word;


namespace JJacksonEmpSolution
{
    

    public static class PuzzleSolconer
    {
        
        public static string[] DICTIONARY = { "OX", "CAT", "TOY", "AT", "DOG", "CATAPULT", "T" };

        static bool IsWord(string testWord)
        {
            if (DICTIONARY.Contains(testWord))
                return true;
            return false;
        }
        public static void FindWords(char[,] puzzle)
        {
            int word_count = 0; 
            foreach(var word in DICTIONARY)
            {
                word_count += WordSearch(puzzle, word).Count(); 
            }
            Console.WriteLine(word_count);
        }

        static List<Tuple<int,int>> WordSearch(char[,] board, string word)
        {
            List<Tuple<int, int>> index_list = new List<Tuple<int, int>>(); 
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (FindWords(i, j, board, word))
                    {
                        index_list.Add(new Tuple<int,int>(i, j)); 
                    }
                }
            }
            return index_list; 
        }

        static bool FindWords(int i, int j, char[,] board, string word)
        {
            if (word.Length == 1)
            {
                return board[i, j] == word[0];
            }

            bool
                con2 = false, con3 = false, 
                con0 = false, con1 = false, 
                con4 = false, con5 = false, 
                con6 = false, con7 = false, 
                con8 = false;
            int m = board.GetLength(0);
            int n = board.GetLength(1);
            string part = word.Substring(1, word.Length - 1);

            con0 = board[i, j] == word[0];

            // WordSearch the neighbourhood
            if (i < m - 1) { con5 = FindWords(i + 1, j, board, part); }
            if (i < m - 1 && j > 0) { con6 = FindWords(i + 1, j - 1, board, part); }
            if (j > 0) { con7 = FindWords(i, j - 1, board, part); }
            if (i > 0 && j > 0) { con8 = FindWords(i - 1, j - 1, board, part); }
            if (i > 0) { con1 = FindWords(i - 1, j, board, part); }
            if (i > 0 && j < n - 1) { con2 = FindWords(i - 1, j + 1, board, part); }
            if (j < n - 1) { con3 = FindWords(i, j + 1, board, part); }
            if (i < m - 1 && j < n - 1) { con4 = FindWords(i + 1, j + 1, board, part); }
            return con0 && (con1 || con2 || con3 || con4 || con5 || con6 || con7 || con8);
        }
    }


    class Program
        {
            static void Main(string[] args)
            {
            char[,] puzzle1 = new char[,]
                         {
                   {'C', 'A', 'T' },
                    {'X','Z','T' },
                    { 'Y','O','T' }

                         };
            
                char[,] puzzle2 = new char[,]
                     {
                   {'C','A','T','A','P','U','L','T' },
                   { 'X','Z','T','T','O','Y','O','O' },
                   {'Y','O','T','O','X','T','X','X' } };
                   
                PuzzleSolconer.FindWords(puzzle1);
                PuzzleSolconer.FindWords(puzzle2);
            Console.ReadKey();

            }
        }
    }

