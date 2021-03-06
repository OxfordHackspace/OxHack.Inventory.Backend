﻿using OxHack.Inventory.Cqrs.Events.Item;
using System;

namespace OxHack.Inventory.Cqrs.Commands.Item
{
    public class ChangeSpecCommand : ICommand, IConcurrencyAware, IMapToEvent<SpecChanged>
    {
        public ChangeSpecCommand(Guid aggregateRootId, int concurrencyId, string spec, dynamic issuerMetadata)
		{
            this.Id = aggregateRootId;
            this.ConcurrencyId = concurrencyId;
            this.Spec = spec;
			this.IssuerMetadata = issuerMetadata;
		}

        public Guid Id
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

		public dynamic IssuerMetadata
		{
			get;
		}

		public SpecChanged GetEvent()
        {
            return new SpecChanged(this.Id, this.ConcurrencyId + 1, this.Spec);
        }
    }
}
