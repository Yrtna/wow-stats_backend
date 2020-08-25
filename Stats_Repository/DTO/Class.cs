using System.Collections.Generic;

namespace Stats_Repository.DTO
{
    public class Class
    {
        public virtual int Id { get; set; }
        public virtual int ClassId { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Spec> Specs { get; set; }
    }

    public class Spec
    {
        public virtual int Id { get; set; }
        public virtual Class Class { get; set; }
        public virtual int SpecId { get; set; }
        public virtual string Name { get; set; }
    }
}