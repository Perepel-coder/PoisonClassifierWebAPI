using Microsoft.EntityFrameworkCore;
using PoisonClassifierWebAPI.Server.Interfaces;
using PoisonClassifierWebAPI.Server.Models;

namespace PoisonClassifierWebAPI.Server.Repositories
{
    public class SQLOrgansReposotories : IRepository<Organ>
    {
        private ApplicationDBContext db;

        public SQLOrgansReposotories(ApplicationDBContext db)
        {
            this.db = db;
        }

        public IEnumerable<Organ> GetList()
        {
            return db.Organs
                .Include(el=>el.Paths)
                .ToList();
        }

        public Organ GetElement(int id)
        {
            GetList();
            return db.Organs.Find(id);
        }

        public void Create(Organ organ)
        {
            db.Organs.Add(organ);
        }

        public void Update(Organ organ)
        {
            db.Entry(organ).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Organ organ = db.Organs.Find(id);
            if (organ != null)
                db.Organs.Remove(organ);
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
