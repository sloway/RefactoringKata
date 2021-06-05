using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class Item
    {
        public String name;

        public int sellIn;

        public int quality;

        public Item(String name, int sellIn, int quality)
        {
            this.name = name;
            this.sellIn = sellIn;
            this.quality = quality;
        }

        public override String ToString()
        {
            return $"{name}, {sellIn}, {quality}";
        }
    }
}
