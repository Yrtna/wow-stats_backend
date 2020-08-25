using System.Collections.Generic;
using System.Linq;

namespace NHibernateDbSetup.DTO
{
    public static partial class DTOExtensions
    {
        public static Stats_Repository.DTO.Class ToClassicClass(this WCL_Api_Library.DTO.Class classicClass)
        {
            var newClass = new Stats_Repository.DTO.Class
            {
                ClassId = classicClass.Id,
                Name = classicClass.Name
            };
            newClass.Specs = classicClass.Specs.ToClassicSpec(newClass);
            return newClass;
        }

        public static ICollection<Stats_Repository.DTO.Spec> ToClassicSpec(this ICollection<WCL_Api_Library.DTO.Spec> specs, Stats_Repository.DTO.Class classicClass)
        {
            return specs.Select(s => new Stats_Repository.DTO.Spec {SpecId = s.Id, Name = s.Name, Class = classicClass}).ToList();
        }
    }

    public class Class
    {
        public virtual int Id { get; set; }
        public virtual int ClassId { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Spec> Specs { get; set; }
    }

    public class Spec
    {
        public virtual Class Class { get; set; }
        public virtual int Id { get; set; }
        public virtual int SpecId { get; set; }
        public virtual string Name { get; set; }
    }
}