//
//  MyClass.cs
//
//  Author:
//       alex <>
//
//  Copyright (c) 2014 alex
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Linq;
using Do.Universe;

namespace WindowList
{
	public class CloseAction: Act
	{
		public override string Name {
			get {

				return "Close window";
			}
		}

		public override string Description {
			get {
				return Name;
			}
		}

		public override string Icon {
			get {
				return "gtk-open";
			}
		}

		public override bool SupportsItem (Item item)
		{
			return item is WindowItem;
		}

		public override System.Collections.Generic.IEnumerable<Type> SupportedItemTypes {
			get {
				yield return typeof(WindowItem);
			}
		}

		public override System.Collections.Generic.IEnumerable<Item> Perform (System.Collections.Generic.IEnumerable<Item> items, System.Collections.Generic.IEnumerable<Item> modItems)
		{
			WindowItem item = items.First () as WindowItem;
			if (item != null) {
				WindowItem.Closethis (item);
			}

			yield break;
		}
	}
}

