using StardewValley;
using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewModdingAPI.Events;
using Microsoft.Xna.Framework.Input;

namespace DailyFriendshipIncreaser
{ 
    public class DailyFriendshipIncreaser : Mod
    {
        public static Game1 TheGame => Program.gamePtr;
        public static Farmer Player => Game1.player;
        public static SocialConfig ModConfig { get; private set; }

        public override void Entry(params object[] objects)
        {
            ModConfig = new SocialConfig();
            ModConfig = ModConfig.InitializeConfig(BaseConfigPath);
            TimeEvents.DayOfMonthChanged += Event_ChangedDayOfMonth;
        }
        static void Event_ChangedDayOfMonth(object sender, EventArgs e)
        {
            //((Farmer)Game1.player).changeFriendship(change, Game1.getCharacterFromName(name));
            if (!ModConfig.decay)
            {
                string[] friends = Player.friendships.Keys.ToArray<string>();
                for (int i = 0; i < friends.Length; i++)
                {
                    if (Player.spouse != null && friends[i].Equals(Player.spouse))
                    {
                        Player.friendships[friends[i]][0] += ModConfig.baseIncrease + 20;
                    }
                    if (Player.friendships[friends[i]][0] < 2500 && !Player.hasTalkedToFriendToday(friends[i]))
                    {
                        Player.friendships[friends[i]][0] += ModConfig.baseIncrease;
                    }
                    if (Player.friendships[friends[i]][0] < 2500 && Player.hasTalkedToFriendToday(friends[i]))
                    {
                        Player.friendships[friends[i]][0] += ModConfig.talkIncrease;
                    }
                }
            }
        }
    }
    public class SocialConfig : Config
    {
        //public bool RegenStamina { get; set; }
        public bool decay { get; set; }
        public int baseIncrease { get; set; }
        public int talkIncrease { get; set; }
        public override T GenerateDefaultConfig<T>()
        {
            decay = false;
            baseIncrease = 10;
            talkIncrease = 50;
            return this as T;
        }
    }
}
