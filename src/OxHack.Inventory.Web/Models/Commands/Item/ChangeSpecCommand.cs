﻿using OxHack.Inventory.Web.Services;
using System;
using DomainCommands = OxHack.Inventory.Cqrs.Commands;

namespace OxHack.Inventory.Web.Models.Commands.Item
{
    public class ChangeSpecCommand : IConcurrencyAwareCommand
    {
        public Guid Id
        {
            get;

            set;
        }
        public string ConcurrencyId
        {
            get;
            set;
        }

        public string Spec
        {
            get;
            set;
        }

        public DomainCommands.ICommand ToDomainCommand(EncryptionService encryptionService)
        {
            throw new NotImplementedException();
        }
    }
}