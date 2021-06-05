using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        private const int MIN_QUALITY = 0;
        private const int MAX_QUALITY = 50;

        [Fact]
        public void TestOnGeneralItem()
        {
            // 아이템의 퀄리티는 0 이상이고 아이템의 퀄리티는 하루가 지날 때마다 1씩 줄어듭니다.
            // 유통 기한(sellin)이 지난 아이템의 퀄리티는 2배의 속도로 떨어집니다
            // 퀄리티는 최대값이 50입니다.

            string name = "General";
            int quality = MAX_QUALITY;
            int sellIn = 10;
            IList<Item> items = new List<Item>{ 
                new Item(name, sellIn, quality)
            };
            var app = new Console.GildedRose(items);

            int expectedQuality = quality;
            int expectedSellIn = sellIn;
            int days = MAX_QUALITY;
            for (int i = 0; i < days; ++i)
            {                
                Assert.Equal(name, app.items[0].name);
                Assert.Equal(expectedSellIn, app.items[0].sellIn);
                Assert.Equal(expectedQuality, app.items[0].quality);

                // 하루가 지나고
                app.UpdateQuality();

                // 기대값
                --expectedSellIn;
                expectedQuality -= (0 > expectedSellIn) ? 2 : 1;
                expectedQuality = (expectedQuality < MIN_QUALITY) ? MIN_QUALITY : expectedQuality;
            }
        }

        [Fact]
        public void TestOnAgedBrie()
        {
            // 기본 룰 + 예외적용
            // 하루가 지날 때마다 퀄리티가 1씩 증가합니다
            // 유통기한이 지나면 퀄리티가 2씩 증가합니다

            string name = "Aged Brie";
            int quality = MIN_QUALITY;
            int sellIn = 10;
            Item[] items = new Item[] { new Item(name, sellIn, quality) };
            var app = new Console.GildedRose(items);

            int expectedQuality = quality;
            int expectedSellIn = sellIn;
            int days = MAX_QUALITY;
            for (int i = 0; i < days; ++i)
            {
                Assert.Equal(name, app.items[0].name);
                Assert.Equal(expectedSellIn, app.items[0].sellIn);
                Assert.Equal(expectedQuality, app.items[0].quality);

                // 하루가 지나고
                app.UpdateQuality();

                // 기대값
                --expectedSellIn;
                expectedQuality += (0 > expectedSellIn) ? 2 : 1;
                expectedQuality = (expectedQuality > MAX_QUALITY) ? MAX_QUALITY : expectedQuality;
            }
        }

        [Fact]
        public void TestOnBackstage()
        {
            // 기본 룰 + 예외적용
            // 유통기한(콘서트일)이 다가올수록 퀄리티가 증가합니다.
            // 유통기한이
            // 11일 이상일 때는 1,
            // 10일 이하일 때는 2,
            // 5일 이하일 때는 3씩 증가하지만
            // 콘서트 날이 지나면 퀄리티는 0이 됩니다.

            string name = "Backstage passes to a TAFKAL80ETC concert";
            int quality = MIN_QUALITY;
            int sellIn = 20;
            Item[] items = new Item[] { new Item(name, sellIn, quality) };
            var app = new Console.GildedRose(items);

            int expectedQuality = quality;
            int expectedSellIn = sellIn;
            int days = MAX_QUALITY;
            for (int i = 0; i < days; ++i)
            {                
                Assert.Equal(name, app.items[0].name);
                Assert.Equal(expectedSellIn, app.items[0].sellIn);
                Assert.Equal(expectedQuality, app.items[0].quality);

                // 하루가 지나고
                app.UpdateQuality();

                // 기대값                                  
                
                if (expectedSellIn > 10)
                {
                    expectedQuality += 1;
                }
                else if(expectedSellIn > 5)
                {
                    expectedQuality += 2;
                }
                else if(expectedSellIn > 0)
                {
                    expectedQuality += 3;
                } 
                else
                {
                    expectedQuality = 0;
                }

                --expectedSellIn;
            }
        }

        [Fact]
    public void TestOnSulfuras()
        {
            // 기본 룰 + 예외적용
            // 퀄리티는 변화가 없습니다.

            string name = "Sulfuras, Hand of Ragnaros";
            int quality = MAX_QUALITY;
            int sellIn = 10;
            Item[] items = new Item[] { new Item(name, sellIn, quality) };
            var app = new Console.GildedRose(items);
                        
            int expectedQuality = quality;
            int expectedSellIn = sellIn;
            int days = MAX_QUALITY;
            for (int i = 0; i < days; ++i)
            {
                Assert.Equal(name, app.items[0].name);
                Assert.Equal(expectedSellIn, app.items[0].sellIn);
                Assert.Equal(expectedQuality, app.items[0].quality);

                // 하루가 지나고
                app.UpdateQuality();

                // 기대값 변화 없음                
            }
        }
    }
}