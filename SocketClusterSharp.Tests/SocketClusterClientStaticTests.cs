//
//  SocketClusterClientStaticTests.cs
//
//  Author:
//       Todd Henderson <todd@todd-henderson.me>
//
//  Copyright (c) 2015-2016 Todd Henderson
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//   
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//   
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
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

