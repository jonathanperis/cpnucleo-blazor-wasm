﻿namespace Cpnucleo.Infra.CrossCutting.Util.Queries.TipoTarefa;

public class ListTipoTarefaViewModel
{
    public IEnumerable<TipoTarefaDTO> TipoTarefas { get; set; }
    public OperationResult OperationResult { get; set; }
}