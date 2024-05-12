using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideGeizerController : MonoBehaviour
{
    // Start is called before the first frame update

     Transform target;
    public GameObject targetOB;
    private Vector3 startPosition;
    float despawnDistance;
    public float moveSpeed = 3f;
    public float rotationSpeed = 5f; // Speed of rotation


    public 
    void Start()
    {
        startPosition = transform.position;
        target = targetOB.GetComponent<Transform>();
       despawnDistance = Vector3.Distance(transform.position, target.position) ;

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // Move towards the target
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            float distanceWalked = Vector3.Distance(startPosition, transform.position);



            Vector2 direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            // If the creature has walked the desired distance, destroy it
            if (distanceWalked >= despawnDistance)
            {
                Destroy(gameObject);
            }

        }
    }
}
