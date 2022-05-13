using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TaskList : MonoBehaviour
{
  //list object variables
  public GameObject DDEntry;
  public GameObject GoNoGoEntry;
  public GameObject StopSignalEntry;

  public Text UserInfoText; //shows participant info

  // default app startup
  void Start(){
      if(StateNameController.DD_task_complete) { DDEntry.SetActive(false); }
      else { DDEntry.SetActive(true); }
      if(StateNameController.GoNoGo_task_complete) { GoNoGoEntry.SetActive(false); }
      else { GoNoGoEntry.SetActive(true); }
      if(StateNameController.StopSignal_task_complete) { StopSignalEntry.SetActive(false); }
      else { StopSignalEntry.SetActive(true); }

      if(StateNameController.platform == "MTURK"){ UserInfoText.text = "Participant ID: " + StateNameController.MTURK_participant_ID; }
      else{}
  }
  
  public void OpenLogin(){
      SceneManager.LoadScene("LogInSystem");
  }

  public void OpenScene1(){
      SceneManager.LoadScene("DelayDiscounting");
  }

  public void OpenScene2(){
      SceneManager.LoadScene("GoNoGo");
  }

  public void OpenScene3(){
      SceneManager.LoadScene("StopSignal");
  }

  public void OpenTaskPage(){
      SceneManager.LoadScene("TaskListPage");
  }

  // Update is called once per frame
    void Update(){
        
    }
}
