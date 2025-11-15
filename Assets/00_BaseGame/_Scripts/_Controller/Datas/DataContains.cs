
using UnityEngine;

public class DataContains : MonoBehaviour
{
    public DataPlayer DataPlayer;
    public LocalizationDataBase localizationDataBase;
    public AudioDataBase audioData;
    public GiftDataBase giftData;
    
    private string jsonName = "PlayerData";
    public void Init()
    {
        LoadData();
    }

    private void LoadData()
    {
        DataPlayer = JsonSaveSystem.Load<DataPlayer>(jsonName);
        if (DataPlayer == null)
        {
            Debug.LogWarning("Không tải được DataPlayer hoặc file bị lỗi. Tạo mới...");
            DataPlayer = new DataPlayer();
            SaveData(); 
        }
    }

    private void SaveData()
    {
        JsonSaveSystem.Save(DataPlayer, jsonName);
    }
}
