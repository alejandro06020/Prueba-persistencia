using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class DataPlayer : MonoBehaviour
{
    
    public static DataPlayer instance;
    public string playerName;
    public int scorePalyer;
    public TMP_InputField namePlayer;
    public TextMeshProUGUI textMeshProUGUI;
    private void Awake()
    {
        namePlayer = GameObject.FindFirstObjectByType<TMP_InputField>();
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadName();
    }
    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int scorePalyer;
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        playerName = namePlayer.text;
        if (data.playerName !=playerName)
        {
            data.playerName = playerName;
            scorePalyer = 0;
            data.scorePalyer = 0;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
        else
        {
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }
    public void SaveAll()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.scorePalyer = scorePalyer;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            scorePalyer = data.scorePalyer;
            textMeshProUGUI.text = playerName +" best score: "+scorePalyer;
        }
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
   
}
