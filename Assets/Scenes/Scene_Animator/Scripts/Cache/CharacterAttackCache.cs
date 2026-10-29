using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackCache : SingleInstance<CharacterAttackCache>
{
    private bool isAttacking1;

    public void SaveToCache(bool isAttacking1)
    {
        this.isAttacking1 = isAttacking1;
        EventCenter.Instance.EventTrigger<bool>(EventName.CharacterAttackCacheUpdate, this.isAttacking1);
    }
    public bool IsAttacking1()
    {
        return this.isAttacking1;
    }
}
