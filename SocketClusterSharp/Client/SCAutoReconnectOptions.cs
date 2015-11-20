//
//  SCAutoReconnectOptions.cs
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

namespace SocketClusterSharp.Client
{
	/// <summary>
	/// SC auto reconnect options.
	/// </summary>
	public class SCAutoReconnectOptions
	{
		/// <summary>
		/// Gets or sets the initial delay.
		/// </summary>
		/// <value>The initial delay.</value>
		public double InitialDelay{ get; set; } = 10000;

		/// <summary>
		/// Gets or sets the multiplier.
		/// </summary>
		/// <value>The multiplier.</value>
		public float Multiplier { get; set; } = 1.5F;

		/// <summary>
		/// Gets or sets the max delay.
		/// </summary>
		/// <value>The max delay.</value>
		public double MaxDelay { get; set; } = 60000;

		/// <summary>
		/// Gets or sets the randomness.
		/// </summary>
		/// <value>The randomness.</value>
		public double? Randomness{ get; set; }= 10000;
	}
}

