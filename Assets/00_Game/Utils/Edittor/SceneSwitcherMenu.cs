#if UNITY_EDITOR
using UnityEditor;
using System.IO;
using System.Text;

public class SceneSwitcherGenerator : AssetPostprocessor
{
    private const string SCENE_FOLDER = "Assets/00_Game/Scenes";
    private const string OUTPUT_PATH = "Assets/00_Game/Editor/SceneSwitcherMenu_Generated.cs";
    
    static void OnPostprocessAllAssets(
        string[] imported, string[] deleted, string[] moved, string[] movedFrom)
    {
        bool sceneChanged = false;
        foreach (var path in imported) if (path.EndsWith(".unity")) sceneChanged = true;
        foreach (var path in deleted)  if (path.EndsWith(".unity")) sceneChanged = true;
        foreach (var path in moved)    if (path.EndsWith(".unity")) sceneChanged = true;

        if (sceneChanged) GenerateMenu();
    }

    [MenuItem("Tools/Regenerate Scene Menu")]
    static void GenerateMenu()
    {
        string[] guids = AssetDatabase.FindAssets("t:Scene", new[] { SCENE_FOLDER });

        var sb = new StringBuilder();
        sb.AppendLine("// AUTO-GENERATED — Do not edit manually");
        sb.AppendLine("#if UNITY_EDITOR");
        sb.AppendLine("using UnityEditor;");
        sb.AppendLine("using UnityEditor.SceneManagement;");
        sb.AppendLine();
        sb.AppendLine("public class SceneSwitcherMenu_Generated");
        sb.AppendLine("{");

        for (int i = 0; i < guids.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            string name = Path.GetFileNameWithoutExtension(path);

            sb.AppendLine($"    [MenuItem(\"Open Scene/{name}\", priority = {i + 1})]");
            sb.AppendLine($"    static void OpenScene_{i}()");
            sb.AppendLine("    {");
            sb.AppendLine($"        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())");
            sb.AppendLine($"            EditorSceneManager.OpenScene(\"{path}\", OpenSceneMode.Single);");
            sb.AppendLine("    }");
            sb.AppendLine();
        }

        sb.AppendLine("}");
        sb.AppendLine("#endif");

        // Tạo folder nếu chưa có
        string dir = Path.GetDirectoryName(OUTPUT_PATH);
        if (!Directory.Exists(dir))
            if (dir != null)
                Directory.CreateDirectory(dir);

        File.WriteAllText(OUTPUT_PATH, sb.ToString());
        AssetDatabase.Refresh();
    }
}
#endif