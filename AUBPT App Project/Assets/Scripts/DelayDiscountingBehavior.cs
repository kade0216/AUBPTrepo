using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayDiscountingBehavior : MonoBehaviour
{
    //Create variables to tell which objects will be referenced
    public GameObject WelcomePanel;
    public GameObject InstructionsPanel;
    public GameObject GamePanelChoosing;
    public GameObject GamePanelResting;
    public GameObject EndPanel;
    
    // default app startup
    void Start() //login page launches when user starts app
    {
        WelcomePanel.SetActive(true);
        InstructionsPanel.SetActive(false);
        GamePanelChoosing.SetActive(false);
        GamePanelResting.SetActive(false);
        EndPanel.SetActive(false);
    }

    public void OpenTaskPage(){
        SceneManager.LoadScene("TaskListPage");
    }

    public void OpenInstructionsPanel(){
        InstructionsPanel.SetActive(true);
        WelcomePanel.SetActive(false);
        GamePanelChoosing.SetActive(false);
        GamePanelResting.SetActive(false);
        EndPanel.SetActive(false);
    }

    public void OpenGamePanelChoosing(){
        GamePanelChoosing.SetActive(true);
        WelcomePanel.SetActive(false);
        InstructionsPanel.SetActive(false);
        GamePanelResting.SetActive(false);
        EndPanel.SetActive(false);
    }

    public void OpenGamePanelResting(){
        GamePanelResting.SetActive(true);
        WelcomePanel.SetActive(false);
        InstructionsPanel.SetActive(false);
        GamePanelChoosing.SetActive(false);
        EndPanel.SetActive(false);
    }

    public void OpenEndPanel(){
        EndPanel.SetActive(true);
        WelcomePanel.SetActive(false);
        InstructionsPanel.SetActive(false);
        GamePanelChoosing.SetActive(false);
        GamePanelResting.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
