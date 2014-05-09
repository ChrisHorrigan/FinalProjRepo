using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
	public ArrayList team1;
	public ArrayList team2;
	private SpaceshipCreator soul;
	// Use this for initialization
	void Start () {
		team1 = new ArrayList();
		team2 = new ArrayList ();
	}
	[RPC] 
	void ListUpdate(SpaceshipCreator toAdd){
		if (team1.Count > team2.Count) {
						team2.Add (toAdd);
			print (toAdd.name+" was added to team 2");
				} 
		else {
			team1.Add (toAdd);
			print (toAdd.name+" was added to team 1");
				}
	}
	public void AddPlayer (SpaceshipCreator thing){
		soul = thing;
		networkView.RPC ("ListUpdate", RPCMode.AllBuffered, soul);
		}
	// Update is called once per frame
	void Update () {
	
	}

}
