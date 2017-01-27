using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeederBike
{
    class FieldOfPlay
    {
        public List<List<IGamePiece>> BackgroundComplete { get; set; } = new List<List<IGamePiece>>();
        Random randomSeed = new Random();
        PlayerPiece playerPiece = new PlayerPiece();
        public int PlayerVerticalLocation { get; set; } = 4;

        public FieldOfPlay()
        {
            for (int i = 0; i < 9; i++)
            {
                BackgroundComplete.Add(new List<IGamePiece>());

                if (i == 0 || i == 8)    // Walls
                {
                    for (int j = 0; j < 10; j++)
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
                    for (int j = 0; j < 50; j++)   // Center Track
                    {
                        BackgroundComplete[i].Add(new BlankSpace());
                    }
                }
            }

            DisplayPlayerLocation();


        } // Constructor OH GOD REFACTOR THIS

        public void DisplayUpdatedGameVisual()
        {
            Console.Clear();

            for (int i = 0; i < BackgroundComplete.Count; i++)
            {
                Console.Write(" ");
                for (int j = 0; j < BackgroundComplete[i].Count; j++)
                {
                    Console.Write(BackgroundComplete[i][j].Symbol);
                }
                Console.Write("\n");
            }
        }

        public void DisplayPlayerLocation()
        {
            BackgroundComplete[PlayerVerticalLocation][0] = playerPiece;
        }

        public void MovePlayerPiece(string pushedKey)
        {
            if (pushedKey == "w")
            {
                MovePlayerPieceUp();
            }
            else if (pushedKey == "s")
            {
                MovePlayerPieceDown();
            }

            DisplayPlayerLocation();
        }

        public void MovePlayerPieceUp()
        {
            if (PlayerVerticalLocation > 1)
            {
                PlayerVerticalLocation -= 1;
            }
        }

        public void MovePlayerPieceDown()
        {
            if (PlayerVerticalLocation < 7)
            {
                PlayerVerticalLocation += 1;
            }
        }

        public bool PlayerHasCollidedWithObject()
        {
            if (true)           //figure out how to check for impact here
            {
                return true;
            }

            return false;
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
                if (i != PlayerVerticalLocation)
                {
                    BackgroundComplete[i].RemoveAt(0);
                    BackgroundComplete[i].Add(GetNewGamePiece());
                }
                else
                {
                    BackgroundComplete[i].RemoveAt(1);
                    BackgroundComplete[i].Add(GetNewGamePiece());
                }

            }
        }

        public IGamePiece GetNewGamePiece()
        {
            int whatBackgroundObjectToSpawn = randomSeed.Next(0, 20);

            if (whatBackgroundObjectToSpawn < 19)
            {
                return new BlankSpace();
            }
            return new Obstacle();
        }

    }
}
