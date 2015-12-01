//
//  SCEventObject.cs
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SocketClusterSharp.Helpers;

namespace SocketClusterSharp
{
	/// <summary>
	/// SocketCluster event object.
	/// </summary>
	public class SCEventObject
	{
		/// <summary>
		/// Gets or sets the event.
		/// </summary>
		/// <value>The event.</value>
		[JsonProperty (PropertyName = "event")]
		public string Event { get; set; }

		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <value>The data.</value>
		[JsonProperty (PropertyName = "data")]
		public JToken Data { get; set; }

		/// <summary>
		/// Gets or sets the cid.
		/// </summary>
		/// <value>The cid.</value>
		[JsonProperty (PropertyName = "cid")]
		public int Cid { get; set; }

		/// <summary>
		/// Gets or sets the callback.
		/// </summary>
		/// <value>The callback.</value>
		[JsonIgnore]
		public SCCallback Callback{ get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance has recieved a response.
		/// </summary>
		/// <value><c>true</c> if this instance has recieved response; otherwise, <c>false</c>.</value>
		[JsonIgnore]
		public bool HasRecievedResponse{ get; set; } = false;

		/// <summary>
		/// Gets or sets the timeout timer.
		/// </summary>
		/// <value>The timeout.</value>
		[JsonIgnore]
		public Timer Timeout {
			get;
			set;
		}
	}
}