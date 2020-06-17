using System;
using System.Collections.Generic;
using System.Text;

namespace xamarinFormsExamenOpdrachtJune12.Models
{
    public enum MenuItemType
    {
        TodoLists,
        Browse,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
