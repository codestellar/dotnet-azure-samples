using Codestellar.CleanArchitecture.Application.Common.Mappings;
using Codestellar.CleanArchitecture.Domain.Entities;

namespace Codestellar.CleanArchitecture.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
