using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public readonly struct Opinion
    {
        public Guid Id {get; init;}
        public OpinionType Type {get; init;}
        public string Text {get; init;}
        public Guid PropositionId {get; init;}
    }
}