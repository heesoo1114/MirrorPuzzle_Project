using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleUI<T> : UIBase where T : UIBase
{
    protected static T inst = null;

    public override bool Init()
    {
        if (base.Init() == false)
        {
            return false;
        }

        inst = transform.GetComponent<T>();

        return true;
    }

    protected static bool CheckInstance()
    {
        if(inst == null)
        {
            Debug.LogError($"{typeof(T).ToString()}'s inst doesn't exist");
            return true;
        }

        return false;
    }
}


