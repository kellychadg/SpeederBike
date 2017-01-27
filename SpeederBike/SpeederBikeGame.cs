using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeederBike
{
    class SpeederBikeGame
    {
        Background background = new Background();

        public void StartGame()
        {
            // DisplayIntro();
            // SetAvailableLettersToGuessToDefault();
            // SetSecretWord();

            while (true)
            {
                background.DisplayBackground();

                background.MoveBackgroundLeftOneUnit();


                Console.ReadLine();
            }

            // GameOver();
        }

    }
}
