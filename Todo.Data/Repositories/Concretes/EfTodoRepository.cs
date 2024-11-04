using Core.Repository;
using Repository.Context;
using Repository.Repositories.Abstract;

namespace Repository.Repositories.Concretes;

public class EfTodoRepository : EfRepositoryBase<BaseDbContext, Models.Entities.Todo, Guid>, ITodoRepository
{
    public EfTodoRepository(BaseDbContext context) : base(context)
    {
    }
}
