using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DustCleaner : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private Image dustImage;
    [SerializeField]
    private Image succesImg;
    [SerializeField]
    private Texture2D cursorImg;

    private Color imageColor;

    private void OnEnable()
    {
        imageColor = dustImage.color;
        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void OnDrag(PointerEventData eventData)
    {
        imageColor.a -= 0.001f;
        dustImage.color = imageColor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dustImage.color.a <= 0)
        {
            dustImage.gameObject.SetActive(false);

            succesImg.gameObject.SetActive(true);
            InventorySystem.Inst.AddItem("BEDROOMKEY");
        }
    }

    public void CursorOff()
    {
        Cursor.visible = false;
    }
}
