﻿//
//  HttpValue.cs
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

namespace SocketClusterSharp.Helpers.Web
{
	/// <summary>
	/// Http query key value pair.
	/// </summary>
	public sealed class HttpValue
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SocketClusterSharp.Helpers.Web.HttpValue"/> class.
		/// </summary>
		public HttpValue ()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SocketClusterSharp.Helpers.Web.HttpValue"/> class.
		/// </summary>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		public HttpValue (string key, string value)
		{
			this.Key = key;
			this.Value = value;
		}

		/// <summary>
		/// Gets or Sets the key in the key/value pair.
		/// </summary>
		/// <value>The key.</value>
		public string Key { get; set; }

		/// <summary>
		/// Gets or Sets the value in the key/value pair.
		/// </summary>
		/// <value>The value.</value>
		public string Value { get; set; }


	}
}

