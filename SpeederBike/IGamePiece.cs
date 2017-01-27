using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeederBike
{
    public interface IGamePiece
    {
        char Symbol { get; set; }
        bool CollidesWithPlayer { get; set; }
    }
}
