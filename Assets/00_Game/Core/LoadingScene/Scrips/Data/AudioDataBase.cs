using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class AudioConfig
{
    [Header("🔊 Identification")] public string key;

    [Header("Audio Data")]
    [SerializeField]
    private List<AudioClip> variants;

    [Header("Pitch Randomization")]
    [Range(0.5f, 2f)]
    [SerializeField] private float minPitch = 0.7f;
    [Range(0.5f, 2f)][SerializeField] private float maxPitch = 1.1f;

    public AudioClip GetRandomClip()
    {
        if (variants == null || variants.Count == 0)
            return null;

        int rand = Random.Range(0, variants.Count);
        return variants[rand];
    }

    public float GetRandomPitch()
    {
        return Random.Range(minPitch, maxPitch);
    }

}

[CreateAssetMenu(fileName = "AudioDataBase", menuName = "DATA/AudioDataBase")]
public class AudioDataBase : ScriptableObject
{
#if UNITY_EDITOR
    [Header("Editor Only: Kéo thư mục chứa Audio vào đây")]
    public DefaultAsset audioFolder;
#endif
    [Header("🔊 All Audio Configurations")]
    public List<AudioConfig> audioConfigs = new();
}

#if UNITY_EDITOR
[CustomEditor(typeof(AudioDataBase))]
public class AudioDataBase_Editor : Editor
{
    private class TempAudioData
    {
        public string key;
        public List<AudioClip> clips = new List<AudioClip>();
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        AudioDataBase so = (AudioDataBase)target;

        if (GUILayout.Button("Auto Fill From Folder", GUILayout.Height(40)))
        {
            if (so.audioFolder == null)
            {
                Debug.LogWarning("Vui lòng kéo thư mục chứa Audio vào trường 'Audio Folder' trước!");
                return;
            }

            string rootFolderPath = AssetDatabase.GetAssetPath(so.audioFolder);
            if (!AssetDatabase.IsValidFolder(rootFolderPath))
            {
                Debug.LogWarning($"Đường dẫn không hợp lệ hoặc không phải thư mục: {rootFolderPath}");
                return;
            }

            List<TempAudioData> parsedData = new List<TempAudioData>();

            string[] topLevelFiles = Directory.GetFiles(rootFolderPath, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string filePath in topLevelFiles)
            {
                if (filePath.EndsWith(".meta")) continue; // Bỏ qua file meta

                string assetPath = filePath.Replace('\\', '/');
                AudioClip clip = AssetDatabase.LoadAssetAtPath<AudioClip>(assetPath);

                if (clip != null)
                {
                    parsedData.Add(new TempAudioData
                    {
                        key = clip.name,
                        clips = new List<AudioClip> { clip }
                    });
                }
            }

            // 2. Quét các thư mục con (Gom tất cả audio vào chung 1 key)
            string[] subFolders = AssetDatabase.GetSubFolders(rootFolderPath);
            foreach (string subFolder in subFolders)
            {
                string folderName = Path.GetFileName(subFolder);
                TempAudioData folderData = new TempAudioData { key = folderName };

                string[] clipGuids = AssetDatabase.FindAssets("t:AudioClip", new[] { subFolder });

                foreach (string guid in clipGuids)
                {
                    string clipPath = AssetDatabase.GUIDToAssetPath(guid);
                    AudioClip clip = AssetDatabase.LoadAssetAtPath<AudioClip>(clipPath);
                    if (clip != null)
                    {
                        folderData.clips.Add(clip);
                    }
                }

                if (folderData.clips.Count > 0)
                {
                    parsedData.Add(folderData);
                }
            }

            // 3. Ghi dữ liệu vào Scriptable Object
            SerializedObject serializedObject = new SerializedObject(so);
            SerializedProperty configsProp = serializedObject.FindProperty("audioConfigs");

            configsProp.ClearArray();
            configsProp.arraySize = parsedData.Count;

            for (int i = 0; i < parsedData.Count; i++)
            {
                var element = configsProp.GetArrayElementAtIndex(i);

                element.FindPropertyRelative("key").stringValue = parsedData[i].key;
                element.FindPropertyRelative("minPitch").floatValue = 0.7f;
                element.FindPropertyRelative("maxPitch").floatValue = 1.1f;

                SerializedProperty variantsProp = element.FindPropertyRelative("variants");
                variantsProp.ClearArray();
                variantsProp.arraySize = parsedData[i].clips.Count;

                for (int j = 0; j < parsedData[i].clips.Count; j++)
                {
                    variantsProp.GetArrayElementAtIndex(j).objectReferenceValue = parsedData[i].clips[j];
                }
            }

            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(so);
            AssetDatabase.SaveAssets();

            Debug.Log($"Auto filled {parsedData.Count} audio keys from {rootFolderPath}!");
        }
    }
}
#endif
