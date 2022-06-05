using Microsoft.EntityFrameworkCore;
using PoisonClassifierWebAPI.Server.Interfaces;
using PoisonClassifierWebAPI.Server.Models;

namespace PoisonClassifierWebAPI.Server.Repositories
{
    public class SQLSubstancRepository : IRepository<Substance>
    {
        private ApplicationDBContext db;

        public SQLSubstancRepository(ApplicationDBContext db)
        {
            this.db = db;
        }

        public IEnumerable<Substance> GetList()
        {

            return db.Substances
                .Include(el => el.SubstanceClass)
                .Include(el => el.IVenom)
                .Include(el => el.MVenom).ToList();
        }

        public Substance GetElement(int id)
        {
            GetList();
            return db.Substances.Find(id);
        }

        public void Create(Substance sub)
        {
            db.Substances.Add(sub);
        }

        public void Update(Substance sub)
        {
            db.Entry(sub).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            GetList();
            Substance sub = db.Substances.Find(id);
            if (sub != null)
                db.Substances.Remove(sub);
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
