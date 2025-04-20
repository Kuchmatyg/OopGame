using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopGame
{
    public class GameSettings
    {
        public int MinNumber { get; set; } = 0;
        public int MaxNumber { get; set; } = 10;
        public DifficultyLevel Difficulty { get; set; } = DifficultyLevel.Easy;
    }
}
