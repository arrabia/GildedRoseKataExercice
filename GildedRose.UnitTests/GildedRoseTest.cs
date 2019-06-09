using NUnit.Framework;
using System.Collections.Generic;


namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {

        [Test]
        public void ReduceQualityItem()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 20 } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            int startQuality = items[0].Quality;
            //Act


            //Assert
            items[0].Quality.Equals(2);
            Assert.AreEqual(19, startQuality);
        }

        [Test]
        public void ReduceSellInItem()
        {
            //Arrang
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 20 } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            int startSellIn = items[0].SellIn;
            //Act


            //Assert
            Assert.AreEqual(9, startSellIn);

        }

        [Test]
        public void ReduceQualituByTwoWhendateHasPassed()
        {
            //Arrang
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 20 } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            int startQuality = items[0].Quality;


            //Assert
            Assert.AreEqual(18, startQuality);
        }

        [Test]
        public void NotReduceQualityBelowZero()
        {
            //Arrang
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 12, Quality = 0 } };

            GildedRose app = new GildedRose(items);
            int startQuality = items[0].Quality;
            //Act
            app.UpdateQuality();

            //Assert
            Assert.AreEqual(0, startQuality);

        }

        [Test]
        public void IncreasesAgedBrieQuality()
        {
            //Arrang
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 3 } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            int startQuality = items[0].Quality;

            //Assert
            Assert.AreEqual(4, startQuality);
        }

        [Test]
        public void ItemQualityNeverMoreThan50()
        {
            //Arrang
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 12, Quality = 50 } };

            GildedRose app = new GildedRose(items);
            int startQuality = items[0].Quality;
            //Act
            app.UpdateQuality();

            //Assert
            Assert.AreEqual(50, startQuality);

        }

        [Test]
        public void NoChangeQualityOfSulfuras()
        {
            //Arrang
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            int startQuality = items[0].Quality;

            //Assert
            Assert.AreEqual(80, startQuality);
        }


        [Test]
        public void NoChangeSellInOfSulfuras()
        {
            //Arrang
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            int startSellIn = items[0].SellIn;

            //Assert
            Assert.AreEqual(0, startSellIn);
        }


        [Test]
        public void QualityOfBackstageincreasesByOneLess11()
        {
            //Arrang
            IList<Item> items = new List<Item> { new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 11,
                    Quality = 20
                } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            int startQuality = items[0].Quality;

            //Assert
            Assert.AreEqual(21, startQuality);
        }

        [Test]
        public void QualityOfBackstageincreasesByOneLess6()
        {
            //Arrang
            IList<Item> items = new List<Item> { new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 6,
                    Quality = 20
                } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            int startQuality = items[0].Quality;

            //Assert
            Assert.AreEqual(22, startQuality);
        }

        [Test]
        public void SetQualityOfBackstagToZeroWhenSillinHazZero()
        {
            //Arrang
            IList<Item> items = new List<Item> { new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 0,
                    Quality = 20
                } };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            int startQuality = items[0].Quality;

            //Assert
            Assert.AreEqual(0, startQuality);
        }


    }
}
