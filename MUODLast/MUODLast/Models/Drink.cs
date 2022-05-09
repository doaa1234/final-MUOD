using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MUODLast.Models
{
    public class Drink
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Id { get; set; }
        public int ParentId { get; set; }
        public bool IsFavorate { get; set; }
        public int RatingValue { get; set; }
        public string Benefits { get; set; }

    }
}
