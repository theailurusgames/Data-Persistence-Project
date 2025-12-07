using System.IO;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class DataDB : MonoBehaviour
{
    class DataToStore
    {
        public int d_score;
        public string d_name;
    }

    public static DataDB Instance;
    public int bestScoreStored;
    public string bestScoreNameStored;


    // public int bestScorePointToDisplay;
    //public string bestScoreNameToDisplay;
    public string playerName;
    //public string nameBoxText;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    public void StoreData()
    {      
        DataToStore data = new DataToStore();

        data.d_score = bestScoreStored;
        data.d_name = bestScoreNameStored;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataToStore data = JsonUtility.FromJson<DataToStore>(json);

            bestScoreNameStored = data.d_name;
            bestScoreStored = data.d_score;
        }

    }
  
}
