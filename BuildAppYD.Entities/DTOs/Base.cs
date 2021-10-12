using System;

namespace BuildAppYD.Entities.DTOs
{
  public class Base
    {
        public int Id { get; set; }
        public DateTime createTime { get; set; }
        public bool isDeleted { get; set; }
    }
}
