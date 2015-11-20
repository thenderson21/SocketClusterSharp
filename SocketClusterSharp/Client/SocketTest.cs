//
//  SocketTest.cs
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
using WebSocket.Portable;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SocketClusterSharp.Client
{
	public static class SocketTest
	{
		public async static void Test ()
		{
			var client = new WebSocketClient ();
			client.Opened += () => Debug.WriteLine ("CONNECTED");
			client.Closed += () => Debug.WriteLine ("DISCONNECTED");
			client.MessageReceived += (obj) => Debug.WriteLine ("MESSAGE RECIEVED: \n {0}", obj);
			client.Error += (Exception obj) => Debug.WriteLine ("ERROR: \n {0}", obj);

			await client.OpenAsync ("ws://echo.websocket.org");

			await client.SendAsync ("Hello World");

			await client.SendAsync ("Hello World2");

			await Task.Delay (1000);

			await client.CloseAsync ();

			await Task.Delay (100);

			Debug.WriteLine ("TestWebsocketPortableEcho");

		}
	}
}

