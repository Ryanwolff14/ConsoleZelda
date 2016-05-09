using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using static projectweek.HERO;
using static projectweek.enemies;

namespace projectweek
{
    public class MapDetails
    {
        public byte[,] roomByteArray { get; set; }
        [XmlAttribute("Room")]
        public MapFunctions.coord roomLocation { get; set; }
        public MapDetails[,] roomArray;



        public MapDetails getRoom()
        {
            return roomArray[roomLocation.Y, roomLocation.X];
        }
        public void SetRoom(Room r)
        {
            roomArray[roomLocation.Y, roomLocation.X] = r;
        }

        public void MoveToNextRoom(FaceDirection direction)
        {
            switch (direction)
            {
                default:
                case HERO.FaceDirection.Up:
                    if (roomLocation.Y > 0)
                    {
                        roomLocation = new MapFunctions.coord(roomLocation.X, (short)(roomLocation.Y - 1));
                    }
                    break;
                case HERO.FaceDirection.Down:
                    if (roomLocation.Y < roomArray.GetLength(0))
                    {
                        roomLocation = new MapFunctions.coord(roomLocation.X, (short)(roomLocation.Y + 1));
                    }
                    break;
                case HERO.FaceDirection.Left:
                    if (roomLocation.X > 0)
                    {
                        roomLocation = new MapFunctions.coord((short)(roomLocation.X - 1), roomLocation.Y);
                    }
                    break;
                case HERO.FaceDirection.Right:
                    if (roomLocation.X < roomArray.GetLength(1))
                    {
                        roomLocation = new MapFunctions.coord((short)(roomLocation.X + 1), roomLocation.Y);
                    }
                    break;
            }
            if (roomArray[roomLocation.Y, roomLocation.X] == null)
            {
                roomArray[roomLocation.Y, roomLocation.X] = new Room(roomByteArray[roomLocation.Y, roomLocation.X], true);
            }
        }

        internal void SetRoom(MapDetails r)
        {
            roomArray[roomLocation.Y, roomLocation.X] = r;
        }

        public void DrawRoom()
        {
            roomArray[roomLocation.Y, roomLocation.X].DrawRoom();
        }

        public static implicit operator MapDetails(Room v)
        {
            throw new NotImplementedException();
        }
    }
}
