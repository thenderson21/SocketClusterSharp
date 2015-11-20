//
//  SCLogging.cs
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
using SocketClusterSharp.Interfaces;

namespace SocketClusterSharp.Internal
{
	interface ICanLog
	{
		SCLogingLevels Logging { get; set; }
	}

	/// <summary>
	/// Socket Cluster loging levels.
	/// </summary>
	public enum SCLogingLevels
	{
		None,
		Error,
		Info,
		Debug,
		Trace
	}

	static class SCLogging
	{
		public static void Log (this ICanLog target, string message, SCLogingLevels logingLevel)
		{
			if (logingLevel <= target.Logging) {
				System.Diagnostics.Debug.WriteLine ("SCTransport:{0}:: {1}", logingLevel, message);
			}
		}

		public static void Log (this ICanLog target, object value, SCLogingLevels logingLevel)
		{
			if (logingLevel <= target.Logging) {
				System.Diagnostics.Debug.WriteLine ("SCTransport:{0}:: {1}", logingLevel, value);
			}
		}
	}
}

