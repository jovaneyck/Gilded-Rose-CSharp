using GuildedRose.Console;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Dsl;
using Xunit;

namespace GuildedRose.Tests.Unit
{
    public class RegularItemTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void WhenSellInNotPassed_DegradesQualityByOne()
        {
            var updated = 
                Updater.Update(
                    AnItem()
                        .With(i=>i.Name, "_normal_item_")
                        .With(i=>i.Quality, 10)
                        .With(i=>i.SellIn, 5)
                        .Create());

            Assert.Equal(9, updated.Quality);
        }

        private ICustomizationComposer<Item> AnItem()
        {
            return _fixture.Build<Item>();
        }

        [Fact]
        public void SellInDecreases()
        {
            var updated = Updater.Update(AnItem().With(i => i.SellIn, 10).Create());

            Assert.Equal(9, updated.SellIn);
        }

        [Fact]
        public void WhenPastSellDate_QualityDecreasesAtDoubleSpeed()
        {
            var updated = Updater.Update(AnItem().With(i => i.Quality, 10).With(i => i.SellIn, 0).Create());
            Assert.Equal(8, updated.Quality);
        }

        [Fact]
        public void QualityDoesNotGoPastZero()
        {
            var updated = Updater.Update(AnItem().With(i => i.Quality, 0).With(i=>i.SellIn, 10).Create());
            Assert.Equal(0, updated.Quality);
        }
    }
}