//
//  DateTimeExtensions.cs
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

namespace SocketClusterSharp.Helpers
{
	/// <summary>
	/// A collection of methods for working with UNIX Timestamps.
	/// </summary>
	public static class UnixTimeStamp
	{

		/// <summary>
		/// Gets the UNIX epoch.
		/// </summary>
		/// <value>The epoch.</value>
		public static DateTime Epoch{ get { return new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); } }

		/// <summary>
		/// Converts a given DateTime into a Unix timestamp
		/// </summary>
		/// <param name="value">Any DateTime</param>
		/// <returns>The given DateTime in Unix timestamp format</returns>
		public static long ToUnixTimeStamp (this DateTime value)
		{
			return (long)Math.Truncate ((value.ToUniversalTime ().Subtract (Epoch)).TotalSeconds);
		}

		/// <summary>
		/// Gets a Unix timestamp representing the current moment
		/// </summary>
		/// <returns>Now expressed as a Unix timestamp</returns>
		public static long Now ()
		{
			return DateTime.UtcNow.ToUnixTimeStamp ();
		}

		/// <summary>
		/// Constructs a DateTime from unix timestamp.
		/// </summary>
		/// <returns>Returns the parsed <see cref="System.DateTime"/></returns>
		/// <param name="unixTimeStamp">Unix time stamp.</param>
		public static DateTime Parse (double unixTimeStamp)
		{
			return Epoch.AddSeconds (unixTimeStamp).ToLocalTime ();
		}

		/// <summary>
		/// Constructs a DateTime from unix timestamp.
		/// </summary>
		/// <returns>Returns the parsed <see cref="System.DateTime"/></returns>
		/// <param name="unixTimeStamp">Unix time stamp.</param>
		public static DateTime Parse (int unixTimeStamp)
		{
			return Epoch.AddSeconds (Convert.ToDouble (unixTimeStamp)).ToLocalTime ();
		}

		/// <summary>
		/// Constructs a DateTime from unix timestamp.
		/// </summary>
		/// <returns>Returns the parsed <see cref="System.DateTime"/></returns>
		/// <param name="unixTimeStamp">Unix time stamp.</param>
		public static DateTime Parse (long unixTimeStamp)
		{
			return Epoch.AddSeconds (Convert.ToDouble (unixTimeStamp)).ToLocalTime ();
		}

		/// <summary>
		/// Constructs a DateTime from unix timestamp.
		/// </summary>
		/// <returns>Returns the parsed <see cref="System.DateTime"/></returns>
		/// <param name="unixTimeStamp">Unix time stamp.</param>
		public static DateTime Parse (string unixTimeStamp)
		{
			return Epoch.AddSeconds (Convert.ToDouble (unixTimeStamp)).ToLocalTime ();
		}
	}
}

