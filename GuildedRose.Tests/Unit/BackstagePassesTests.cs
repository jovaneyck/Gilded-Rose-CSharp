using GuildedRose.Console;
using Ploeh.AutoFixture;
using Xunit;

namespace GuildedRose.Tests.Unit
{
    public class BackstagePassesTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void QualityIncreasesWhenConcertIsAWayOff()
        {
            var item = 
                _fixture
                    .Build<Item>()
                    .With(i => i.Name, "Backstage passes to a TAFKAL80ETC concert")
                    .With(i => i.Quality, 20)
                    .With(i => i.SellIn, 30)
                    .Create();

            Assert.Equal(21, Updater.Update(item).Quality);
        }

        [Fact]
        public void QualityIncreasesDoubleWhenConcertInTenDays()
        {
            var item = 
                _fixture
                    .Build<Item>()
                    .With(i => i.Name, "Backstage passes to a TAFKAL80ETC concert")
                    .With(i => i.Quality, 20)
                    .With(i => i.SellIn, 10)
                    .Create();

            Assert.Equal(22, Updater.Update(item).Quality);
        }

        [Fact]
        public void QualityIncreasesThreefoldWhenConcertInFiveDays()
        {
            var item = 
                _fixture
                    .Build<Item>()
                    .With(i => i.Name, "Backstage passes to a TAFKAL80ETC concert")
                    .With(i => i.Quality, 20)
                    .With(i => i.SellIn, 5)
                    .Create();

            Assert.Equal(23, Updater.Update(item).Quality);
        }

        [Fact]
        public void QualityDropsToZeroWhenConcertIsOver()
        {
            var item = 
                _fixture
                    .Build<Item>()
                    .With(i => i.Name, "Backstage passes to a TAFKAL80ETC concert")
                    .With(i => i.Quality, 20)
                    .With(i => i.SellIn, 0)
                    .Create();

            Assert.Equal(0, Updater.Update(item).Quality);
        }
    }
}