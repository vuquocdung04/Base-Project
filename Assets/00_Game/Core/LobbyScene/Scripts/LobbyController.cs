using UnityEngine;
using Cysharp.Threading.Tasks;
public class LobbyController : Singleton<LobbyController>
{
    public LobbyScene lobbyScene;
    [Header("UI Layers")]
    public Transform botCanvas;
    public Transform midCanvas;
    public Transform topCanvas;
    
    
    protected override void OnAwake()
    {
        base.OnAwake();
        m_DontDestroyOnLoad = false;
        Init();
    }

    private void Init()
    {
        lobbyScene.InitAsync().Forget();
    }
}
