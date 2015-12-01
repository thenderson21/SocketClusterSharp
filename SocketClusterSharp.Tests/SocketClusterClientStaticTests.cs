//
//  SocketClusterClientStaticTests.cs
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
using NUnit.Framework;
using SocketClusterSharp.Client;

namespace SocketClusterSharp.Tests
{
	[TestFixture]
	[Description ("Testing Static items in SocketCluster")]
	[Category ("StaticResourses")]
	[Author ("Todd Henderson")]
	public class SocketClusterClientStaticTests
	{
		[Test]
		[Description ("Testing that \"SocketCluster.Version\" returns a valid reponse.")]
		public void VersionString ()
		{
			Assert.That (SocketCluster.Version, Is.Not.Null.And.Not.Empty);
			Assert.That (SocketCluster.Version, Does.Match (@"\d+\.\d+(\.\d+)?(-\w+)?"));
		}

		[Test]
		[Description ("Testing that \"SocketCluster.Connection ()\" returns a valid reponse.")]
		public void Connection ()
		{
			var connection = SocketCluster.Connection ();
			Assert.That (connection, Is.InstanceOf (typeof(SCSocket)), "Invalid type");
		}
	}
}

