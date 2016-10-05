using System;

namespace FlappyBirdTeam
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new FlappyBirdGame())
            {
                game.IsMouseVisible = true;
                game.Run();
            }
        }
    }
}
