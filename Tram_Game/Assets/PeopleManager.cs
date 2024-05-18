using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PeopleManager : MonoBehaviour
{
    public static PeopleManager Instance;
    GameObject sceneRoot;
    private Dictionary<int, GameObject> chairToUnsatisfiedPerson = new Dictionary<int, GameObject>();


    private void Start()
    {
        sceneRoot = FindObjectOfType<GameCoreInside>().gameObject;
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
    public void DisableAllUnsatisfiedPeople()
    {
        foreach (KeyValuePair<int, GameObject> entry in chairToUnsatisfiedPerson)
        {
            if (entry.Value != null)
            {
                entry.Value.SetActive(false);
            }
        }
    }

    public void EnableAllUnsatisfiedPeople()
    {
        foreach (KeyValuePair<int, GameObject> entry in chairToUnsatisfiedPerson)
        {
            if (entry.Value != null)
            {
                entry.Value.SetActive(true);
            }
        }
    }

    public bool hasId(int id)
    {
        return chairToUnsatisfiedPerson.ContainsKey(id);
    }

    public GameObject getPerson(int id)
    {
        return chairToUnsatisfiedPerson[id];
    }

    public void RegisterPerson(GameObject person, int id)
    {
        chairToUnsatisfiedPerson.Add(id, person);
        DontDestroyOnLoad(person);
    }

    public void DeregisterPerson(GameObject person, int id)
    {
        if (chairToUnsatisfiedPerson.ContainsKey(id))
        {
            chairToUnsatisfiedPerson.Remove(id);
        }
        DoDestroyOnLoad(person);
    }

    private void DoDestroyOnLoad(GameObject person)
    {
        // Find the root object of the current scene
        GameObject sceneRoot = new GameObject("SceneRoot");
        SceneManager.MoveGameObjectToScene(sceneRoot, SceneManager.GetActiveScene());
       // Debug.Log("DESTROY");
        // Reparent the person to the root of the current scene
        person.transform.SetParent(sceneRoot.transform);
    }
}
