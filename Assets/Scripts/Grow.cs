using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour {


    //public float sizeMultiplier = 1.1f;
    public float maxX = 2f;
    public float maxY = 2f;
    public float maxZ = 2f;
    public float timeInSeconds = 0.1f;
    public Vector3 scaleVector = new Vector3(2f,2f,2f);
    
    public bool growNow = false;
    private bool hasGrown = false;

    //private Transform cubeMeshTransform;
    public GameObject cubeMesh;

    private void Awake() {
        //cubeMeshTransform = transform.parent.Find("CubeMesh");

        scaleVector = cubeMesh.transform.localScale;
        cubeMesh.transform.parent = gameObject.transform;
        //print("CubeMesh = " + cubeMeshTransform);
    }
    
    void Start () { }
	
	
	void Update () {

        //CheckScale();

        if (growNow && !hasGrown) {
            print("growing!");
            hasGrown = true;
            iTween.ScaleUpdate(cubeMesh, iTween.Hash("scale", scaleVector, "time", timeInSeconds, "easeType", iTween.EaseType.easeOutSine));
        } else if (!growNow && hasGrown) {
            print("shrinking!");
            hasGrown = false;
            iTween.ScaleTo(cubeMesh, iTween.Hash("scale", Vector3.one, "time", timeInSeconds, "easeType", iTween.EaseType.easeOutSine));
        }

	}

    //void CheckScale() {
    //    if (scaleVector.x < maxX) {
    //        scaleVector.x = scaleVector.x * sizeMultiplier;
    //    }
    //    if (scaleVector.y < maxY) {
    //        scaleVector.y = scaleVector.y * sizeMultiplier;
    //    }
    //    if (scaleVector.z < maxZ) {
    //        scaleVector.z = scaleVector.z * sizeMultiplier;
    //    }
    //}

    //void ScaleValues() {
    //    if (scaleVector.x < maxX) {
    //        scaleVector.x = scaleVector.x * sizeMultiplier;
    //    }
    //    if (scaleVector.y < maxY) {
    //        scaleVector.y = scaleVector.y * sizeMultiplier;
    //    }
    //    if (scaleVector.z < maxZ) {
    //        scaleVector.z = scaleVector.z * sizeMultiplier;
    //    }
    //}
}
