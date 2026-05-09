
using UnityEngine;

public class GamePlayController : Singleton<GamePlayController>
{
    public Camera cameraUI;
    public Camera cameraGameplay;
    public GameScene gameScene;
    public BoosterController boosterController;
    public HandAnimation handAnimation;
    protected override void OnAwake()
    {
        base.OnAwake();
        Init();
    }

    private void Init()
    {
        gameScene.Init();
        boosterController.Init();
        handAnimation.Init();

        FXManager.Instance.isNextSceneReady = true;
    }
}
