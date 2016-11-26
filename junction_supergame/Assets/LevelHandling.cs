using UnityEngine;
using System.Collections;

public class LevelHandling : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<GenerateFirstLevel>().initialize();
		//GetComponent<GenerateFirstLevel>().createNextLevel();
	}

	public bool nextLevel()
	{
		GetComponent<DestroyLevel>().destroyLevel();
		return GetComponent<GenerateFirstLevel>().createNextLevel();
	}

	public void resetLevel()
	{
		GetComponent<DestroyLevel>().destroyLevel();		
		if(!GetComponent<GenerateFirstLevel>().recreateCurrentLevel())
			GetComponent<GenerateFirstLevel>().createNextLevel();
	}


	// Update is called once per frame
	void Update () {
	
	}
}
