using Codestellar.CleanArchitecture.Application.Common.Mappings;
using Codestellar.CleanArchitecture.Domain.Entities;
using System.Collections.Generic;

namespace Codestellar.CleanArchitecture.Application.TodoLists.Queries.GetTodos
{
    public class TodoListDto : IMapFrom<TodoList>
{
    public TodoListDto()
    {
        Items = new List<TodoItemDto>();
    }

    public int Id { get; set; }

    public string Title { get; set; }

    public IList<TodoItemDto> Items { get; set; }
}
}
