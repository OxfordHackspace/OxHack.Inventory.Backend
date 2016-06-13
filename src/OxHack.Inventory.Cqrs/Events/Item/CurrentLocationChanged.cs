﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OxHack.Inventory.Cqrs.Events.Item
{
    public class CurrentLocationChanged : IEvent, IConcurrencyAware
    {
        public CurrentLocationChanged(Guid aggregateRootId, int concurrencyId, string currentLocation)
        {
            this.AggregateRootId = aggregateRootId;
            this.ConcurrencyId = concurrencyId;
            this.CurrentLocation = currentLocation;
        }

        public Guid AggregateRootId
        {
            get;
        }

        public int ConcurrencyId
        {
            get;
        }

        public string CurrentLocation
        {
            get;
        }
    }
}
