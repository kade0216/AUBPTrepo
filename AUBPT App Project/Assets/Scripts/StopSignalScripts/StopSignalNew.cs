using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopSignalNew : MonoBehaviour
{

//Create variables to tell which objects will be referenced
public GameObject Panel1;
public GameObject Panel2;
public GameObject Panel3;
public GameObject Panel4;
public GameObject Panel5;
public GameObject Panel6;
public GameObject Panel7;
public GameObject Panel7a;
public GameObject Panel8;

public GameObject FixationPointPanel;
public GameObject TrialPanel1;
public GameObject TrialPanel2;
public GameObject StopPanel1;
public GameObject StopPanel2;

public GameObject CorrectResponsePanel;
public GameObject IncorrectResponsePanel;
public GameObject TrialBlockPanel;

//public AudioSource audioSource;


public float delay;
// System.Random random = new System.Random();
public List<double> startTimes = new List<double>{0.1,0.2,0.3,0.4};
// System.Random random = new System.Random();
// public List<int> startTimes = new List<int>{100,200,300,400};
// public int index = random.Next(startTimes.Count);
// delay = (float)startTimes[index];

private float waitTime;
public int numberTrials = 0;
public int totalTrials = 0;
public bool trial;
public int panel = 1;
public float reactionTime;
public float timeSinceStartup;

//public int correctResponse;
//public int incorrectResponse;
//public List<List<bool>> correctness = new List<List<bool>>();
//public Dictionary<int, List<bool>> correctness = new Dictionary<int, List<bool>>();

public bool result;
public bool pressed;

public string output;

//public List<float> listReactionTimes = new List<float>();
//public Dictionary<int, float> listReactionTimes = new Dictionary<int, float>();




// default app startup
void Start() //login page launches when user starts app
{
    Panel1.SetActive(true);
    //set active false for other panels

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
    StartCoroutine(stopDemo());

    IEnumerator stopDemo() {
      yield return new WaitForSeconds(2);
      Panel7.SetActive(false);
      Panel7a.SetActive(true);
    }

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

public void TrialPanel(){

    Panel1.SetActive(false);
    Panel2.SetActive(false);
    Panel3.SetActive(false);
    Panel4.SetActive(false);
    Panel5.SetActive(false);
    Panel6.SetActive(false);
    Panel7.SetActive(false);
    Panel8.SetActive(false);
    TrialBlockPanel.SetActive(false);
    TrialPanel1.SetActive(trial);
    TrialPanel2.SetActive(!trial);
    if (trial == true) {
      panel = 1;
    }
    if (trial == false) {
      panel = 0;
    }
    timeSinceStartup = Time.time;

    System.Random random = new System.Random();
    int val = random.Next(0,4);
    delay = (float)startTimes[val];
}


public void chooseNeither() {
  if (pressed == false && numberTrials <= 10) {
    List<bool> currCorrect = new List<bool>();
    numberTrials++;
    totalTrials++;
    currCorrect.Add(true);
    currCorrect.Add(result);
    StateNameController.correctness.Add(totalTrials, currCorrect);
    delay += (float)0.05;
    trial =  Random.Range(0f, 1f) > 0.50;
    panel = trial ? 1 : 0;
    chooseTrue();
  }
  else {
    TrialAlternate(true);
  }
}



public void chooseRight() {
  // If right or left button is true and result is true, then this is a wrong behavior
  // Transform function into a variable

  reactionTime = Time.time - timeSinceStartup;
  // Debug.Log(reactionTime);
  //
  StateNameController.listReactionTimes.Add(totalTrials+1, reactionTime);

  pressed = true;

  if (panel == 0 && result == false) {
    TrialAlternate(true);
  }
  else if (panel == 1 && result == false) {
    TrialAlternate(false);
  }

  // if (result == true) {
  //   TrialAlternate(false);
  // }

  // if (result == false) {
  //   if (panel == 0) {
  //     //chooseTrue();
  //     TrialAlternate(true);
  //     correctResponse++;
  //
  //   }
  //
  //   else {
  //     TrialAlternate(false);
  //     incorrectResponse++;
  //   }
  // }


}

public void chooseLeft() {
  reactionTime = Time.time - timeSinceStartup;
  // Debug.Log(reactionTime);

  // Differentiate between right and wrong reaction time
  // Maybe a dictionary to store correct and incorrect responses
  // Key is the panel number and value is whether response is True or False
  // String correct or wrong

  StateNameController.listReactionTimes.Add(totalTrials+1, reactionTime);
  pressed = true;

  if (panel == 1 && result == false) {
    TrialAlternate(true);
  }
  else if (panel == 0 && result == false){
    TrialAlternate(false);
  }

  // if (result == true) {
  //   TrialAlternate(false);
  // }
  //
  // if (result == false) {
  //   if (panel == 1) {
  //     //chooseTrue();
  //     TrialAlternate(true);
  //     correctResponse++;
  //
  //   }
  //   else {
  //     TrialAlternate(false);
  //     incorrectResponse++;
  //   }
  // }


}

public void chooseTrue() {
  StartCoroutine(GoodJob());

  IEnumerator GoodJob() {
    yield return new WaitForSeconds(0);
    CorrectResponsePanel.SetActive(true);
    yield return new WaitForSeconds(1);
    CorrectResponsePanel.SetActive(false);
    // FixationPointPanel.SetActive(true);
    // yield return new WaitForSeconds(1);
    // FixationPointPanel.SetActive(false);
    TrialPanel1.SetActive(trial);
    TrialPanel2.SetActive(!trial);
    timeSinceStartup = Time.time;
    // delay += (float)0.05;
    WhistleAudio();
  }
}

public void chooseFalse() {
  StartCoroutine(BadJob());

  IEnumerator BadJob() {
    yield return new WaitForSeconds(0);
    IncorrectResponsePanel.SetActive(true);
    yield return new WaitForSeconds(1);
    IncorrectResponsePanel.SetActive(false);
    TrialPanel1.SetActive(trial);
    TrialPanel2.SetActive(!trial);
    timeSinceStartup = Time.time;
    // delay -= (float)0.05;
    WhistleAudio();
  }


}

public void endOfBlock() {
  StartCoroutine(endBlock());

  IEnumerator endBlock() {
    TrialPanel1.SetActive(false);
    TrialPanel2.SetActive(false);
    yield return new WaitForSeconds(0);
    CorrectResponsePanel.SetActive(true);
    yield return new WaitForSeconds(1);
    CorrectResponsePanel.SetActive(false);
    TrialBlockPanel.SetActive(true);
    StateNameController.StopSignal_task_complete = true;
  }
}

public void endOfBlockFalse() {
  StartCoroutine(endBlock());

  IEnumerator endBlock() {
    TrialPanel1.SetActive(false);
    TrialPanel2.SetActive(false);
    yield return new WaitForSeconds(0);
    IncorrectResponsePanel.SetActive(true);
    yield return new WaitForSeconds(1);
    IncorrectResponsePanel.SetActive(false);
    TrialBlockPanel.SetActive(true);
    StateNameController.StopSignal_task_complete = true;
  }


}

public void TrialAlternate(bool dir) {

  List<bool> currCorrect = new List<bool>();

  if (numberTrials <= 10) {
    trial =  Random.Range(0f, 1f) > 0.50;
    panel = trial ? 1 : 0;
    numberTrials++;
    totalTrials++;

    if (dir == true && result == false && pressed == true)  {
      //timeSinceStartup = Time.time;
      currCorrect.Add(dir);
      currCorrect.Add(result);
      StateNameController.correctness.Add(totalTrials, currCorrect);
      chooseTrue();
      //TrialPanel1.SetActive(trial);
      //TrialPanel2.SetActive(!trial);
      //WhistleAudio();
    }
    if (dir == false && result == false && pressed == true)  {
      //timeSinceStartup = Time.time;
      currCorrect.Add(dir);
      currCorrect.Add(result);
      StateNameController.correctness.Add(totalTrials, currCorrect);
      chooseFalse();
      //TrialPanel1.SetActive(trial);
      //TrialPanel2.SetActive(!trial);
      //WhistleAudio();
    }
    if (result == true && pressed == true)  {
      //timeSinceStartup = Time.time;
      currCorrect.Add(false);
      currCorrect.Add(result);
      StateNameController.correctness.Add(totalTrials, currCorrect);
      delay -= (float)0.05;
      chooseFalse();
      //TrialPanel1.SetActive(trial);
      //TrialPanel2.SetActive(!trial);
      //WhistleAudio();
    }
    if (result == true && pressed == false)  {
      //timeSinceStartup = Time.time;
      currCorrect.Add(true);
      currCorrect.Add(result);
      StateNameController.correctness.Add(totalTrials, currCorrect);
      chooseTrue();
      //TrialPanel1.SetActive(trial);
      //TrialPanel2.SetActive(!trial);
    }

  }

  else {
    // string result = "List contents: ";
    // foreach (var item in StateNameController.listReactionTimes)
    // {
    //   result += item.ToString() + ", ";
    // }
    // Debug.Log(result);
    //Debug.Log(incorrectResponse);
    numberTrials++;
    totalTrials++;

    if (dir == true && result == false) {
        endOfBlock();
        currCorrect.Add(dir);
        currCorrect.Add(result);
        StateNameController.correctness.Add(totalTrials, currCorrect);
    }
    else if (result == true && pressed == false) {
        endOfBlock();
        currCorrect.Add(true);
        currCorrect.Add(result);
        StateNameController.correctness.Add(totalTrials, currCorrect);
    }
    else if (dir == false && result == false) {
        endOfBlockFalse();
        currCorrect.Add(dir);
        currCorrect.Add(result);
        StateNameController.correctness.Add(totalTrials, currCorrect);
    }
    else if (result == true && pressed == true) {
        currCorrect.Add(false);
        currCorrect.Add(result);
        StateNameController.correctness.Add(totalTrials, currCorrect);
        endOfBlockFalse();
    }
    else {
      TrialPanel1.SetActive(false);
      TrialPanel2.SetActive(false);
      TrialBlockPanel.SetActive(true);
    }

    string output = "Correct contents: ";
    string combinedString;
    foreach (var item in StateNameController.correctness)
    {
      combinedString = item.Key + ": ";
      foreach (var it in item.Value) {
        combinedString += it + " ";
      }
      output += combinedString + ", ";
    }
    Debug.Log(output);
    //Debug.Log(StateNameController.correctness);

    // string reactions = "RT contents: ";
    // foreach (var item in StateNameController.listReactionTimes)
    // {
    //   reactions += item.ToString() + ", ";
    // }
    // Debug.Log(reactions);

    string reactions = "RT contents: ";
    string intermediate;
    foreach (var item in StateNameController.listReactionTimes)
    {
      intermediate = item.Key + ": ";
      intermediate += item.Value.ToString() + " ";
      reactions += intermediate + ", ";
    }
    Debug.Log(reactions);


    numberTrials = 0;
    panel = 1;
    trial =  Random.Range(0f, 1f) > 0.50;
  }




}


//     }
// //
//     else {
//       // string result = "List contents: ";
//       // foreach (var item in StateNameController.listReactionTimes)
//       // {
//       //   result += item.ToString() + ", ";
//       // }
//       //Debug.Log(result);
//       //Debug.Log(incorrectResponse);
//
//       if (dir == true) {
//           endOfBlock();
//       }
//       else {
//         TrialPanel1.SetActive(false);
//         TrialPanel2.SetActive(false);
//         TrialBlockPanel.SetActive(true);
//       }
//
//       numberTrials = 0;
//       panel = 1;
//     }
//     //Debug.Log(reactionTime);
// }


public void WhistleAudio() {

  result = Random.Range(0f, 1f) > 0.4; //%25 percent chance to be true


  // System.Random random = new System.Random();
  // double val = (random.NextDouble() * (0.234 - 0.069) + 0.069);
  // delay = (float)val;
  // If clicked, it is wrong - if not clicked, it is right

  if (result) {
    // audioSource.PlayDelayed(delay);
    StartCoroutine(StopSignalDelay());
    // TrialAlternate(true);
  }

  IEnumerator StopSignalDelay() {
    Debug.Log(delay);
    yield return new WaitForSeconds(delay);
    TrialPanel1.SetActive(false);
    TrialPanel2.SetActive(false);
    pressed = false;
    if (panel == 1) {
      StopPanel1.SetActive(true);
    }
    if (panel == 0) {
      StopPanel2.SetActive(true);
    }

    yield return new WaitForSeconds(3);
    StopPanel1.SetActive(false);
    StopPanel2.SetActive(false);

    chooseNeither();
    result = false;
    //TrialAlternate(true);
    //StateNameController.correctness.Add(totalTrials, dir, result);
    //chooseTrue();
    //TrialAlternate(true);
  }

  Debug.Log(delay);
}





public void OpenTaskPage(){
      SceneManager.LoadScene("TaskListPage");
  }

}
