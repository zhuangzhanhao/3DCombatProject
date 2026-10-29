using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimController : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        EventCenter.Instance.AddEventListener<float>(EventName.CharacterMoveCacheUpdate, UpdateMoveAnimation);
        EventCenter.Instance.AddEventListener<bool>(EventName.CharacterAttackCacheUpdate, UpdateAttackAnimation);
    }

    private void UpdateMoveAnimation(float curSpeed)
    {
        anim.SetFloat("Speed", curSpeed);
    }

    private void UpdateAttackAnimation(bool isAttack1)
    {
        anim.SetBool("IsAttack1", isAttack1);
    }
}
