using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour {

    
    public float sizeMultiplier = 1.1f;
    public float maxX = 2f;
    public float maxY = 2f;
    public float maxZ = 2f;
    public float timeInSeconds = 1.0f;
    public Vector3 scaleVector = new Vector3(2f,2f,2f);
    
    public bool growNow = false;
    private bool hasGrown = false;

    private Transform cubeMeshTransform;
    
    private void Awake() {
        cubeMeshTransform = transform.parent.Find("CubeMesh");
        scaleVector = cubeMeshTransform.localScale;
    }
    
    void Start () { }
	
	
	void Update () {

        if (growNow && !hasGrown) {
            hasGrown = true;
            iTween.ScaleTo(cubeMeshTransform.gameObject, iTween.Hash("scale", scaleVector, "time", timeInSeconds, "easeType", iTween.EaseType.easeOutSine));
        } else if (!growNow && hasGrown) {
            hasGrown = false;
            iTween.ScaleTo(cubeMeshTransform.gameObject, iTween.Hash("scale", Vector3.one, "time", timeInSeconds, "easeType", iTween.EaseType.easeOutSine));
        }

	}


    //void ScaleValues() {
    //    if(scaleVector.x < maxX) {
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
