using Microsoft.EntityFrameworkCore;
using PoisonClassifierWebAPI.Server.Interfaces;
using PoisonClassifierWebAPI.Server.Models;

namespace PoisonClassifierWebAPI.Server.Repositories
{
    public class SQLOrigionsReposotories : IRepository<Origion>
    {
        private ApplicationDBContext db;

        public SQLOrigionsReposotories(ApplicationDBContext db)
        {
            this.db = db;
        }

        public IEnumerable<Origion> GetList()
        {
            return db.Origions
                .Include(el=>el.MedicalVenoms).ToList();
        }

        public Origion GetElement(int id)
        {
            GetList();
            return db.Origions.Find(id);
        }

        public void Create(Origion origion)
        {
            db.Origions.Add(origion);
        }

        public void Update(Origion origion)
        {
            db.Entry(origion).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Origion origion = db.Origions.Find(id);
            if (origion != null)
                db.Origions.Remove(origion);
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
