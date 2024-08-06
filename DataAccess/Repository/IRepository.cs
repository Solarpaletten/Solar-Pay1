using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
		bool AddRange(List<T> entities);
		bool Delete(Guid id);
        bool Delete(List<T> Entities);
        IQueryable<T> GetAll();
        T GetById(Guid id);
		T GetById(string id);
		T Update(T entity);
		public List<T> GetDataFiltered(Expression<Func<T, bool>> condition);

	}
}
