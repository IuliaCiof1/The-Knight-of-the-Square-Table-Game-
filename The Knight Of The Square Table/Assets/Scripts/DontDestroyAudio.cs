using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject); //will keep audio when moving to next scene
    }
}
