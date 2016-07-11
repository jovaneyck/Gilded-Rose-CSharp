using System;

namespace GuildedRose.Console
{
    public class BackstageRules
    {
        public void Update(Item item)
        {
            item.SellIn--;

            if (item.SellIn < 10)
            {
                item.Quality++;
            }

            if (item.SellIn < 5)
            {
                item.Quality++;
            }

            item.Quality++;

            item.Quality = Math.Min(50, item.Quality);

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }
}