using System;
using System.Collections.Generic;
using System.Linq;
using WithoutBorders.Data.Entities;

namespace WithoutBordersASP.Models.Dto
{
    public class YearDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CampDto> Camps { get; set; }

        public YearDto()
        {
        }
        public YearDto(Year year)
        {
            this.Id = year.Id;
            this.Name = year.Name;
            this.Camps = year.Camps.Select(c=>new CampDto(c));
        }

        public Year ToEntity()
        {
            return new()
            {
                Id = this.Id ?? throw new ArgumentNullException(nameof(Id)),
                Name = this.Name,
                Camps = this.Camps.Select(c=>c.ToEntity()).ToList()
            };
        }
        
        public Year ToEntitySimple()
        {
            return new()
            {
                Id = this.Id ?? throw new ArgumentNullException(nameof(Id)),
                Name = this.Name
            };
        }
    }
}