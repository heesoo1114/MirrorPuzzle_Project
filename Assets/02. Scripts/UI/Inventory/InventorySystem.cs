using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class InventorySystem : MonoSingleton<InventorySystem>
{
    public string equipItemDataID;

    [SerializeField] private ItemPanel _itemPanelTemp;
    [SerializeField] private int _defaultGenerateCnt = 5;

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
        _timer = _changeItemDelay;

        _itemNameText.text = "";
        _itemInfoText.text = "";

        GeneratePanel();

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
        if (GameManager.Inst.GameState == EGameState.Timeline) return;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _isActive = !_isActive;
            GameManager.Inst.ChangeGameState(_isActive ? EGameState.UI : EGameState.Game);
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

    public void AddItem(string itemID, int addCount = 1)
    {
        ItemData itemData = DataManager.Inst.ItemDataList.Find(x => x.itemID.Equals(itemID));
        if (itemData == null)
        {
            Debug.LogError("해당 ID의 아이템이 없어요.");
        }

        foreach (var panel in _itemPanelList)
        {
            if (panel.IsEmpty)
            {
                panel.SetItem(new ItemData(itemData));
                return;
            }

            else if (panel.InventoryData.itemData.itemID.Equals(itemID))
            {
                panel.SetItemCount(addCount);
                return;
            }
        }

        AddPanel(new InventoryItemData(itemData, addCount));
    }

    public bool EqualsItem(string itemID)
    {
        foreach (var panel in _itemPanelList)
        {
            if (panel.IsEmpty == false)
            {
                if (panel.InventoryData.itemData.itemID.Equals(itemID))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void SettingCurrentItemPanel()
    {
        CurrentItemPanel.SetSprite(_selectSprite);

        if (CurrentItemPanel.IsEmpty)
        {
            _equipItemIamge.enabled = false;
            equipItemDataID = "";
        }

        else
        {
            _equipItemIamge.sprite = CurrentItemPanel.InventoryData.itemData.sprite;
            _equipItemIamge.enabled = true;
            equipItemDataID = CurrentItemPanel.InventoryData.itemData.itemID;
        }

        _targetPicker.SetPos(CurrentItemPanel.transform.position);
        SetItemText();

    }

    public void UseEquipItem(int useCount = 1)
    {
        CurrentItemPanel.SetItemCount(useCount * -1);
    }

    public void SetItemText()
    {
        if (CurrentItemPanel.IsEmpty) return;
        _itemNameText.text = CurrentItemPanel.ItemName;
        _itemInfoText.text = CurrentItemPanel.ItemInfo;
    }




    public void GeneratePanel()
    {
        var list = DataManager.Inst.CurrentPlayer.inventoryList;

        int cnt = list.Count < _defaultGenerateCnt ? _defaultGenerateCnt : list.Count;
        for (int i = 0; i < cnt; i++)
        {
            if (i < list.Count)
            {
                AddPanel(list[i]);
            }

            else
            {
                AddPanel(new InventoryItemData(null, 0));
            }
        }
    }

    public ItemPanel AddPanel(InventoryItemData data)
    {
        ItemPanel panel = Instantiate(_itemPanelTemp, _itemPanelTemp.transform.parent);

        panel.Init(data);

        if (!DataManager.Inst.CurrentPlayer.inventoryList.Equals(data))
        {
            DataManager.Inst.CurrentPlayer.inventoryList.Add(data);
        }

        _itemPanelList.Add(panel);
        panel.gameObject.SetActive(true);
        return panel;
    }
}
