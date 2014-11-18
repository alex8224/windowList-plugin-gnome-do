// 
//  Utils.cs
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
using Wnck;

namespace WindowList
{
	public class Utils
	{
		public static uint GetTimeStamp() {
			return (uint)(DateTime.Now.ToUniversalTime () - new DateTime (1970, 1, 1)).TotalSeconds;
		}

		public static Window[] GetWindows() {
			Screen.Default.ForceUpdate();
			return Screen.Default.Windows;
		}

		public static void CloseWindow(Window window) {
			window.Close(GetTimeStamp());
		}

		public static void CloseCurrentWindow() {
		
			CloseWindow (GetCurrentWindow ());
		}

		public static void ActiveWindow(Window window) {
			window.Activate(GetTimeStamp());
		}

		public static Window GetCurrentWindow() {
			//Screen.Default.ForceUpdate();
			Window currenWindow = Screen.Default.ActiveWindow;
			Console.WriteLine ("active window is " + currenWindow.Name);
			return currenWindow;
		}
	}
}