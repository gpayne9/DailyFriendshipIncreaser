using StardewValley;
using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewModdingAPI.Events;

namespace MyFirstMod
{
    public class MyfirstMod : Mod
    {
        public override string Name
        {
            get
            { return "MyFirstMod"; }
        }

        public override string Authour
        {
            get
            { return "Guy Payne"; }
        }
        public override string Version
        {
            get
            { return "0.1"; }
        }
        public override string Description
        {
            get
            { return "Not sure yet"; }
        }
        public override void Entry(params object[] objects)
        {
            TimeEvents.DayOfMonthChanged += Event_ChangedDayOfMonth;
        }
        static void Event_ChangedDayOfMonth(object sender, EventArgs e)
        {
                

        }
    }
}
