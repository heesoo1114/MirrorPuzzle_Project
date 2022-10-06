using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBase : MonoBehaviour
{
	protected Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

	protected bool _init = false;

	public virtual bool Init()
	{
		if (_init)
			return false;

		return _init = true;
	}

	private void Awake()
	{
		Init();
	}

	protected void Bind<T>(out T target, string name) where T : UnityEngine.Object
	{
		target = transform.Find(name).GetComponent<T>();
    }

	protected T[] Bind<T>(Type type) where T : UnityEngine.Object
	{
		string[] names = Enum.GetNames(type);
		T[] objects = new T[names.Length];
			

		for (int i = 0; i < names.Length; i++)
		{
			Bind(out objects[i], names[i]);

			if (objects[i] == null)
            {
				Debug.Log($"Failed to bind({names[i]})");
				return null;
            }
		}

		return objects;
	}
}
