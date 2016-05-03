//
//  SCConnectEventArgs.cs
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
	/// SocketCluster connect status.
	/// </summary>
	public class SCConnectStatus
	{
		/// <summary>
		/// Gets or sets the socket's id.
		/// </summary>
		/// <value>The identifier.</value>
		[JsonProperty (PropertyName = "id")]
		public string Id{ get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether or not the current socket is authenticated with 
		/// the server (has a valid auth token).
		/// </summary>
		/// <value><c>true</c> if this instance is authenticated; otherwise, <c>false</c>.</value>
		[JsonProperty (PropertyName = "isAuthenticated", NullValueHandling = NullValueHandling.Ignore)]
		public bool IsAuthenticated { get; set; }

		/// <summary>
		/// Gets or sets the ping timeout.
		/// </summary>
		/// <value>The ping timeout.</value>
		[JsonProperty (PropertyName = "pingTimeout", NullValueHandling = NullValueHandling.Ignore)]
		public double PingTimeout{ get; set; }

		/// <summary>
		/// Gets or sets the auth error.
		/// </summary>
		/// <value>The auth error.</value>
		[JsonProperty (PropertyName = "authError", NullValueHandling = NullValueHandling.Ignore)]
		public SCAuthError AuthError { get; set; }

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="SocketClusterSharp.SCConnectStatus"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="SocketClusterSharp.SCConnectStatus"/>.</returns>
		public override string ToString ()
		{
			return string.Format ("[SCConnectStatus: Id={0}, IsAuthenticated={1}, PingTimeout={2}, AuthError={3}]", Id, IsAuthenticated, PingTimeout, AuthError);
		}
	}
}

