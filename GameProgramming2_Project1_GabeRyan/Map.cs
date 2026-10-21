using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal class Map
    {

        public string[] _map;
        public char[] _boarder = {'═', '║', '^', '#', '~'};

        public bool[,] _occupiedSpaces;



        
        

        public void LoadMap(string mapPath)
        {
            _map = File.ReadAllLines(mapPath);

            _occupiedSpaces = new bool[_map.Length, _map[0].Length];



        }

        public bool IsSpaceOccupied(Position position)
        {
            // check _occupiedSpaces if position = true or false

            return _occupiedSpaces[position.Y, position.X];

        }

        public void SetOccupied(Position position, bool state)
        {
            _occupiedSpaces[position.X, position.Y] = state;
        }


        public void DisplayMap()
        {
           

            for (int i = 0; i < _map.Length; i++)
            {
                for (int j = 0; j < _map[i].Length; j++)
                {
                    DrawMapTile(i, j);
                }

            }


            Console.Write("\n");
    

        }

        public void DrawMapTile(int row, int col) 
        {
            Console.SetCursorPosition(col, row);

            if (_map[row][col] == '`')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (_map[row][col] == '~')
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (_map[row][col] == '^')
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (_map[row][col] == '#')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            Console.Write(_map[row][col]);
            Console.ResetColor();
        }

        public bool CheckCharInBoarder(char boarderchar)
        {
            for(int i = 0; i < _boarder.Length; i++)
            {
                if (_boarder[i] == boarderchar)
                {
                    return true;
                }
               
            }
            return false;
        }

    }
}
