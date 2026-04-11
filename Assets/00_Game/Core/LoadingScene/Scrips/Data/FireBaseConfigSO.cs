using Firebase.RemoteConfig;
using Newtonsoft.Json;
using UnityEngine;

[CreateAssetMenu(fileName = "new FireBaseConfigSO", menuName = "DATA/FIRE BASE CONFIG")]
public class FireBaseConfigSO : ScriptableObject
{

    public void Init()
    {
        totalKeysDeclared = 0;
        totalKeysLoaded = 0;
        
        DebugRemote();
    }

    private void DebugRemote()
    {
        bool allLoaded = totalKeysLoaded == totalKeysDeclared;
        string color = allLoaded ? "lime" : "orange";
        Debug.Log($"<color={color}>{'═'.ToString().PadRight(60, '═')}</color>");
        Debug.Log($"<color={color}>📋 Remote Config Summary: {totalKeysLoaded}/{totalKeysDeclared} keys loaded successfully</color>");
        if (!allLoaded)
            Debug.LogWarning($"<color=orange>⚠ {totalKeysDeclared - totalKeysLoaded} key(s) missing or failed — using default values</color>");
        Debug.Log($"<color={color}>{'═'.ToString().PadRight(60, '═')}</color>");
    }

    private ConfigValue GetRemoteValue(string key) => FirebaseRemoteConfig.DefaultInstance.GetValue(key);

    private int totalKeysDeclared;
    private int totalKeysLoaded;
    private T GetRemoteValueJson<T>(string key, T defaultValue)
    {
        totalKeysDeclared++;
        var json = GetRemoteValue(key).StringValue;

        if (!string.IsNullOrEmpty(json))
        {
            try
            {
                var result = JsonConvert.DeserializeObject<T>(json);
                totalKeysLoaded++;
                Debug.Log($"<color=cyan>✔ Remote Config loaded: <b>{key}</b> = {json}</color>");
                return result;
            }
            catch (System.Exception e)
            {
                Debug.LogError($"<color=red>✘ Remote Config parse error: <b>{key}</b> — {e.Message} | Using default: {defaultValue}</color>");
            }
        }
        else
        {
            // ← thêm log này
            Debug.LogWarning($"<color=orange>⚠ Remote Config missing or empty: <b>{key}</b> | Using default: {JsonConvert.SerializeObject(defaultValue)}</color>");
        }

        return defaultValue;
    }
}
