using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    private bool isAttacking1 = false;
    void Update()
    {
        UpdateInput();
    }
    private void UpdateInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isAttacking1 = true;
        }
        CharacterAttackCache.Instance.SaveToCache(isAttacking1);
    }
    private void IsAttack1Over()
    {
        isAttacking1 = false;
        CharacterAttackCache.Instance.SaveToCache(isAttacking1);
    }
}
