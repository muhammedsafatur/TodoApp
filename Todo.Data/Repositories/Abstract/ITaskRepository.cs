
using Todo.Core.Repository;
using Todo.Models.Entities;

namespace Todo.Repository.Repositories.Abstract;

    public interface ITaskRepository : IRepository<Models.Entities.Task, Guid>
    {
    }

