﻿using Cpnucleo.Infra.CrossCutting.Util.Commands.Responses.Apontamento;
using Cpnucleo.Infra.CrossCutting.Util.ViewModels;
using MediatR;
using System.Runtime.Serialization;

namespace Cpnucleo.Infra.CrossCutting.Util.Commands.Requests.Apontamento
{
    [DataContract]
    public class UpdateApontamentoCommand : IRequest<UpdateApontamentoResponse>
    {
        [DataMember(Order = 1)]
        public ApontamentoViewModel Apontamento { get; set; }
    }
}