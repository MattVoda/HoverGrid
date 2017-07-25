using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riser : MonoBehaviour {


    public float riseDistanceMultiplier = 3f;
    public float time = 0.5f;

    private bool risen = false;

    private SteamVR_Camera HMD;
    private Vector3 HMDpos;
    private Quaternion originalRotationValue;

    // Use this for initialization
    void Start () {
        HMD = SteamVR_Render.Top();
        originalRotationValue = gameObject.transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        HMDpos = HMD.transform.position;
        if (risen) {
            gameObject.transform.LookAt(HMDpos);
        }
    }

    public void StartRise() {
        risen = true;
        StartCoroutine(Rise(true));
    }
    public void EndRise() {
        risen = false;
        StartCoroutine(Rise(false));
        gameObject.transform.rotation = originalRotationValue;
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
