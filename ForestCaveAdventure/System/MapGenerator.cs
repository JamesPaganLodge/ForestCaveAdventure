using ForestCaveAdventure.Core;
using RogueSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestCaveAdventure.System
{
    public class MapGenerator
    {
        private readonly int _width;
        private readonly int _height;
        private readonly int _maxRooms;
        private readonly int _roomMaxSize;
        private readonly int _roomMinSize;

        private readonly DungeonMap _map;

        // Constructing a new MapGenerator requires the dimensions of the maps it will create
        public MapGenerator(int width, int height, int maxRooms, int roomMaxSize, int roomMinSize)
        {
            _width = width;
            _height = height;
            _maxRooms = maxRooms;
            _roomMaxSize = roomMaxSize;
            _roomMinSize = roomMinSize;
            _map = new DungeonMap();
        }

        public DungeonMap CreateMap()
        {
            // Initialize every cell in the map by setting walkable, transparency and explored to true
            _map.Initialize(_width, _height);

            // Try to place as many rooms as maxRooms
            for (int r = _maxRooms; r > 0; r--)
            {
                int roomWidth = Game.Random.Next(_roomMinSize, _roomMaxSize);
                int roomHeight = Game.Random.Next(_roomMinSize, _roomMaxSize);
                int roomXPosition = Game.Random.Next(0, _width - roomWidth - 1);
                int roomYPosition = Game.Random.Next(0, _height - roomHeight - 1);

                // All the rooms can be represented as rectangles
                var newRoom = new Rectangle(roomXPosition, roomYPosition, roomWidth, roomHeight);

                // Check if the room rectangle intersects with any other rooms
                bool newRoomIntersects = _map.Rooms.Any(room => newRoom.Intersects(room));

                // As long as it dowsnt intersect add it to the list
                if (!newRoomIntersects)
                {
                    _map.Rooms.Add(newRoom);
                }
            }

            // Iterate through each generated room except the first
            for (int r = 1; r < _map.Rooms.Count; r++)
            {
                // get the centre of the romm and previous room
                int previousRoomCentreX = _map.Rooms[r - 1].Center.X;
                int previousRoomCentreY = _map.Rooms[r - 1].Center.Y;
                int currentRoomCentreX = _map.Rooms[r].Center.X;
                int currentRoomCentreY = _map.Rooms[r].Center.Y;

                // 50/50 chance of L shaped hall
                if (Game.Random.Next(1,2) == 1)
                {
                    CreateHorizontalTunnel(previousRoomCentreX, currentRoomCentreX, previousRoomCentreY);
                    CreateVerticalTunnel(previousRoomCentreY, currentRoomCentreY, currentRoomCentreX);
                }
                else
                {
                    CreateVerticalTunnel(previousRoomCentreY, currentRoomCentreY, previousRoomCentreX);
                    CreateHorizontalTunnel(previousRoomCentreX, currentRoomCentreX, currentRoomCentreY);
                }
            }

            // Iterate over all the rooms in the list and create them
            foreach (Rectangle room in _map.Rooms)
            {
                CreateRoom(room);
            }

            PlacePlayer();

            return _map;
        }

        private void CreateRoom(Rectangle room)
        {
            for (int x = room.Left + 1; x < room.Right; x++)
            {
                for (int y = room.Top + 1; y < room.Bottom; y++)
                {
                    _map.SetCellProperties(x, y, true, true, true);
                }
            }
        }

        private void PlacePlayer()
        {
            Player player = Game.player;

            if (player == null)
            {
                player = new Player();
            }

            player.X = _map.Rooms[0].Center.X;
            player.Y = _map.Rooms[0].Center.Y;

            _map.AddPlayer(player);
        }

        // Carve a tunnel on the x-axis
        private void CreateHorizontalTunnel(int xStart, int xEnd, int yPosition)
        {
            for (int x = Math.Min(xStart,xEnd); x <= Math.Max(xStart,xEnd); x++)
            {
                _map.SetCellProperties(x, yPosition, true, true);
            }
        }

        // Carve a tunnel on the y-axis
        private void CreateVerticalTunnel(int yStart, int yEnd, int xPosition)
        {
            for (int y = Math.Min(yStart,yEnd); y <= Math.Max(yStart,yEnd); y++)
            {
                _map.SetCellProperties(xPosition, y, true, true);
            }
        }
    }
}
