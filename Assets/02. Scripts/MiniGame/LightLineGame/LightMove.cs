using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMove : MonoBehaviour
{
    // �������� ��ġ�ϰ� �����⸸ �����ϰ�?

    private void Update()
    {
        transform.Translate(transform.right * 5f * Time.deltaTime);
    }

}
