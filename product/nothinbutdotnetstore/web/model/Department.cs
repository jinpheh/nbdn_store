using System;

namespace nothinbutdotnetstore.model
{
    public class Department
    {
        public string name { get; set; }
        public DateTime active_in_store_since { get; set; }
        public bool is_special { get; set; }
    }
}