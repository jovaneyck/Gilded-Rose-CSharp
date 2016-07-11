using System;
using System.Collections.Generic;

namespace GuildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;
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

        private static void Update(Item item)
        {
            ItemRules rules;

            switch (item.Name)
            {
                case "Aged Brie":
                    rules = new BrieRules();
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    rules = new BackstageRules();
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    rules = new SulfurasRules();
                    break;
                default:
                    rules = new RegularItemRules();
                    break;
            }

            rules.Update(item);
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
