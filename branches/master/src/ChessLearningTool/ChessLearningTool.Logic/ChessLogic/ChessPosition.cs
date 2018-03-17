using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.ChessLogic.Pieces;
using ChessLearningTool.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLearningTool.Logic.ChessLogic
{
    public sealed class ChessPosition
    {
        private readonly IChessPiece[,] _position = new IChessPiece[8, 8];
        private readonly List<ChessMove> _moves = new List<ChessMove>();

        public ChessPosition()
        {

        }

        public event Action PositionChanged;

        public IChessPiece this[int row, int column]
        {
            get { return _position[row, column]; }
            set { _position[row, column] = value; }
        }

        public IEnumerable<ChessMove> Moves => _moves;

        public void SetStartingPosition()
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    switch (r)
                    {
                        case 1:
                            _position[r, c] = new Pawn(ChessColor.White, new BoardCoordinates(r, c));
                            _position[r, c].MoveMade += OnMoveMade;
                            break;
                        case 6:
                            _position[r, c] = new Pawn(ChessColor.Black, new BoardCoordinates(r, c));
                            _position[r, c].MoveMade += OnMoveMade;
                            break;
                        case 0:
                        case 7:
                            switch (c)
                            {
                                case 0:
                                case 7:
                                    _position[r, c] = new Rook(r == 0 ?  ChessColor.White : ChessColor.Black, new BoardCoordinates(r, c));
                                    break;
                                case 1:
                                case 6:
                                    _position[r, c] = new Knight(r == 0 ? ChessColor.White : ChessColor.Black, new BoardCoordinates(r, c));
                                    break;
                                case 2:
                                case 5:
                                    _position[r, c] = new Bishop(r == 0 ? ChessColor.White : ChessColor.Black, new BoardCoordinates(r, c));
                                    break;
                                case 3:
                                    _position[r, c] = new Queen(r == 0 ? ChessColor.White : ChessColor.Black, new BoardCoordinates(r, c));
                                    break;
                                case 4:
                                    _position[r, c] = new King(r == 0 ? ChessColor.White : ChessColor.Black, new BoardCoordinates(r, c));
                                    break;
                            }

                            _position[r, c].MoveMade += OnMoveMade;
                            break;
                    }
                }
            }
        }

        private void OnMoveMade(ChessMove move)
        {
            _position[move.End.Row, move.End.Column] = move.Piece;
            _position[move.Start.Row, move.Start.Column] = null;
            _moves.Add(move);

            PositionChanged?.Invoke();
        }
    }
}
