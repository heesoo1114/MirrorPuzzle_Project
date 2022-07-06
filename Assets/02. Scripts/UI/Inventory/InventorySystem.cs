using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private TMP_Text _itemNameText;
    [SerializeField] private TMP_Text _itemInfoText;
    [SerializeField] private TargetPicker _targetPicker;
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _selectSprite;

    [SerializeField] private float _changeItemDelay;

    private CanvasGroup _canvasGroup;

    private List<ItemPanel> _itemPanelList = new List<ItemPanel>();
    private int _selectItemIndex = 0;

    public ItemPanel CurrentItemPanel => _itemPanelList[_selectItemIndex];

    private bool _isActive;

    private float _timer;
    private float _axisValue;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _itemPanelList = GetComponentInChildren<GenerateItemPanel>().GeneratePanel();
        _timer = _changeItemDelay;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _isActive = !_isActive;
            GameManager.Inst.OnUI = _isActive;
            _canvasGroup.DOFade(_isActive ? 1f : 0f, 0.5f);
            _canvasGroup.interactable = _isActive;
            _canvasGroup.blocksRaycasts = _isActive;

            if (_isActive)
                _targetPicker.SetPos(CurrentItemPanel.transform.position);
        }
        if (!_isActive) return;

        _axisValue = Input.GetAxisRaw("Horizontal");
        if (_axisValue != 0)
        {
            _timer += Time.deltaTime;
            if (_timer >= _changeItemDelay)
            {
                _timer = 0f;
                SetSelectItem(_selectItemIndex + (int)_axisValue);
            }
        }

        else
        {
            _timer = _changeItemDelay;
        }


    }

    public void SetSelectItem(int idx)
    {
        if (idx >= _itemPanelList.Count || idx < 0) return;

        CurrentItemPanel.SetSprite(_defaultSprite);

        _selectItemIndex = idx;

        CurrentItemPanel.SetSprite(_selectSprite);
        _targetPicker.SetPos(CurrentItemPanel.transform.position);
        SetItemText();
    }

    public void SetItemText()
    {
        if (CurrentItemPanel.IsEmpty) return;
        _itemNameText.text = CurrentItemPanel.ItemName;
        _itemInfoText.text = CurrentItemPanel.ItemInfo;
    }

}
