using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public record Opinion
    {
        public Guid Id {get; init;}
        public OpinionType Type {get; init;}
        public string Text {get; init;} = String.Empty;
        public Guid PropositionId {get; init;}
    }
}