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


        public void StartGame()
        {

            while (true)
            {
                Console.CursorVisible = false;

                fieldOfPlay.DisplayUpdatedGameVisual();

                string pushedKey = GetKeyPressed();

                fieldOfPlay.MovePlayerPiece(pushedKey);

                fieldOfPlay.MoveBackgroundLeftOneUnit();

                CreateTimeDelayUntilNextFrame();
            }

        }

        public void CreateTimeDelayUntilNextFrame()
        {
            Thread.Sleep(100);
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

    }
}
