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
public GameObject IncorrectResponsePanel;
public GameObject TrialBlockPanel;

public AudioSource audioSource;
public float delay;

private float waitTime;
public int numberTrials = 0;
public int totalTrials = 0;
public bool trial;
public int panel = 1;
public float reactionTime;
public float timeSinceStartup;

//public int correctResponse;
//public int incorrectResponse;
public List<List<bool>> correctness = new List<List<bool>>();

public bool result;
public bool pressed;

public string output;

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
    audioSource.PlayDelayed(delay);

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
    TrialBlockPanel.SetActive(false);
    timeSinceStartup = Time.time;

}


public void chooseNeither() {
  if (pressed == false) {
    List<bool> currCorrect = new List<bool>();
    currCorrect.Add(true);
    currCorrect.Add(result);
    correctness.Add(currCorrect);
    numberTrials++;
    totalTrials++;
    chooseTrue();
  }
}



public void chooseRight() {
  // If right or left button is true and result is true, then this is a wrong behavior
  // Transform function into a variable

  reactionTime = Time.time - timeSinceStartup;
  // Debug.Log(reactionTime);
  //
  listReactionTimes.Add(reactionTime);

  pressed = true;

  if (panel == 0) {
    TrialAlternate(true);
  }
  else {
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

  listReactionTimes.Add(reactionTime);
  pressed = true;

  if (panel == 1) {
    TrialAlternate(true);
  }
  else {
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
    TrialPanel1.SetActive(trial);
    TrialPanel2.SetActive(!trial);
    WhistleAudio();
  }
}

public void chooseFalse() {
  StartCoroutine(BadJob());

  IEnumerator BadJob() {
    yield return new WaitForSeconds(0);
    IncorrectResponsePanel.SetActive(true);
    yield return new WaitForSeconds((float)0.5);
    IncorrectResponsePanel.SetActive(false);
    TrialPanel1.SetActive(trial);
    TrialPanel2.SetActive(!trial);
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
  }


}

public void TrialAlternate(bool dir) {

  List<bool> currCorrect = new List<bool>();

  if (numberTrials <= 2) {
    trial =  Random.Range(0f, 1f) > 0.50;
    panel = trial ? 1 : 0;
    numberTrials++;
    totalTrials++;

    if (dir == true && result == false)  {
      timeSinceStartup = Time.time;
      currCorrect.Add(dir);
      currCorrect.Add(result);
      correctness.Add(currCorrect);
      chooseTrue();
      //TrialPanel1.SetActive(trial);
      //TrialPanel2.SetActive(!trial);
      //WhistleAudio();
    }
    if (dir == false && result == false)  {
      timeSinceStartup = Time.time;
      currCorrect.Add(dir);
      currCorrect.Add(result);
      correctness.Add(currCorrect);
      chooseFalse();
      //TrialPanel1.SetActive(trial);
      //TrialPanel2.SetActive(!trial);
      //WhistleAudio();
    }
    if (result == true && pressed == true)  {
      //timeSinceStartup = Time.time;
      currCorrect.Add(false);
      currCorrect.Add(result);
      correctness.Add(currCorrect);
      chooseFalse();
      //TrialPanel1.SetActive(trial);
      //TrialPanel2.SetActive(!trial);
      //WhistleAudio();
    }
    if (result == true && pressed == false)  {
      //timeSinceStartup = Time.time;
      currCorrect.Add(true);
      currCorrect.Add(result);
      correctness.Add(currCorrect);
      chooseTrue();
      //TrialPanel1.SetActive(trial);
      //TrialPanel2.SetActive(!trial);
    }

  }

  else {
    // string result = "List contents: ";
    // foreach (var item in listReactionTimes)
    // {
    //   result += item.ToString() + ", ";
    // }
    // Debug.Log(result);
    //Debug.Log(incorrectResponse);

    if (dir == true && result == false) {
        endOfBlock();
        currCorrect.Add(dir);
        currCorrect.Add(result);
        correctness.Add(currCorrect);
    }
    else if (result == true && pressed == false) {
        endOfBlock();
        currCorrect.Add(true);
        currCorrect.Add(result);
        correctness.Add(currCorrect);
    }
    else if (dir == false && result == false) {
        endOfBlockFalse();
        currCorrect.Add(dir);
        currCorrect.Add(result);
        correctness.Add(currCorrect);
    }
    else if (result == true && pressed == true) {
        currCorrect.Add(false);
        currCorrect.Add(result);
        correctness.Add(currCorrect);
        endOfBlockFalse();
    }
    else {
      TrialPanel1.SetActive(false);
      TrialPanel2.SetActive(false);
      TrialBlockPanel.SetActive(true);
    }

    string output = "List contents: ";
    foreach (var item in correctness)
    {
      string combinedString = string.Join( ",", item);
      output += combinedString + ", ";
    }
    Debug.Log(output);
    //Debug.Log(correctness);
    numberTrials = 0;
    panel = 1;
  }




}


//     }
// //
//     else {
//       // string result = "List contents: ";
//       // foreach (var item in listReactionTimes)
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

  result = Random.Range(0f, 1f) > 0.75; //%25 percent chance to be true

  System.Random random = new System.Random();
  double val = (random.NextDouble() * (0.234 - 0.069) + 0.069);
  delay = (float)val;
  // If clicked, it is wrong - if not clicked, it is right

  if (result) {
    audioSource.PlayDelayed(delay);
    StartCoroutine(StopSignalDelay());
    // TrialAlternate(true);
  }

  IEnumerator StopSignalDelay() {
    pressed = false;
    yield return new WaitForSeconds(3);
    chooseNeither();
    //TrialAlternate(true);
    //correctness.Add(totalTrials, dir, result);
    //chooseTrue();
    //TrialAlternate(true);
  }

  // Debug.Log(delay);
}





public void OpenTaskPage(){
      SceneManager.LoadScene("TaskListPage");
  }

}
