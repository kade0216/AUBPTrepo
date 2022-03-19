using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayDiscountingBehavior : MonoBehaviour
{
    //panel variables
    public GameObject WelcomePanel;
    public GameObject InstructionsPanel;
    public GameObject GamePanelChoosing;
    public GameObject GamePanelResting;
    public GameObject EndPanel;

    //game variables
    public int adj_amount = 250;
    public int trial = 0;
    public int delay = 0;
    public int imm_amount = 500;
    public int delayed_amount = 1000;//fixed for now
    public boolean imm_side;//0 == left, 1 == right
    //^^randomize this, either 0 or 1
    public boolean user_selection;//0 == left, 1 == right

    //exported user data variables
    public int[] indifference_points = new int[7];//index is based on delay var
    /*
    0 == 1 day
    1 == 1 week
    2 == 1 month
    3 == 6 months
    4 == 1 years
    5 == 5 years
    6 == 25 years*/

    /*public int value_1day;
    public int value_1week;
    public int value_1mo;
    public int value_6mo;
    public int value_1yr;
    public int value_5yr;
    public int value_25yr;*/
    
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

    public void LoadNextTrial(){
        OpenGamePanelResting();
        trial ++;
        if(user_selection == imm_side){
            indifference_points[delay] = imm_amount;
        }
        if(trial == 5){
            if(delay == 6) {
                //end game
            }
            delay++;
            trial = 0;
            imm_amount = 500;
            adj_amount = 250;
        }
        else{
            if(user_selection == imm_side){
                imm_amount -= adj_amount;
            }
            else{
                imm_amount += adj_amount;
            }
            adj_amount /= 2;
        }
        imm_side = 1;//randomize this, either 0 and 1
        UpdateText();
        //rest time -- figure this out
        OpenGamePanelChoosing();
    }
    
    public void LeftPressed(){
        user_selection = false;
        LoadNextTrial();
    }

    public void RightPressed(){
        user_selection = true;
        LoadNextTrial();
    }

    public void UpdateText(){
        //figure this out
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
