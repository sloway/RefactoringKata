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
            // �������� ����Ƽ�� 0 �̻��̰� �������� ����Ƽ�� �Ϸ簡 ���� ������ 1�� �پ��ϴ�.
            // ���� ����(sellin)�� ���� �������� ����Ƽ�� 2���� �ӵ��� �������ϴ�
            // ����Ƽ�� �ִ밪�� 50�Դϴ�.

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

                // �Ϸ簡 ������
                app.UpdateQuality();

                // ��밪
                --expectedSellIn;
                expectedQuality -= (0 > expectedSellIn) ? 2 : 1;
                expectedQuality = (expectedQuality < MIN_QUALITY) ? MIN_QUALITY : expectedQuality;
            }
        }

        [Fact]
        public void TestOnAgedBrie()
        {
            // �⺻ �� + ��������
            // �Ϸ簡 ���� ������ ����Ƽ�� 1�� �����մϴ�
            // ��������� ������ ����Ƽ�� 2�� �����մϴ�

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

                // �Ϸ簡 ������
                app.UpdateQuality();

                // ��밪
                --expectedSellIn;
                expectedQuality += (0 > expectedSellIn) ? 2 : 1;
                expectedQuality = (expectedQuality > MAX_QUALITY) ? MAX_QUALITY : expectedQuality;
            }
        }

        [Fact]
        public void TestOnBackstage()
        {
            // �⺻ �� + ��������
            // �������(�ܼ�Ʈ��)�� �ٰ��ü��� ����Ƽ�� �����մϴ�.
            // ���������
            // 11�� �̻��� ���� 1,
            // 10�� ������ ���� 2,
            // 5�� ������ ���� 3�� ����������
            // �ܼ�Ʈ ���� ������ ����Ƽ�� 0�� �˴ϴ�.

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

                // �Ϸ簡 ������
                app.UpdateQuality();

                // ��밪                                  
                
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
            // �⺻ �� + ��������
            // ����Ƽ�� ��ȭ�� �����ϴ�.

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

                // �Ϸ簡 ������
                app.UpdateQuality();

                // ��밪 ��ȭ ����                
            }
        }
    }
}