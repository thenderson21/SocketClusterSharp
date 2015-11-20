//
//  SCSocketOptions.cs
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

using SocketClusterSharp.Internal;
using SocketClusterSharp.Helpers.Web;
using SocketClusterSharp.Interfaces;

namespace SocketClusterSharp.Client
{
	public class SCClientOptions : ISCOptions
	{
		/// <summary>
		///  This is the timeout in milliseconds for getting a response to a SCSocket emit event (when a callback is provided).
		/// </summary>
		public double AckTimeout { get; set; } = 30000D;

		/// <summary>
		/// A custom engine to use for storing and loading JWT auth tokens on the client side.
		/// </summary>
		public SCAuthEngine AuthEngine{ get; set; }

		/// <summary>
		/// The auto process subscriptions.
		/// </summary>
		public bool AutoProcessSubscriptions{ get; set; } = true;

		/// <summary>
		/// Whether or not to automatically reconnect the socket when it loses the connection.
		/// </summary>
		public bool AutoReconnect{ get; set; } = true;

		/// <summary>
		/// Gets or sets the auto reconnect options.
		/// </summary>
		/// <value>The auto reconnect options.</value>
		public SCAutoReconnectOptions AutoReconnectOptions{ get; set; }

		/// <summary>
		/// The name of the JWT auth token (provided to the authEngine - By default this is the localStorage variable name); 
		/// defaults to 'socketCluster.authToken'.
		/// </summary>
		public string AuthTokenName{ get; set; } = "socketCluster.authToken";

		/// <summary>
		/// Set this to false during debugging - Otherwise client connection will fail when using self-signed certificates.
		/// </summary>
		public string BinaryType{ get; set; } = "arraybuffer";

		/// <summary>
		/// Gets or sets the call identifier generator.
		/// </summary>
		/// <value>The call identifier generator.</value>
		public Func<int> CallIdGenerator { get; set; }

		/// <summary>
		/// The hostname.
		/// </summary>
		public string Hostname{ get; set; }

		public SCLogingLevels Logging { get; set; } = SCLogingLevels.Error;

		/// <summary>
		/// The path.
		/// </summary>
		public string Path{ get; set; } = "/socketcluster/";

		/// <summary>
		/// The port number.
		/// </summary>
		public int? Port{ get; set; }

		/// <summary>
		/// Gets or sets the query string.
		/// </summary>
		/// <value>The query.</value>
		public HttpValueCollection Query{ get; set; }

		/// <summary>
		/// Set this to false during debugging - Otherwise client connection will fail when using self-signed certificates.
		/// </summary>
		/// <value><c>true</c> if reject unauthorized; otherwise, <c>false</c>.</value>
		public bool RejectUnauthorized { get; set; } = true;

		/// <summary>
		/// Use secure connection.
		/// </summary>
		public bool Secure{ get; set; }

		/// <summary>
		/// Whether or not to add a timestamp to the WebSocket.
		/// </summary>
		public bool TimestampRequests{ get; set; } = false;

		/// <summary>
		/// The query parameter name to use to hold the timestamp.
		/// </summary>
		public string TimestampParam{ get; set; } =  "t";

	}
}

