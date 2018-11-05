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

        public string Add(Item itemToAdd,int count)
        {
            var result = AllItems.FindAll((i) => { return i.sItem.Ids == itemToAdd.Ids; });
            if (result != null && result.Count > 0)
            {
                result[0].sCount += count;
            }
            return ReturnCode.OK;
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

        public string Consume(Item item,int count)
        {
            if (IfHas(item.Ids, count))
            {
                if (!item.ConsumeFromPackage(this))
                {
                    return ReturnCode.Error;
                }
                var itemCell = AllItems.Find((i) => { return i.sItem.Ids == item.Ids; });

                itemCell.sCount -= count;
                
                return ReturnCode.OK;
            }

            Debug.Log("doesn't has enough items to consume");
            return ReturnCode.DoesntHaveEnoughItems;
        }

        private int CountItem(string itemIds)
        {
            var itemCells = AllItems.FindAll((i) => { return i.sItem.Ids == itemIds; });
            int count = 0;
            for (int i = 0; i < itemCells.Count; i++)
            {
                count += itemCells[i].sCount;
            }
            return count;
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