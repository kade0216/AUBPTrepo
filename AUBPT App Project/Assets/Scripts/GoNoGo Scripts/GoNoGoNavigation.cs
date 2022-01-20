using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNoGoNavigation : MonoBehaviour
{

//Create variables to tell which objects will be referenced
public GameObject BeforeYouStart;
public GameObject Instructions;
public GameObject InstructionsContinued;
public GameObject X;
public GameObject Y;
public GameObject CorrectPage;
public GameObject IncorrectPage1;
public GameObject IncorrectPage2;
public GameObject Cross;
public GameObject TrialBlock;
public GameObject EndingPage;

private float waitTime;
public int numberTrials = 0;
public int totalTrials = 0;
public int blockNumber = 1;
public bool trial;
public int panel = 1;
public float reactionTime;
public float timeSinceStartup;

public int correctResponse;
public int incorrectResponse;
public List<List<bool>> correctness = new List<List<bool>>();
public Dictionary<int, List<bool>> correctness = new Dictionary<int, List<bool>>();

public bool result;
public bool pressed;

public string output;

// public List<float> listReactionTimes = new List<float>();
public Dictionary<int, float> listReactionTimes = new Dictionary<int, float>();





// default app startup
void Start() //login page launches when user starts app
{
	BeforeYouStart.SetActive(true);
}

public void BeforeYouStartPage() {
	BeforeYouStart.SetActive(true);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(false);
	X.SetActive(false);
	Y.SetActive(false);
	CorrectPage.SetActive(false);
	IncorrectPage1.SetActive(false);
	IncorrectPage2.SetActive(false);
	Cross.SetActive(false);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(false);
}

public void InstructionsPage() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(true);
	InstructionsContinued.SetActive(false);
	X.SetActive(false);
	Y.SetActive(false);
	CorrectPage.SetActive(false);
	IncorrectPage1.SetActive(false);
	IncorrectPage2.SetActive(false);
	Cross.SetActive(false);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(false);
}

public void InstructionsContinuedPage() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(true);
	X.SetActive(false);
	Y.SetActive(false);
	CorrectPage.SetActive(false);
	IncorrectPage1.SetActive(false);
	IncorrectPage2.SetActive(false);
	Cross.SetActive(false);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(false);
}

public void XPage() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(false);
	X.SetActive(true);
	Y.SetActive(false);
	CorrectPage.SetActive(false);
	IncorrectPage1.SetActive(false);
	IncorrectPage2.SetActive(false);
	Cross.SetActive(false);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(false);
}

public void YPage() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(false);
	X.SetActive(false);
	Y.SetActive(true);
	CorrectPage.SetActive(false);
	IncorrectPage1.SetActive(false);
	IncorrectPage2.SetActive(false);
	Cross.SetActive(false);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(false);
}

public void Correct() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(false);
	X.SetActive(false);
	Y.SetActive(false);
	CorrectPage.SetActive(true);
	IncorrectPage1.SetActive(false);
	IncorrectPage2.SetActive(false);
	Cross.SetActive(false);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(false);
}

public void Incorrect1() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(false);
	X.SetActive(false);
	Y.SetActive(false);
	CorrectPage.SetActive(false);
	IncorrectPage1.SetActive(true);
	IncorrectPage2.SetActive(false);
	Cross.SetActive(false);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(false);
}

public void Incorrect2() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(false);
	X.SetActive(false);
	Y.SetActive(false);
	CorrectPage.SetActive(false);
	IncorrectPage1.SetActive(false);
	IncorrectPage2.SetActive(true);
	Cross.SetActive(false);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(false);
}

public void CrossPage() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(false);
	X.SetActive(false);
	Y.SetActive(false);
	CorrectPage.SetActive(false);
	IncorrectPage1.SetActive(false);
	IncorrectPage2.SetActive(false);
	Cross.SetActive(true);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(false);
}

public void TrialBlockPage() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(false);
	X.SetActive(false);
	Y.SetActive(false);
	CorrectPage.SetActive(false);
	IncorrectPage1.SetActive(false);
	IncorrectPage2.SetActive(false);
	Cross.SetActive(false);
	TrialBlock.SetActive(true);
	EndingPage.SetActive(false);
}

public void Ending() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(false);
	X.SetActive(false);
	Y.SetActive(false);
	CorrectPage.SetActive(false);
	IncorrectPage1.SetActive(false);
	IncorrectPage2.SetActive(false);
	Cross.SetActive(false);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(true);
}





// public void chooseSceneGivenX(){
//	int prob  = rnd.Next(1, 11); // creates number between 1 and 10
//	if (prob < 8)
// {
//		XPage();
// }
// 	if (prob > 8)
// {
//		YPage();	
// }
// 	}


