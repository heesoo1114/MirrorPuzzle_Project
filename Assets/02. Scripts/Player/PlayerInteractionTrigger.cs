using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionTrigger : MonoBehaviour
{
    private List<InteractionObject> _interactionObjectList = new List<InteractionObject>();
    private InteractionObject CurrentObject
    {
        get
        {
            int cnt = _interactionObjectList.Count;
            if (cnt <= 0)
                return null;



            return _interactionObjectList[cnt - 1];
        }
    }


    public void LateUpdate()
    {
        if (CurrentObject != null)
        {
            Vector3 objPos = CurrentObject.transform.position;
            InteractionImage.Show(objPos);
        }
    }

    public void TriggerEvent()
    {
        if (TextSystem.Inst.gameObject.activeSelf) return;

        if (InventorySystem.Inst.equipItemDataID == "HAND_MIRROR")
        {
            if (GameManager.Inst.isCanUseHandMirror == true)
                GameManager.Inst.ChangeWorld();
        }
        else if (CurrentObject != null)
        { 
            CurrentObject.InteractionEvent();
        }
        else
        {
            string equipItemID = InventorySystem.Inst.equipItemDataID;

            switch (equipItemID)
            {
                case "2065":
                    GameManager.Inst.ChangeGameState(EGameState.UI);
                    LetterUI.OpenLetter("ÇüÀº ±¦Âú¾Æ.\n°ÆÁ¤ÇÏÁö¸¶.\n±×¸®°í Á¶½ÉÇØ.");
                    InventorySystem.Inst.UseEquipItem();
                    break;
                case "HALLWAY_LETTER_VERANDA":
                    GameManager.Inst.ChangeGameState(EGameState.UI);
                    LetterUI.OpenLetter("ri");
                    break;
                case "HALLWAY_LETTER_BEDROOM":
                    GameManager.Inst.ChangeGameState(EGameState.UI);
                    LetterUI.OpenLetter("r");
                    break;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Inst.GameState != EGameState.Game) return;

        if (collision.gameObject.CompareTag("Interaction"))
        {
            InteractionObject obj = collision.transform.GetComponent<InteractionObject>();

            if (obj != null)
            {
                _interactionObjectList.Add(obj);
                obj.EnterInteraction();
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interaction"))
        {
            InteractionImage.UnShow();

            InteractionObject obj = collision.transform.GetComponent<InteractionObject>();

            if (obj != null && _interactionObjectList.Find(x => x == obj) != null)
            {
                obj.ExitInteraction();
                _interactionObjectList.Remove(obj);
            }
        }

    }
}
