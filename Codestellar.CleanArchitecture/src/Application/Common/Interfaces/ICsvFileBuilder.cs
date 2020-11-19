using Codestellar.CleanArchitecture.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace Codestellar.CleanArchitecture.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
