//
//  SCCallback.cs
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
using Newtonsoft.Json.Linq;
using SocketClusterSharp.Errors;

namespace SocketClusterSharp
{
	/// <summary>
	/// SocketCluster callback deligate called when oporation is compleated.
	/// </summary>
	/// <param name="error">Optional <see cref="SocketClusterSharp.Errors.SCError"/> object to be bassed to callback.</param>
	/// /// <param name="data">Optional <see cref="Newtonsoft.Json.Linq.JToken"/> object to be passed to callback.</param>
	public delegate void SCCallback (SCError error = null, JToken data = null);
}

