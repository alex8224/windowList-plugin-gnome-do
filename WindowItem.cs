// 
//  WindowItem.cs
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
using System.Collections.Generic;
using Wnck;
using Do.Universe;

namespace WindowList
{
	public class WindowItem : Item, IApplicationItem
	{
		private Window window;
		private string icon;

		public String Exec {get {return "";}}

		public void LaunchWithFiles (IEnumerable<IFileItem> files) {;}

		public void Run(){
			Utils.ActiveWindow (window);
		}

		public override string Name {
			get {
				return String.Format ("{0} - {1} -- window", window.Name, window.Application.Name);
			}
		}

		public override string Description {
			get {
				return window.Name;
			}
		}

		public override string Icon {
			get {
				return icon;
			}
		}

		public Window MyWindow {

			get {
				return window;
			}
		}

		public WindowItem(Window w, string icon)
		{
			this.icon = icon;
			this.window = w;
		}

		public uint Timestamp {

			get {
				return (uint)(DateTime.Now.ToUniversalTime () - new DateTime (1970, 1, 1)).TotalSeconds;
			}
		}
	}
}