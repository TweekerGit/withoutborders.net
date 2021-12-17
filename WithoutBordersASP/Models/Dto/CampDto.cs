using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WithoutBorders.Data.Entities;

namespace WithoutBordersASP.Models.Dto
{
    public class CampDto
    {
        public int? Id { get; set; }
        public string Place { get; set; }
        public string Name { get; set; }
        public int? YearId { get; set; }
        public IEnumerable<Photo> Photos { get; set; }
        public YearDto Year { get; set; }

        public CampDto()
        {
        }

        public CampDto(Camp camp)
        {
            this.Id = camp.Id;
            this.Place = camp.Place;
            this.Name = camp.Name;
            this.YearId = camp.YearId;
            this.Photos = camp.Photos.ToList();
            this.Year = new YearDto(camp.Year);
        }

        public Camp ToEntity()
        {
            return new()
            {
                Id = this.Id ?? throw new ArgumentNullException(nameof(Id)),
                Place = this.Place,
                Name = this.Name,
                YearId = this.YearId ?? throw new ArgumentNullException(nameof(YearId)),
                Photos = this.Photos.ToList(),
                Year = this.Year.ToEntity()
            };
        }
        
        public Camp ToEntitySimple()
        {
            return new()
            {
                Id = this.Id ?? throw new ArgumentNullException(nameof(Id)),
                Place = this.Place,
                Name = this.Name,
                YearId = this.YearId ?? throw new ArgumentNullException(nameof(YearId)),
            };
        }
    }
}