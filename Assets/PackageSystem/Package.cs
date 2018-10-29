using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace OneGame.Package
{
    [Serializable]
    public class Package
    {
        private const int MaxCellCount = 99;
        private const int MaxAbilityForEachCategory = 50;
        List<ItemCell> AllItems = new List<ItemCell>();

        public List<ItemCell> OneTimeUseItems { get; set; }
        public List<ItemCell> Ingredients { get; set; }
        public List<ItemCell> Skills { get; set; }

        public void Add(Item itemToAdd,int count)
        {
            var result = AllItems.FindAll((i) => { return i.sItem.Ids == itemToAdd.Ids && i.sCount < 99; });
            if (result != null && result.Count > 0)
            {
                if (result[0].sCount + count > MaxCellCount)
                {
                    result[0].sCount = MaxCellCount;
                    AllItems.Add(new ItemCell() { sCount = result[0].sCount + count - MaxCellCount, sItem = itemToAdd, sType = result[0].sType });
                }
                else if (result[0].sCount + count == MaxCellCount)
                {
                    result[0].sCount = MaxCellCount;
                }
                else
                {
                    result[0].sCount += count;
                }
            }
        }

        public bool IfHas(string ids,int count)
        {
            
            var results = AllItems.FindAll((i) => { return i.sItem.Ids == ids; });

            int allCount = 0;

            //add all item in all
            foreach (var item in results)
            {
                allCount += item.sCount;
            }

            return allCount >= count ? false : true;

        }
    }

    public class ItemCell
    {
        public Item sItem { get; set; }
        public int sCount { get; set; }
        public PackageCategory sType { get; set; }
    }

    public enum PackageCategory
    {
        None,
        OneTimeUseItem,
        Ingredients,
        Skills,
    }
}

