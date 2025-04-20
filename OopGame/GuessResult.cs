using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopGame
{
    public class GuessResult
    {
        public bool IsCorrect { get; set; }
        public string Message { get; set; }
        public int AttemptsLeft { get; set; }
    }
}
