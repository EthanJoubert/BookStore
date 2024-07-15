using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string price { get; set; }
        public string image { get; set; }
    }
}
