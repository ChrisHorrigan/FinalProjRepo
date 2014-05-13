using UnityEngine;
using System.Collections;

public class TeachScript : MonoBehaviour {
	public GUIText words; 
	public bool moved=false;
	public bool turned=false;
	public bool tiltVert=false;
	public bool barrelRoll=false;
	// Use this for initialization
	void Start () {
		words= this.gameObject.GetComponent<GUIText> ();
		words.text = "Welcome to space ship training. Go ahead and press the Start button.";

	}
	public void PressedStart(){

		words.text = "Let's start with movement.  Use the I key to move forward.";
		}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.I)) {
						moved = true;
			words.text="J and L turn you left and right.  Try.";
				}
		if ((Input.GetKeyDown (KeyCode.J)||Input.GetKeyDown (KeyCode.L))&&moved) {
			turned = true;
			words.text="You can angle your craft up and down with W and S.  Try.";
		}
		if ((Input.GetKeyDown (KeyCode.W)||Input.GetKeyDown (KeyCode.S))&&moved&&turned) {
			tiltVert = true;
			words.text="A and D are the barrel roll keys.  Try.";
		}
		if ((Input.GetKeyDown (KeyCode.A)||Input.GetKeyDown (KeyCode.D))&&moved&&turned&&tiltVert) {
			turned = true;
			words.text="You can angle your craft up and down with W and S.  Try.";
		}
	}
}
