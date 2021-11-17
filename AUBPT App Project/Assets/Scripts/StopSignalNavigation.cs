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
public GameObject Panel6;
public GameObject Panel7;
public GameObject Panel8;

public GameObject TrialPanel1;
public GameObject TrialPanel2;

public GameObject CorrectResponsePanel;

private float waitTime;
public int numberTrials = 0;
public bool trial;
public int panel = 1;
public float reactionTime;
public float timeSinceStartup;

public List<float> listReactionTimes = new List<float>();




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
    Panel6.SetActive(false);
    Panel7.SetActive(false);
    Panel8.SetActive(false);

}

public void PanelThree(){

    Panel1.SetActive(false);
    Panel2.SetActive(false);
    Panel3.SetActive(true);
    Panel4.SetActive(false);
    Panel5.SetActive(false);
    Panel6.SetActive(false);
    Panel7.SetActive(false);
    Panel8.SetActive(false);

}

public void PanelFour(){

    Panel1.SetActive(false);
    Panel2.SetActive(false);
    Panel3.SetActive(false);
    Panel4.SetActive(true);
    Panel5.SetActive(false);
    Panel6.SetActive(false);
    Panel7.SetActive(false);
    Panel8.SetActive(false);

}

public void PanelFive(){

    Panel1.SetActive(false);
    Panel2.SetActive(false);
    Panel3.SetActive(false);
    Panel4.SetActive(false);
    Panel5.SetActive(true);
    Panel6.SetActive(false);
    Panel7.SetActive(false);
    Panel8.SetActive(false);

}

public void PanelSix(){

    Panel1.SetActive(false);
    Panel2.SetActive(false);
    Panel3.SetActive(false);
    Panel4.SetActive(false);
    Panel5.SetActive(false);
    Panel6.SetActive(true);
    Panel7.SetActive(false);
    Panel8.SetActive(false);

}

public void PanelSeven(){

    Panel1.SetActive(false);
    Panel2.SetActive(false);
    Panel3.SetActive(false);
    Panel4.SetActive(false);
    Panel5.SetActive(false);
    Panel6.SetActive(false);
    Panel7.SetActive(true);
    Panel8.SetActive(false);

}

public void PanelEight(){

    Panel1.SetActive(false);
    Panel2.SetActive(false);
    Panel3.SetActive(false);
    Panel4.SetActive(false);
    Panel5.SetActive(false);
    Panel6.SetActive(false);
    Panel7.SetActive(false);
    Panel8.SetActive(true);

}

public void TrialPanelOne(){

    Panel1.SetActive(false);
    Panel2.SetActive(false);
    Panel3.SetActive(false);
    Panel4.SetActive(false);
    Panel5.SetActive(false);
    Panel6.SetActive(false);
    Panel7.SetActive(false);
    Panel8.SetActive(false);
    TrialPanel1.SetActive(true);

}


// private void Start() {
//     StartCoroutine(InfiniteLoop());
// }
// private IEnumerator InfiniteLoop()
//     {
//         waitTime = Random.Range(1, 3);
//     while (true){
//         # yield return new WaitForSeconds(waitTime);
//         Panel6.SetActive(true);
//         Panel5.SetActive(false);
//         # yield return new WaitForSeconds(waitTime);
//         Panel5.SetActive(true);
//         Panel6.SetActive(false);
//         }
//
//     }

public void chooseRight() {
  reactionTime = Time.time - timeSinceStartup;
  Debug.Log(reactionTime);
  listReactionTimes.Add(reactionTime);

  if (panel == 0) {
    TrialAlternate(true);
  }
  else {
    TrialAlternate(false);
  }

}

public void chooseLeft() {
  reactionTime = Time.time - timeSinceStartup;
  Debug.Log(reactionTime);
  listReactionTimes.Add(reactionTime);

  if (panel == 1) {
    TrialAlternate(true);
  }
  else {
    TrialAlternate(false);
  }
}


public void TrialAlternate(bool dir) {
    if (numberTrials <= 5) {
      trial =  Random.Range(0f, 1f) > 0.50;
      panel = trial ? 1 : 0;
      // reactionTime = Time.time;


      if (dir == true) {
        // yield return new WaitForSeconds(2);
        StartCoroutine(GoodJob());

        IEnumerator GoodJob() {
          yield return new WaitForSeconds(0);
          CorrectResponsePanel.SetActive(true);
          yield return new WaitForSeconds(1);
          CorrectResponsePanel.SetActive(false);
          TrialPanel1.SetActive(trial);
          TrialPanel2.SetActive(!trial);
          timeSinceStartup = Time.time;
        }
      }

      if (dir == false) {

        TrialPanel1.SetActive(trial);
        TrialPanel2.SetActive(!trial);
        timeSinceStartup = Time.time;

        //yield return new WaitForSeconds(2);
        //CorrectResponsePanel.SetActive(true);
      }

      numberTrials++;
    }

    else {
      string result = "List contents: ";
      foreach (var item in listReactionTimes)
      {
        result += item.ToString() + ", ";
      }
      Debug.Log(result);
    }
    //Debug.Log(reactionTime);
}


public void whistleAudio() {

  bool result = Random.Range(0f, 1f) > 0.75; //%25 percent chance to be true
  Debug.Log(result);
}





public void OpenTaskPage(){
      SceneManager.LoadScene("TaskListPage");
  }

}
