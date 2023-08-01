using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHitManager : MonoBehaviour
{
    public static StarHitManager Instance { get; private set; }
    public ParticleSystem starHit;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayStarHit(Vector3 position)
    {
        transform.position = position;
        starHit.Play();
    }

    public void StopStarHit()
    {
        starHit.Stop();
    }
}
