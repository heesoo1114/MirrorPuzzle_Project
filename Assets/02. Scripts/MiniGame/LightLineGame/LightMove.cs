using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMove : MonoBehaviour
{
    // 여러개를 배치하고 돌리기만 가능하게?

    private bool isMove = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            isMove = true;
        if (isMove == false) return;
        transform.Translate(transform.right * 5f * Time.deltaTime);
    }

}
