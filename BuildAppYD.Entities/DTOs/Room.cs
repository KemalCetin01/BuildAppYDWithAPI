

namespace BuildAppYD.Entities.DTOs
{
    public class Room : Base
    {
        public string roomName { get; set; }

        public int BuildingId { get; set; }
        public Building Buildings { get; set; }

    }
}
