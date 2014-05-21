using UnityEngine;
using System;
using System.Collections;
//SpawnCode
public class SpawnCode : MonoBehaviour {
	public Transform playerPrefab;
	public ArrayList playerScripts = new ArrayList();
	public int playerNumber;

	void Start(){
				//DontDestroyOnLoad (transform.gameObject);
		print ("Velcome");
		}
	void OnServerInitialized()
	{
		//print ("Somethasdfg;lkj");
		AddPlayer(Network.player);
	}
	void OnPlayerConnected(NetworkPlayer player)
	{
		networkView.RPC ("AddPlayer", RPCMode.AllBuffered, player);
	}
	[RPC]
	void AddPlayer(NetworkPlayer player)
	{
		string tempPlayerString = player.ToString ();
		playerNumber = Convert.ToInt32(tempPlayerString);
		print ("Playernumber:" + playerNumber);
		//Transform newPlayerTransform = (Transform)Network.Instantiate (playerPrefab, transform.position, transform.rotation, playerNumber);
		//playerScripts.Add (newPlayerTransform.GetComponent ("CubeScriptAuthoritative"));//that's the authoritative movement script
		//NetworkView theNetworkView = newPlayerTransform.networkView;
		//theNetworkView.RPC ("SetPlayer", RPCMode.AllBuffered, player);
	}
	public void SpawnPlayers(){
		Transform newPlayerTransform = (Transform)Network.Instantiate (playerPrefab, transform.position, transform.rotation,0);
		Camera.main.transform.parent = newPlayerTransform.transform;
		//playerScripts.Add (newPlayerTransform.GetComponent ("CubeScriptAuthoritative"));//that's the authoritative movement script
		//NetworkView theNetworkView = newPlayerTransform.networkView;
		//theNetworkView.RPC ("SetPlayer", RPCMode.AllBuffered, player);
		}
	
}