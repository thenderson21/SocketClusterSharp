//
//  StringExtensions.cs
//
//  Author:
//       Todd Henderson <todd@todd-henderson.me>
//
//  Copyright (c) 2015 Talk Fusion Inc.
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;

namespace SocketClusterSharp.Helpers
{
	/// <summary>
	/// A collection of helper methods and extensions for <see cref="System.Collections.Generic.ICollection">
	/// </summary>
	public static class CollectionHelper
	{
		/// <summary>
		/// Adds a value to an ICollection and converts a it to a html query string
		/// </summary>
		/// <returns>The query string.</returns>
		/// <param name="query">Query.</param>
		/// <param name="name">parameter name.</param>
		/// <param name="value">parameter value.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static String ToQueryString <T> (this ICollection<T> query, string name, string value)
		{

			// decodes urlencoded pairs from uri.Query to HttpValueCollection
			var httpValueCollection = Helpers.Web.HttpUtility.ParseQueryString (String.Empty);

			httpValueCollection.Add (name, value);

			return httpValueCollection.ToString ();
		}
	}
}

