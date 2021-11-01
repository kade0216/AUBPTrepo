using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopSignalNavigation : MonoBehaviour
{

//Create variables to tell which objects will be referenced
public GameObject Panel1;
public GameObject Panel2;
public GameObject Panel3;
public GameObject Panel4;
public GameObject Panel5;



// default app startup
void Start() //login page launches when user starts app
{
    Panel1.SetActive(true);

}

public void PanelTwo(){

    Panel1.SetActive(false);
    Panel2.SetActive(true);
    Panel3.SetActive(false);
    Panel4.SetActive(false);
    Panel5.SetActive(false);

}

public void PanelThree(){

    Panel1.SetActive(false);
    Panel2.SetActive(false);
    Panel3.SetActive(true);
    Panel4.SetActive(false);
    Panel5.SetActive(false);

}

public void PanelFour(){

    Panel1.SetActive(false);
    Panel2.SetActive(false);
    Panel3.SetActive(false);
    Panel4.SetActive(true);
    Panel5.SetActive(false);

}

public void PanelFive(){

    Panel1.SetActive(false);
    Panel2.SetActive(false);
    Panel3.SetActive(false);
    Panel4.SetActive(false);
    Panel5.SetActive(true);

}

public void OpenTaskPage(){
      SceneManager.LoadScene("TaskListPage");
  }

}
