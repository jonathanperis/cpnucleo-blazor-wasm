﻿using System.Runtime.Serialization;

namespace Cpnucleo.Infra.CrossCutting.Util.Commands.Responses.Workflow
{
    [DataContract]
    public class UpdateWorkflowResponse
    {
        [DataMember(Order = 1)]
        public OperationResult Status { get; set; }
    }
}