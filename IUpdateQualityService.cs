using System.Collections.Generic;
using csharp.Interface;

namespace csharp
{
    public class IUpdateQualityService : IUpdateQuality
    {
        IList<Item> Items;
        public IUpdateQualityService(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateQualityItem(item);
            }
        }
        

        public void UpdateQualityItem(Item item)
        {

             if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                new DoNothingUpdate();
            }
            else if (item.Name == "Aged Brie")
            {
                 new AgedBrieUpdateStrategy();
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                 new BackstagePassesUpdateStrategy();
            }
            else if (item.Name.Contains("Conjured"))
            {
                 new StandardUpdateStrategy(2);
            }
            else
            {
                 new StandardUpdateStrategy();
            }

             

    }
    }

    public class StandardUpdateStrategy : IUpdateQuality
    {
        private readonly int _factor;

        public StandardUpdateStrategy(int factor = 1)
        {
            _factor = factor;
        }

        public void UpdateQualityItem(Item item)
        {
            item.SellIn--;
            if (item.Quality > 0)
            {
                item.Quality -= _factor * (item.SellIn < 0 ? 2 : 1);
            }
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }
    }

    public class AgedBrieUpdateStrategy 
        : IUpdateQuality 
    {
        public void UpdateQualityItem(Item item)
        {
            item.SellIn--;
            if (item.Quality < 50)

            {
                item.Quality++;
            }
        }
    }

    public class BackstagePassesUpdateStrategy : IUpdateQuality
    {
        public void UpdateQualityItem(Item item)
        {
            item.SellIn--;
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
            else if (item.SellIn <= 5)
            {
                item.Quality = item.Quality + 3;
            }
            else if (item.SellIn <= 10)
            {
                item.Quality = item.Quality + 2;
            }
            else if (item.Quality < 50)
            {
                item.Quality++;
            }
        }
    }

    public class DoNothingUpdate : IUpdateQuality
    {
        public void UpdateQualityItem(Item item) { }
    }


}
