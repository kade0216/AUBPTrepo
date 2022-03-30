using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DelayDiscountingBehavior : MonoBehaviour
{
    //panel variables
    public GameObject WelcomePanel;
    public GameObject InstructionsPanel;
    public GameObject GamePanelChoosing;
    public GameObject GamePanelResting;
    public GameObject EndPanel;
    public Text LeftText;
    public Text RightText;

    //game variables
    public int adj_amount = 250;
    public int trial = 0;
    public int delay = 0;
    public int imm_amount = 500;
    public int delayed_amount = 1000;//fixed for now
    public bool random;
    public int imm_side; //0 == left, 1 == right
    //^^randomize this, either 0 or 1
    public int user_selection;//0 == left, 1 == right

    //exported user data variables
    public float[] indifference_points = {1000,1000,1000,1000,1000,1000,1000};
    /*delay var + indiff index meanings:
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
        random = Random.Range(0f, 1f) > 0.50;
        imm_side = random ? 0 : 1;
        UpdateText();
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
                OpenEndPanel();
                return;
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
        random = Random.Range(0f, 1f) > 0.50;
        imm_side = random ? 0 : 1;
        //for boolean values: Random.Range(0f, 1f) > 0.50;
        //for int: Random.Range(0, 1); do i have to cast as int?
        UpdateText();
        StartCoroutine(RestPanelDelay());
        IEnumerator RestPanelDelay(){
            yield return new WaitForSeconds(1);
            OpenGamePanelChoosing();
            }
    }
    
    public void LeftPressed(){
        user_selection = 0;
        LoadNextTrial();
    }

    public void RightPressed(){
        user_selection = 1;
        LoadNextTrial();
    }

    public void UpdateText(){
        string imm_text = "$" + imm_amount.ToString() + " NOW";
        string delayed_text = "$" + delayed_amount.ToString() + " in ";
        if(delay == 0) { delayed_text += "1 DAY"; }
        else if(delay == 1) { delayed_text += "1 WEEK"; }
        else if(delay == 2) { delayed_text += "1 MONTH"; }
        else if(delay == 3) { delayed_text += "6 MONTHS"; }
        else if(delay == 4) { delayed_text += "1 YEAR"; }
        else if(delay == 5) { delayed_text += "5 YEARS"; }
        else { delayed_text += "25 YEARS"; }
        if(imm_side == 1){
            LeftText.text = delayed_text;
            RightText.text = imm_text;
        }
        else{
            LeftText.text = imm_text;
            RightText.text = delayed_text;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
