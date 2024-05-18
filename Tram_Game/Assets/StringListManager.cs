using UnityEngine;
using System.Collections.Generic;

public class StringListManager : MonoBehaviour
{
    // Static reference to this script instance
    public static StringListManager instance;

    // List of strings to be transferred between scenes
    public List<string> stringList = new List<string>();

    public int score = 0;

    // Awake is called before Start functions
    void Awake()
    {
        // Ensure there is only one instance of this script
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this GameObject persistent between scenes
        }
        else
        {
            Destroy(gameObject); // If another instance exists, destroy this one
        }
    }

    // Method to add a string to the list
    public void Add(string newString)
    {
        stringList.Add(newString);
    }

    // Method to remove a string from the list
    public void Remove(string stringToRemove)
    {
        stringList.Remove(stringToRemove);
    }
    public void Clear()
    {
        stringList.Clear();
        score = 0;
    }

    public bool Contains(string item)
    {
        return stringList.Contains(item);
    }

    public int Count()
    {
       return stringList.Count;
    }

    // Method to clear the list
    public void ClearList()
    {
        stringList.Clear();
    }
}
