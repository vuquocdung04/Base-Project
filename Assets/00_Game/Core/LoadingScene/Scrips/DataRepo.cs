
using UnityEngine;

public class DataRepo : MonoBehaviour
{
    public static DataRepo instance;
    public LocalizationDataBase localizationDataBase;
    public AudioDataBase audioData;
    public void Init()
    {
        instance = this;
    }
}
