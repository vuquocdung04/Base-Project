using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set;}


    public AudioSource asBg;
    [Header("SFX Pooling")]
    public GameObject sfxPrefab;

    private AudioDataBase audioDataBase;
    private Dictionary<string, AudioConfig> audioLookup;
    private float currentSfxVolume = 1f;

    
    public void Init()
    {
        Instance = this;
        audioDataBase = DataRepo.Instance.audioData;
        BuildAudioLookup();
        SetInitVolumes();
    }

    private void BuildAudioLookup()
    {
        audioLookup = new Dictionary<string, AudioConfig>();
        foreach (var config in audioDataBase.audioConfigs)
        {
            if (string.IsNullOrEmpty(config.key))
                continue;

            string lowerKey = config.key.ToLower();

            if (!audioLookup.ContainsKey(lowerKey))
                audioLookup.Add(lowerKey, config);
            else
                Debug.LogWarning($"Tìm thấy AudioKey bị trùng: {config.key}");
        }
    }

    private void SetInitVolumes()
    {
        SetMusicVolume(1f);
        SetSoundVolume(1f);
    }

    /// <summary>
    /// Phát một SFX (âm thanh ngắn) dựa trên Key.
    /// </summary>
    public void PlaySfx(string key)
    {
        if (!UseProfile.OnSound || string.IsNullOrEmpty(key)) return;

        string lowerKey = key.ToLower();

        if (!audioLookup.TryGetValue(lowerKey, out var config))
        {
#if UNITY_EDITOR
            Debug.LogWarning($"Không tìm thấy AudioKey SFX: {key}");
#endif
            return;
        }

        AudioClip clipToPlay = config.GetRandomClip();
        if (clipToPlay == null) return;

        // Spawn từ Pool
        GameObject sfxObj = SimplePool2.Spawn(sfxPrefab, Vector3.zero, Quaternion.identity);
        if (sfxObj == null) return;

        AudioSource source = sfxObj.GetComponent<AudioSource>();

        // Cài đặt thông số
        source.clip = clipToPlay;
        source.pitch = config.GetRandomPitch();
        
        source.volume = lowerKey == "coin" ? 0.2f : currentSfxVolume;

        source.Play();

        // Tự động thu hồi bằng UniTask
        DespawnAfterPlayAsync(sfxObj, clipToPlay.length).Forget();
    }
    private async UniTaskVoid DespawnAfterPlayAsync(GameObject obj, float delay)
    {
        await UniTask.Delay(System.TimeSpan.FromSeconds(delay));

        if (obj != null && obj.activeInHierarchy)
        {
            SimplePool2.Despawn(obj);
        }
    }
    public void PlayMusic(string key)
    {
        if (string.IsNullOrEmpty(key)) return;

        string lowerKey = key.ToLower();

        if (!audioLookup.TryGetValue(lowerKey, out AudioConfig config))
        {
            Debug.LogWarning($"Không tìm thấy AudioKey nhạc: {key}");
            return;
        }

        AudioClip clipToPlay = config.GetRandomClip();
        if (clipToPlay == null) return;

        asBg.clip = clipToPlay;
        asBg.loop = true;
        asBg.pitch = 1f;
        
        asBg.Play();
        RefreshMusicVolume();
    }
    public void RefreshMusicVolume()
    {
        SetMusicVolume(1f);
    }
    private void SetMusicVolume(float volume)
    {
        asBg.volume = volume;
        asBg.volume = UseProfile.OnMusic ? 1f : 0f;
    }

    private void SetSoundVolume(float volume)
    {
        currentSfxVolume = UseProfile.OnSound ? volume : 0f;
    }
}