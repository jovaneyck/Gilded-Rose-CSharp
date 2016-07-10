using System;
using ApprovalTests;
using ApprovalTests.Reporters;
using GuildedRose.Console;
using Newtonsoft.Json;
using Xunit;

namespace GuildedRose.Tests.GoldenMaster
{
    [UseReporter(typeof(XUnit2Reporter))]
    //[UseReporter(typeof(DiffReporter))]
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
    }
}