using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource.Play();
    }
}
