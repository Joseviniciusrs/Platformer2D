using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : CollectableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins();

    }
}
