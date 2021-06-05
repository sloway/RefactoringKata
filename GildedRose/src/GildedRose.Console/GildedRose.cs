using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class GildedRose
    {
        public IList<Item> items;

        public GildedRose(IList<Item> items)
        {
            this.items = items;
        }

        public void UpdateQuality()
        {            
            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].name != "Aged Brie" && items[i].name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (items[i].quality > 0)
                    {
                        if (items[i].name != "Sulfuras, Hand of Ragnaros")
                        {
                            items[i].quality = items[i].quality - 1;
                        }
                    }
                }
                else
                {
                    if (items[i].quality < 50)
                    {
                        items[i].quality = items[i].quality + 1;

                        if (items[i].name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (items[i].sellIn < 11)
                            {
                                if (items[i].quality < 50)
                                {
                                    items[i].quality = items[i].quality + 1;
                                }
                            }

                            if (items[i].sellIn < 6)
                            {
                                if (items[i].quality < 50)
                                {
                                    items[i].quality = items[i].quality + 1;
                                }
                            }
                        }
                    }
                }

                if (items[i].name != "Sulfuras, Hand of Ragnaros")
                {
                    items[i].sellIn = items[i].sellIn - 1;
                }

                if (items[i].sellIn < 0)
                {
                    if (items[i].name != "Aged Brie")
                    {
                        if (items[i].name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (items[i].quality > 0)
                            {
                                if (items[i].name != "Sulfuras, Hand of Ragnaros")
                                {
                                    items[i].quality = items[i].quality - 1;
                                }
                            }
                        }
                        else
                        {
                            items[i].quality = items[i].quality - items[i].quality;
                        }
                    }
                    else
                    {
                        if (items[i].quality < 50)
                        {
                            items[i].quality = items[i].quality + 1;
                        }
                    }
                }
            }
        }


    }
}
