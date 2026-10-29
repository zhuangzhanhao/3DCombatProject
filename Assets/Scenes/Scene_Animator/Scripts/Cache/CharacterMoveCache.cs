using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveCache : SingleInstance<CharacterMoveCache>
{
    private Vector2 inputCache;
    private Vector3 directionCache;
    private float curSpeedCache;

    public void SaveToCache(Vector2 input, Vector3 direction, float curSpeed)
    {
        inputCache = input;
        directionCache = direction;
        curSpeedCache = curSpeed;
        EventCenter.Instance.EventTrigger<float>(EventName.CharacterMoveCacheUpdate, curSpeedCache);
    }

    public float GetCurSpeed()
    {
        return curSpeedCache;
    }
}

public static class EventName
{
    public const string CharacterMoveCacheUpdate = "CharacterMoveCacheUpdate";
}

