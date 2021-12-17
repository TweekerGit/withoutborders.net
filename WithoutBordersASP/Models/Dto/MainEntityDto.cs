using System;
using System.Collections.Generic;
using System.Linq;
using WithoutBorders.Data.Entities;

namespace WithoutBordersASP.Models.Dto
{
    public class MainEntityDto
    {
        public int? Id { get; set; }
        public string LeftTitle { get; set; }
        public string LeftTitlePhoto { get; set; }
        public string RightTitle { get; set; }
        public string RightTitlePhoto { get; set; }
        public string About { get; set; }
        public string AboutPhoto { get; set; }
        public List<Expectation> Expectations { get; set; }

        public MainEntityDto()
        {
        }

        public MainEntityDto(MainEntity entity)
        {
            this.Id = entity.Id;
            this.LeftTitle = entity.LeftTitle;
            this.LeftTitlePhoto = entity.LeftTitlePhoto;
            this.RightTitle = entity.RightTitle;
            this.RightTitlePhoto = entity.RightTitlePhoto;
            this.About = entity.About;
            this.AboutPhoto = entity.AboutPhoto;
            this.Expectations = entity.Expectations.ToList();
        }

        public MainEntity ToEntity()
        {
            return new()
            {
                Id = this.Id ?? throw new ArgumentNullException(nameof(Id)),
                LeftTitle = this.LeftTitle,
                LeftTitlePhoto = this.LeftTitlePhoto,
                RightTitle = this.RightTitle,
                RightTitlePhoto = this.RightTitlePhoto,
                About = this.About,
                AboutPhoto = this.AboutPhoto,
                Expectations = this.Expectations.ToList()
            };
        }
        
        public MainEntity ToEntitySimple()
        {
            return new()
            {
                Id = this.Id ?? throw new ArgumentNullException(nameof(Id)),
                LeftTitle = this.LeftTitle,
                LeftTitlePhoto = this.LeftTitlePhoto,
                RightTitle = this.RightTitle,
                RightTitlePhoto = this.RightTitlePhoto,
                About = this.About,
                AboutPhoto = this.AboutPhoto,
            };
        }
    }
}