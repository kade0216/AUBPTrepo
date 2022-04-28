using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginNavegation : MonoBehaviour
{

//Create variables to tell which objects will be referenced
public GameObject LoginPage;
public GameObject ForgotPage;
public GameObject ImPage;
public GameObject SignUpParticipant;
public GameObject SignUpClinician;
    
    
    
// default app startup
void Start() //login page launches when user starts app
{
    LoginPage.SetActive(true);

    //setting compeltion vars for tasks
    StateNameController.DD_task_complete = false;
    StateNameController.GoNoGo_task_complete = false;
    StateNameController.StopSignal_task_complete = false;
}

public void WhoIm(){ 

    ImPage.SetActive(true);
    LoginPage.SetActive(false);
    ForgotPage.SetActive(false);
    SignUpParticipant.SetActive(false);
    SignUpClinician.SetActive(false);

}

public void CreateAccountClinician(){

    SignUpClinician.SetActive(true);
    ImPage.SetActive(false);
    LoginPage.SetActive(false);
    ForgotPage.SetActive(false);
    SignUpParticipant.SetActive(false);
    

}

public void CreateAccountParticipant(){

    SignUpParticipant.SetActive(true);
    SignUpClinician.SetActive(false);
    ImPage.SetActive(false);
    LoginPage.SetActive(false);
    ForgotPage.SetActive(false);
    

}

public void ForgotMyLogin(){

    ForgotPage.SetActive(true);
    SignUpParticipant.SetActive(false);
    SignUpClinician.SetActive(false);
    ImPage.SetActive(false);
    LoginPage.SetActive(false);
    

}

public void GoBackLoginPge(){
    
    LoginPage.SetActive(true);
    ImPage.SetActive(false);    
    ForgotPage.SetActive(false);
    SignUpParticipant.SetActive(false);
    SignUpClinician.SetActive(false);

}

public void OpenTaskPage(){
      SceneManager.LoadScene("TaskListPage");
  }

}
