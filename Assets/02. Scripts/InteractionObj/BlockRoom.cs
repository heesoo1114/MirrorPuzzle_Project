using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRoom : InteractionObject
{
    private bool _isOpen;
    [SerializeField] private string _keyItemID;
    public override void InteractionEvent()
    {
        if (_isOpen) return;
        if (InventorySystem.Inst.equipItemDataID.Equals(_keyItemID))
        {
            _isOpen = true;
            TextSystem.Inst.ActiveTextPanal("���� ���Ƚ��ϴ�");
            StartCoroutine(ImmediatelyStop());  
        }

        else
        {
            TextSystem.Inst.ActiveTextPanal("���谡 �ʿ��ϴ�");
        }
    }

    IEnumerator ImmediatelyStop()
    {
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
    }

}
