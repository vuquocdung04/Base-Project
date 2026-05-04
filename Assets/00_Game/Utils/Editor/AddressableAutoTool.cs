using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;

#if UNITY_EDITOR
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
#endif

public class AddressableAutoTool : OdinEditorWindow
{
    [MenuItem("Tools/Auto Addressable & PathPrefabs")]
    private static void OpenWindow()
    {
        GetWindow<AddressableAutoTool>("Auto Addressable").Show();
    }

    [Title("Cấu hình Thư mục")]
    [FolderPath(RequireExistingPath = true)]
    [InfoBox("Chọn thư mục chứa các UI Prefab (Ví dụ: Assets/Prefabs/UI)")]
    public string prefabFolderPath;

    [FolderPath(RequireExistingPath = true)]
    [InfoBox("Chọn thư mục để lưu file PathPrefabs.cs (Ví dụ: Assets/Scripts/Data)")]
    public string scriptOutputFolder;

    [Button("⚡ Tự Động Tích Addressable & Sinh Script", ButtonSizes.Large), GUIColor(0.4f, 0.8f, 1f)]
    private void ProcessPrefabs()
    {
        if (string.IsNullOrEmpty(prefabFolderPath) || !AssetDatabase.IsValidFolder(prefabFolderPath))
        {
            Debug.LogError("Vui lòng chọn thư mục chứa Prefab hợp lệ!");
            return;
        }

        if (string.IsNullOrEmpty(scriptOutputFolder) || !AssetDatabase.IsValidFolder(scriptOutputFolder))
        {
            Debug.LogError("Vui lòng chọn thư mục lưu script hợp lệ!");
            return;
        }

        // 1. Lấy Settings của Addressable (Bắt buộc phải có file AddressableAssetSettings trong project)
        AddressableAssetSettings settings = AddressableAssetSettingsDefaultObject.Settings;
        if (settings == null)
        {
            Debug.LogError("Không tìm thấy Addressable Settings! Vui lòng cài đặt Addressables và tạo Settings trước.");
            return;
        }

        // Dùng group mặc định (Default Local Group)
        AddressableAssetGroup group = settings.DefaultGroup;

        // Quét toàn bộ Prefab trong thư mục đã chọn
        string[] prefabGuids = AssetDatabase.FindAssets("t:Prefab", new[] { prefabFolderPath });
        List<string> generatedConstants = new List<string>();

        foreach (string guid in prefabGuids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            string prefabName = Path.GetFileNameWithoutExtension(assetPath);

            // 2. Tự động thêm vào Addressable và đặt Address = Tên Prefab
            AddressableAssetEntry entry = settings.CreateOrMoveEntry(guid, group, readOnly: false, postEvent: false);
            entry.address = prefabName;

            // 3. Xử lý chuỗi: Chuyển "KeepPlayingBox" thành "KEEP_PLAYING_BOX"
            string constName = Regex.Replace(prefabName, "([a-z])([A-Z])", "$1_$2").ToUpper();
            generatedConstants.Add($"    public const string {constName} = \"{prefabName}\";");
        }

        // Lưu lại thay đổi của Addressables
        settings.SetDirty(AddressableAssetSettings.ModificationEvent.EntryMoved, null, true);
        AssetDatabase.SaveAssets();

        // 4. Sinh file PathPrefabs.cs
        string scriptPath = Path.Combine(scriptOutputFolder, "PathPrefabs.cs").Replace("\\", "/");
        GenerateScript(scriptPath, generatedConstants);

        Debug.Log($"<color=green>[Thành Công]</color> Đã xử lý {prefabGuids.Length} prefabs và tạo file PathPrefabs tại {scriptPath}");
    }

    private void GenerateScript(string path, List<string> constants)
    {
        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.WriteLine("// AUTO-GENERATED CODE. DO NOT EDIT MANUALLY.");
            writer.WriteLine("public class PathPrefabs");
            writer.WriteLine("{");
            
            foreach (string constLine in constants)
            {
                writer.WriteLine(constLine);
            }
            
            writer.WriteLine("}");
        }
        
        // Yêu cầu Unity compile lại script vừa sinh ra
        AssetDatabase.Refresh();
    }
}