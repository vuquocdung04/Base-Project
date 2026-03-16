using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private DataRepo dataRepo;
    [SerializeField] private FXManager fxManager;
    [SerializeField] private AudioManager audioManager;
    public LocalizationManager localizationManager;
    public LivesManager livesManager;

    protected override void OnAwake()
    {
        Init();
    }

    private void Init()
    {
        Application.targetFrameRate = 60;
        fxManager.Init();
        dataRepo.Init();
        //
        audioManager.Init();
        // livesManager.Init();
        //Init final
        fxManager.LoadSceneWithIrisWipe(SceneName.LOBBY_SCENE, isSkipOutPhase);
    }

    public bool isSkipOutPhase;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.LogError("ewqweq");
            fxManager.LoadSceneWithIrisWipe(SceneName.LOBBY_SCENE, isSkipOutPhase);
        }
    }
}