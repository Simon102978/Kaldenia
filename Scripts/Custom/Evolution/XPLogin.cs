﻿using System;
using System.Text;
using Server;
using Server.Commands;
using Server.Mobiles;

namespace Server
{
  class Broadcast
  {
    public static void Initialize()
    {
      EventSink.Login += new LoginEventHandler(EventSink_Login);
      EventSink.Logout += new LogoutEventHandler(EventSink_Logout);
    }

    public static void EventSink_Login(LoginEventArgs e)
    {
      if (e.Mobile.Player)
      {
        if (e.Mobile is CustomPlayerMobile cp)
        {
          cp.LastLoginTime = DateTime.Now;
		  cp.LastCountGameTime = DateTime.Now;



		}
      }
    }

    public static void EventSink_Logout(LogoutEventArgs e)
    {
			if (e.Mobile is CustomPlayerMobile cp)
			{

				cp.TotalGameTime += DateTime.Now - cp.LastCountGameTime;
				cp.LastCountGameTime = DateTime.Now;
			}

      /*if (e.Mobile.Player)
      {
        if (e.Mobile is SolsoraPlayerMobile)
        {
          ((SolsoraPlayerMobile)e.Mobile).LastLoginTime = null;
        }
      }*/
    }
  }
}