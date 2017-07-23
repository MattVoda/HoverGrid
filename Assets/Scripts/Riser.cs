using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riser : MonoBehaviour {


    public float riseDistanceMultiplier = 3f;
    public float time = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartRise() {
        StartCoroutine(Rise(true));
    }
    public void EndRise() {
        StartCoroutine(Rise(false));
    }

    IEnumerator Rise(bool riseNow) {

        if (riseNow) {
            for (float i = 0; i <= time; i += Time.deltaTime) {
                gameObject.transform.localPosition = new Vector3(0, i * riseDistanceMultiplier, 0);
                yield return null;
            }
        }

        // fall
        else {
            for (float i = time; i >= 0; i -= Time.deltaTime) {
                gameObject.transform.localPosition = new Vector3(0, i * riseDistanceMultiplier, 0);
                yield return null;
            }
            
        }
    }
}
