﻿using OxHack.Inventory.Cqrs.Events.Item;
using System;

namespace OxHack.Inventory.Cqrs.Commands.Item
{
    public class ChangeSpecCommand : ICommand, IConcurrencyAware, IMapToEvent<SpecChanged>
    {
        public ChangeSpecCommand(Guid aggregateRootId, int concurrencyId, string spec) 
        {
            this.AggregateRootId = aggregateRootId;
            this.ConcurrencyId = concurrencyId;
            this.Spec = spec;
        }

        public Guid AggregateRootId
        {
            get;
        }

        public int ConcurrencyId
        {
            get;
        }

        public string Spec
        {
            get;
        }

        public SpecChanged GetEvent()
        {
            return new SpecChanged(this.AggregateRootId, this.ConcurrencyId, this.Spec);
        }
    }
}
