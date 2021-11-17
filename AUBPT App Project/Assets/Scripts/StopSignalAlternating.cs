using UnityEngine;
using System.Collections;

public class StopSignalAlternating : MonoBehaviour
{
    public GameObject Panel5;
    public GameObject Panel6;
    private float waitTime;

private void Start() {
    StartCoroutine(InfiniteLoop());
}
    private IEnumerator InfiniteLoop()
    {
        waitTime = Random.Range(1, 3);
    while (true){
        yield return new WaitForSeconds(waitTime);
        Panel6.SetActive(true);
        Panel5.SetActive(false);
        yield return new WaitForSeconds(waitTime);
        Panel5.SetActive(true);
        Panel6.SetActive(false);
        }

    }

public void whistleAudio() {

  bool result = Random.Range(0f, 1f) > 0.75; //%25 percent chance to be true
  Debug.Log(result);
}

}
