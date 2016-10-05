using System;
using OpenTK.Input;

namespace FlappyBirdTeam.Tools
{
    public class InputHandler
    {
        public EventHandler Touch;
        private MouseState state;

        public InputHandler()
        {
            state = new MouseState();
        }

        public void CheckForTouch()
        {
            if (Mouse.GetState().IsButtonDown(MouseButton.Left))
            {
                if (Touch != null)
                {
                    Touch.Invoke(null, EventArgs.Empty);
                }
            }
        }
    }
}
