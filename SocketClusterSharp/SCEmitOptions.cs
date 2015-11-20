//
//  SCEmitOptions.cs
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

namespace SocketClusterSharp
{
	public class SCEmitOptions
	{
		/// <summary>
		/// Gets or sets a value indicating whether to force and the send.
		/// </summary>
		/// <value><c>true</c> if force; otherwise, <c>false</c>.</value>
		public bool Force { get; set; } = false;

		/// <summary>
		/// Gets or sets a value indicating whether not to timeout send.
		/// </summary>
		/// <value><c>true</c> if no timeout; otherwise, <c>false</c>.</value>
		public bool NoTimeout { get; set; } = false;
	}
}

