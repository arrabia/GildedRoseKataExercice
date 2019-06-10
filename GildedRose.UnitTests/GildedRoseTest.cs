using NUnit.Framework;
using System.Collections.Generic;


namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {

        [Test]
        public void StandardUpdateStrategyTest()
        {
            Item item = new Item { Name = "foo", SellIn = 10, Quality = 20 };

            var result = new StandardUpdateStrategy(1);
            result.UpdateQualityItem(item);
            int startQuality = item.Quality;
            //Act

            //Assert
            Assert.AreEqual(19, startQuality);
        }

        [Test]
        public void AgedBrieUpdateStrategyTest()
        {
            //Arrang
            Item item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 3 };

            var resualt = new AgedBrieUpdateStrategy();
            resualt.UpdateQualityItem(item);
            int startQuality = item.Quality;

            //Assert
            Assert.AreEqual(4, startQuality);
        }


        [Test]
        public void BackstagePassesUpdateStrategyTest()
        {
            //Arrang
            Item item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 6,
                Quality = 20
            };

            var result = new BackstagePassesUpdateStrategy();
            result.UpdateQualityItem(item);
            int startQuality = item.Quality;
          

            //Assert
            Assert.AreEqual(22, startQuality);
        }


        [Test]
        public void DoNothingUpdateTest()
        {
            //Arrang
            Item item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };

            var result = new DoNothingUpdate();
            result.UpdateQualityItem(item);
            int startSellIn = item.SellIn;

            //Assert
            Assert.AreEqual(0, startSellIn);
        }











    }
}
