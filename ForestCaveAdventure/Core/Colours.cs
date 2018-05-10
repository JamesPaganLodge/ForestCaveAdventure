using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;

namespace ForestCaveAdventure.Core
{
    public class Colours
    {
        public static RLColor FloorBackground = RLColor.Black;
        public static RLColor Floor = Palette.AlternateDarkest;
        public static RLColor FloorBackgroundFOV = Palette.DbDark;
        public static RLColor FloorFOV = Palette.Alternate;

        public static RLColor WallBackground = Palette.SecondaryDarkest;
        public static RLColor Wall = Palette.Secondary;
        public static RLColor WallBackgroundFOV = Palette.SecondaryDarker;
        public static RLColor WallFOV = Palette.SecondaryLighter;

        public static RLColor TextHeading = RLColor.White;
        public static RLColor Text = Palette.DbLight;
        public static RLColor Gold = Palette.DbSun;

        public static RLColor Player = Palette.DbLight;

        public static RLColor Kobold = Palette.DbBrightWood;
        public static RLColor Goblin = Palette.DbVegetation;
        public static RLColor Ooze = Palette.DbBlood;
    }
}
