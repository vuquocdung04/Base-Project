
using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public DataRepo dataRepo;
    public FXManager fxManager;
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
        fxManager.Init();
        // dataRepo.Init();
        //
        // audioManager.Init();
        // livesManager.Init();
        //Init final
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
