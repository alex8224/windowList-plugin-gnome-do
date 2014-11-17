// 
//  WindowList.cs
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
using Do.Universe;
using Do.Platform;
using Wnck;

namespace WindowList
{
	public class WindowItemSource:DynamicItemSource
	{

		private Dictionary<Window, WindowItem> windowlist = new Dictionary<Window, WindowItem> ();	
		private void WinOpenedMethod(object win, WindowOpenedArgs args) {
			if(!this.Connected) return;
			Window window = args.Window;
			if (!windowlist.ContainsKey(window)) {
				String iconpath = String.Format ("/tmp/{0}.png", window.Application.Pid);
				window.Icon.Save (iconpath, "png");
				WindowItem item = new WindowItem (window, iconpath);
				windowlist [window] = item;

				RaiseItemsAvailable (new ItemsAvailableEventArgs () { newItems = new WindowItem[]{item} });
				Log.Debug ("add window", window.Name);
			} else {
				Log.Debug ("this window {0} already existed", window.Name);
			}
		}

		private void WinClosedMethod(object win, WindowClosedArgs args) {
			if(!this.Connected) return;
			Window window = args.Window;

			if (windowlist.ContainsKey(window)) {
				RaiseItemsUnavailable (new ItemsUnavailableEventArgs (){ unavailableItems = new WindowItem[]{windowlist[window]}});
				windowlist.Remove (window);
				Log.Debug (window.Name + " closed!");
			}
		}

		public WindowItemSource() {

			WindowOpenedHandler openedhandler = WinOpenedMethod;
			WindowClosedHandler closehandler = WinClosedMethod;

			Screen.Default.WindowOpened += openedhandler;

			Screen.Default.WindowClosed += closehandler;
		}

		public override string Name {
			get {
				return "窗口项目";
			}
		}

		public override string Description {
			get {
			
				return "激活某个窗口";
			}
		}

		public override string Icon {
			get {
				return "gnome-windows";
			}
		}

		public override IEnumerable<Type> SupportedItemTypes {
			get {
				yield return typeof(WindowItem);
			}
		}

		protected override void Enable ()
		{
			ItemsAvailableEventArgs eventArgs = new ItemsAvailableEventArgs ();

			lock(windowlist) {
				Screen.Default.ForceUpdate ();
				foreach (Window win in Screen.Default.WindowsStacked) {
					Log.Debug ("title is {0}, pid is {1}, processname is {2}", win.Name, win.Application.Pid, win.Application.Name);
					String iconpath = String.Format ("/tmp/{0}.png", win.Application.Pid);
					win.Icon.Save (iconpath, "png");
					WindowItem item = new WindowItem (win, iconpath);
					windowlist [win] = item;				
				}
				eventArgs.newItems = windowlist.Values;
			}

			RaiseItemsAvailable (eventArgs);
		}

		protected override void Disable ()
		{
			lock (windowlist) {
				windowlist.Clear ();
			}
		}
	}
}
