//
//  Response.cs
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
using System.Threading.Tasks;

using SocketClusterSharp.Errors;
using SocketClusterSharp.Helpers;

using WebSocket.Portable;

namespace SocketClusterSharp
{
	/// <summary>
	/// SocketCluster responce object.
	/// </summary>
	public class SCResponse
	{
		#region Public Properties

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the socket client.
		/// </summary>
		/// <value>The socket.</value>
		public WebSocketClient Socket{ get; set; }

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="SocketClusterSharpClient.SCResponse"/> class.
		/// </summary>
		/// <param name="id">Identifier.</param>
		/// <param name="socket">Web socket client.</param>
		public SCResponse (string id, WebSocketClient socket)
		{
			Socket = socket;
			Id = id;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Ends the response.
		/// </summary>
		/// <returns>The async.</returns>
		public async Task EndAsync ()
		{
			if (!String.IsNullOrWhiteSpace (Id)) {
				await RespondAsync (new SCResponseData{ Rid = Id });
			}
		}

		/// <summary>
		/// Ends the response.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="data">Data.</param>
		public async Task EndAsync (object data)
		{
			if (!String.IsNullOrWhiteSpace (Id)) {
				await RespondAsync (new SCResponseData{ Rid = Id, Data = data });
			}
		}

		/// <summary>
		/// Sends error responce asyncronously.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="error">Error.</param>
		public async Task ErrorAsync (string error)
		{
			await ErrorAsync (new SCError (error), null);
		}

		/// <summary>
		/// Sends error responce asyncronously.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="error">Error.</param>
		public async Task ErrorAsync (SCError error)
		{
			await ErrorAsync (error, null);
		}

		/// <summary>
		/// Sends error responce asyncronously.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="exception">Error.</param>
		public async Task ErrorAsync (Exception exception)
		{
			var error = new SCError (exception.Message);
			error.Stack = exception.StackTrace;


			if (exception.InnerException != null) {
				var data = new {
					innerException = new {
						message = exception.InnerException.Message,
						stack = exception.InnerException.StackTrace
					}
				};
				await ErrorAsync (error, data);
			} else {
				await ErrorAsync (error, null);
			}
		}

		/// <summary>
		/// Sends error responce asyncronously.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="error">Error.</param>
		/// <param name = "data"></param>
		public async Task ErrorAsync (string error, object data)
		{
			await ErrorAsync (new SCError (error), data);
		}

		/// <summary>
		/// Sends error responce asyncronously.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="exception">Error.</param>
		/// <param name = "data"></param>
		public async Task ErrorAsync (Exception exception, object data)
		{
			var error = new SCError (exception.Message);
			error.Stack = exception.StackTrace;

			if (exception.InnerException != null) {
				data = data.Merge (new {
					innerException = new {
						message = exception.InnerException.Message,
						stack = exception.InnerException.StackTrace
					}
				});
			}
			await ErrorAsync (error, data);
		}

		/// <summary>
		/// Sends error responce asyncronously.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="error">Error.</param>
		/// <param name="data">Data.</param>
		public async Task ErrorAsync (SCError error, object data)
		{
			if (!String.IsNullOrWhiteSpace (Id)) {
				var response = new SCResponseData { 
					Rid = Id, 
					Data = data,
					Err = error
				};

				await RespondAsync (response);
			}
		}

		/// <summary>
		/// The asyncronous callback.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="error">Error.</param>
		/// <param name="data">Data.</param>
		public async Task CallbackAsync (SCError error, object data = null)
		{
			if (error != null) {
				await ErrorAsync (error, data);
			} else {
				await EndAsync (data);
			}
		}

		#endregion

		#region Private Methods

		async Task RespondAsync (SCResponseData data)
		{
			await Socket.SendAsync (data.ToJSON ());
		}

		#endregion
	}
}

