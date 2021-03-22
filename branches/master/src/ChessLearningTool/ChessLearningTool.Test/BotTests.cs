using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Bot;
using ChessLearningTool.Logic.ChessLogic;
using Xunit;

namespace ChessLearningTool.Test
{
    public class BotTests
    {
        private readonly ChessPosition _position;
        private readonly ChessBot _bot;

        public BotTests()
        {
            _position = new ChessPosition();
            _bot = new ChessBot(ChessColor.Black, _position);

            _position.SetStartingPosition();
        }

        [Fact]
        public void TestMakeMove()
        {
        }
    }
}
