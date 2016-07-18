using System.Linq;
using GuildedRose.Console;
using Xunit;

namespace GuildedRose.Tests.Unit
{
    public class ConjuredItemTests
    {
        [Fact]
        public void AConjuredRegularItemDegradesTwiceAsFast()
        {
            var conjuredItem = new Item {Name = "Conjured Item", Quality = 30, SellIn = 5};
            var updated = UpdateQuality(conjuredItem);

            Assert.Equal(4, updated.SellIn);
            Assert.Equal(28, updated.Quality);
        }

        [Fact]
        public void AConjuredItemPastSellInDegradesFourTimesAsFast()
        {
            var conjuredItem = new Item { Name = "Conjured Item", Quality = 24, SellIn = 0 };
            var updated = UpdateQuality(conjuredItem);

            Assert.Equal(20, updated.Quality);
        }

        private Item UpdateQuality(Item item)
        {
            var app = new Program {Items = new[] {item}};
            app.UpdateQuality();
            return app.Items.Single();
        }
    }
}