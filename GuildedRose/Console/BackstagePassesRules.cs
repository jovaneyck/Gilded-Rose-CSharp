﻿namespace GuildedRose.Console
{
    internal class BackstagePassesRules : Rules
    {
        public void Update(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;

                if (item.SellIn < 11 && item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }

                if (item.SellIn < 6 && item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }
}