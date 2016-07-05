using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartShaking() {
        animator.SetBool("shaking", true);
    }

    public void StopShaking() {
        animator.SetBool("shaking", false);
    }

}
