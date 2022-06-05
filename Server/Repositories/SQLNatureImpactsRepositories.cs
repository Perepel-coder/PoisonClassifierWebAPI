using Microsoft.EntityFrameworkCore;
using PoisonClassifierWebAPI.Server.Interfaces;
using PoisonClassifierWebAPI.Server.Models;

namespace PoisonClassifierWebAPI.Server.Repositories
{
    public class SQLNatureImpactsRepositories : IRepository<NatureImpact>
    {
        private ApplicationDBContext db;

        public SQLNatureImpactsRepositories(ApplicationDBContext db)
        {
            this.db = db;
        }

        public IEnumerable<NatureImpact> GetList()
        {
            return db.NatureImpacts
                .Include(el=>el.IndustrialVenoms)
                .Include(el=>el.MedicalVenoms).ToList();
        }

        public NatureImpact GetElement(int id)
        {
            GetList();
            return db.NatureImpacts.Find(id);
        }

        public void Create(NatureImpact natureImpact)
        {
            db.NatureImpacts.Add(natureImpact);
        }

        public void Update(NatureImpact natureImpact)
        {
            db.Entry(natureImpact).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            NatureImpact natureImpact = db.NatureImpacts.Find(id);
            if (natureImpact != null)
                db.NatureImpacts.Remove(natureImpact);
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
