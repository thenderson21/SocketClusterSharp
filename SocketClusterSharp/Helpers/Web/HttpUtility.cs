﻿//
//  HttpUtility.cs
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

namespace SocketClusterSharp.Helpers.Web
{
	sealed class HttpUtility
	{
		/// <summary>
		/// Parses a query string into a <see cref="SocketClusterSharpClient.Helpers.Web.HttpValueCollection"> using UTF8 encoding.
		/// </summary>
		/// <returns>A <see cref="SocketClusterSharpClient.Helpers.Web.HttpValueCollection"> of query parameters and values. </returns>
		/// <param name="query">The query string to parse.</param>
		public static HttpValueCollection ParseQueryString (string query)
		{
			if (query == null) {
				throw new ArgumentNullException ("query");
			}

			if ((query.Length > 0) && (query [0] == '?')) {
				query = query.Substring (1);
			}

			return new HttpValueCollection (query, true);
		}
	}
}
