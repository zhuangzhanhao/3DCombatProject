using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks.Internal;
using Cysharp.Threading.Tasks;

public class TestMain : MonoBehaviour
{
    async UniTaskVoid Start()
    {
        bool result = await MyCoroutine();
        Debug.Log("穿插的打印");
        if (result == true)
        {
            Debug.Log("结果");
        }
    }

    async UniTask<bool> MyCoroutine()
    {
        for(int i = 0; i < 3; i++)
        {
            Debug.Log("倒计时:" + i);
            await UniTask.Delay(1000);
        }
        Debug.Log("倒计时结束");
        return true;
    }
}
