using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Pdf
    {
        [JsonProperty("Chapter 2")]
        public string Chapter2 { get; set; }

        [JsonProperty("Chapter 5")]
        public string Chapter5 { get; set; }
    }

    public class ExtraBookDetails
    {
        public string error { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string authors { get; set; }
        public string publisher { get; set; }
        public string language { get; set; }
        public string isbn10 { get; set; }
        public string isbn13 { get; set; }
        public string pages { get; set; }
        public string year { get; set; }
        public string rating { get; set; }
        public string desc { get; set; }
        public string price { get; set; }
        public string image { get; set; }
        public string url { get; set; }
        public Pdf pdf { get; set; }
    }
}
