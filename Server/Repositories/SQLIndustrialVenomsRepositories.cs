using Microsoft.EntityFrameworkCore;
using PoisonClassifierWebAPI.Server.Interfaces;
using PoisonClassifierWebAPI.Server.Models;

namespace PoisonClassifierWebAPI.Server.Repositories
{
    public class SQLIndustrialVenomsRepositories : IRepository<IndustrialVenom>
    {
        private ApplicationDBContext db;

        public SQLIndustrialVenomsRepositories(ApplicationDBContext db)
        {
            this.db = db;
        }

        public IEnumerable<IndustrialVenom> GetList()
        {
            return db.IndustrialVenoms
                .Include(el => el.DToxicity)
                .Include(el => el.Paths)
                .Include(el => el.Symptoms)
                .Include(el => el.Substance)
                .Include(el => el.NatureImpact)
                .Include(el => el.DegreeImpact).ToList();
        }

        public IndustrialVenom GetElement(int id)
        {
            GetList();
            return db.IndustrialVenoms.Find(id);
        }

        public void Create(IndustrialVenom IVenom)
        {
            db.IndustrialVenoms.Add(IVenom);
        }

        public void Update(IndustrialVenom IVenom)
        {
            db.Entry(IVenom).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            IndustrialVenom IVenom = db.IndustrialVenoms.Find(id);
            if (IVenom != null)
                db.IndustrialVenoms.Remove(IVenom);
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
