using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskList : MonoBehaviour
{
  //list object variables
  public GameObject DDEntry;
  public GameObject GoNoGoEntry;
  public GameObject StopSignalEntry;

  // default app startup
  void Start(){
      if(StateNameController.DD_task_complete) {
          DDEntry.SetActive(false);
          //remove below stuff, just using to test
          Debug.Log("0: "+StateNameController.indifference_points[0]);
          Debug.Log("1: "+StateNameController.indifference_points[1]);
          Debug.Log("2: "+StateNameController.indifference_points[2]);
          Debug.Log("3: "+StateNameController.indifference_points[3]);
          Debug.Log("4: "+StateNameController.indifference_points[4]);
          Debug.Log("5: "+StateNameController.indifference_points[5]);
          Debug.Log("6: "+StateNameController.indifference_points[6]);
          }
      else { DDEntry.SetActive(true); }
      if(StateNameController.GoNoGo_task_complete) { GoNoGoEntry.SetActive(false); }
      else { GoNoGoEntry.SetActive(true); }
      if(StateNameController.StopSignal_task_complete) { StopSignalEntry.SetActive(false); }
      else { StopSignalEntry.SetActive(true); }
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
