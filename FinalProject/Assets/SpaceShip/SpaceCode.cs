using UnityEngine;
using System.Collections;

public class SpaceCode : DestructableObject {

	public Transform Lazer;
	public Transform HeatSeeker;

	private float speed;
	//private float phi;
	//private float theta;


	private float curvature;
	private float torsion;
	private float lift;

	private float throttle;
	private float throttleMod;
	private GUIStyle nameplate;
	private float curvatureMod;
	private float torsionMod;
	private float liftMod;
	private Vector3 namePlatePos;
	private Vector3 newForward;
	private Vector3 newRight;
	private Vector3 newUp;
	private string playaName;
	private Vector3 newPos;
	// Use this for initialization
	void Start () {



		speed = 0;
		//phi = 0;
		//theta = Mathf.PI / 2;
		curvature = 0f;
		torsion = 0f;
		lift = 0f;

		curvatureMod = .2f;
		torsionMod = .9f;
		liftMod = .5f;

		throttle = 0f;
		throttleMod = .2f;

		newForward = new Vector3(0f, 0f, 1f);
		newRight = new Vector3(1f, 0f, 0f);
		newUp = new Vector3(0f, 1f, 0f);

		newPos = new Vector3(0f, 0f, 0f);
	}
	void OnGUI() {
		// Place the name plate where the gameObject (player prefab) is
		namePlatePos = Camera.main.WorldToScreenPoint(gameObject.transform.position);  
		GUI.Label(new Rect(((float)namePlatePos.x-75f), ((float)Screen.height - namePlatePos.y-40f), 100, 50), playaName);  
	}
	[RPC]
	void setName(string name){
		//TextMesh mesh = this.GetComponentInChildren<TextMesh> ();
		//mesh.text = name;
		playaName = name;
		}
	public void sendName(string n){
		networkView.RPC ("setName", RPCMode.AllBuffered, n);
	}


	// Update is called once per frame
	void Update () {
		if (networkView.isMine) {
			if (Input.GetKey(KeyCode.I)) {
				speed += 3f * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.K)) {
				speed -= 3f * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.L)) {
				curvature += Time.deltaTime * curvatureMod;
			}
			if (Input.GetKey(KeyCode.J)) {
				curvature -= Time.deltaTime * curvatureMod;
			}
			if (Input.GetKey(KeyCode.W)) {
				lift += Time.deltaTime * liftMod;
			}
			if (Input.GetKey(KeyCode.S)) {
				lift -= Time.deltaTime * liftMod;
			}
			if (Input.GetKey(KeyCode.A)) {
				torsion += Time.deltaTime * torsionMod;
			}
			if (Input.GetKey(KeyCode.D)) {
				torsion -= Time.deltaTime * torsionMod;
			}

			if (Input.GetKey(KeyCode.N)) {
				throttle += Time.deltaTime * throttleMod;
			}
		

		//phi += theta * Time.deltaTime * .1f;

		speed *= Mathf.Pow(.001f, Time.deltaTime);
		curvature *= Mathf.Pow(.001f, Time.deltaTime);
		lift *= Mathf.Pow(.001f, Time.deltaTime);
		torsion *= Mathf.Pow(.001f, Time.deltaTime);
		throttle *= Mathf.Pow(.6f, Time.deltaTime);
		speed += throttle * Mathf.Sign(speed);


		//theta = theta * Mathf.Pow(.6f, Time.deltaTime) + Mathf.PI;
		//phi *= Mathf.Pow(.9f, Time.deltaTime);




		Vector3 curvedForward = (newForward + curvature * newRight).normalized;
		Vector3 curvedRight = (newRight - curvature * newForward).normalized;
		Vector3 curvedUp = newUp;

		Vector3 liftedForward = (curvedForward + lift * curvedUp).normalized;
		Vector3 liftedRight = curvedRight;
		Vector3 liftedUp = (curvedUp - lift * curvedForward).normalized;

		newForward = liftedForward;
		newRight = (liftedRight + torsion * liftedUp).normalized;
		newUp = (liftedUp - torsion * liftedRight).normalized;  

