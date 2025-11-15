using UnityEngine;

public abstract class BoxSingleton<T> : BaseBox where T : BoxSingleton<T>
{
    private static T instance;
    private DataPlayer dataPlayer;
    public static T Path(string prefabPath)
    {
        if (instance == null)
        {
            T prefab = Resources.Load<T>(prefabPath);
            if (prefab == null)
            {
                Debug.LogError($"[BoxSingleton] Không tìm thấy prefab tại đường dẫn: {prefabPath}");
                return null;
            }
            instance = Instantiate(prefab);
            instance.InitData();
            instance.Init();
        }

        instance.InitState();
        return instance;
    }
    
    protected abstract void Init();
    protected abstract void InitState();

    private void InitData()
    {
        dataPlayer = GameController.Instance.dataContains.DataPlayer;
    }
    
    // goi o initState
    protected virtual void RefreshLocalization()
    {
        if (!dataPlayer.IsLanguageChanged) return;
    }
}