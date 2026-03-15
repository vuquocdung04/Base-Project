
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneSwitcherMenu
{
    private const string SCENE_FOLDER_PATH = "Assets/00_Game/Scenes/";

    [MenuItem("Open Scene/Loading Scene", priority = 1)]
    static void OpenScene0()
    {
        OpenScene(SCENE_FOLDER_PATH + "LoadingScene.unity");
    }

    [MenuItem("Open Scene/Lobby Scene", priority = 2)]
    static void OpenScene1()
    {
        OpenScene(SCENE_FOLDER_PATH + "LobbyScene.unity");
    }

    [MenuItem("Open Scene/Game Play", priority = 3)]
    static void OpenScene2()
    {
        OpenScene(SCENE_FOLDER_PATH + "GamePlayScene.unity");
    }
    
    static void OpenScene(string scenePath)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);
        }
    }
}
#endif