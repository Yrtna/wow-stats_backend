using FluentNHibernate.Mapping;
using Stats_Repository.DTO;

namespace Stats_Repository.Mappings
{
    public class ZoneMappings
    {
        public class ZoneMap : ClassMap<Zone>
        {
            public ZoneMap()
            {
                Id(c => c.Id);
                Map(c => c.ZoneId);
                Map(c => c.Name);
                Map(c => c.Frozen);
                Component(c => c.Brackets);
                HasMany(c => c.Encounters).Cascade.All();
                HasMany(c => c.Partitions).Cascade.All();
            }
        }

        public class BracketMap : ComponentMap<Brackets>
        {
            public BracketMap()
            {
                Map(x => x.Bucket);
                Map(x => x.Max);
                Map(x => x.Min);
                Map(x => x.Type);
            }
        }

        public class EncounterMap : ClassMap<Encounter>
        {
            public EncounterMap()
            {
                References(x => x.Zone);
                Id(x => x.Id);
                Map(x => x.EncounterId);
                Map(x => x.Name);
            }
        }

        public class PartitionMap : ClassMap<Partition>
        {
            public PartitionMap()
            {
                References(x => x.Zone);
                Id(x => x.Id);
                Map(x => x.Name);
                Map(x => x.Compact);
            }
        }
    }
}