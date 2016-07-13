namespace GuildedRose.Console
{
    internal class ConjuredRules : ItemRules
    {
        public void Update(Item item)
        {
            item.SellIn--;
            item.Quality -= 2;
        }
    }
}