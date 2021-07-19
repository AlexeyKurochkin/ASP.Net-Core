using System.Linq;

namespace Mentoring.Services.DataProvider
{
	public interface IDataProvider<TEntity>
	{
		IQueryable<TEntity> GetData();
		TEntity Add(TEntity entity);
		void Update();
		void Delete(TEntity entity);
	}
}
