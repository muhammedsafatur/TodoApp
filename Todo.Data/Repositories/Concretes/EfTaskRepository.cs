using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Repository;
using Todo.Repository.Context;
using Todo.Repository.Repositories.Abstract;

namespace Todo.Repository.Repositories.Concretes;

public class EfTaskRepository : EfRepositoryBase<BaseDbContext, Models.Entities.Task, Guid>, ITaskRepository
{
    public EfTaskRepository(BaseDbContext context) : base(context)
    {
    }
}
