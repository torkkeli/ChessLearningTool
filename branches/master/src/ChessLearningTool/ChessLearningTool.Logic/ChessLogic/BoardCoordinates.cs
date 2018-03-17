using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLearningTool.Logic.ChessLogic
{
    public sealed class BoardCoordinates
    {
        private readonly int _row;
        private readonly int _column;

        public BoardCoordinates(int row, int column)
        {
            _row = row;
            _column = column;
        }

        public int Row => _row;

        public int Column => _column;
    }
}
