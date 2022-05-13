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
public GameObject XPractice;
public GameObject YPractice;

// game variables
public int totalTrials = 0;
public bool trial;
public int panel = 1;
public float reactionTime;
public float timeSinceStartup;
public int xcount = 0;
public int numberTrials = 0;

public int correctResponse;
public int incorrectResponse;
//public List<int> Incorrect = new List<int>(); on StateNameConttoller
public List<int> Trials1List = new List<int>();
public List<int> Trials2List = new List<int>();

public bool result;
public bool pressed;
public string output;

// default app startup
void Start() //login page launches when user starts app
{
	BeforeYouStart.SetActive(true);
}

// page functions
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

public void clickIncorrect() {
	StateNameController.Incorrect.Add(numberTrials);
}

public void PracticeTrials(){
	StartCoroutine(Delay());
	IEnumerator Delay() {
		XPracticePage();
		yield return new WaitForSeconds(1);
		CrossPage();
		yield return new WaitForSeconds(0.4f);
		XPracticePage();
		yield return new WaitForSeconds(1);
		TwoInARowPage();
		yield return new WaitForSeconds(5);
	  YPracticePage();
	  yield return new WaitForSeconds(1);
		CrossPage();
		yield return new WaitForSeconds(0.4f);
	  XPracticePage();
	  yield return new WaitForSeconds(1);
		CrossPage();
		yield return new WaitForSeconds(0.4f);
		YPracticePage();
	 	yield return new WaitForSeconds(1);
	 	CrossPage();
	 	yield return new WaitForSeconds(0.4f);
	 	XPracticePage();
	 	yield return new WaitForSeconds(1);
		DifferentPage();
		yield return new WaitForSeconds(5);
		StartRealTrialsPage();
	}}

public void pressFunc (){
	StartCoroutine(Delay2());
	IEnumerator Delay2() {
	CrossPage();
	yield return new WaitForSeconds(1);
}}

public void Trials1 (){
	StartCoroutine(Delay());
	IEnumerator Delay() {
		for (int i = 0; i < 30; i++){
				CrossPage();
				yield return new WaitForSeconds(0.4f);

				if (i == 0){
					trial =  Random.Range(0f, 1f) > 0.50;
					panel = trial ? 1 : 0;}

				else{
					if (Trials1List[i - 1] == 0){
						trial =  Random.Range(0f, 1f) > 0.30;
						panel = trial ? 1 : 0;
					}
					else{
						trial =  Random.Range(0f, 1f) > 0.30;
						panel = trial ? 0 : 1;
					}}

					if (panel == 0) {
							XPage();
							numberTrials++;
							Debug.Log(numberTrials);
							Trials1List.Add(panel);
							if (i != 0) {
								if (Trials1List[i] == Trials1List[i-1] & pressed == true){
									clickIncorrect();	}}
							yield return new WaitForSeconds(1);
					}

					else {
							YPage();
							numberTrials++;
							Debug.Log(numberTrials);
							Trials1List.Add(panel);
							if (i != 0) {
								if (Trials1List[i] == Trials1List[i-1] & pressed == true){
									clickIncorrect();	}}
							yield return new WaitForSeconds(1);
						}
		TrialBlockPage();
}}}


public void Trials2 (){
	StartCoroutine(Delay2());
	IEnumerator Delay2() {
		for (int j = 0; j < 30; j++){
				CrossPage();
				yield return new WaitForSeconds(0.4f);

				if (j == 0){
					trial =  Random.Range(0f, 1f) > 0.50;
					panel = trial ? 1 : 0;}

				else{
					if (Trials2List[j - 1] == 0){
						trial =  Random.Range(0f, 1f) > 0.30;
						panel = trial ? 1 : 0;
					}
					else{
						trial =  Random.Range(0f, 1f) > 0.30;
						panel = trial ? 0 : 1;
					}}

					if (panel == 0) {
							XPage();
							numberTrials++;
							Debug.Log(numberTrials);
							Trials2List.Add(panel);
							if (j != 0){
								if (Trials2List[j] == Trials2List[j-1] & pressed == true){
									clickIncorrect();	}}
							yield return new WaitForSeconds(1);
					}
					else {
							YPage();
							numberTrials++;
							Debug.Log(numberTrials);
							Trials2List.Add(panel);
							if (j != 0){
								if (Trials2List[j] == Trials2List[j-1] & pressed == true){
									clickIncorrect();	}}
							yield return new WaitForSeconds(1);
						}
		Ending();
}}}

public void OpenTaskPage(){
      SceneManager.LoadScene("TaskListPage");
  }

void Update(){
  //key pressed update on choice page
  if ((X.activeSelf || Y.activeSelf) && Input.GetKeyUp(KeyCode.Space)) { pressFunc(); }
}

}
