

using Cysharp.Threading.Tasks;

public class LobbyController : Singleton<LobbyController>
{
    public LobbyScene lobbyScene;
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
