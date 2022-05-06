using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNoGoNavigation : MonoBehaviour
{

// panel variables
public GameObject BeforeYouStart;
public GameObject Instructions;
public GameObject InstructionsContinued;
public GameObject X;
public GameObject Y;
public GameObject TwoInARow;
public GameObject Different;
public GameObject Cross;
public GameObject TrialBlock;
public GameObject EndingPage;
public GameObject StartRealTrials;
public GameObject TrialBlockTwo;
public GameObject XPractice;
public GameObject YPractice;

// game variables
private float waitTime;
public int totalTrials = 0;
public int blockNumber = 1;
public bool trial;
public int practice = 0;
public int panel = 1;
public int block = 0;
public float reactionTime;
public float timeSinceStartup;
public int xcount = 0;
public int ycount = 0;

public int correctResponse;
public int incorrectResponse;
public List<int> Correct = new List<int>();
List<int> Incorrect = new List<int>();

public bool result;
public bool pressed;

public string output;

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
	TwoInARow.SetActive(false);
	Different.SetActive(false);
	Cross.SetActive(false);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(false);
	StartRealTrials.SetActive(false);
	XPractice.SetActive(false);
	YPractice.SetActive(false);
}

public void InstructionsPage() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(true);
	InstructionsContinued.SetActive(false);
	X.SetActive(false);
	Y.SetActive(false);
	TwoInARow.SetActive(false);
	Different.SetActive(false);
	Cross.SetActive(false);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(false);
	StartRealTrials.SetActive(false);
	XPractice.SetActive(false);
	YPractice.SetActive(false);
}

public void InstructionsContinuedPage() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(true);
	X.SetActive(false);
	Y.SetActive(false);
	TwoInARow.SetActive(false);
	Different.SetActive(false);
	Cross.SetActive(false);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(false);
	StartRealTrials.SetActive(false);
	XPractice.SetActive(false);
	YPractice.SetActive(false);
}

public void XPage() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(false);
	X.SetActive(true);
	Y.SetActive(false);
	TwoInARow.SetActive(false);
	Different.SetActive(false);
	Cross.SetActive(false);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(false);
	StartRealTrials.SetActive(false);
	XPractice.SetActive(false);
	YPractice.SetActive(false);
}

public void YPage() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(false);
	X.SetActive(false);
	Y.SetActive(true);
	TwoInARow.SetActive(false);
	Different.SetActive(false);
	Cross.SetActive(false);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(false);
	StartRealTrials.SetActive(false);
	XPractice.SetActive(false);
	YPractice.SetActive(false);
}


public void CrossPage() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(false);
	X.SetActive(false);
	Y.SetActive(false);
	TwoInARow.SetActive(false);
	Different.SetActive(false);
	Cross.SetActive(true);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(false);
	StartRealTrials.SetActive(false);
	XPractice.SetActive(false);
	YPractice.SetActive(false);
}

public void TrialBlockPage() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(false);
	X.SetActive(false);
	Y.SetActive(false);
	TwoInARow.SetActive(false);
	Different.SetActive(false);
	Cross.SetActive(false);
	TrialBlock.SetActive(true);
	EndingPage.SetActive(false);
	StartRealTrials.SetActive(false);
	XPractice.SetActive(false);
	YPractice.SetActive(false);
}

public void TrialBlockTwoPage() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(false);
	X.SetActive(false);
	Y.SetActive(false);
	TwoInARow.SetActive(false);
	Different.SetActive(false);
	Cross.SetActive(false);
	TrialBlock.SetActive(false);
	TrialBlockTwo.SetActive(true);
	EndingPage.SetActive(false);
	StartRealTrials.SetActive(false);
	XPractice.SetActive(false);
	YPractice.SetActive(false);
}

public void Ending() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(false);
	X.SetActive(false);
	Y.SetActive(false);
	TwoInARow.SetActive(false);
	Different.SetActive(false);
	Cross.SetActive(false);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(true);
	StartRealTrials.SetActive(false);
	XPractice.SetActive(false);
	YPractice.SetActive(false);

	StateNameController.GoNoGo_task_complete = true;
}

public void TwoInARowPage() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(false);
	X.SetActive(false);
	Y.SetActive(false);
	TwoInARow.SetActive(true);
	Different.SetActive(false);
	Cross.SetActive(false);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(false);
	StartRealTrials.SetActive(false);
	XPractice.SetActive(false);
	YPractice.SetActive(false);
}

public void DifferentPage() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(false);
	X.SetActive(false);
	Y.SetActive(false);
	TwoInARow.SetActive(false);
	Different.SetActive(true);
	Cross.SetActive(false);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(false);
	StartRealTrials.SetActive(false);
	XPractice.SetActive(false);
	YPractice.SetActive(false);
}

public void StartRealTrialsPage() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(false);
	X.SetActive(false);
	Y.SetActive(false);
	TwoInARow.SetActive(false);
	Different.SetActive(false);
	Cross.SetActive(false);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(false);
	StartRealTrials.SetActive(true);
	XPractice.SetActive(false);
	YPractice.SetActive(false);
}

public void XPracticePage() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(false);
	X.SetActive(false);
	Y.SetActive(false);
	TwoInARow.SetActive(false);
	Different.SetActive(false);
	Cross.SetActive(false);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(false);
	StartRealTrials.SetActive(false);
	XPractice.SetActive(true);
	YPractice.SetActive(false);
}

