using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeederBike
{
    class Background
    {
        public List<List<IGamePiece>> BackgroundComplete { get; set; } = new List<List<IGamePiece>>();

        public Background()
        {
            for (int i = 0; i < 9; i++)
            {
                BackgroundComplete.Add(new List<IGamePiece>());

                if(i == 0 || i == 8)    // Walls
                {
                    for (int j = 0; j < 20; j++)
                    {
                        BackgroundComplete[i].Add(new Wall1());
                        BackgroundComplete[i].Add(new Wall1());
                        BackgroundComplete[i].Add(new Wall1());
                        BackgroundComplete[i].Add(new Wall1());
                        BackgroundComplete[i].Add(new Wall2());
                    }
                }
                else
                {
                    for (int j = 0; j < 100; j++)   // Center Track
                    {
                        BackgroundComplete[i].Add(new BlankSpace());
                    }
                }
            }


        } // Constructor OH GOD REFACTOR THIS

        public void DisplayBackground()
        {
            Console.Clear();

            for (int i = 0; i < BackgroundComplete.Count; i++)
            {
                for (int j = 0; j < BackgroundComplete[i].Count; j++)
                {
                    Console.Write(BackgroundComplete[i][j].Symbol);
                }
                Console.Write("\n");
            }
        }



        public void MoveBackgroundLeftOneUnit()
        {
            MoveBackgroundWallsLeftOneUnit();
            MoveBackgroundTrackLeftOneUnit();
        }

        public void MoveBackgroundWallsLeftOneUnit()
        {
            int topRow = 0;
            int bottomRow = BackgroundComplete.Count() - 1;

            BackgroundComplete[topRow].Add(BackgroundComplete[topRow][0]);
            BackgroundComplete[topRow].RemoveAt(0);

            BackgroundComplete[bottomRow].Add(BackgroundComplete[bottomRow][0]);
            BackgroundComplete[bottomRow].RemoveAt(0);
        }

        public void MoveBackgroundTrackLeftOneUnit()
        {
            for (int i = 1; i < BackgroundComplete.Count - 1; i++)
            {
                BackgroundComplete[i].RemoveAt(0);
                BackgroundComplete[i].Add(GetNewGamePiece());
            }
        }

        public IGamePiece GetNewGamePiece()
        {
            return new Obstacle(); // Dummy, add result of choosing a random object or empty space
        }

    }
}
