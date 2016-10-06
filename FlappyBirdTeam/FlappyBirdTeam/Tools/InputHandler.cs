using System;
using System.Windows.Forms;
using OpenTK.Input;
using ButtonState = OpenTK.Input.ButtonState;

namespace FlappyBirdTeam.Tools
{
    public static class InputHandler
    {
        private static Boolean isClicked;
        private static Timer _timer;
        public static EventHandler Touch;


        static InputHandler()
        {
            _timer = new Timer { Interval = 16 };
            _timer.Tick += CheckForTouch;
            _timer.Start();
        }

        private static void CheckForTouch(Object sender, EventArgs e)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && !isClicked)
            {
                if (Touch != null)
                    Touch.Invoke(null, EventArgs.Empty);
                isClicked = true;
            }
            else if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                isClicked = false;
            }
        }
    }
}