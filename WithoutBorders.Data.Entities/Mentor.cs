using System.ComponentModel.DataAnnotations;
using WithoutBorders.Core;

namespace WithoutBorders.Data.Entities
{
    public class Mentor : IEntity<int>
    {
        public int Id { get; set; }

        [MaxLength(32)] public string Name { get; set; }

        [MaxLength(32)] public string Hobby { get; set; }

        [MaxLength(1024)] public string About { get; set; }

        public string PhotoUrl { get; set; }
    }
}