

using System.Collections.Generic;

namespace BuildAppYD.Entities.DTOs
{
   public class Building:Base
    {
        public string buildingName { get; set; }
        public string buildingNo { get; set; }
        public string fullAddress { get; set; }
        public long squareMeter { get; set; }

        public List<Room> Rooms { get; set; }
        public List<Store> Stores { get; set; }
    }
}
