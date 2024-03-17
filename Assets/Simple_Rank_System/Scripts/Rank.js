#pragma strict

//*********************************************************** Simple rank system control **************************************************************
//CODE By : Paulo Aguiar
//Unity 3D Forum Nick: pauloaguiar
//Date: 20-06-2013
//*****************************************************************************************************************************************************




//Rank progression control.
var curRank : int;
var maxRank : int = 100;

//Level up progression control.
var levelUp : int;
var maxLevelUp : int = 200;
var rankPointsToAdd : int = 10;

// Your Rank pictures to show.
var rank50 : GUITexture;
var rank100 : GUITexture;
var rank150 : GUITexture;

// Control the current points to turn on the current rank and save data.
private var up50 : int = 50;
private var up100 : int = 100;
private var up150 : int = 150;

//play notification sound.
var soundUnlocked : AudioClip;

function Awake () {

	// check on/off rank state and load all saved data lasted saved.
	LoadData ();
}

function Update () {

	// check curRank with the maxRank to raise level.
	if (curRank == maxRank)
	{
		rankUpdated();
	}	
	
	//  Control the current levelUp to the maxlevelUp then stop level Up if max Level.
	if (levelUp >= maxLevelUp)
	{
		levelUp = maxLevelUp;
	}	
}

function rankUpdated ()
{
	// reset curRank and add levelUp.
	curRank = 0;
	levelUp += 50;
	
	//****************************************************** On/Off the current rank state, save data and sound notification.*************************************
	if (levelUp == up50)
	{
		audio.PlayOneShot(soundUnlocked);
		
		rank50.enabled = true;
		
		PlayerPrefs.SetInt("up50" ,up50);		
	}
	if (levelUp == up100)
	{		
		audio.PlayOneShot(soundUnlocked);
			
		rank50.enabled = false;
		rank100.enabled = true;
		
		PlayerPrefs.SetInt("up100" ,up100);
		
	}
	if (levelUp == up150)
	{		
		audio.PlayOneShot(soundUnlocked);	
		
		rank50.enabled = false;
		rank100.enabled = false;
		rank150.enabled = true;
		
		PlayerPrefs.SetInt("up150" ,up150);
	}					
}

function OnGUI ()
{
	// raise you rank by pressing the button (for testing).
	if (GUI.Button(Rect(10,100,100,30), "+Rank"))
	{
		// add rank points.
		curRank += rankPointsToAdd;
		
		PlayerPrefs.SetInt("curRank" ,curRank);	
		PlayerPrefs.SetInt("levelUp" ,levelUp);	
	}
	// Delete all saved data and turn off the rank state.
	if (GUI.Button(Rect(10,150,100,30), "Delete data"))
	{	
		PlayerPrefs.DeleteAll();
		
		rank50.enabled = false;
		rank100.enabled = false;
		rank100.enabled = false;									
	}
	
	//*************************************************************** Show the state on screen.*****************************************************************
	GUI.Label(Rect(10,190,100,30), "Your Rank = " + curRank);
	GUI.Label(Rect(10,210,100,30), "Level Up = " + levelUp);
}


function LoadData ()
{
	// loads and check all saved data and control the on/off rank state.
	curRank = PlayerPrefs.GetInt("curRank");
	levelUp = PlayerPrefs.GetInt("levelUp");
	
	//************************************************************** Verify the current and lasted saved data.***************************************************
	if (PlayerPrefs.HasKey("up50"))
	{
		rank50.enabled = true;
	}
	else
	{
		rank50.enabled = false;
	}
	
	if (PlayerPrefs.HasKey("up100"))
	{
		rank100.enabled = true;
		rank50.enabled = false;
	}
	else
	{
		rank100.enabled = false;
	}
	
	if (PlayerPrefs.HasKey("up150"))
	{
		rank150.enabled = true;
		rank50.enabled = false;
		rank100.enabled = false;
	}
	else
	{
		rank150.enabled = false;
	}	
}

@script ExecuteInEditMode();