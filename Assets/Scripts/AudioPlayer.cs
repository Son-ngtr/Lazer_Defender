using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Taken Damage")]
    [SerializeField] AudioClip takenDamageClip;
    [SerializeField][Range(0f, 1f)] float takenDamageVolume = 1f;

    static AudioPlayer instance;

    public AudioPlayer GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        ManageSingleTon();
    }

    void ManageSingleTon()
    {
        /*int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1 )*/
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayTakenDamage()
    {
        PlayClip(takenDamageClip, takenDamageVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
