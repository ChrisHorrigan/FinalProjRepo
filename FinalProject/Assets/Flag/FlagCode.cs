using UnityEngine;
using System.Collections;

public class FlagCode : MonoBehaviour {
	public int side;
	// Use this for initialization
	void Start () {
	
	}
	void OnCollisionEnter(Collision collision){
		print ("Trigger enter ran");
		if (collision.collider.gameObject.CompareTag ("Targetable"))
					networkView.RPC ("Grabbed", RPCMode.AllBuffered, collision.collider);
		}
	[RPC]
	void Grabbed(Collider player){
		print ("Grabbed ran");
		this.transform.parent = player.transform;
		}
	// Update is called once per frame
	void Update () {
	
	}
}
