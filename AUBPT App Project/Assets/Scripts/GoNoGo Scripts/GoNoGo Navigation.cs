using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
public GameObject ThankYou/EndingPage;

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


public void Instructions() {
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
	ThankYou/EndingPage.SetActive(false);
}

public void InstructionsContinued() {
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
	ThankYou/EndingPage.SetActive(false);
}

public void X() {
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
	ThankYou/EndingPage.SetActive(false);
}

public void Y() {
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
	ThankYou/EndingPage.SetActive(false);
}

public void CorrectPage() {
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
	ThankYou/EndingPage.SetActive(false);
}

public void IncorrectPage1() {
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
	ThankYou/EndingPage.SetActive(false);
}

public void IncorrectPage2() {
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
	ThankYou/EndingPage.SetActive(false);
}

public void Cross() {
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
	ThankYou/EndingPage.SetActive(false);
}

public void TrialBlock() {
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
	ThankYou/EndingPage.SetActive(false);
}

public void ThankYou/EndingPage() {
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
	ThankYou/EndingPage.SetActive(true);
}







    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
