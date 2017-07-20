using UnityEngine;
using System.Collections;


public class InteractableItem : MonoBehaviour {

    private bool isScaled = false;

    public Rigidbody rigidbody;
    private bool currentlyInteracting;

    public float velocityFactor = 1f;
    private Vector3 posDelta;

    private Quaternion rotationDelta;
    private float rotationFactor = 4f;
    private float angle;
    private Vector3 axis;

    private WandController attachedWand;
    private Grow growScript;
    private Transform interactionPoint;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        interactionPoint = new GameObject().transform; //an empty object's transform
        velocityFactor = rigidbody.mass;  //realistic -- bigger mass = smaller velocity factor

        growScript = gameObject.GetComponent<Grow>();
	}
	
	void Update () {
	    //make it do stuff!
        if (attachedWand && currentlyInteracting) {
            growScript.growNow = true;
        } else {
            growScript.growNow = false;
        }
	}

    public void BeginInteraction(WandController wand) {
        attachedWand = wand;
        interactionPoint.position = wand.transform.position;
        interactionPoint.rotation = wand.transform.rotation;
        interactionPoint.SetParent(transform, true);

        currentlyInteracting = true;
    }

    public void EndInteraction(WandController wand) {
        if (wand == attachedWand) {
            attachedWand = null;
            currentlyInteracting = false;
        }
    }

    public bool IsInteracting() {
        return currentlyInteracting;
    }
}


//posDelta = attachedWand.transform.position - interactionPoint.position;
//this.rigidbody.velocity = posDelta * velocityFactor * Time.fixedDeltaTime;

//rotationDelta = attachedWand.transform.rotation * Quaternion.Inverse(interactionPoint.rotation);
//rotationDelta.ToAngleAxis(out angle, out axis);

//if (angle > 180) { //if you have a big rotation to make, take the path of least resistance
//    angle -= 360;
//}

//this.rigidbody.angularVelocity = (Time.fixedDeltaTime * angle * axis) * rotationFactor;