﻿using OxHack.Inventory.Web.Extensions;
using OxHack.Inventory.Web.Services;
using System;
using DomainCommands = OxHack.Inventory.Cqrs.Commands;

namespace OxHack.Inventory.Web.Models.Commands.Item
{
	public class ChangeModelCommand : IConcurrencyAwareCommand
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

		public string Model
		{
			get;
			set;
		}

		public DomainCommands.ICommand ToDomainCommand(EncryptionService encryptionService, dynamic issuerMetadata)
		{
			return new DomainCommands.Item.ChangeModelCommand(this.Id, this.GetDecryptedConcurrencyId(encryptionService), this.Model, issuerMetadata);
		}
	}
}
