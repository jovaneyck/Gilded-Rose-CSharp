namespace GuildedRose.Console
{
    public class RegularItemRules : ItemRules
    {
        public void Update(Item item)
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