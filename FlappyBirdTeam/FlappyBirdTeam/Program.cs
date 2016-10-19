using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace FlappyBirdTeam
{

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

