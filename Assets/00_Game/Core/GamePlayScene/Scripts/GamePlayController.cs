
public class GamePlayController : Singleton<GamePlayController>
{
    public GameScene gameScene;
    public BoosterController boosterController;
    protected override void OnAwake()
    {
        base.OnAwake();
        Init();
    }

    private void Init()
    {
        gameScene.Init();
        boosterController.Init();
    }
}
