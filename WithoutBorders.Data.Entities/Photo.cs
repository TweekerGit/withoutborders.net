using System.ComponentModel.DataAnnotations.Schema;
using WithoutBorders.Core;

namespace WithoutBorders.Data.Entities
{
    public class Photo:IEntity<int>
    {
        public int Id { get; set; }
        
        public string Url { get; set; }
        
        [ForeignKey(nameof(Camp))]
        public int CampId { get; set; }
        
        public virtual Camp Camp { get; set; }
    }
}