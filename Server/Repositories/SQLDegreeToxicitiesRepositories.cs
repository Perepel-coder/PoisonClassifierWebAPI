using Microsoft.EntityFrameworkCore;
using PoisonClassifierWebAPI.Server.Interfaces;
using PoisonClassifierWebAPI.Server.Models;

namespace PoisonClassifierWebAPI.Server.Repositories
{
    public class SQLDegreeToxicitiesRepositories : IRepository<DegreeToxicity>
    {
        private ApplicationDBContext db;

        public SQLDegreeToxicitiesRepositories(ApplicationDBContext db)
        {
            this.db = db;
        }

        public IEnumerable<DegreeToxicity> GetList()
        {
            return db.DegreeToxicities
                .Include(el=>el.IndustrialVenom);
        }

        public DegreeToxicity GetElement(int id)
        {
            return db.DegreeToxicities.Find(id);
        }

        public void Create(DegreeToxicity degreeToxicity)
        {
            db.DegreeToxicities.Add(degreeToxicity);
        }

        public void Update(DegreeToxicity degreeToxicity)
        {
            db.Entry(degreeToxicity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            DegreeToxicity degreeToxicity = db.DegreeToxicities.Find(id);
            if (degreeToxicity != null)
                db.DegreeToxicities.Remove(degreeToxicity);
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
