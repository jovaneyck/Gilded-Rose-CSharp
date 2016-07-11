using GuildedRose.Console;
using Ploeh.AutoFixture;
using Xunit;

namespace GuildedRose.Tests.Unit
{
    public class AgedBrieTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void IncreasesQualityWithAge()
        {
            var item =
                _fixture
                    .Build<Item>()
                    .With(i=>i.Name, "Aged Brie")
                    .With(i=>i.Quality, 10)
                    .With(i=>i.SellIn, 10)
                    .Create();

            var updated = Updater.Update(item);

            Assert.Equal(11, updated.Quality);
        } 

        [Fact]
        public void SellInDecreasesEveryDay()
        {
            var item =
                _fixture
                    .Build<Item>()
                    .With(i=>i.Name, "Aged Brie")
                    .With(i=>i.SellIn, 10)
                    .Create();

            var updated = Updater.Update(item);

            Assert.Equal(9, updated.SellIn);
        }

        [Fact]
        public void MaximumQualityIsFifty()
        {
            var item =
                _fixture
                    .Build<Item>()
                    .With(i => i.Name, "Aged Brie")
                    .With(i => i.Quality, 50)
                    .With(i => i.SellIn, 10)
                    .Create();

            var updated = Updater.Update(item);

            Assert.Equal(50, updated.Quality);
        }
    }
}