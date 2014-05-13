using UnityEngine;
using System.Collections;
using System.Net;
public class MenuScript : MonoBehaviour {
	public bool playClicked=false;
	private string playerName = "Player Name";
	string connectionIP="ip address";
	string serverIP;
	public int connectionPort = 25001;
	public bool tutorial=false;
	private string quitstring="Shut down server";
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
		string host = Dns.GetHostName();
		IPHostEntry ip = Dns.GetHostEntry(host);	//grabs all the ip entries for this computer
		serverIP = ip.AddressList[0].ToString();
	}
	void OnGUI(){
		if (Network.peerType == NetworkPeerType.Disconnected) {
						if (GUI.Button (new Rect (10, 10, 170, 30), "Play Online") && !playClicked)
								playClicked = true;
						//else if (GUI.Button (new Rect (10, 10, 170, 30), "Play Online"))
						//playClicked = false;
						if (playClicked) {
								playerName = GUI.TextField (new Rect (180, 10, 170, 30), playerName);
								connectionIP = GUI.TextField (new Rect (180, 70, 170, 30), connectionIP);
								//lastly, the Connect bustton
				GUI.Label(new Rect(180,40,170,30),"Connect to a game:");
								if (GUI.Button (new Rect (180, 100, 170, 40), "CONNECT")) {
					playClicked=false;
					Network.Connect(connectionIP, connectionPort); //change serverIP to localhostIP for testing on same computer
					//if(Network.peerType == NetworkPeerType.Client)

					Application.LoadLevel(2);
										//connects to server
								}
								if(GUI.Button(new Rect (350, 10, 170, 30), "Host Game>>>")){
					playClicked=false;
					Network.InitializeServer(32, connectionPort, false);
					Application.LoadLevel(2);
					//creates a game with you as the server
				}
								
						}

						if (GUI.Button (new Rect (10, 40, 170, 30), "Play Tutorial")) {
								playClicked = false;
								Network.InitializeServer(0, connectionPort, false);
								Application.LoadLevel(2);
								tutorial=true;
								quitstring="Back to menu";
						}
						if (GUI.Button (new Rect (10, 70, 170, 30), "Instructions")) {
								playClicked = false;
						}
						if (GUI.Button (new Rect (10, 100, 170, 30), "Quit Game")) {
								Application.Quit ();
						}
						//creates local server tutorial scene
				}
		else if (Network.peerType == NetworkPeerType.Client){
			GUI.Label(new Rect(10, 10, 300, 20), "Connected as Client");
			if (GUI.Button(new Rect(10, 30, 120, 20), "Disconnect")){
				GameObject.Find("GameManager").GetComponent<SpaceshipCreator>().BeforeLeaving();
				Network.Disconnect(200);
				Application.LoadLevel(0);
				tutorial=false;
			}
		}
		else{

			if(Application.loadedLevel==1)
				quitstring="Return to main menu";
			GUI.Label(new Rect(10, 10, 300, 20), "Server IP:" + serverIP);
			if (GUI.Button(new Rect(10, 30, 170, 30), "Shut down server")){
				Network.Disconnect(200);
				tutorial=false;
				Application.LoadLevel(0);
			}
			//if(Application.loadedLevel==1){
			if (!SpaceshipCreator.gameOn){//consider variable replacement later
				string startText;
				if(tutorial)
					startText="Start Tutorial";
				else
					startText="Start Match";
				if(GUI.Button(new Rect(10, 70, 170, 30), "Start")){
					GameObject.Find("GameManager").GetComponent<SpaceshipCreator>().RoundStart();
					GameObject.Find ("Tutorial(Clone)").GetComponent<TeachScript>().PressedStart();
						//!GameObject.Find("GameManager").GetComponent<SpaceshipCreator>().gameOn
				}
			}
			//}
		}
		}
	public string getName(){
		return playerName;
		}
	// Update is called once per frame
	void Update () {
	
	}
}
