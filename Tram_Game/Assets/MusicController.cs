using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController Instance;

    public AudioSource tramSound;
    public AudioSource ambientSound;
    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        // Play the tram sound
        tramSound.Play();
        ambientSound.Play();
        music.Play();
    }

    void Awake()
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
