//
//  SocketCluster.cs
//
//  Author:
//       Todd Henderson <todd@todd-henderson.me>
//
//  Copyright (c) 2015 Talk Fusion, Inc
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
using System.Reflection;

namespace SocketClusterSharp.Client
{
	public static class SocketCluster
	{
		#region Public Properties

		static string _version;

		/// <summary>
		/// Gets the current version number of this assembly.
		/// </summary>
		/// <value>The version.</value>
		public static string Version {
			get {
				if (_version == null) {
					var assembly = typeof(SocketCluster).GetTypeInfo ().Assembly;
					// In some PCL profiles the above line is: var assembly = typeof(MyType).Assembly;
					var assemblyName = new AssemblyName (assembly.FullName);
					_version = assemblyName.Version.Major + "." + assemblyName.Version.Minor;
				}
				return _version;
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Creates and returns a new socket connection to the specified host (or origin if not specified). 
		/// The options argument is optional - If omitted, the socket will try to connect to the origin server 
		/// on the current port. For cross domain requests, a typical options object might look like this 
		/// (example over HTTPS/WSS):
		/// </summary>
		/// <param name="options">Options.</param>
		public static SCSocket Connection (SCClientOptions options = null)
		{
			var Socket = new SCSocket (options);
			return Socket;
		}

		#endregion
	}
}

