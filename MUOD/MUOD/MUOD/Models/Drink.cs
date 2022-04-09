using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MUOD.Models
{
    public class Drink
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Id { get; set; }
        public int ParentId { get; set; }
        public bool IsFavorate { get; set; }

        public static implicit operator ObservableCollection<object>(Drink v)
        {
            throw new NotImplementedException();
        }
    }
}
