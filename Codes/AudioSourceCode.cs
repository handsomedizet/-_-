using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceCode : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] backgroundClips; // 여러 배경음악으로 사용할 AudioClip 배열

    [SerializeField, Range(0f, 1f)]
    private float volume = 1f; // 배경음악의 볼륨

    [SerializeField]
    private bool loop = true; // 배경음악의 루프 여부

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = loop;
        audioSource.volume = volume;

        // 인스펙터에서 설정된 클립이 있다면 무작위로 선택하여 재생
        if (backgroundClips != null && backgroundClips.Length > 0)
        {
            int randomIndex = Random.Range(0, backgroundClips.Length);
            audioSource.clip = backgroundClips[randomIndex];
            audioSource.Play(); // 배경음악 재생 시작
        }
        else
        {
            Debug.LogWarning("No background clips assigned.");
        }
    }

    public float Volume
    {
        get { return volume; }
        set
        {
            volume = Mathf.Clamp01(value);
            audioSource.volume = volume;
        }
    }

    public bool Loop
    {
        get { return loop; }
        set
        {
            loop = value;
            audioSource.loop = loop;
        }
    }

    public void StopBackgroundMusic()
    {
        audioSource.Stop();
    }

    public void PlayBackgroundMusic()
    {
        // 무작위로 새로운 클립 선택하여 재생
        if (backgroundClips != null && backgroundClips.Length > 0)
        {
            int randomIndex = Random.Range(0, backgroundClips.Length);
            audioSource.clip = backgroundClips[randomIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No background clips assigned.");
        }
    }
}
