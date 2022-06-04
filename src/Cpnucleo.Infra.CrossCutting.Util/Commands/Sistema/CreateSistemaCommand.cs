﻿namespace Cpnucleo.Infra.CrossCutting.Util.Commands.Sistema;

public class CreateSistemaCommand : IRequest<OperationResult>
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
}