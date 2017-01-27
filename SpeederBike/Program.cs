using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeederBike;

namespace SpeederBike
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeederBikeGame speederBikeGame = new SpeederBikeGame();

            speederBikeGame.StartGame();


            Console.ReadLine();
        }
    }
}
