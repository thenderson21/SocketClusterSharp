//
//  MyClass.cs
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
using SocketClusterSharp.Internal;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SocketClusterSharp.Tests
{
	[TestFixture]
	[Description ("Testing SocketCluster Client")]
	[Category ("NetworkConnections")]
	[Author ("Todd Henderson")]
	public class SocketClusterClientTests
	{
		SCSocket SocketClient;

		bool Connected = false;

		#region Setup/TearDown

		[OneTimeSetUp]
		public void SetUpFixture ()
		{
			var options = new SCClientOptions { Hostname = "ws://socket.talkfusion.com", Logging = SCLogingLevels.Debug };
			SocketClient = SocketCluster.Connection (options);

			SocketClient.Connected += (obj) => Connected = true;
			SocketClient.Disconnected += (arg1, arg2) => Connected = false;
		}

		[SetUp]
		public async Task SetUpTest ()
		{
			await SocketClient.ConnectAsync ();
		}

		[TearDown]
		public async Task TearDownTests ()
		{
			if (SocketClient.State != SCConnectionState.Closed) {
				await SocketClient.DisconnectAsync ();
			}
		}

		#endregion

		#region Tests

		[Test][Ignore ("Ignore a test temporarily")]
		[Description ("Testing connection to SocketCluster Server.")]
		public void Connecting ()
		{
			if (RetryUntilSuccessOrTimeout (() => Connected, TimeSpan.FromMilliseconds (500))) {
				Assert.That (SocketClient.State, Is.EqualTo (SCConnectionState.Open), "SocketClient.State is incorrect.");
				Assert.That (SocketClient.Id, Is.Not.Null.And.Not.Empty, "Missing or Invalid SocketClient.Id");
			} else {
				Assert.Fail ("Failed to connect to the server in under 500 miliseconds");
			}
		}

		[Test][Ignore ("Ignore a test temporarily")]
		[Description ("Testing subscription to Socket Channels.")]
		public async Task Channels ()
		{
			if (RetryUntilSuccessOrTimeout (() => Connected, TimeSpan.FromMilliseconds (500))) {
				const string channelName = "app:TFtest";

				JToken subscribedObject = null;
				SocketClient.Subscribed += (obj) => subscribedObject = obj;

				JToken watchResults = null;
				SocketClient.Watch (channelName, (data) => watchResults = data);

				var channel = await SocketClient.SubscribeAsync (channelName);

				bool channelSubscribed = false;
				channel.Subscribed += () => channelSubscribed = true;
				channel.SubscribeFailed += (obj) => Assert.Fail (obj.ToString ());

				JToken channelWatchResults = null;
				channel.Watch ((data) => channelWatchResults = data);

				var publishData = JToken.Parse (@"{
				'$applications': ['video-chat'],
				'$event': 'chat:send-message',
				'$user': {
				 	'ip': '123.456.78.91',
					'name': 'Ryan'
				},
				'data':{
					'content': 'This is my super awesome message'
				}   		
			}");
				
				if (RetryUntilSuccessOrTimeout (() => channelSubscribed, TimeSpan.FromMilliseconds (500))) {
					Assert.That (SocketClient.Channel (channelName), Is.EqualTo (channel), "SocketClient.Channel() did not return the correct channel.");
					Assert.That (subscribedObject, Is.Not.Null, "SocketClient.Subscribed event was not triggered.");
					Assert.That (subscribedObject.ToString (), Is.EqualTo (channelName), "SocketClient.Subscribed event returned invalid data.");

					Assert.That (channel.IsSubscribed (), Is.True, "channel.IsSubscribed () return false");
					Assert.That (channel.Name, Is.EqualTo (channelName), "Channel.Name set incorrectly.");

					//Publish Channel Data
					await channel.PublishAsync (publishData);
					if (RetryUntilSuccessOrTimeout (() => channelWatchResults != null, TimeSpan.FromMilliseconds (500))) {
						Assert.That (channelWatchResults ["$applications"], Is.EqualTo (publishData ["$applications"]), "channelWatchResults[\"$applications\"] value does not match.");
						Assert.That (channelWatchResults ["$event"], Is.EqualTo (publishData ["$event"]), "channelWatchResults[\"$event\"]  value does not match.");
						Assert.That (channelWatchResults ["$user"], Is.EqualTo (publishData ["$user"]), "channelWatchResults[\"$user\"]  value does not match.");
						Assert.That (channelWatchResults ["data"], Is.EqualTo (publishData ["data"]), "channelWatchResults[\"data\"]  value does not match.");
					} else {
						Assert.Fail ("Failed to recieve channelWatchResults in under 500 miliseconds");
					}

					if (RetryUntilSuccessOrTimeout (() => watchResults != null, TimeSpan.FromMilliseconds (500))) {
						Assert.That (watchResults ["$applications"], Is.EqualTo (publishData ["$applications"]), "watchResults[\"$applications\"] value does not match.");
						Assert.That (watchResults ["$event"], Is.EqualTo (publishData ["$event"]), "watchResults[\"$event\"]  value does not match.");
						Assert.That (watchResults ["$user"], Is.EqualTo (publishData ["$user"]), "watchResults[\"$user\"]  value does not match.");
						Assert.That (watchResults ["data"], Is.EqualTo (publishData ["data"]), "watchResults[\"data\"]  value does not match.");
					} else {
						Assert.Fail ("Failed to recieve watchResults in under 500 miliseconds");
					}

				} else {
					Assert.Fail ("Failed to subscribe to channel in under 500 miliseconds");
				}
						
			} else {
				Assert.Inconclusive ("Could not connect to the server in under 500 miliseconds");
			}
		}


		[Test]
		[Description ("Testing disconnection from SocketCluster Server.")]
		public async Task Disconnecting ()
		{
			if (RetryUntilSuccessOrTimeout (() => Connected, TimeSpan.FromMilliseconds (500))) {
				await SocketClient.DisconnectAsync ();
				TestContext.WriteLine ("Disconnect Sent");

				if (RetryUntilSuccessOrTimeout (() => !Connected, TimeSpan.FromMilliseconds (1000))) {
					Assert.That (SocketClient.State, Is.EqualTo (SCConnectionState.Closed), "SocketClient.State is incorrect.");
				} else {
					Assert.Fail ("Failed to disconnect from the server in under 1000 miliseconds");
				}
			} else {
				Assert.Inconclusive ("Could not connect to the server in under 500 miliseconds");
			}
		}

		#endregion

		#region Common Methods

		bool RetryUntilSuccessOrTimeout (Func<bool> task, TimeSpan timeSpan, int interval = 25)
		{
			bool success = false;
			int elapsed = 0;
			while ((!success) && (elapsed < timeSpan.TotalMilliseconds)) {
				Thread.Sleep (interval);
				elapsed += interval;
				success = task ();
			}
			return success;
		}

		#endregion
	}
}