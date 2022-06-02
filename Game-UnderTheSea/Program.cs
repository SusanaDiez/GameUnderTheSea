using System;

namespace Game_UnderTheSea
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1(5, 10, 0))
                game.Run();
        }
    }
}
