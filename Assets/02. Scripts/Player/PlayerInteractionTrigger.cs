using UnityEngine;

public class PlayerInteractionTrigger : MonoBehaviour
{
    private InteractionObject _interactionObject;

    public void LateUpdate()
    {
        if (_interactionObject != null)
        {
            Vector3 objPos = _interactionObject.transform.position;
            GameManager.Inst.UI.ShowInteractionUI(objPos);
        }
    }

    public void TriggerEvent()
    {
        if (GameManager.Inst.UI.IsActiveTextPanal()) return;

        if (_interactionObject != null)
        {
            _interactionObject.InteractionEvent();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interaction"))
        {
            _interactionObject = collision.transform.GetComponent<InteractionObject>();
            if(_interactionObject)
            {
                _interactionObject.EnterInteraction();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interaction"))
        {
            GameManager.Inst.UI.UnShowInteractionUI();

            if (_interactionObject != null)
            {
                _interactionObject.ExitInteraction();
                _interactionObject = null;
            }
        }
    }

}
