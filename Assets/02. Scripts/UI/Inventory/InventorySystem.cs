using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class InventorySystem : MonoSingleton<InventorySystem>
{
    public InventoryItemData equipInventoryData;

    [SerializeField] private TMP_Text _itemNameText;
    [SerializeField] private TMP_Text _itemInfoText;
    [SerializeField] private TargetPicker _targetPicker;
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _selectSprite;

    [SerializeField] private Image _equipItemIamge;

    [SerializeField] private float _changeItemDelay;
    [SerializeField] private int _maxShowPanelCnt = 6;
    private CanvasGroup _canvasGroup;

    private List<ItemPanel> _itemPanelList = new List<ItemPanel>();
    private int _selectItemIndex = 0;

    public ItemPanel CurrentItemPanel => _itemPanelList[_selectItemIndex];

    private bool _isActive;

    private float _timer;
    private float _axisValue;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _itemPanelList = GetComponentInChildren<GenerateItemPanel>().GeneratePanel();
        _timer = _changeItemDelay;

        SetActiveItemPanel();
        SettingCurrentItemPanel();
    }

    private void SetActiveItemPanel()
    {
        if (_itemPanelList.Count < _maxShowPanelCnt) return;

        int currentPanelIndex = CurrentItemPanel.Index;

            for (int i = 0; i < _itemPanelList.Count; i++)
            {
                if (_itemPanelList[i].Index <= Mathf.Max(currentPanelIndex, _maxShowPanelCnt - 1) &&
                   _itemPanelList[i].Index > currentPanelIndex - _maxShowPanelCnt)
                {
                    _itemPanelList[i].gameObject.SetActive(true);
                }

                else
                {
                    _itemPanelList[i].gameObject.SetActive(false);
                }
            }


    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _isActive = !_isActive;
            GameManager.Inst.SetGameState(_isActive);
            _canvasGroup.DOFade(_isActive ? 1f : 0f, 0.5f);
            _canvasGroup.interactable = _isActive;
            _canvasGroup.blocksRaycasts = _isActive;

            if (_isActive)
            {
                SettingCurrentItemPanel();
            }
        }
        if (!_isActive) return;

        _axisValue = Input.GetAxisRaw("Horizontal");
        if (_axisValue != 0)
        {
            _timer += Time.deltaTime;
            if (_timer >= _changeItemDelay)
            {
                _timer = 0f;
                StartCoroutine(SetSelectItem(_selectItemIndex + (int)_axisValue));
            }
        }

        else
        {
            _timer = _changeItemDelay;
        }


    }

    public IEnumerator SetSelectItem(int idx)
    {
        if (idx >= _itemPanelList.Count || idx < 0) yield break;

        CurrentItemPanel.SetSprite(_defaultSprite);

        _selectItemIndex = idx;

        SetActiveItemPanel();

        yield return new WaitForEndOfFrame();

        SettingCurrentItemPanel();
    }

    private void SettingCurrentItemPanel()
    {
        CurrentItemPanel.SetSprite(_selectSprite);
        _equipItemIamge.sprite = CurrentItemPanel.ItemData.itemData.sprite;
        _targetPicker.SetPos(CurrentItemPanel.transform.position);
        SetItemText();

       equipInventoryData = CurrentItemPanel.ItemData; 
    }

    public void SetItemText()
    {
        if (CurrentItemPanel.IsEmpty) return;
        _itemNameText.text = CurrentItemPanel.ItemName;
        _itemInfoText.text = CurrentItemPanel.ItemInfo;
    }

}
