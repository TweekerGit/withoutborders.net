using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WithoutBorders.Core;

namespace WithoutBorders.Data.Entities
{
    public class Year : IEntity<int>
    {
        public int Id { get; set; }
        
        [MaxLength(32)]
        public string Name { get; set; }
        public virtual ICollection<Camp> Camps { get; set; }

        public Year()
        {
            Camps = new HashSet<Camp>();
        }
    }
}