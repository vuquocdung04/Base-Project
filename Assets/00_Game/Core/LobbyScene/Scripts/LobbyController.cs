

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
        lobbyScene.Init();

        
    }
}
