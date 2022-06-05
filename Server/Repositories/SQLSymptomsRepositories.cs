using Microsoft.EntityFrameworkCore;
using PoisonClassifierWebAPI.Server.Interfaces;
using PoisonClassifierWebAPI.Server.Models;

namespace PoisonClassifierWebAPI.Server.Repositories
{
    public class SQLSymptomsRepositories : IRepository<Symptom>
    {
        private ApplicationDBContext db;

        public SQLSymptomsRepositories(ApplicationDBContext db)
        {
            this.db = db;
        }

        public IEnumerable<Symptom> GetList()
        {
            return db.Symptoms
                .Include(el=>el.IndustrialVenoms)
                .Include(el=>el.MedicalVenoms);
        }

        public Symptom GetElement(int id)
        {
            return db.Symptoms.Find(id);
        }

        public void Create(Symptom symptom)
        {
            db.Symptoms.Add(symptom);
        }

        public void Update(Symptom symptom)
        {
            db.Entry(symptom).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Symptom symptom = db.Symptoms.Find(id);
            if (symptom != null)
                db.Symptoms.Remove(symptom);
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
