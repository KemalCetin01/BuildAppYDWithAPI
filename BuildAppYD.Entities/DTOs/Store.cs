

namespace BuildAppYD.Entities.DTOs
{
   public class Store:Base
    {
        public string StoreName { get; set; }

        public int BuildingId { get; set; }
        public Building Buildings { get; set; }
    }
}
