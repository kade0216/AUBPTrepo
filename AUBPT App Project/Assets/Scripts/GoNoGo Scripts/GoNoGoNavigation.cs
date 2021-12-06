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
	BeforeYouStart.SetActive(true);
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







    // // Start is called before the first frame update
    // void Start()
    // {
		//
    // }

    // Update is called once per frame
    void Update()
    {

    }
}
