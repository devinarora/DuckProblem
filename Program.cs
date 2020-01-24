using System;
using System.Collections.Generic;

namespace DuckProblem
{

    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            float totalMoves = 0f;
            Rock[,] rocks = new Rock[Globals.NUM_ROCKS_HORIZONTAL, Globals.NUM_ROCKS_VERTICAL];
            Duck[] ducks = new Duck[Globals.NUM_DUCKS];
            bool sameRock = true;
            
            for(int i = 0; i < Globals.NUM_ROCKS_HORIZONTAL; i++)
            {
                for(int j = 0; j < Globals.NUM_ROCKS_VERTICAL; j++) // Initializes rocks
                {
                    Rock thisrock = new Rock(i, j, new List<Rock>());
                    rocks[i, j] = thisrock;
                }
            }

            for (int i = 0; i < Globals.NUM_ROCKS_HORIZONTAL; i++) 
            {
                for (int j = 0; j < Globals.NUM_ROCKS_VERTICAL; j++) // Passes over each rock and adds adjacents
                {
                    if(i - 1 >= 0)
                    {
                        rocks[i, j].adjacent.Add(rocks[i - 1, j]);
                    }

                    if(i + 1 < Globals.NUM_ROCKS_HORIZONTAL)
                    {
                        rocks[i, j].adjacent.Add(rocks[i + 1, j]);
                    }

                    if(j - 1 >= 0)
                    {
                        rocks[i, j].adjacent.Add(rocks[i, j - 1]);
                    }

                    if(j + 1 < Globals.NUM_ROCKS_VERTICAL)
                    {
                        rocks[i, j].adjacent.Add(rocks[i, j + 1]);
                    }
                }
            }

            for (int i = 0; i < Globals.NUM_DUCKS; i++)
            {
                ducks[i] = new Duck(rocks[Globals.NUM_ROCKS_HORIZONTAL / 2, Globals.NUM_ROCKS_VERTICAL / 2]); // sets initial rock to center rock, rounded down
            }

            Console.WriteLine("Begin\n");
            for (int iter = 0; iter < Globals.NUM_ITERATIONS; iter++)
            {
                float move_count = 0.0f;

                do
                {
                    sameRock = true; // Reset sameRock
                    foreach (Duck duck in ducks) // Move each duck
                    {
                        duck.Move();
                    }
                    move_count++;

                    for (int i = 0; i < ducks.Length - 1; i++) // Compare each pair of ducks
                    {
                        if (ducks[i].rock != ducks[i + 1].rock) // If not on same rock, set sameRock to false
                        {
                            sameRock = false;
                        }
                    }
                } while (!sameRock); // Loop until sameRock true

                totalMoves += move_count;

                Console.WriteLine(move_count.ToString() + " moves");
            }

            TimeSpan ts = DateTime.Now - dt;

            float avgMoves = totalMoves / Globals.NUM_ITERATIONS;
            Console.WriteLine("End. Average number of moves = " + avgMoves.ToString());
            Console.WriteLine("Program finished in " + ts.TotalSeconds.ToString() + " seconds");
        }
    }
}
