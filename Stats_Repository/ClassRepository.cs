using System.Collections.Generic;
using Stats_Repository.DTO;

namespace Stats_Repository
{
    public class ClassRepository : Repository<Class>
    {
        public new void Add(Class entity)
        {
            var existingClassId = this.FindBy(entity.ClassId);
            if (existingClassId == null)
                Session.Save(entity);
        }

        public new void Add(IEnumerable<Class> entities)
        {
            foreach (var entity in entities)
            {
                this.Add(entity);
            }
        }

        public new void Update(Class entity)
        {
            var existingClass = this.FindBy(entity.ClassId);

            if (existingClass == null) return;
            existingClass.Name = entity.Name;
            existingClass.Specs = entity.Specs;
            Session.Save(existingClass);
        }

        public new void Update(IEnumerable<Class> entities)
        {
            foreach (var entity in entities)
            {
                this.Update(entity);
            }
        }

        public void Delete(Class entity)
        {
            var existingClassId = this.FindBy(entity.ClassId);
            if (existingClassId != null)
                Session.Delete(entity);
        }

        public void Delete(IEnumerable<Class> entities)
        {
            foreach (var entity in entities)
            {
                this.Delete(entity);
            }
        }
    }
}