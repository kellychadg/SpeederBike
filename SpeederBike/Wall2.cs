using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeederBike
{
    public class Wall2 : IGamePiece
    {
        public char Symbol { get; set; } = '+';
        public bool CollidesWithPlayer { get; set; } = true;
    }
}