using System;
using System.Collections.Generic;
using System.Text;

namespace Game_UnderTheSea
{
    class PlayerStatus : Sprite
{
        public static int lives;
        public static int score;

        public static int Lives
        {
            get
            {
                return lives;
            }
            set
            {
                lives = value;
            }
        }

        public static int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }

        static PlayerStatus()
        {
            Reset();
        }

        public static void Reset()
        {
            Score = 0;
            Lives = 5;
        }


    }
}
