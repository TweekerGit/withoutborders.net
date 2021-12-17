using System.ComponentModel.DataAnnotations;
using WithoutBorders.Core;

namespace WithoutBorders.Data.Entities
{
    public class Kid : IEntity<int>
    {
        public int Id { get; set; }
        [MaxLength(32)] public string Name { get; set; }
        [MaxLength(32)] public string Surname { get; set; }
        [MaxLength(32)] public string Sex { get; set; }
        public byte Age { get; set; }
        [MaxLength(256)] public string Alergy { get; set; }
        public string Number { get; set; }
    }
}