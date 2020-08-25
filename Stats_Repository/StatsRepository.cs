using System.Collections.Generic;
using System.Configuration;
using Stats_Repository.DTO;

namespace Stats_Repository
{
    public class StatsRepository
    {
        public readonly Repository<Zone> Zones = new ZoneRepository();
        public readonly Repository<Class> Classes = new ClassRepository();
        // public Repository<Ranking> Rankings = new Repository<Ranking>();
    }
}