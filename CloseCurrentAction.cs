// 
//  CloseCurrentAction.cs
//  
//  Author:
//       Alex Zhang <alex8224@gmail.com>
// 
//  Copyright © 2014 Alex Zhang <alex8224@gmail.com>
// 
//  This library is free software; you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as
//  published by the Free Software Foundation; either version 2.1 of the
//  License, or (at your option) any later version.
// 
//  This library is distributed in the hope that it will be useful, but
//  WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//  Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
using System;
using Do.Universe;

namespace WindowList
{
	public class CloseCurrentAction: Act
	{
		public override string Name {
			get {

				return "关闭当前窗口";
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
			return true;
		}

		public override System.Collections.Generic.IEnumerable<Type> SupportedItemTypes {
			get {
				yield return typeof(Item);
			}
		}


		public override System.Collections.Generic.IEnumerable<Item> Perform (System.Collections.Generic.IEnumerable<Item> items, System.Collections.Generic.IEnumerable<Item> modItems)
		{
			Utils.CloseCurrentWindow ();
			yield break;
		}
	}
}

