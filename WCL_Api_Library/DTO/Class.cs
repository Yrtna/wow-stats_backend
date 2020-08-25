using System.Collections.Generic;

namespace WCL_Api_Library.DTO
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Spec> Specs { get; set; }
    }

    public class Spec
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}