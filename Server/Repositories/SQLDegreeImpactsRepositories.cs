using Microsoft.EntityFrameworkCore;
using PoisonClassifierWebAPI.Server.Interfaces;
using PoisonClassifierWebAPI.Server.Models;

namespace PoisonClassifierWebAPI.Server.Repositories
{
    public class SQLDegreeImpactsRepositories : IRepository<DegreeImpact>
    {
        private ApplicationDBContext db;

        public SQLDegreeImpactsRepositories(ApplicationDBContext db)
        {
            this.db = db;
        }

        public IEnumerable<DegreeImpact> GetList()
        {
            return db.DegreeImpacts
                .Include(el=>el.IndustrialVenoms);
        }

        public DegreeImpact GetElement(int id)
        {
            return db.DegreeImpacts.Find(id);
        }

        public void Create(DegreeImpact degreeImpact)
        {
            db.DegreeImpacts.Add(degreeImpact);
        }

        public void Update(DegreeImpact degreeImpact)
        {
            db.Entry(degreeImpact).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            DegreeImpact degreeImpact = db.DegreeImpacts.Find(id);
            if (degreeImpact != null)
                db.DegreeImpacts.Remove(degreeImpact);
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
