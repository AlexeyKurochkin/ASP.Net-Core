using System.Linq;
using Mentoring.Data;

namespace Mentoring.Services.DataProvider
{
	public class SqlDataProvider<TEntity> : IDataProvider<TEntity> where TEntity : class
	{
		private NorthwindDbContext _context;

		public SqlDataProvider(NorthwindDbContext context)
		{
			_context = context;
		}

		public IQueryable<TEntity> GetData()
		{
			return _context.Set<TEntity>();
		}

		public TEntity Add(TEntity entity)
		{
			_context.Add(entity);
			_context.SaveChanges();
			return entity;
		}

		public void Update()
		{
			_context.SaveChanges();
		}

		public void Delete(TEntity entity)
		{
			_context.Remove(entity);
		}
	}
}
