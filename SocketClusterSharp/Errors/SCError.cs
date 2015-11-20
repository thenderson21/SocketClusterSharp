//
//  Error.cs
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
using System.Collections.Generic;

namespace SocketClusterSharp.Errors
{
	/// <summary>
	/// SocketCluster error.
	/// </summary>
	public class SCError
	{
		
		[JsonProperty (PropertyName = "code", NullValueHandling = NullValueHandling.Ignore)]
		public int Code { get; set; }

		/// <summary>
		/// Gets or sets the error message.
		/// </summary>
		/// <value>The message.</value>
		[JsonProperty (PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
		public string Message { get; set; }

		/// <summary>
		/// Gets or sets the error name.
		/// </summary>
		/// <value>The name.</value>
		[JsonProperty (PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the error type.
		/// </summary>
		/// <value>The type.</value>
		[JsonProperty (PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
		public string Type { get; set; }

		/// <summary>
		/// Gets or sets the error stack.
		/// </summary>
		/// <value>The stack.</value>
		[JsonProperty (PropertyName = "stack", NullValueHandling = NullValueHandling.Ignore)]
		public string Stack { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="SocketClusterSharpClient.Errors.SCError"/> class.
		/// </summary>
		public SCError ()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SocketClusterSharpClient.Errors.SCError"/> struct.
		/// </summary>
		/// <param name="message">Error Message.</param>
		public SCError (string message)
		{
			Message = message;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SocketClusterSharpClient.Errors.SCError"/> struct.
		/// </summary>
		/// <param name="type">Error Type.</param>
		/// <param name="message">Error Message.</param>
		public SCError (string type, string message)
		{
			Type = type;
			Message = message;
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="SocketClusterSharp.Errors.SCError"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="SocketClusterSharp.Errors.SCError"/>.</returns>
		public override string ToString ()
		{
			return string.Format ("[SCError: Code={0}, Message=\"{1}\", Name=\"{2}\", Type=\"{3}\", Stack=\"{4}\"]", Code, Message, Name, Type, Stack);
		}
	
	}
}

