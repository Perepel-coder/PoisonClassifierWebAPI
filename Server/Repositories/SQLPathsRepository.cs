using Microsoft.EntityFrameworkCore;
using PoisonClassifierWebAPI.Server.Interfaces;
using PoisonClassifierWebAPI.Server.Models;

namespace PoisonClassifierWebAPI.Server.Repositories
{
    public class SQLPathsRepository : IRepository<Models.Path>
    {
        private ApplicationDBContext db;

        public SQLPathsRepository(ApplicationDBContext db)
        {
            this.db = db;
        }

        public IEnumerable<Models.Path> GetList()
        {
            return db.Paths
                .Include(el=>el.Organs)
                .Include(el => el.IndustrialVenoms)
                .ToList();
        }

        public Models.Path GetElement(int id)
        {
            GetList();
            return db.Paths.Find(id);
        }

        public void Create(Models.Path path)
        {
            db.Paths.Add(path);
        }

        public void Update(Models.Path path)
        {
            db.Entry(path).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Models.Path path = db.Paths.Find(id);
            if (path != null)
                db.Paths.Remove(path);
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
