using GuildedRose.Console;
using Ploeh.AutoFixture;
using Xunit;

namespace GuildedRose.Tests.Unit
{
    public class SulfurasTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void NeverDecreasesInQuality()
        {
            var item =
                _fixture.Build<Item>()
                    .With(i => i.Name, "Sulfuras, Hand of Ragnaros")
                    .With(i => i.Quality, 80)
                    .Create();

            Assert.Equal(80, Updater.Update(item).Quality);
        }
        [Fact]
        public void NeverExpires()
        {
            var item =
                _fixture.Build<Item>()
                    .With(i => i.Name, "Sulfuras, Hand of Ragnaros")
                    .With(i => i.SellIn, 30)
                    .Create();
            Assert.Equal(30, Updater.Update(item).SellIn);
        }
    }
}