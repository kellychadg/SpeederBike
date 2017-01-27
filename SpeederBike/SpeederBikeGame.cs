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

                CheckForKeyPress();

                fieldOfPlay.MoveBackgroundLeftOneUnit();

                CreateTimeDelayUntilNextFrame();
            }

        }

        public void CreateTimeDelayUntilNextFrame()
        {
            Thread.Sleep(400);
        }

        public void CheckForKeyPress()
        {
            if (Console.KeyAvailable)
            {
                PushedKey = Console.ReadKey(true).KeyChar.ToString();
            }

            fieldOfPlay.MovePlayerPiece(PushedKey);
        }

    }
}
