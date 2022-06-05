using Microsoft.EntityFrameworkCore;
using PoisonClassifierWebAPI.Server.Interfaces;
using PoisonClassifierWebAPI.Server.Models;

namespace PoisonClassifierWebAPI.Server.Repositories
{
    public class SQLAggregateStatesRepositories : IRepository<AggregateState>
    {
        private ApplicationDBContext db;

        public SQLAggregateStatesRepositories(ApplicationDBContext db)
        {
            this.db = db;
        }

        public IEnumerable<AggregateState> GetList()
        {
            return db.AggregateStates
                .Include(el=>el.MedicalVenoms).ToList();
        }

        public AggregateState GetElement(int id)
        {
            GetList();
            return db.AggregateStates.Find(id);
        }

        public void Create(AggregateState aggregateState)
        {
            db.AggregateStates.Add(aggregateState);
        }

        public void Update(AggregateState aggregateState)
        {
            db.Entry(aggregateState).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            AggregateState aggregateState = db.AggregateStates.Find(id);
            if (aggregateState != null)
                db.AggregateStates.Remove(aggregateState);
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
