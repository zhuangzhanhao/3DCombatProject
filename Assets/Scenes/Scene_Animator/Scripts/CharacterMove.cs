using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float speed = 2f;
    public float turnSpeed = 12f;

    private Vector2 input;
    private Vector3 direction;
    private float curSpeed;
    private bool hasInput;


    private void Update()
    {
        UpdateInput();
    }

    private void FixedUpdate()
    {
        if (CharacterAttackCache.Instance.IsAttacking1()) return;
        UpdateRotation();
        UpdatePosition();
    }

    private void UpdateInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        direction = new Vector3(input.x, 0f, input.y);
        if (direction.sqrMagnitude > 1f) direction.Normalize();

        hasInput = direction.sqrMagnitude > 0.0001f;
        if (Input.GetMouseButtonDown(1) && hasInput)
            speed = 6f;
        if (!hasInput) 
            speed = 2f;

        curSpeed = hasInput ? speed : 0f;
        CharacterMoveCache.Instance.SaveToCache(input, direction, curSpeed);

        // 没输入的话,后续逻辑就提前return
        if (!hasInput) return;
    }

    void UpdateRotation()
    {
        if (direction.sqrMagnitude < 0.0001f) return;
        Quaternion targetRot = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnSpeed * Time.fixedDeltaTime);
    }

    private void UpdatePosition()
    {
        transform.position += transform.forward * curSpeed * Time.fixedDeltaTime;
    }

}