using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using static UnityEditor.Progress;

public class outsidePlayerController : MonoBehaviour
{
    public GameObject CanvasManager;

    public List<string> inventoryItems = new List<string>();
    public int inventoryCapacity = 5;

    public string ItemStandTag = "ItemStation";
    public string DroppingOfStationTag = "DroppingOfStation";

    private bool isOnItemStation = false;
    private bool isOnDroppingOfStation = false;

    private GameObject currentItemStation;


    Animator animator;
    //outsideGameController gameManager;

    [SerializeField] GameObject gameManager;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float movementSpeed = 5f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void rotate_character_to_mouse()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.z));

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
    private void MoveToInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * movementSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.up * verticalInput * movementSpeed * Time.deltaTime, Space.World);
        bool isMoving = (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f);
        if(isMoving)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

    void check_if_picking_up_item_then_proceed()
    {
        if (Input.GetKeyDown(KeyCode.E) && isOnItemStation)
        {
            if(inventoryItems.Count<inventoryCapacity)
            {
                string item = currentItemStation.GetComponent<ItemStationController>().CreateItem();
                inventoryItems.Add(item);
                CanvasManager.GetComponent<outsideChangeUItext>().SpawnItemText(item);
                //gameManager.GetComponent<outsideGameController>().AddItemToStorage(item);
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) && isOnDroppingOfStation)
        {
            for(int i = 0; i < inventoryItems.Count; i++)
            {
                gameManager.GetComponent<outsideGameController>().AddItemToStorage(inventoryItems[i]);
            }
            CanvasManager.GetComponent<outsideChangeUItext>().DeleteItemTexts();
            inventoryItems.Clear();

        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(ItemStandTag))
        {
            isOnItemStation = true;
            currentItemStation = other.gameObject;
        }
        if (other.CompareTag(DroppingOfStationTag))
        {
            isOnDroppingOfStation = true;
            currentItemStation = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the collider is tagged as "Ground"
        if (other.CompareTag(ItemStandTag))
        {
            isOnItemStation = false;
            currentItemStation = null;
        }
        if (other.CompareTag(DroppingOfStationTag))
        {
            isOnDroppingOfStation = false;
            currentItemStation = null;
        }
    }

    public bool is_on_dropping_station()
    {
        return isOnDroppingOfStation;
    }

    void Update()
    {
        rotate_character_to_mouse();
        MoveToInput();
        check_if_picking_up_item_then_proceed();
        if(Input.GetKeyDown(KeyCode.Space)) {
            gameManager.GetComponent<outsideGameController>().end_scene();
        }
    }
}
