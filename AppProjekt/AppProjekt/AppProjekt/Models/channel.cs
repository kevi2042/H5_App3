using System;
using System.Collections.Generic;
using System.Text;

namespace AppProjekt.Models
{
    public class channel
    {
        public int id { get; set; }
        public string  name { get; set; }
        public string  description { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string field1 { get; set; }
        public string field2 { get; set; }
        public string field3 { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public int last_entry_id { get; set; }
    }
}
