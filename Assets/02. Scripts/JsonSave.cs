using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonSave : MonoBehaviour
{
    PlayerMove playerMove;
    public PlayerData playerData;

    private void Start()
    {
        playerMove = GameObject.Find("PlayerMove").GetComponent<PlayerMove>();
    }

    [ContextMenu("To Json Data")]
    void SavePlayerDataToJson()
    {
        string jsonData = JsonUtility.ToJson(playerData, true);
        string path = Path.Combine(Application.dataPath, "playerData.Json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json Data")]
    void LoadPlayerDataFromJson()
    {
        string path = Path.Combine(Application.dataPath, "playerData.Json");
        string jsonData = File.ReadAllText(path);
        playerData = JsonUtility.FromJson<PlayerData>(jsonData);
    }

    public void GameSave()
    {

    }
}

[System.Serializable]
public class PlayerData
{
    public bool isDead;
    public int playerId;
    public string name;
}