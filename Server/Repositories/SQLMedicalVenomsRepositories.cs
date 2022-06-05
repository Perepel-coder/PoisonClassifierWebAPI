using Microsoft.EntityFrameworkCore;
using PoisonClassifierWebAPI.Server.Interfaces;
using PoisonClassifierWebAPI.Server.Models;

namespace PoisonClassifierWebAPI.Server.Repositories
{
    public class SQLMedicalVenomsRepositories : IRepository<MedicalVenom>
    {
        private ApplicationDBContext db;

        public SQLMedicalVenomsRepositories(ApplicationDBContext db)
        {
            this.db = db;
        }

        public IEnumerable<MedicalVenom> GetList()
        {
            return db.MedicalVenoms
                .Include(el => el.Origion)
                .Include(el => el.Symptoms)
                .Include(el => el.AggregateState)
                .Include(el => el.NatureImpact)
                .Include(el => el.Substance).ToList();
        }

        public MedicalVenom GetElement(int id)
        {
            GetList();
            return db.MedicalVenoms.Find(id);
        }

        public void Create(MedicalVenom MVenom)
        {
            db.MedicalVenoms.Add(MVenom);
        }

        public void Update(MedicalVenom MVenom)
        {
            db.Entry(MVenom).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            MedicalVenom MVenom = db.MedicalVenoms.Find(id);
            if (MVenom != null)
                db.MedicalVenoms.Remove(MVenom);
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
