using ForestCaveAdventure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestCaveAdventure.System
{
    public class CommandSystem
    {
        // Return is true if the player is able to move
        public bool MovePlayer(Direction direction)
        {
            int x = Game.player.X;
            int y = Game.player.Y;

            switch(direction)
            {
                case Direction.Up:
                    {
                        y = Game.player.Y - 1;
                        break;
                    }
                case Direction.Down:
                    {
                        y = Game.player.Y + 1;
                        break;
                    }
                case Direction.Left:
                    {
                        x = Game.player.X - 1;
                        break;
                    }
                case Direction.Right:
                    {
                        x = Game.player.X + 1;
                        break;
                    }
                default:
                    {
                        return false;
                    }
            }

            if (Game.DungeonMap.SetActorPosition(Game.player, x, y))
            {
                return true;
            }

            return false;
        }
    }
}
