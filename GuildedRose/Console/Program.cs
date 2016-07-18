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
                              Items = new List<Item>
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
            switch (item.Name)
            {
                case "Aged Brie":
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (item.SellIn < 11 && item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }

                        if (item.SellIn < 6 && item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    break;
                default:
                    if (item.Quality > 0)
                    {
                        item.Quality = item.Quality - 1;
                    }
                    break;
            }

            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    item.Quality = 0;
                }
                else if (item.Name != "Aged Brie" && item.Quality > 0 && item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.Quality = item.Quality - 1;
                }
                else if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
