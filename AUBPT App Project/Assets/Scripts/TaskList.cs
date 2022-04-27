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
  
  //task completion vars
  public bool DD_task_complete = false;
  //do same for other tasks

  // default app startup
  void Start(){
      DDEntry.SetActive(true);
      GoNoGoEntry.SetActive(true);
      StopSignalEntry.SetActive(true);

      //DD_task_complete = GameObject.Find("DDCanvas").GetComponent<DelayDiscountingBehavior>().task_complete;
      //do same for other tasks
      
      //if(DD_task_complete) { DDEntry.SetActive(false); }
      //do same for other tasks
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
