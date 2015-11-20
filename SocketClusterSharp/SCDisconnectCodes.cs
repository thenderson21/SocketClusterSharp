//
//  SCStatusCodes.cs
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

namespace SocketClusterSharp
{
	public static class SCDisconnectCodes
	{
		#region Public static Properties

		/// <summary>
		/// The error statuses.
		/// </summary>
		public static Dictionary<int, string> Error = new Dictionary<int, string> {
			{ 1001, "Socket was disconnected" },
			{ 1002, "A WebSocket protocol error was encountered" },
			{ 1003, "Server terminated socket because it received invalid data" },
			{ 1005, "Socket closed without status code" },
			{ 1006, "Socket hung up" },
			{ 1007, "Message format was incorrect" },
			{ 1008, "Encountered a policy violation" },
			{ 1009, "Message was too big to process" },
			{ 1010, "Client ended the connection because the server did not comply with extension requirements" },
			{ 1011, "Server encountered an unexpected fatal condition" },
			{ 4000, "Server ping timed out" },
			{ 4001, "Client pong timed out" },
			{ 4002, "Server failed to sign auth token" },
			{ 4003, "Failed to complete handshake" },
			{ 4004, "Client failed to save auth token" }
		};

		/// <summary>
		/// The ignore statuses.
		/// </summary>
		public static Dictionary<int, string> Ignore = new Dictionary<int, string> {
			{ 1000, "Socket closed normally" },
			{ 1001, "Socket hung up" }
		};

		#endregion
	}
}

