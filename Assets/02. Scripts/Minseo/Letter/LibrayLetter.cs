using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibrayLetter : MonoBehaviour
{
    [SerializeField]
    private GameObject letter;

    private void OnTriggerEnter(Collider2D other)
    {
        if (other.tag == "LetterCollider")
        {
            letter.gameObject.SetActive(true);
        }
    }

    public void LetterHint()
    {
        GameManager.Inst.ChangeGameState(EGameState.UI);
        LetterUI.OpenLetter("or");
        InventorySystem.Inst.UseEquipItem();
    }

    IEnumerator DestroyLetter()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
