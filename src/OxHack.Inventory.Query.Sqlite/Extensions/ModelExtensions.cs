﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OxHack.Inventory.Query.Sqlite.Extensions
{
	internal static class ModelExtensions
	{
		public static Query.Models.Item ToDomainModel(this Sqlite.Models.Item @this)
		{
			return Query.Models.Item.CreateNew(
				new Guid(@this.Id),
				@this.AdditionalInformation,
				@this.Appearance,
				@this.AssignedLocation,
				@this.Category,
				@this.CurrentLocation,
				(@this.IsLoan == 1),
				@this.Manufacturer,
				@this.Model,
				@this.Name,
				@this.Origin,
				(int)@this.Quantity,
				@this.Spec,
				@this.Photos.Select(item => item.Filename).ToList(),
                (int)@this.ConcurrencyId);
		}

		public static Sqlite.Models.Item ToDbModel(this Query.Models.Item @this)
		{
			var resultItem = new Sqlite.Models.Item()
			{
				Id = @this.Id.ToString(),
				AdditionalInformation = @this.AdditionalInformation,
				Appearance = @this.Appearance,
				AssignedLocation = @this.AssignedLocation,
				Category = @this.Category,
				CurrentLocation = @this.CurrentLocation,
				IsLoan = (@this.IsLoan ? 1 : 0),
				Manufacturer = @this.Manufacturer,
				Model = @this.Model,
				Name = @this.Name,
				Origin = @this.Origin,
				Quantity = @this.Quantity,
				Spec = @this.Spec,
                ConcurrencyId = @this.ConcurrencyId
			};

			var photos = 
				@this.Photos
					.Select(filename => 
					new Sqlite.Models.Photo()
					{
						Filename = filename,
						Item = resultItem,
						ItemId = resultItem.Id
					}).ToList();

			resultItem.Photos = photos;

			return resultItem;
		}
	}
}
