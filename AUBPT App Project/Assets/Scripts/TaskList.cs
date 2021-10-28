using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskList : MonoBehaviour
{
  public void OpenLogin(){
      SceneManager.LoadScene("Scene1");
  }

  public void OpenScene1(){
      SceneManager.LoadScene("Task1");
  }

  public void OpenScene2(){
      SceneManager.LoadScene("Task2");
  }

  public void OpenScene3(){
      SceneManager.LoadScene("Task3");
  }

  public void OpenTaskPage(){
      SceneManager.LoadScene("TaskListPage");
  }
}
