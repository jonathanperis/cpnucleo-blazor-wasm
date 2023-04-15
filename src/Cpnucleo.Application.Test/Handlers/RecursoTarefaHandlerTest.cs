﻿namespace Cpnucleo.Application.Test.Handlers;

public class RecursoTarefaHandlerTest
{
    [Fact]
    public async Task CreateRecursoTarefaCommand_Handle_Success()
    {
        // Arrange
        IApplicationDbContext context = DbContextHelper.GetContext();

        var tarefa = context.Tarefas.First();
        var recurso = context.Recursos.First();

        CreateRecursoTarefaCommand request = MockCommandHelper.GetNewCreateRecursoTarefaCommand(tarefa.Id, recurso.Id);

        // Act
        CreateRecursoTarefaCommandHandler handler = new(context);
        OperationResult response = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.True(response == OperationResult.Success);
    }

    [Fact]
    public async Task GetRecursoTarefaQuery_Handle_Success()
    {
        // Arrange
        IApplicationDbContext context = DbContextHelper.GetContext();

        var recursoTarefa = context.RecursoTarefas.First();

        GetRecursoTarefaQuery request = MockQueryHelper.GetNewGetRecursoTarefaQuery(recursoTarefa.Id);

        // Act
        GetRecursoTarefaQueryHandler handler = new(context);
        GetRecursoTarefaViewModel response = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.True(response.RecursoTarefa != null);
        Assert.True(response.RecursoTarefa.Id != Guid.Empty);
        Assert.True(response.RecursoTarefa.DataInclusao.Ticks != 0);
    }

    [Fact]
    public async Task ListRecursoTarefaQuery_Handle_Success()
    {
        // Arrange
        IApplicationDbContext context = DbContextHelper.GetContext();

        ListRecursoTarefaQuery request = MockQueryHelper.GetNewListRecursoTarefaQuery();

        // Act
        ListRecursoTarefaQueryHandler handler = new(context);
        ListRecursoTarefaViewModel response = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.True(response.RecursoTarefas != null);
        Assert.True(response.RecursoTarefas.Any());
    }

    [Fact]
    public async Task RemoveRecursoTarefaCommand_Handle_Success()
    {
        // Arrange
        IApplicationDbContext context = DbContextHelper.GetContext();

        var recursoTarefa = context.RecursoTarefas.First();

        RemoveRecursoTarefaCommand request = MockCommandHelper.GetNewRemoveRecursoTarefaCommand(recursoTarefa.Id);
        GetRecursoTarefaQuery request2 = MockQueryHelper.GetNewGetRecursoTarefaQuery(recursoTarefa.Id);

        // Act
        RemoveRecursoTarefaCommandHandler handler = new(context);
        OperationResult response = await handler.Handle(request, CancellationToken.None);

        GetRecursoTarefaQueryHandler handler2 = new(context);
        GetRecursoTarefaViewModel response2 = await handler2.Handle(request2, CancellationToken.None);

        // Assert
        Assert.True(response == OperationResult.Success);
        Assert.True(response2.OperationResult == OperationResult.NotFound);
    }

    [Fact]
    public async Task UpdateRecursoTarefaCommand_Handle_Success()
    {
        // Arrange
        IApplicationDbContext context = DbContextHelper.GetContext();

        var tarefa = context.Tarefas.First();
        var recurso = context.Recursos.First();
        var recursoTarefa = context.RecursoTarefas.First();

        UpdateRecursoTarefaCommand request = MockCommandHelper.GetNewUpdateRecursoTarefaCommand(tarefa.Id, recurso.Id, recursoTarefa.Id);
        GetRecursoTarefaQuery request2 = MockQueryHelper.GetNewGetRecursoTarefaQuery(recursoTarefa.Id);

        // Act
        UpdateRecursoTarefaCommandHandler handler = new(context);
        OperationResult response = await handler.Handle(request, CancellationToken.None);

        GetRecursoTarefaQueryHandler handler2 = new(context);
        GetRecursoTarefaViewModel response2 = await handler2.Handle(request2, CancellationToken.None);

        // Assert
        Assert.True(response == OperationResult.Success);
        Assert.True(response2.RecursoTarefa != null);
        Assert.True(response2.RecursoTarefa.Id == recursoTarefa.Id);
    }

    [Fact]
    public async Task ListRecursoTarefaByTarefaQuery_Handle_Success()
    {
        // Arrange
        IApplicationDbContext context = DbContextHelper.GetContext();

        var tarefa = context.Tarefas.First();

        ListRecursoTarefaByTarefaQuery request = MockQueryHelper.GetNewListRecursoTarefaByTarefaQuery(tarefa.Id);

        // Act
        ListRecursoTarefaByTarefaQueryHandler handler = new(context);
        ListRecursoTarefaByTarefaViewModel response = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.True(response.RecursoTarefas != null);
        Assert.True(response.RecursoTarefas.Any());
    }
}
