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
			XPage();
			yield return new WaitForSeconds(2);
			CrossPage();
			yield return new WaitForSeconds(1);
			XPage();
			yield return new WaitForSeconds(2);
			TwoInARowPage();
			yield return new WaitForSeconds(5);
		  YPage();
		  yield return new WaitForSeconds(2);
			CrossPage();
			yield return new WaitForSeconds(1);
		  XPage();
		  yield return new WaitForSeconds(2);
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
				yield return new WaitForSeconds(1);

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 1

				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 2

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 3

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 4

				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 5


				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 6


				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 7

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 8


				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 9


				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 10

				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 11


				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 12

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 13


				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 14

				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 15

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 16

				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 17

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 18

				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 19

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 20

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 21

				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 22

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 23

				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 24

				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 25

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 26

				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 27

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 28

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 29

				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
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
				yield return new WaitForSeconds(1);

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 31

				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 32

				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 33

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 34

				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 35


				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 36


				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 37

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 38


				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 39


				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 40

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 41


				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 42

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 43


				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 44

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 45

				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 46

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 47

				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 48

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 49

				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 50

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 51

				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 52

				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 53

				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 54

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 55

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 56

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 57

				YPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 58

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 59

				XPage();
				numberTrials++;
				Debug.Log(numberTrials);
				yield return new WaitForSeconds(2);
				CrossPage();
				yield return new WaitForSeconds(1);
				// 60

				Ending();

		}
	}


public void OpenTaskPage(){
      SceneManager.LoadScene("TaskListPage");
  }
}
