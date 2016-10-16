using Microsoft.Xna.Framework;
using FlappyBirdTeam.View.Screens;

namespace FlappyBirdTeam.Tools
{
    public class ScreenManager : DrawableGameComponent
    {
        private Game _currentGame;
        private GameState _currentGameState;
        public ScreenManager(Game game) : base(game)
        {
            _currentGame = game;
        }
    }
}