// public void Update()
// {
//	if(Input.GetMouseButtonDown(0))
//	{
//		if (EventSystem.current.IsPointerOverGameObject())
//			return;
//
//		Ray ray = Camera.main.ScreenPointToRay(Input.MousePosition);
//		RaycastHit hitInfo;
//}
//} 



    // // Start is called before the first frame update
    // void Start()
    // {
		//
    // }

    // Update is called once per frame
//    void Update()
//    {

//    }
// }


public void chooseTrue() {
   Start Coroutine(GoodJob());

   IEnumerator GoodJob () {
      yield return new WaitForSeconds(0);
      CorrectPage.SetActive(true);
      Yield return new WaitForSeconds(1);
      CorrectPage.SetActive(false);
      timeSinceStartup = Time.time;
   }
} 

public void chooseFalse1() {
   StartCoroutine(BadJob());

   IEnumerator BadJob() {
      yield return WaitForSeconds(0);
      IncorrectPage1.SetActive(true);
      yield return new WaitForSeconds((float)0.5);
      IncorrectPage1.SetActive(false);
      timeSinceStartup = Time.time;
   }
}

public void chooseFalse2() {
   StartCoroutine(BadJob());

   IEnumerator BadJob() {
      yield return WaitForSeconds(0);
      IncorrectPage2.SetActive(true);
      yield return new WaitForSeconds((float)0.5);
      IncorrectPage2.SetActive(false);
      timeSinceStartup = Time.time;
   }
}

public void endOfBlock() {
  StartCoroutine(endBlock());

  IEnumerator endBlock() {
    yield return new WaitForSeconds(1);
    TrialBlock.SetActive(true);
  }
}

public void endOfGame() {
  StartCoroutine(endGame());

  IEnumerator endGame() {
    yield return new WaitForSeconds(1);
    EndingPage.SetActive(true);
  }
}














public void TrialAlternate(bool dir) {

  List<bool> currCorrect = new List<bool>();

  if (numberTrials <= 2) {
    trial =  Random.Range(0f, 1f) > 0.50;
    panel = trial ? 1 : 0;
    numberTrials++;
    totalTrials++;

    if (dir == true && result == false && pressed == true)  {
      //timeSinceStartup = Time.time;
      currCorrect.Add(dir);
      currCorrect.Add(result);
      correctness.Add(totalTrials, currCorrect);
      chooseTrue();
      //TrialPanel1.SetActive(trial);
      //TrialPanel2.SetActive(!trial);

    }
    if (dir == false && result == false && pressed == true)  {
      //timeSinceStartup = Time.time;
      currCorrect.Add(dir);
      currCorrect.Add(result);
      correctness.Add(totalTrials, currCorrect);
      chooseFalse();
      //TrialPanel1.SetActive(trial);
      //TrialPanel2.SetActive(!trial);

    }
    if (result == true && pressed == true)  {
      //timeSinceStartup = Time.time;
      currCorrect.Add(false);
      currCorrect.Add(result);
      correctness.Add(totalTrials, currCorrect);
      chooseFalse();
      //TrialPanel1.SetActive(trial);
      //TrialPanel2.SetActive(!trial);
    }
    if (result == true && pressed == false)  {
      //timeSinceStartup = Time.time;
      currCorrect.Add(true);
      currCorrect.Add(result);
      correctness.Add(totalTrials, currCorrect);
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
    numberTrials++;
    totalTrials++;

    if (dir == true && result == false) {
        endOfBlock();
        currCorrect.Add(dir);
        currCorrect.Add(result);
        correctness.Add(totalTrials, currCorrect);
    }
    else if (result == true && pressed == false) {
        endOfBlock();
        currCorrect.Add(true);
        currCorrect.Add(result);
        correctness.Add(totalTrials, currCorrect);
    }
    else if (dir == false && result == false) {
        endOfBlockFalse();
        currCorrect.Add(dir);
        currCorrect.Add(result);
        correctness.Add(totalTrials, currCorrect);
    }
    else if (result == true && pressed == true) {
        currCorrect.Add(false);
        currCorrect.Add(result);
        correctness.Add(totalTrials, currCorrect);
        endOfBlockFalse();
    }
    else {
      TrialPanel1.SetActive(false);
      TrialPanel2.SetActive(false);
      TrialBlockPanel.SetActive(true);
    }

    string output = "Correct contents: ";
    string combinedString;
    foreach (var item in correctness)
    {
      combinedString = item.Key + ": ";
      foreach (var it in item.Value) {
        combinedString += it + " ";
      }
      output += combinedString + ", ";
    }
    Debug.Log(output);
    //Debug.Log(correctness);

    // string reactions = "RT contents: ";
    // foreach (var item in listReactionTimes)
    // {
    //   reactions += item.ToString() + ", ";
    // }
    // Debug.Log(reactions);

    string reactions = "RT contents: ";
    string intermediate;
    foreach (var item in listReactionTimes)
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












public void OpenTaskPage(){
      SceneManager.LoadScene("TaskListPage");
  }
}
