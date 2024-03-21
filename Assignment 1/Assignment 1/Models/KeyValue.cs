using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Models
{
    public class KeyValue
    {
        [Key]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
