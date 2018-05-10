using RLNET;
using RogueSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestCaveAdventure.Core
{
    public class DungeonMap : Map
    {
        private readonly List<Monster> _monsters;

        public List<Rectangle> Rooms;

        public DungeonMap()
        {
            // Initialize all lists when we create a dungeon map
            Rooms = new List<Rectangle>();
            _monsters = new List<Monster>();
        }

        // The draw method will be called each time the map is updated
        // It will render the symbols and colours for each cell to the map sub-console
        public void Draw(RLConsole mapConsole)
        {
            mapConsole.Clear();

            foreach (Cell cell in GetAllCells())
            {
                SetConsoleSymbolForCell(mapConsole, cell);
            }
        }

        private void SetConsoleSymbolForCell(RLConsole console, Cell cell)
        {
            // When we havent explored a cell yet dont draw anything
            if (!cell.IsExplored)
            {
                return;
            }

            // When a cell is currently in the FOV it should be drawn with lighter colours
            if (IsInFov(cell.X, cell.Y))
            {
                // Choose the symbol to draw based on if the cell is walkable of not
                // . for floor
                // # for walls
                if (cell.IsWalkable)
                {
                    console.Set(cell.X, cell.Y, Colours.FloorFOV, Colours.FloorBackgroundFOV, '.');
                }
                else
                {
                    console.Set(cell.X, cell.Y, Colours.WallFOV, Colours.WallBackgroundFOV, '#');
                }
            }
            // When a cell is outside FOV draw it with darker colours
            else
            {
                if (cell.IsWalkable)
                {
                    console.Set(cell.X, cell.Y, Colours.Floor, Colours.FloorBackground, '.');
                }
                else
                {
                    console.Set(cell.X, cell.Y, Colours.Wall, Colours.WallBackground, '#');
                }
            }
        }

        // Will be called any time the player is moved to update FOV
        public void UpdatePlayerFOV()
        {
            Player player = Game.player;

            ComputeFov(player.X, player.Y, player.Perception, true);

            foreach (Cell cell in GetAllCells())
            {
                if (IsInFov(cell.X,cell.Y))
                {
                    SetCellProperties(cell.X, cell.Y, cell.IsTransparent, cell.IsWalkable, true);
                }
            }
        }

        // Returns true when able to place an Actor on the cell
        public bool SetActorPosition(Actor actor, int x, int y)
        {
            // Only allow placement if walkable
            if (GetCell(x,y).IsWalkable)
            {
                // The previous cell is not walkable
                SetIsWalkable(actor.X, actor.Y, true);
                actor.X = x;
                actor.Y = y;

                // the new cell is not walkable
                SetIsWalkable(actor.X, actor.Y, false);

                // Update FOV
                if (actor is Player)
                {
                    UpdatePlayerFOV();
                }

                return true;
            }

            return false;
        }

        // Helper method for setting tyhe IsWalkable property on a Cell
        public void SetIsWalkable(int x, int y, bool isWalkable)
        {
            Cell cell = GetCell(x, y);
            SetCellProperties(cell.X, cell.Y, cell.IsTransparent, isWalkable, cell.IsExplored);
        }

        // Add player to Map after it is generated
        public void AddPlayer(Player player)
        {
            Game.player = player;
            SetIsWalkable(player.X, player.Y, false);
            UpdatePlayerFOV();
        }

        public void AddMonster(Monster monster)
        {
            _monsters.Add(monster);
            SetIsWalkable(monster.X, monster.Y, false);
        }

        // Look for a random location in a room that is walkable
        public Point GetRandomWalkableLocationInRoom(Rectangle room)
        {
            return null;
        }

        public bool DoesRoomHaveWalkableSpace(Rectangle room)
        {
            return false;
        }
    }
}
