using System;
using System.Collections.Generic;
using System.Linq;
using ApprovalTests;
using ApprovalTests.Reporters;
using GuildedRose.Console;
using Newtonsoft.Json;
using Xunit;

namespace GuildedRose.Tests.GoldenMaster
{
    //[UseReporter(typeof(XUnit2Reporter))]
    [UseReporter(typeof(DiffReporter))]
    public class GoldenMasterTest
    {
        [Fact]
        public void RandomInputKeepsSameResultsAsBefore()
        {
            var items = new[]
            {
                new Item {Name = "_item_name_", Quality = 10, SellIn = 30},
                new Item {Name = "Aged Brie", Quality = 10, SellIn = 30},
                new Item {Name= "Backstage passes to a TAFKAL80ETC concert", Quality = 10, SellIn = 10 },
                new Item {Name= "Backstage passes to a TAFKAL80ETC concert", Quality = 10, SellIn = 5 },
                new Item {Name= "Sulfuras, Hand of Ragnaros", Quality = 10, SellIn = 5 },
                new Item {Name = "Aged Brie", Quality = 10, SellIn = 0},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 3, SellIn = 0},
                new Item {Name = "_an_expired_item_", Quality = 3, SellIn = 0},
                new Item {Name = "Sulfuras, Hand of Ragnaros", Quality = 3, SellIn = 0}

            };

            var app = new Program { Items = items};

            app.UpdateQuality();

            Approvals.VerifyJson(JsonConvert.SerializeObject(app.Items));
        }

        [Fact]
        public void CompletelyRandomGoldenMaster()
        {
            var app = new Program {Items = RandomItems(1000, 1337)};

            app.UpdateQuality();

            Approvals.VerifyJson(JsonConvert.SerializeObject(app.Items));
        }

        private static List<Item> RandomItems(int numberOfItems, int seed)
        {
            var names = 
                new []
                {
                    "_an_item_",
                    "Aged Brie",
                    "Backstage passes to a TAFKAL80ETC concert",
                    "Sulfuras, Hand of Ragnaros"
                };

            var qualities = Enumerable.Range(0, 51).ToList();
            var sellIn = Enumerable.Range(0, 100).ToList();
            
            var random = new Random(seed);

            return 
                Enumerable
                    .Range(1, numberOfItems)
                    .Select(_ => 
                        new Item
                        {
                            Name = GetRandomFrom(names, random),
                            Quality = GetRandomFrom(qualities, random),
                            SellIn = GetRandomFrom(sellIn, random)
                        })
                    .ToList();
        }

        private static T GetRandomFrom<T>(IList<T> source, Random random)
        {
            return source[random.Next(source.Count)];
        }
    }
}