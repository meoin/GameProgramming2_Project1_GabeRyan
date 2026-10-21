using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_Project1_GabeRyan
{
    internal class EnemyScared : Enemy
    {

        public EnemyScared(string display, ConsoleColor colour, Position position, Health health) : base(display, colour, position, health)
        {
            

        }

        public override void EnemyMove()
        {
            int enemyXInput = 0;
            int enemyYInput = 0;

            if (Health.CurrentHealth <= 0)
            {
                EraseEnemy();
                EventBus.Invoke(EventType.EnemyDied);
                return;
            }
            if (Program.GameManager.PlayerTurn == false)
            {
                Console.SetCursorPosition(0, 25);
                Console.WriteLine("debug");

                EnemyWait += 1;
                if (EnemyWait >= 2)
                {
                    EnemyWait = 0;
                    EraseEnemy();

                    if (Program.GameManager.Player.Position.X < Position.X)
                    {
                        enemyXInput += 1;

                    }
                    if (Program.GameManager.Player.Position.Y < Position.Y)
                    {
                        enemyYInput += 1;

                    }
                    if (Program.GameManager.Player.Position.X > Position.X)
                    {
                        enemyXInput -= 1;

                    }
                    if (Program.GameManager.Player.Position.Y > Position.Y)
                    {
                        enemyYInput -= 1;

                    }

                    Position.X += enemyXInput;
                    Position.Y += enemyYInput;


                    if (Program.GameManager.Player.Position.X == Position.X && Program.GameManager.Player.Position.Y == Position.Y)
                    {
                        Program.GameManager.Player.Health.TakeDmg();
                        Position.X -= enemyXInput;
                        Position.Y -= enemyYInput;


                    }



                    if (Program.GameManager.Map.IsSpaceOccupied(Position) == true)
                    {
                        Position.X -= enemyXInput;
                        Position.Y -= enemyYInput;

                    }

                }

            }

        }


        public override void DisplayEnemy()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.ForegroundColor = PColour;
            Console.Write(PDisplay);
            Console.ResetColor();

        }

    }
}