public void YPracticePage() {
	BeforeYouStart.SetActive(false);
	Instructions.SetActive(false);
	InstructionsContinued.SetActive(false);
	X.SetActive(false);
	Y.SetActive(false);
	TwoInARow.SetActive(false);
	Different.SetActive(false);
	Cross.SetActive(false);
	TrialBlock.SetActive(false);
	EndingPage.SetActive(false);
	StartRealTrials.SetActive(false);
	XPractice.SetActive(false);
	YPractice.SetActive(true);
}

public void clickCorrect() {
  reactionTime = Time.time - timeSinceStartup;
  Debug.Log(reactionTime); // potentially comment this out after
  listReactionTimes.Add(numberTrials, reactionTime);
	Correct.Add(numberTrials);
}

public void clickInCorrect() {
  reactionTime = Time.time - timeSinceStartup;
  Debug.Log(reactionTime); // potentially comment this out after
  listReactionTimes.Add(totalTrials+1, reactionTime);
	Incorrect.Add(numberTrials);
}

// X --> 0
// Y --> 0

public void PracticeTrials(){
	if (practice == 0){
		StartCoroutine(Delay());
		IEnumerator Delay() {
			XPracticePage();
			yield return new WaitForSeconds(1);
			CrossPage();
			yield return new WaitForSeconds(1);
			XPracticePage();
			yield return new WaitForSeconds(1);
			TwoInARowPage();
			yield return new WaitForSeconds(5);
		  YPracticePage();
		  yield return new WaitForSeconds(1);
			CrossPage();
			yield return new WaitForSeconds(1);
		  XPracticePage();
		  yield return new WaitForSeconds(1);
			CrossPage();
			yield return new WaitForSeconds(1);
			YPracticePage();
		 	yield return new WaitForSeconds(1);
		 	CrossPage();
		 	yield return new WaitForSeconds(1);
		 	XPracticePage();
		 	yield return new WaitForSeconds(1);
			DifferentPage();
			yield return new WaitForSeconds(5);
			StartRealTrialsPage();
	}
	}
	practice++;
	}






public void Trials1() {
	List<int> Trial = new List<int>();
	if (block <= 2){
		if (numberTrials == 0){
			trial =  Random.Range(0f, 1f) > 0.50;
			panel = trial ? 1 : 0;
			if (panel == 0) {
				StartCoroutine(Delay());
				IEnumerator Delay() {
					CrossPage();
					yield return new WaitForSeconds(1);
					XPage();
					yield return new WaitForSeconds(2);
					Trial.Add(panel);
					numberTrials++;
					totalTrials++;
			}
		}
			else {
				StartCoroutine(Delay1());
				IEnumerator Delay1() {
					CrossPage();
					yield return new WaitForSeconds(1);
					YPage();
					yield return new WaitForSeconds(2);
					Trial.Add(panel);
					numberTrials++;
					totalTrials++;
				}
			}
		}
		else if (numberTrials > 0 && numberTrials < 100) { //set numberTrials to < 100
			if (Trial[numberTrials - 1] == 0){
				trial =  Random.Range(0f, 1f) > 0.70;
				panel = trial ? 1 : 0;
			}
			else{
				trial =  Random.Range(0f, 1f) > 0.70;
				panel = trial ? 0 : 1;
			}
			if (panel == 0) {
				StartCoroutine(Delay2());
				IEnumerator Delay2() {
					CrossPage();
					yield return new WaitForSeconds(1);
					XPage();
					yield return new WaitForSeconds(2);
				}
				//	if (pressed == true){
				//		clickIncorrect();
				//	}
				Trial.Add(panel);
			}
			else {
				StartCoroutine(Delay3());
				IEnumerator Delay3() {
					CrossPage();
					yield return new WaitForSeconds(1);
					YPage();
					yield return new WaitForSeconds(2);
				}
				//	if (pressed == false) {
					//		clickIncorrect();
					//	}
	}
				numberTrials++;
				totalTrials++;
	}

			else if (numberTrials == 10){
				TrialBlock.SetActive(true);
			}
	}
	block++;

	if (block > 2){
		EndingPage.SetActive(true);
	}
	}



public int numberTrials = 0;

public void pressFunc (){
	StartCoroutine(Delay2());
	IEnumerator Delay2() {
	CrossPage();
	yield return new WaitForSeconds(1);
}}


public void Block1() {
	List<int> Trial = new List<int>();

			Debug.Log(numberTrials);
			StartCoroutine(Delay());
			IEnumerator Delay() {
				CrossPage();
				yield return new WaitForSeconds(1.5f);

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 1

				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 2

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 3

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 4

				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 5


				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 6


				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 7

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 8


				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 9


				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 10

				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 11


				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 12

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 13


				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 14

				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 15

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 16

				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 17

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 18

				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 19

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 20

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 21

				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 22

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 23

				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 24

				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 25

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 26

				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 27

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 28

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 29

				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				TrialBlockPage();
				// 30

		}
}




public void Block2() {
	List<int> Trial = new List<int>();

			Debug.Log(numberTrials);
			StartCoroutine(Delay());
			IEnumerator Delay() {
				CrossPage();
				yield return new WaitForSeconds(1.5f);

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 31

				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 32

				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 33

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 34

				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 35


				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 36


				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 37

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 38


				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 39


				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 40

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 41


				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 42

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 43


				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 44

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 45

				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 46

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 47

				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 48

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 49

				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 50

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 51

				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 52

				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 53

				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 54

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 55

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 56

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 57

				YPage();
				numberTrials++;
				ycount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 58

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 59

				XPage();
				numberTrials++;
				xcount++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(1);
				CrossPage();
				yield return new WaitForSeconds(1.5f);
				// 60

				Ending();
				Debug.Log("Number of x trials: " + xcount);

		}
	}


public void OpenTaskPage(){
      SceneManager.LoadScene("TaskListPage");
  }
}
