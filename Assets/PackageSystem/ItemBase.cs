using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace OneGame.Package
{
    public abstract class ItemBase
    {
        public abstract string Ids { get; set; }
        public abstract string Name { get; set; }
    }

    public class Item : ItemBase
    {
        protected string mIds;

        protected string mName;

        public override string Ids
        {
            get{return mIds;}
            set{mIds = value;}
        }

        public override string Name { get { return mName; } set { mName = value; } }

        public Item(string ids)
        {
            mIds = ids;
        }

        public virtual bool Add2Package(Package package)
        {
            throw new NotImplementedException("Add2Package function has not been implemented, you should overide it in inherited class!");
        }

        public virtual bool RemoveFromPackage(Package package)
        {
            throw new NotImplementedException("Add2Package function has not been implemented, you should overide it in inherited class!");
        }

        public virtual bool ConsumeFromPackage(Package package)
        {
            throw new NotImplementedException("Add2Package function has not been implemented, you should overide it in inherited class!");
        }
    }
}

