using Core.Repository;
using Models.Entities;
using Repository.Context;
using Repository.Repositories.Abstract;

namespace Repository.Repositories.Concretes;

public class EfCategoryRepository : EfRepositoryBase<BaseDbContext, Category, int>, ICategoryRepository
{
    public EfCategoryRepository(BaseDbContext context) : base(context)
    {
    }
}
