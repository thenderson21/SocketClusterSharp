//
//  SCResponceData.cs
//
//  Author:
//       Todd Henderson <todd@todd-henderson.me>
//
//  Copyright (c) 2015 Todd Henderson
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
using SocketClusterSharp.Errors;
using Newtonsoft.Json;

namespace SocketClusterSharp
{
	/// <summary>
	/// SocketCluster response data object.
	/// </summary>
	public class SCResponseData
	{
		/// <summary>
		/// Gets or sets the rid.
		/// </summary>
		/// <value>The rid.</value>
		[JsonProperty (PropertyName = "rid")]
		public string Rid { get; set; }

		/// <summary>
		/// Gets or sets the response error.
		/// </summary>
		/// <value>The error.</value>
		[JsonProperty (PropertyName = "err", NullValueHandling = NullValueHandling.Ignore)]
		public object Err { get; set; }

		/// <summary>
		/// Gets or sets the response data.
		/// </summary>
		/// <value>The data.</value>
		[JsonProperty (PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
		public object Data{ get; set; }
	}
}

