using System.Linq;
using GuildedRose.Console;

namespace GuildedRose.Tests.Unit
{
    public class Updater
    {
        public static Item Update(Item item)
        {
            var app = new Program { Items = new[] { item } };
            app.UpdateQuality();
            return app.Items.Single();
        }
    }
}