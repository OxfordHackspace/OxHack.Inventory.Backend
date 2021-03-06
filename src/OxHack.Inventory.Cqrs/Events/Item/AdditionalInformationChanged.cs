﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OxHack.Inventory.Cqrs.Events.Item
{
    public class AdditionalInformationChanged : IAggregateEvent
	{
        public AdditionalInformationChanged(Guid id, int concurrencyId, string additionalInformation)
        {
            this.Id = id;
            this.ConcurrencyId = concurrencyId;
            this.AdditionalInformation = additionalInformation;
        }

        public Guid Id
        {
            get;
        }

        public int ConcurrencyId
        {
            get;
        }

        public string AdditionalInformation
        {
            get;
        }

        public dynamic Apply(dynamic aggregate)
        {
            aggregate.AdditionalInformation = this.AdditionalInformation;

            return aggregate;
        }
    }
}
