//
//  JSONExtensons.cs
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
using Newtonsoft.Json.Linq;


namespace SocketClusterSharp.Helpers
{
	/// <summary>
	/// Helpers for working with JSON data.
	/// </summary>
	public static class JsonHelpers
	{
		/// <summary>
		/// Determines if is null or empty the specified token.
		/// </summary>
		/// <returns><c>true</c> if is null or empty the specified token; otherwise, <c>false</c>.</returns>
		/// <param name="token">Token.</param>
		public static bool IsNullOrEmpty (this JToken token)
		{
			return (token == null) ||
			(token.Type == JTokenType.Array && !token.HasValues) ||
			(token.Type == JTokenType.Object && !token.HasValues) ||
			(token.Type == JTokenType.String && token.ToString () == String.Empty) ||
			(token.Type == JTokenType.Null);
		}
	}
}


