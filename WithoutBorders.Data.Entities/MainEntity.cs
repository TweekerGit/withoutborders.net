using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WithoutBorders.Core;

namespace WithoutBorders.Data.Entities
{
    public class MainEntity : IEntity<int>
    {
        public int Id { get; set; }
        [MaxLength(32)] public string LeftTitle { get; set; }
        public string LeftTitlePhoto { get; set; }
        [MaxLength(32)] public string RightTitle { get; set; }
        public string RightTitlePhoto { get; set; } 
        public string AboutPhoto { get; set; }
        [MaxLength(2048)] public string About { get; set; }
        public virtual ICollection<Expectation> Expectations { get; set; }

        public MainEntity()
        {
            Expectations = new HashSet<Expectation>();
        }
    }
}