using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSignalAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public float delay;

    // Start is called before the first frame update
    public void Start()
    {
      bool result = Random.Range(0f, 1f) > 0.75; //%25 percent chance to be true
      System.Random random = new System.Random();
      double val = (random.NextDouble() * (0.234 - 0.069) + 0.069);
      delay = (float)val;

      if (result) {
        audioSource.PlayDelayed(delay);
      }
      Debug.Log(delay);
    }

    // // Update is called once per frame
    // void Update()
    // {
    //
    // }
}
