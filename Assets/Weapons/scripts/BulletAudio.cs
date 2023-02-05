using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAudio : MonoBehaviour
{
    public AudioSource audio;
    private bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (start && !audio.isPlaying)
            Destroy(gameObject);
    }
}
