
using UnityEngine;

public class GameController : Singleton<GameController>
{
    public StartLoading startLoading;
    public UseProfile useProfile;
    public DataContains dataContains;
    public AdmobController admobController;
    public EffectController effectController;
    public AudioController audioController;
    public LocalizationController localizationController;
    public HeartGame heartGame;
    
    protected override void OnAwake()
    {
        Init();
    }

    private void Init()
    {
        Application.targetFrameRate = 60;
        dataContains.Init();
        admobController.Init();
        
        audioController.Init();
        heartGame.Init();
        
        //Init final
        startLoading.Init();
    }
}
