//
//  SCChannelsState.cs
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
	/// <summary>
	/// Socket Cluster Channels state.
	/// </summary>
	public enum SCChannelsState
	{
		/// <summary>Currently subscibed to.</summary>
		Subscribed,
		/// <summary>Currently not subscibed to.</summary>
		UnSubscribed,
		/// <summary>Currently in the process of subscibeing to the channel.</summary>
		Pending,
		/// <summary>Waiting on a responce from server about subscription.</summary>
		AwaitingCallback
	}
}

