using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PopupUI
{
    public Popup puzzlePref;
    public string keyID;
}

[CreateAssetMenu(menuName = "SO/PopupUI")]
public class PopupUISO : ScriptableObject
{
    [SerializeField]
    private List<PopupUI> popupUIList;

    public void OrderList()
    {
        popupUIList.OrderBy(x => Animator.StringToHash(x.keyID));
    }

    public PopupUI this[int idx]
    {
        get => popupUIList[idx];
        set => popupUIList[idx] = value;
    }

    public Popup this[string key]
    {
        get
        {
            // 이분탐색 알고리즘

            return popupUIList.Find(x=>x.keyID.Equals(key)).puzzlePref;

            int hash = Animator.StringToHash(key);
            GameObject pref = null;
            int idx = popupUIList.Count / 2;
            while (true)
            {
                int tempHash = Animator.StringToHash(popupUIList[idx].keyID);

                if (hash > tempHash)
                {
                    idx = idx / 2;
                    continue;
                }

                else if(hash < tempHash)
                {
                    idx = (popupUIList.Count - idx) / 2;
                    continue;
                }

                pref = popupUIList[idx].puzzlePref;
                break;
            }

            return pref;
        }
    }
}
