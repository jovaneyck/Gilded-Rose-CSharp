using System.Linq;
using GuildedRose.Console;
using Xunit;

namespace GuildedRose.Tests.Unit
{
    public class ConjuredItemTests
    {
        //[Fact]//Let's refactor the codebase a bit first
        public void AConjuredRegularItemDegradesTwiceAsFast()
        {
            var conjuredItem = new Item {Name = "Conjured _regular_item_", Quality = 30, SellIn = 5};
            var updated = UpdateQuality(conjuredItem);

            Assert.Equal(4, updated.SellIn);
            Assert.Equal(28, updated.Quality);
        }

        private Item UpdateQuality(Item item)
        {
            var app = new Program {Items = new[] {item}};
            app.UpdateQuality();
            return app.Items.Single();
        }
    }
}