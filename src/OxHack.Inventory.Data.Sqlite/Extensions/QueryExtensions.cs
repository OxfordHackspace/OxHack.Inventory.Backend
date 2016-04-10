﻿using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity.Query;
using OxHack.Inventory.Query.Sqlite.Models;

namespace OxHack.Inventory.Query.Sqlite.Extensions
{
	public static class QueryExtensions
	{
		internal static IIncludableQueryable<T, IEnumerable<Photo>> IncludeAllMembers<T>(this IQueryable<T> source) where T : Item
		{
			return source.Include(item => item.Photos);
		}
	}
}
