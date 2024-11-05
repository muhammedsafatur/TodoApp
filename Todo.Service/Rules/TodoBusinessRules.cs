using Core.Exceptions;
using Repository.Repositories.Abstract;
using Service.Constants;

namespace Service.Rules;


public class TodoBusinessRules(ITodoRepository _todoRepository)
{
    public virtual bool TodoIsPresent(Guid id)
    {
        var todo = _todoRepository.GetById(id);
        if (todo == null)
        {
            throw new Exception(Messages.TodoIsNotPresentMessage(id));
        }
        return true;
    }
    public virtual void TodoTitleMustBeUnique(string title)
    {
        var todo = _todoRepository.GetAll(x => x.Title == title);
        if (string.IsNullOrEmpty(title))
        {
            throw new ArgumentNullException(nameof(title), "Title cannot be null or empty.");
        }
        if (todo.Count > 0)
        {
            throw new BusinessException("Task benzersiz olmalı.");
        }
    }

}
