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
        Background background = new Background();


        public void StartGame()
        {

            while (true)
            {
                Console.CursorVisible = false;

                background.DisplayBackground();

                background.MoveBackgroundLeftOneUnit();

                CreateTimeDelayUntilNextFrame();
            }

            // GameOver();
        }

        public void CreateTimeDelayUntilNextFrame()
        {
            Thread.Sleep(250);
        }

    }
}
