﻿using Codestellar.CleanArchitecture.Application.Common.Exceptions;
using Codestellar.CleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;
using Codestellar.CleanArchitecture.Application.TodoItems.Commands.DeleteTodoItem;
using Codestellar.CleanArchitecture.Application.TodoLists.Commands.CreateTodoList;
using Codestellar.CleanArchitecture.Domain.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Codestellar.CleanArchitecture.Application.IntegrationTests.TodoItems.Commands
{
    using static Testing;

    public class DeleteTodoItemTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoItemId()
        {
            var command = new DeleteTodoItemCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoItem()
        {
            var listId = await SendAsync(new CreateTodoListCommand
            {
                Title = "New List"
            });

            var itemId = await SendAsync(new CreateTodoItemCommand
            {
                ListId = listId,
                Title = "New Item"
            });

            await SendAsync(new DeleteTodoItemCommand
            {
                Id = itemId
            });

            var list = await FindAsync<TodoItem>(listId);

            list.Should().BeNull();
        }
    }
}
