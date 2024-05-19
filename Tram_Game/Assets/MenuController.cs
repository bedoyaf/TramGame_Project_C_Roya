using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public string startScene;

    bool showing_inside = true;
    public GameObject Menu;
    public GameObject Tutorial;
    public GameObject TutorialOutside;
    public GameObject TutorialInside;
    void Start()
    {

    }

    public void start_button_click()
    {
        SceneManager.LoadScene(startScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void show_tutorial()
    {
        showing_inside=true;
        TutorialOutside.SetActive(false);
        TutorialInside.SetActive(true);
        Menu.SetActive(false);
        Tutorial.SetActive(true);
    }
    public void hide_tutorial() {
        showing_inside = true;
        TutorialOutside.SetActive(false);
        TutorialInside.SetActive(false);
        Menu.SetActive(true);
        Tutorial.SetActive(false);
    }
    public void switch_to_inside_or_outside()
    {
        if(showing_inside)
        {
            showing_inside=false;
            TutorialOutside.SetActive(true);
            TutorialInside.SetActive(false);
        }
        else
        {
            showing_inside = true;
            TutorialOutside.SetActive(false);
            TutorialInside.SetActive(true);
        }
    }
}
