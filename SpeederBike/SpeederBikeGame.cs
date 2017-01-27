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
        string PushedKey { get; set; } = string.Empty;

        public void StartGame()
        {

            while (true)
            {
                Console.CursorVisible = false;

                fieldOfPlay.DisplayUpdatedGameVisual();

                fieldOfPlay.MoveBackgroundLeftOneUnit();

                CheckForKeyPress();

                fieldOfPlay.MovePlayerPiece(PushedKey);

                CreateTimeDelayUntilNextFrame();
            }

        }

        public void CreateTimeDelayUntilNextFrame()
        {
            Thread.Sleep(150);
        }

        public void CheckForKeyPress()
        {
            if (Console.KeyAvailable)
            {
                PushedKey = Console.ReadKey(true).KeyChar.ToString();
            }
        }

    }
}
