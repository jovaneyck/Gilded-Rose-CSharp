﻿namespace GuildedRose.Console
{
    public class BrieRules : ItemRules
    {
        public void Update(Item item)
        {
            item.SellIn--;

            if (item.Quality < 50)
            {
                item.Quality++;
            }
            if (item.SellIn < 0)
            {
                item.Quality++;
            }
        }
    }
}