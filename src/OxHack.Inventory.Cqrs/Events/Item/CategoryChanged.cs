﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OxHack.Inventory.Cqrs.Events.Item
{
    public class CategoryChanged : IAggregateEvent
	{
        public CategoryChanged(Guid id, int concurrencyId, string category)
        {
            this.Id = id;
            this.ConcurrencyId = concurrencyId;
            this.Category = category;
        }

        public Guid Id
        {
            get;
        }

        public int ConcurrencyId
        {
            get;
        }

        public string Category
        {
            get;
        }

        public dynamic Apply(dynamic aggregate)
        {
            aggregate.Category = this.Category;

            return aggregate;
        }
    }
}
