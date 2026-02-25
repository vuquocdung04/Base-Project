
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public DataRepo dataRepo;
    public AdmobManager admobManager;
    public FeedBackManager feedBackManager;
    public AudioManager audioManager;
    public LocalizationManager localizationManager;
    public LivesManager livesManager;
    
    protected override void OnAwake()
    {
        Init();
    }

    private void Init()
    {
        Application.targetFrameRate = 60;
        dataRepo.Init();
        admobManager.Init();
        
        audioManager.Init();
        livesManager.Init();
        
        //Init final
    }
}
