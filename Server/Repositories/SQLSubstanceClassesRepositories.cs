using Microsoft.EntityFrameworkCore;
using PoisonClassifierWebAPI.Server.Interfaces;
using PoisonClassifierWebAPI.Server.Models;

namespace PoisonClassifierWebAPI.Server.Repositories
{
    public class SQLSubstanceClassesRepositories : IRepository<SubstanceClass>
    {
        private ApplicationDBContext db;

        public SQLSubstanceClassesRepositories(ApplicationDBContext db)
        {
            this.db = db;
        }

        public IEnumerable<SubstanceClass> GetList()
        {
            return db.SubstanceClasses.Include(el=>el.Substances);
        }

        public SubstanceClass GetElement(int id)
        {
            return db.SubstanceClasses.Find(id);
        }

        public void Create(SubstanceClass subcl)
        {
            db.SubstanceClasses.Add(subcl);
        }

        public void Update(SubstanceClass subcl)
        {
            db.Entry(subcl).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            SubstanceClass subcl = db.SubstanceClasses.Find(id);
            if (subcl != null)
                db.SubstanceClasses.Remove(subcl);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
