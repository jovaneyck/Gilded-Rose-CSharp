namespace GuildedRose.Console
{
    public class RegularItemRules
    {
        public void Item(Item item)
        {
            item.SellIn--;

            if (item.Quality > 0)
            {
                item.Quality--;
            }
            if (item.SellIn < 0)
            {
                item.Quality--;
            }
        }
    }
}