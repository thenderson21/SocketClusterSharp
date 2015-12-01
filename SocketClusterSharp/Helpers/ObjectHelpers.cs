//
//  ObjectExtensions.cs
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
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SocketClusterSharp.Helpers
{
	static public class ObjectHelpers
	{
		/// <summary>
		/// Merge the specified target and source.
		/// </summary>
		/// <param name="target">Target.</param>
		/// <param name="source">Source.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T Merge<T> (this T target, T source)
		{
			var typeOfT = typeof(T);
			if (typeOfT.GetTypeInfo ().IsValueType) {
				target = source;
			} else if (source != null) {
				var properties = typeOfT
					.GetRuntimeProperties ()
					.Select ((PropertyInfo x) => new KeyValuePair<PropertyInfo, object> (x, x.GetValue (source, null)))
					.Where ((KeyValuePair<PropertyInfo, object> x) => x.Value != null).ToList ();

				foreach (var property in properties) {
					property.Key.SetValue (target, property.Value);
				}
			}

			//return the modified copy of Target
			return target;
		}

		/// <summary>
		/// Returns a JSON string that represents the current object.
		/// </summary>
		/// <returns>JSON String.</returns>
		/// <param name="source">Source.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static string ToJSON<T> (this T source)
		{
			return JsonConvert.SerializeObject (source);
		}

		/// <summary>
		/// Returns a <see cref="Newtonsoft.Json.Linq.JToken"/> that represents the current object.
		/// </summary>
		/// <returns><see cref="Newtonsoft.Json.Linq.JToken"/></returns>
		/// <param name="source">Source.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static JToken ToJToken<T> (this T source)
		{
			return JToken.FromObject (source);
		}
	}
}

