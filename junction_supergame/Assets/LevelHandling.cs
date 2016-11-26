using UnityEngine;
using System.Collections;

public class LevelHandling : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<GenerateFirstLevel>().initialize();
		GetComponent<GenerateFirstLevel>().createNextLevel();
	}

	public void nextLevel()
	{
		GetComponent<DestroyLevel>().destroyLevel();
		GetComponent<GenerateFirstLevel>().createNextLevel();
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
