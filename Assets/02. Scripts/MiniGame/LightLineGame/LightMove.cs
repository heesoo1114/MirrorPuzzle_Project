using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMove : MonoBehaviour
{
    // �������� ��ġ�ϰ� �����⸸ �����ϰ�?

    private bool isMove = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            isMove = true;
        if (isMove == false) return;
        transform.Translate(transform.right * 5f * Time.deltaTime);
    }

}
