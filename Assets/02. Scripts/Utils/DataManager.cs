using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;



[System.Serializable]
public class PlayerData
{
    public float effectSoundVolume;
    public float bgmSoundVolume;

    public bool isTutorial;
    public List<InventoryItemData> inventoryList;

    public PlayerData(float soundVolume)
    {
        effectSoundVolume = soundVolume;
        bgmSoundVolume = soundVolume;
        inventoryList = new List<InventoryItemData>();
        isTutorial = false;
    }
}

public class DataManager : MonoSingleton<DataManager>
{
    [SerializeField] private ItemSO _itemDataList;
    [SerializeField] private float defaultSound = 0.5f;
    private PlayerData _player;

    public PlayerData CurrentPlayer => _player;

    private string SAVE_PATH = "";
    private const string SAVE_FILE = "/SaveFile.Json";

    private void Awake()
    {
        DataManager[] dmanagers = FindObjectsOfType<DataManager>();
        if (dmanagers.Length != 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);

        SAVE_PATH = Application.dataPath + "/Save";

        if (!Directory.Exists(SAVE_PATH))
        {
            Directory.CreateDirectory(SAVE_PATH);
        }

        LoadFromJson();

        _player.inventoryList.Clear();
        foreach (var item in _itemDataList.itemDataList)
        {
            _player.inventoryList.Add(new InventoryItemData(item, 1));
        }
    }

    private void Start()
    {
    }

    private void LoadFromJson()
    {
        if (File.Exists(SAVE_PATH + SAVE_FILE))
        {
            string stringJson = File.ReadAllText(SAVE_PATH + SAVE_FILE);
            _player = JsonUtility.FromJson<PlayerData>(stringJson);
        }
        else
        {
            _player = new PlayerData(defaultSound);
            
        }
        SaveToJson();
    }
    public void SaveToJson()
    {
        string stringJson = JsonUtility.ToJson(_player, true);
        File.WriteAllText(SAVE_PATH + SAVE_FILE, stringJson, System.Text.Encoding.UTF8);
    }
    public void DataReset()
    {
        _player = new PlayerData(defaultSound);
        SaveToJson();
        Application.Quit();
    }

    private void OnApplicationQuit()
    {
        SaveToJson();
    }

    private void OnDestroy()
    {
        SaveToJson();
    }
}