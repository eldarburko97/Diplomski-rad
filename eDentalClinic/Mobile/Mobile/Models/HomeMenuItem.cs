using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Models
{
    public enum MenuItemType
    {
        Home,
       // Browse,
      //  About,
        YourProfile,
        Forum,
        BookingAppointments,
        MyAppointments,
        Rating,
        LogOut
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
