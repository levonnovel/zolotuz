using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zolotuz.Models
{
    public class Headers
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public string EngName { get; set; }
        public List<Types> Values { get; set; } = new List<Types>();
    }
    public class Types
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public string EngName { get; set; }
        public List<SubTypes> Values { get; set; } = new List<SubTypes>();
    }
    public class SubTypes
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public string EngName { get; set; }
    }
}
