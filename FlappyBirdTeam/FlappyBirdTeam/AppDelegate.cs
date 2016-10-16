using System.Reflection;
using Microsoft.Xna.Framework;
using Cocos2D;
using CocosDenshion;
using FlappyBirdTeam.View.Screens;

namespace FlappyBirdTeam
{
    public class AppDelegate : CCApplication
    {
        GameState currentScene;
        int preferredWidth;
        int preferredHeight;
        CCDirector _pDirector;
        CCScene sceneMenu;
        CCScene sceneGame;

        public AppDelegate(Game game, GraphicsDeviceManager graphics)
            : base(game, graphics)
        {
            s_pSharedApplication = this;

            preferredWidth = 1024;
            preferredHeight = 768;
            graphics.PreferredBackBufferWidth = preferredWidth;
            graphics.PreferredBackBufferHeight = preferredHeight;

            CCDrawManager.InitializeDisplay(game,
                                          graphics,
                                          DisplayOrientation.LandscapeRight | DisplayOrientation.LandscapeLeft);


            graphics.PreferMultiSampling = false;

        }

        public override bool InitInstance()
        {
            _pDirector = CCDirector.SharedDirector;
            sceneMenu = new MenuScreen();
            sceneGame = new GameScreen();
            return base.InitInstance();
        }

        public override bool ApplicationDidFinishLaunching()
        {   
            _pDirector.SetOpenGlView();

            // 2D projection
            _pDirector.Projection = CCDirectorProjection.Projection2D;
            var resPolicy = CCResolutionPolicy.ExactFit;

            CCDrawManager.SetDesignResolutionSize(preferredWidth,
                                                  preferredHeight,
                                                  resPolicy);

            _pDirector.DisplayStats = true;

            // default
            _pDirector.AnimationInterval = 1.0 / 60;

            CCScene sceneMenu = new MenuScreen();
            CCScene sceneGame = new GameScreen();

            return true;
        }

        public void ChangeScene(GameState changed)
        {
            currentScene = changed;
            if(currentScene == GameState.Hello)
                _pDirector.RunWithScene(sceneMenu);
            else
                _pDirector.RunWithScene(sceneGame);

        }
        /// <summary>
        /// The function be called when the application enters the background
        /// </summary>
        public override void ApplicationDidEnterBackground()
        {
            CCDirector.SharedDirector.Pause();

            //CCSimpleAudioEngine.SharedEngine.PauseBackgroundMusic = true;
        }

        /// <summary>
        /// The function be called when the application enter foreground  
        /// </summary>
        public override void ApplicationWillEnterForeground()
        {
            CCDirector.SharedDirector.Resume();

            //CCSimpleAudioEngine.SharedEngine.PauseBackgroundMusic = false;

        }
    }
}