		//Vector3 curvedForward = (new Vector3(oldForward.x + curvature * oldRight.x, oldForward.y + curvature * oldRight.y, oldForward.z + curvature * oldRight.z)).normalized;
		//Vector3 curvedRight = (new Vector3(oldRight.x - curvature * oldForward.x, oldRight.y - curvature * oldForward.y, oldRight.z - curvature * oldForward.z)).normalized;
		//Vector3 curvedUp = oldUp;
		//Vector3 liftedForward = (curvedForward + lift * curvedUp).normalized;
		//Vector3 liftedRight = curvedRight;
		//Vector3 liftedUp = (curvedUp - lift * curvedForward).normalized;
		//Vector3 turnedForward = liftedForward;
		//Vector3 turnedRight = (liftedRight + torsion * liftedUp).normalized;
		//Vector3 turnedUp = (liftedUp - torsion * liftedRight).normalized;  
		//transform.forward = turnedForward;
		//transform.right = turnedRight;
		//transform.up = turnedUp; 
		//this.transform.right = curvedRight;
		//this.transform.forward = curvedForward;
		//this.transform.up = curvedUp; 
		//transform.right = -1 * Vector3.Cross(transform.forward, transform.up);
		//**************************************************************
		//                      Lift                             
		//**************************************************************
		//transform.forward = Vector3.Normalize(transform.forward + lift * transform.up);
		//transform.up = Vector3.Normalize(transform.up + lift * transform.forward);
		//transform.up = -1 * Vector3.Cross(transform.forward, transform.right);
		//transform.forward = Vector3.Normalize(transform.forward + lift * transform.up);
		//transform.up = Vector3.Normalize(transform.up + lift * transform.forward);
		//transform.eulerAngles = new Vector3(Mathf.Acos(Mathf.Sin(phi) * Mathf.Cos(theta)), Mathf.Acos(Mathf.Sin(phi) * Mathf.Sin(theta)), phi);
		//transform.forward = Vector3.Normalize(new Vector3(Mathf.Acos(Mathf.Sin(phi) * Mathf.Cos(theta)), Mathf.Acos(Mathf.Sin(phi) * Mathf.Sin(theta)), phi));
		//transform.right = Vector3.Normalize(new Vector3(Mathf.Cos(reduceAngle(theta)), Mathf.Sin (reduceAngle(Mathf.PI - theta)), 0));


		//transform.rotation = Quaternion.Euler(Mathf.Acos(Mathf.Sin(theta) * Mathf.Cos(phi)), Mathf.Acos(Mathf.Sin(theta) * Mathf.Sin(phi)), theta);


		newPos = newPos + (speed * newForward);
		transform.localPosition = newPos;
		//this.GetComponent<CharacterController>().Move(speed * newForward);

		//transform.Translate(speed * newForward);


		//transform.forward = newForward;
		//transform.right = newRight;
		//transform.up = newUp;
		//Vector3 N = Vector3.Cross(new Vector3(0, 0, 1), newForward).normalized;
		//transform.eulerAngles.x = Mathf.Acos(Vector3.Dot(N, new Vector3(1, 0, 0)));
		//transform.eulerAngles.y = Mathf.Acos(Vector3.Dot(newForward, new Vector3(0, 0, 1)));
		//transform.eulerAngles.z = Mathf.Acos(Vector3.Dot(newRight, N));

		transform.rotation = Quaternion.LookRotation (newForward, newUp);

		}

		if (Input.GetKeyDown(KeyCode.Space) && networkView.isMine) {

			Transform temp1 = (Transform) Network.Instantiate(Lazer, transform.position, transform.rotation, 0);
			//Transform temp1 = (Transform) GameObject.Instantiate(Lazer);
			temp1.localPosition = this.transform.localPosition + newRight * this.transform.localScale.x / 2f + newUp * this.transform.localScale.y / 2f;
			temp1.localRotation = this.transform.localRotation;
			temp1.GetComponent<LazerCode>().setForwardVector(newForward);

			Transform temp2 = (Transform) Network.Instantiate(Lazer, transform.position, transform.rotation, 0);
			//Transform temp2 = (Transform) GameObject.Instantiate(Lazer);
			temp2.localPosition = this.transform.localPosition + newRight * this.transform.localScale.x / -2f + newUp * this.transform.localScale.y / 2f;
			temp2.localRotation = this.transform.localRotation;
			temp2.GetComponent<LazerCode>().setForwardVector(newForward);
		}

		if (Input.GetKeyDown(KeyCode.U) && networkView.isMine) {
			RaycastHit hit;
			Physics.Raycast(this.transform.localPosition + (this.transform.localScale.z / 2 * newUp), newForward, out hit);
			if(Physics.Raycast(this.transform.localPosition + (this.transform.localScale.z / 2 * newUp), newForward, 1000f)) {
				if (hit.collider.CompareTag("Targetable")) {
					print("target aquired");
					Transform tempSeek = (Transform) Network.Instantiate(HeatSeeker, transform.position, transform.rotation, 0);
					//Transform tempSeek = (Transform) GameObject.Instantiate(HeatSeeker);
					tempSeek.localPosition = this.transform.localPosition;
					tempSeek.GetComponent<SeekerCode>().setTarget(hit.collider.transform);
				} else {
					print("target failed");
				}
			}

			//Transform tempSeek = (Transform) GameObject.Instantiate(HeatSeeker);
			//tempSeek.localPosition = this.transform.localPosition;
		}




	}

	private float reduceAngle(float a) {
		while (a >= Mathf.PI * 2f) {
			a -= (Mathf.PI * 2f);
		}
		while (a <= Mathf.PI * -2f) {
			a += (Mathf.PI * 2f);
		}
		return a;
	}

	protected override void innitializeHealth() {
		
	}
	protected override void damageEffect() {
		
	}
	protected override void destructionEffect() {
		
	}
}
