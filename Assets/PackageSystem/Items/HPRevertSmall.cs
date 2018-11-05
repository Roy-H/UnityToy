using OneGame.Package;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HPRevertSmall : Item
{
    private const string sIds = "";
    
    public override string Ids
    {
        get
        {
            return mIds;
        }

        set
        {
            mIds = value;
        }
    }

    public HPRevertSmall():base(sIds)
    {
       
    }
    public override string Name { get { return mName; } set { mName = value; } }

    public override bool ConsumeFromPackage(Package package)
    {
        //return base.ConsumeFromPackage(package);
        throw new NotImplementedException();
    }

    public override bool Add2Package(Package package)
    {
        throw new NotImplementedException();
    }

    public override bool RemoveFromPackage(Package package)
    {
        throw new NotImplementedException();

    }
}
