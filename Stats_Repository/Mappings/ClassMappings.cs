using FluentNHibernate.Mapping;
using Stats_Repository.DTO;

namespace Stats_Repository.Mappings
{
    public class ClassMappings
    {
        public class ClassMap : ClassMap<Class>
        {
            public ClassMap()
            {
                Id(c => c.Id);
                Map(c => c.Name);
                Map(c => c.ClassId);
                HasMany(c => c.Specs).Cascade.All();
            }
        }

        public class SpecMap : ClassMap<Spec>
        {
            public SpecMap()
            {
                References(x => x.Class);
                Id(x => x.Id);
                Map(x => x.Name);
                Map(x => x.SpecId);
            }
        }
    }
}