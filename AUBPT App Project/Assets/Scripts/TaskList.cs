using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskList : MonoBehaviour
{
  public void OpenLogin(){
      SceneManager.LoadScene("LogInSystem");
  }

  public void OpenScene1(){
      SceneManager.LoadScene("DelayDiscounting");
  }

  public void OpenScene2(){
      SceneManager.LoadScene("Task2");
  }

  public void OpenScene3(){
      SceneManager.LoadScene("StopSignal");
  }

  public void OpenTaskPage(){
      SceneManager.LoadScene("TaskListPage");
  }
}
