﻿using OxHack.Inventory.Web.Extensions;
using OxHack.Inventory.Web.Services;
using System;
using DomainCommands = OxHack.Inventory.Cqrs.Commands;

namespace OxHack.Inventory.Web.Models.Commands.Item
{
    public class ChangeAppearanceCommand : IConcurrencyAwareCommand
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

        public string Appearance
        {
            get;
            set;
        }

        public DomainCommands.ICommand ToDomainCommand(EncryptionService encryptionService, dynamic issuerMetadata)
        {
            return new DomainCommands.Item.ChangeAppearanceCommand(this.Id, this.GetDecryptedConcurrencyId(encryptionService), this.Appearance, issuerMetadata);
        }
    }
}
