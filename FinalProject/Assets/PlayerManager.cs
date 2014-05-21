using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
	public ArrayList team1=new ArrayList();
	public ArrayList team2=new ArrayList();
	public ArrayList players;
//	public int team1count;
//	public int team2count;
	//private SpaceshipCreator soul;
	// Use this for initialization
	void Start () {
		if (Network.isServer) {
			string servernum = Network.player.ToString ();

			networkView.RPC ("UpdateTeamList", RPCMode.AllBuffered, servernum);
				}

	}

	void OnPlayerConnected(NetworkPlayer player){
		print ("this ran");
		networkView.RPC ("UpdateTeamList", RPCMode.AllBuffered, player.ToString());
	
		}
	void OnPlayerDisconnected(NetworkPlayer player){
		networkView.RPC ("RemoveFromTeams", RPCMode.AllBuffered, player.ToString ());
		}


	[RPC]
	void UpdateTeamList(string newteammate){
		if (team1.Count <= team2.Count) {
						
						team1.Add (newteammate);
						print ("Team 1 size: " + team1.Count);
				} 
		else {

						team2.Add (newteammate);
			print ("Team 2 size: "+team2.Count);
				}
		}
	[RPC] 
	void RemoveFromTeams(string leaver){
		//check team 1:
		if (team1.IndexOf (leaver) != -1) {
						team1.RemoveAt (team1.IndexOf (leaver));
			print ("Team 1 size: "+team1.Count);
				} 
		else {
						team2.RemoveAt (team2.IndexOf (leaver));
			print ("Team 2 size: "+team2.Count);
				}
		}
	void Update () {
	
	}

}
