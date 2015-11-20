//
//  AuthEngine.cs
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

namespace SocketClusterSharp.Client
{
	public class SCAuthEngine
	{
		Dictionary<string, string> _localStorage { get; set; } = new Dictionary<string, string>();

		/// <summary>
		/// Saves a token.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="token">Token.</param>
		/// <param name="options">Options.</param>
		/// <param name="callback">Callback.</param>
		public void SaveToken (string name, string token, object options = null, SCCallback callback = null)
		{
			_localStorage.Add (name, token);
			if (callback != null)
				callback (null);
		}

		/// <summary>
		/// Removes a token.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="callback">Callback.</param>
		public void RemoveToken (string name, SCCallback callback = null)
		{
			_localStorage.Remove (name);
			if (callback != null)
				callback (null);
		}

		/// <summary>
		/// Loads a token.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="callback">Callback.</param>
		public void LoadToken (string name, Action<Errors.SCError, string> callback)
		{
			string value;
			if (_localStorage.TryGetValue (name, out value)) {
				callback (null, value);
			} else {
				callback (null, null);
			}
		}

	}
}

