using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeederBike
{
    class SpeederBikeGame
    {
        FieldOfPlay fieldOfPlay = new FieldOfPlay();
        public bool GameIsOver { get; private set; } = false;
        public int GameDistanceCounter { get; private set; } = 0;

        public void StartGame()
        {
            IntroScreen();

            Console.CursorVisible = false;
            
            while (!GameIsOver)
            {
                fieldOfPlay.DisplayUpdatedGameVisual();

                DisplaySpeedAndDistance();

                string pushedKey = GetKeyPressed();

                fieldOfPlay.MovePlayerPiece(pushedKey);

                fieldOfPlay.MoveBackgroundLeftOneUnit();

                CreateTimeDelayUntilNextFrame(GameDistanceCounter);

                IncrementGameDistanceCounter();

                CheckForGameOver();
            }

            GameOverScreen();
        }

        public void CreateTimeDelayUntilNextFrame(int counter)
        {
            int sleepTime = 100;

            if (counter < 50)
            {
                sleepTime = 300;
            }
            else if (counter < 100)
            {
                sleepTime = 200;
            }
            else if (counter < 150)
            {
                sleepTime = 100;
            }
            else if (counter < 200)
            {
                sleepTime = 50;
            }
            else
            {
                sleepTime = 20;
            }
            
            Thread.Sleep(sleepTime);
        }

        public string GetKeyPressed()
        {
            string pushedKey = string.Empty;

            if (Console.KeyAvailable)
            {
                pushedKey = Console.ReadKey(true).KeyChar.ToString();
            }

            return pushedKey;

        }

        public void CheckForGameOver()
        {
            if (fieldOfPlay.PlayerHasCollided)
            {
                GameIsOver = true;
            }
        }

        public void IncrementGameDistanceCounter()
        {
            GameDistanceCounter++;
        }

        public void DisplaySpeedAndDistance()
        {
            string speed = ((GameDistanceCounter - (GameDistanceCounter % 50))+50).ToString();

            Console.WriteLine($"         [SPEED]: {speed} KPH");
            Console.WriteLine($"      [DISTANCE]: {GameDistanceCounter} Meters");
        }

        public void IntroScreen()
        {
            Console.WriteLine("   ____                    __             ___    _   __           ");
            Console.WriteLine("  / __/ ___  ___  ___  ___/ / ___   ____ / _ )  (_) / /__  ___    ");
            Console.WriteLine(" _\\ \\  / _ \\/ -_)/ -_)/ _/ / / -_) /__/ / _  | / / /  '_/ / -_)   ");
            Console.WriteLine("/___/ / .__/\\__/ \\__/ \\_,_/  \\__/ /_/  /____/ /_/ /_ /\\_\\ \\__/    ");
            Console.WriteLine("     /_/                                                          ");
            Console.WriteLine("                                            by Nathan Rathbun     ");
            Console.WriteLine("\n          w: Move up  s: Move down  Enter: Start");
            Console.ReadLine();
        }

        public void GameOverScreen()
        {
            Console.Clear();
            Console.WriteLine(" '.  \\ | /  ,' ");
            Console.WriteLine("   `. `.' ,' ");
            Console.WriteLine(" (, .`.|, ' .)        G A M E   O V E R   M A N");     
            Console.WriteLine("   - ~-0 - ~ -");
            Console.WriteLine(" (, '|'.` )',)            G A M E   O V E R");
            Console.WriteLine("   .' .'. '.  ");
            Console.WriteLine(" ,'  / | \\  '. ");
            Console.WriteLine($"\n\n    Total Distance Traveled:  {GameDistanceCounter} Meters");

            Console.ReadLine();
        }

    }
}
