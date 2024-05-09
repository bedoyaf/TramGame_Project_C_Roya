using UnityEngine;

public class GameCoreInside : MonoBehaviour
{
    public AudioSource tramSound;
    public AudioSource ambientSound;
    public AudioSource spacebarSound;

    void Start()
    {
        // Play the tram sound
        tramSound.Play();

        // Play the ambient sound
        ambientSound.Play();
    }

    void Update()
    {
        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Play the spacebar sound
            spacebarSound.Play();
        }
    }
}
