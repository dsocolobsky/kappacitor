using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour {

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
	}

    public void StartShaking() {
        animator.SetBool("shaking", true);
    }

    public void StopShaking() {
        animator.SetBool("shaking", false);
    }

}
