// AUTO-GENERATED — Do not edit manually
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneSwitcherMenu_Generated
{
    [MenuItem("Open Scene/GamePlayScene", priority = 1)]
    static void OpenScene_0()
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            EditorSceneManager.OpenScene("Assets/00_Game/Scenes/GamePlayScene.unity", OpenSceneMode.Single);
    }

    [MenuItem("Open Scene/LoadingScene", priority = 2)]
    static void OpenScene_1()
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            EditorSceneManager.OpenScene("Assets/00_Game/Scenes/LoadingScene.unity", OpenSceneMode.Single);
    }

    [MenuItem("Open Scene/LobbyScene", priority = 3)]
    static void OpenScene_2()
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            EditorSceneManager.OpenScene("Assets/00_Game/Scenes/LobbyScene.unity", OpenSceneMode.Single);
    }

}
#endif
