using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using Stats_Repository.DTO;
using Stats_Repository.Interfaces;

namespace Stats_Repository
{
    public class ZoneRepository : Repository<Zone>
    {
        public new void Add(Zone entity)
        {
            var existingZoneId = this.FindBy(entity.ZoneId);
            if (existingZoneId == null)
                Session.Save(entity);
        }

        public new void Add(IEnumerable<Zone> entities)
        {
            foreach (var entity in entities)
            {
                this.Add(entity);
            }
        }

        public new void Update(Zone entity)
        {
            var existingZone = this.FindBy(entity.ZoneId);

            if (existingZone == null) return;
            existingZone.Name = entity.Name;
            existingZone.Brackets = entity.Brackets;
            existingZone.Encounters = entity.Encounters;
            existingZone.Frozen = entity.Frozen;
            existingZone.Partitions = entity.Partitions;
            Session.Save(existingZone);
        }

        public new void Update(IEnumerable<Zone> entities)
        {
            foreach (var entity in entities)
            {
                this.Update(entity);
            }
        }

        public void Delete(Zone entity)
        {
            var existingZoneId = this.FindBy(entity.ZoneId);
            if (existingZoneId != null)
                Session.Delete(entity);
        }

        public void Delete(IEnumerable<Zone> entities)
        {
            foreach (var entity in entities)
            {
                this.Delete(entity);
            }
        }
    }
}