using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TwitterTestApp.Models
{
    public class Twit
    {
        [DisplayFormat(DataFormatString = "{0:o}")]
        public DateTime CreateAt { get; set; }

        public User Author { get; set; }
        public string Text { get; set; }
        public List<string> Tags { get; set; }
        public List<Image> Images { get; set; }
    }
}
