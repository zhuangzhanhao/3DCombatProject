using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimController : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        EventCenter.Instance.AddEventListener<float>(EventName.CharacterMoveCacheUpdate, UpdateAnimation);
    }

    private void UpdateAnimation(float curSpeed)
    {
        anim.SetFloat("Speed", curSpeed);
    }
}
