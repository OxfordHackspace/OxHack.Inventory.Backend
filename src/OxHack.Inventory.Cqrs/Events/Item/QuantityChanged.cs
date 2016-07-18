﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OxHack.Inventory.Cqrs.Events.Item
{
    public class QuantityChanged : IEvent
    {
        public QuantityChanged(Guid aggregateRootId, int concurrencyId, int quantity)
        {
            this.AggregateRootId = aggregateRootId;
            this.ConcurrencyId = concurrencyId;
            this.Quantity = quantity;
        }

		public Guid AggregateRootId
		{
			get;
		}

        public int ConcurrencyId
        {
            get;
        }

		public int Quantity
		{
			get;
		}

		public dynamic Apply(dynamic aggregate)
		{
			aggregate.Quantity = this.Quantity;

			return aggregate;
		}
	}
}
