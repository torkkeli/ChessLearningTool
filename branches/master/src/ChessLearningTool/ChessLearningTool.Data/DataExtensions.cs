using ChessLearningTool.Data.Enums;

namespace ChessLearningTool.Data
{
    public static class DataExtensions
    {
        public static ChessColor Opposite(this ChessColor color)
        {
            return color == ChessColor.White ? ChessColor.Black : ChessColor.White;
        }
    }
}
