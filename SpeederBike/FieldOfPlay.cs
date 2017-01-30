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

        public int PlayerVerticalLocation { get; private set; } = 4;
        public bool PlayerHasCollided { get; private set; } = false;

        public FieldOfPlay()
        {
            for (int i = 0; i < 9; i++)
            {
                BackgroundComplete.Add(new List<IGamePiece>());

                if (i == 0 || i == 8)    // Walls
                {
                    for (int j = 0; j < 15; j++)
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
                    for (int j = 0; j < 75; j++)   // Center Track
                    {
                        BackgroundComplete[i].Add(new BlankSpace());
                    }
                }
            }

            DisplayPlayerLocation();
        } // Constructor 


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


        public void MoveBackgroundLeftOneUnit()
        {
            MoveBackgroundWallsLeftOneUnit();
            MoveBackgroundTrackLeftOneUnit();
        }

        public void MoveBackgroundWallsLeftOneUnit()
        {
            MoveTopBackgroundWallLeftOneUnit();
            MoveBottomBackgroundWallLeftOneUnit();
        }

        public void MoveTopBackgroundWallLeftOneUnit()
        {
            int topRow = 0;
            BackgroundComplete[topRow].Add(BackgroundComplete[topRow][0]);
            BackgroundComplete[topRow].RemoveAt(0);
        }

        public void MoveBottomBackgroundWallLeftOneUnit()
        {
            int bottomRow = BackgroundComplete.Count() - 1;
            BackgroundComplete[bottomRow].Add(BackgroundComplete[bottomRow][0]);
            BackgroundComplete[bottomRow].RemoveAt(0);
        }

        public void MoveBackgroundTrackLeftOneUnit()
        {
            for (int i = 1; i < BackgroundComplete.Count - 1; i++)
            {
                if (i != PlayerVerticalLocation)
                {
                    MoveBackgroundNotPlayerRow(i);
                }
                else
                {
                    if (BackgroundComplete[i][1].CollidesWithPlayer)
                    {
                        PlayerHasCollided = true;
                    }
                    MoveBackgroundPlayerRow(i);
                }
            }
        }


        public void MoveBackgroundPlayerRow(int i)
        {
            BackgroundComplete[i].RemoveAt(1);
            BackgroundComplete[i].Add(GetNewGamePiece());
        }

        public void MoveBackgroundNotPlayerRow(int i)
        {
            BackgroundComplete[i].RemoveAt(0);
            BackgroundComplete[i].Add(GetNewGamePiece());
        }


        public IGamePiece GetNewGamePiece()
        {
            int whatBackgroundObjectToSpawn = randomSeed.Next(0, 50);

            if (whatBackgroundObjectToSpawn < 47)
            {
                return new BlankSpace();
            }
            else if (whatBackgroundObjectToSpawn == 47)
            {
                return new Obstacle2();
            }
            else if (whatBackgroundObjectToSpawn == 48)
            {
                return new Obstacle3();
            }
            return new Obstacle();
        }

    }
}
