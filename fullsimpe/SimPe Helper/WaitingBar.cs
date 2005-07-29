/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace SimPe
{
	/// <summary>
	/// This calass can be used to interface the StatusBar of the Main GUI, which will display 
	/// something like the WaitingScreen
	/// </summary>
	public class Wait
	{
		static IWaitingBarControl bar;
		static Stack mystack = new Stack();

		public static IWaitingBarControl Bar
		{
			set { bar = value; }
		}

		public static bool Running
		{
			get { 
				if (bar!=null) return bar.Running;
				return false;
			}
		}

		public static string Message
		{
			get 
			{ 
				if (bar!=null) return bar.Message; 
				return "";
			} 
			set 
			{
				if (bar!=null) bar.Message = value;
				
			}
		}

		public static Image Image
		{
			get 
			{ 
				if (bar!=null) return bar.Image; 
				return null;
			} 
			set 
			{
				if (bar!=null) bar.Image = value;
				
			}
		}

		public static int Progress
		{
			get 
			{ 
				if (bar!=null) return bar.Progress; 
				return MaxProgress;
			} 
			set 
			{
				if (bar!=null) bar.Progress = value;				
			}
		}

		public static int MaxProgress
		{
			get 
			{ 
				if (bar!=null) return bar.MaxProgress; 
				return 1;
			} 	
			set 
			{
				if (bar!=null) bar.MaxProgress = value;		
			}
		}

		static int running = 0;
		static void CommonStart()
		{
			running = Math.Max(running, 1);
		}
		public static void Start()
		{
			if (bar!=null) 
			{
				bar.Wait();
				CommonStart();
			}
		}		

		public static void Start(int max)
		{
			if (bar!=null) 
			{
				bar.Wait(max);
				CommonStart();
			}
		}

		public static void Stop()
		{
			if (bar!=null) 
			{
				bar.Stop();
				mystack.Clear();
				running = 0;
			}
		}

		static void SubStartCommon()
		{
			running++;
			mystack.Push(Progress);
			mystack.Push(MaxProgress);
			mystack.Push(Message);
		}
		public static void SubStart()
		{			
			SubStartCommon();
			Start();
		}

		public static void SubStart(int max)
		{
			SubStartCommon();
			Start(max);
		}

		public static void SubStop()
		{
			if (running>0) running--;			
			try 
			{
				if (mystack.Count>0) Message = (string)mystack.Pop();
				if (mystack.Count>0) MaxProgress = (int)mystack.Pop();
				if (mystack.Count>0) Progress = (int)mystack.Pop();
			} 
			catch (Exception ex)
			{
				if (Helper.DebugMode) Helper.ExceptionMessage(ex);
			}
			
			if (running==0) Stop();
		}
	}
}