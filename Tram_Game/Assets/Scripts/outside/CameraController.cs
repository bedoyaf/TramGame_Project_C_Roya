using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera myCamera = null;
    [SerializeField] private CinemachineVirtualCamera myCineMachine = null;
    [SerializeField] private GameObject followPointer = null;

    [SerializeField] private GameObject unitGameObject = null;

    Vector3 mousePosition = new Vector3();
    Vector3 followPointerPosition = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = myCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        followPointerPosition = (mousePosition  + unitGameObject.transform.position) / 2;
        followPointerPosition = (followPointerPosition +unitGameObject.transform.position) / 2;
        followPointer.transform.position = followPointerPosition;
    }
}
