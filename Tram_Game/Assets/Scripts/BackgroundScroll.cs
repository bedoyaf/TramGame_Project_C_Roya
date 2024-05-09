using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 10f;
    [SerializeField] Transform background1;
    [SerializeField] Transform background2;
    float backgroundSize;

    void Start()
    {
        // Calculate the size of one background based on the sprite renderer bounds
        SpriteRenderer renderer = background1.GetComponent<SpriteRenderer>();
        backgroundSize = renderer.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the backgrounds
        background1.Translate(Vector2.left * scrollSpeed * Time.deltaTime);
        background2.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

        // If the first background has moved completely past the camera
        if (background1.position.x < -backgroundSize)
        {
            // Teleport it to the right side of the second background
            Vector3 newPos = new Vector3(background2.position.x + backgroundSize, background1.position.y, background1.position.z);
            background1.position = newPos;
        }

        // If the second background has moved completely past the camera
        if (background2.position.x < -backgroundSize)
        {
            // Teleport it to the right side of the first background
            Vector3 newPos = new Vector3(background1.position.x + backgroundSize, background2.position.y, background2.position.z);
            background2.position = newPos;
        }
    }
}
