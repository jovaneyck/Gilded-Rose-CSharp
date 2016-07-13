using System.Collections.Generic;

namespace GuildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;

        private readonly Dictionary<string, ItemRules> _specificRulesForItemNamed = 
            new Dictionary<string, ItemRules>
            {
                { "Aged Brie", new BrieRules()},
                { "Backstage passes to a TAFKAL80ETC concert", new BackstageRules() },
                { "Sulfuras, Hand of Ragnaros", new SulfurasRules()},
                { "Conjured Item", new ConjuredRules() }
            };

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                            Items = 
                                new List<Item>
                                {
                                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                    new Item
                                        {
                                            Name = "Backstage passes to a TAFKAL80ETC concert",
                                            SellIn = 15,
                                            Quality = 20
                                        },
                                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                }
                          };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                Update(item);
            }
        }

        private void Update(Item item)
        {
            var rules = FindRules(item);
            rules.Update(item);
        }

        private ItemRules FindRules(Item item)
        {
            if (!_specificRulesForItemNamed.ContainsKey(item.Name))
            {
                return new DefaultItemRules();
            }

            return _specificRulesForItemNamed[item.Name];
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
