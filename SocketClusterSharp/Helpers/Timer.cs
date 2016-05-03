//
//  Timer.cs
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
using System.Threading.Tasks;
using System.Threading;

namespace SocketClusterSharp.Helpers
{
	/// <summary>
	/// Generates a recurring events at a set interval while the callback returns true.
	/// </summary>
	public class Timer
	{
		Guid _id = Guid.NewGuid ();

		readonly CancellationTokenSource _cancellationTokenSourse = new CancellationTokenSource ();

		TimeSpan _interval = TimeSpan.FromMilliseconds (25);

		TimeSpan _maxInterval = TimeSpan.FromTicks (Int32.MaxValue);

		Func<bool> _csallback;


		/// <summary>
		/// Starts a recurring timer using the device clock capabilities.
		/// </summary>
		Timer Start ()
		{
			bool success = false;

			_cancellationTokenSourse.CancelAfter (_maxInterval);

			Task.Run (() => {
				while (!success) {
					if (_cancellationTokenSourse.IsCancellationRequested)
						break;

					Task.Delay (_interval).Wait ();
					success = !_csallback ();
				}
			}, _cancellationTokenSourse.Token);
				

			return this;
		}

		/// <summary>
		/// Starts a recurring timer using the device clock capabilities.
		/// </summary>
		/// <remarks>While the callback returns true, the timer will keep recurring.</remarks>
		public static Timer Start (Func<bool> callback)
		{
			var timer = new Timer ();
			timer._csallback = callback;
			return timer.Start ();
		}

		/// <summary>
		/// Starts a recurring timer using the device clock capabilities.
		/// </summary>
		/// <remarks>While the callback returns true, the timer will keep recurring.</remarks>
		/// <param name="callback">The action to run when the timer elapses.</param>
		/// <param name="interval">The interval between invocations of the callback.</param>
		public static Timer Start (Func<bool> callback, TimeSpan interval)
		{
			var timer = new Timer ();
			timer._interval = interval;
			timer._csallback = callback;
			return timer.Start ();
		}

		/// <summary>
		/// Starts a recurring timer using the device clock capabilities.
		/// </summary>
		/// <remarks>While the callback returns true, the timer will keep recurring.</remarks>
		/// <param name="callback">The action to run when the timer elapses.</param>
		/// <param name="interval">The interval in miliseconds between invocations of the callback.</param>
		public static Timer Start (Func<bool> callback, double interval)
		{
			var timer = new Timer ();
			timer._interval = TimeSpan.FromMilliseconds (interval);
			timer._csallback = callback;
			return timer.Start ();
		}

		/// <summary>
		/// Starts a recurring timer using the device clock capabilities.
		/// </summary>
		/// <remarks>While the callback returns true, the timer will keep recurring or the max interval is reached.</remarks>
		/// <param name="callback">The action to run when the timer elapses.</param>
		/// <param name="interval">The interval between invocations of the callback.</param>
		/// <param name = "maxInterval">The maximum interval before timer stops.</param>
		public static Timer Start (Func<bool> callback, TimeSpan interval, TimeSpan maxInterval)
		{
			var timer = new Timer ();
			timer._interval = interval;
			timer._csallback = callback;
			timer._maxInterval = maxInterval;
			return timer.Start ();
		}

		/// <summary>
		/// Starts a recurring timer using the device clock capabilities.
		/// </summary>
		/// <remarks>While the callback returns true, the timer will keep recurring or the max interval is reached.</remarks>
		/// <param name="callback">The action to run when the timer elapses.</param>
		/// <param name="interval">The interval in miliseconds between invocations of the callback.</param>
		/// <param name = "maxInterval">The maximum interval in miliseconds before timer stops.</param>
		public static Timer Start (Func<bool> callback, double interval, double maxInterval)
		{
			var timer = new Timer ();
			timer._interval = TimeSpan.FromMilliseconds (interval);
			timer._csallback = callback;
			timer._maxInterval = TimeSpan.FromMilliseconds (maxInterval);
			return timer.Start ();
		}

		/// <summary>
		/// Manually stops the timer.
		/// </summary>
		public void Stop ()
		{
			_cancellationTokenSourse.Cancel ();
			_csallback = () => {
				return true;
			};
		}
	}
}

