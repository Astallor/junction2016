using UnityEngine;
using System.Collections;

public class DestroyLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void destroyLevel()
	{
		destroyObjectsWithTag("Wall");
		destroyObjectsWithTag( "Grave" );
		destroyObjectsWithTag( "Character" );

		GameObject.FindObjectOfType<ArrowGenerator>().destroyArrows();		
	}

	private void destroyObjectsWithTag( string tag )
	{
		foreach( GameObject obj in GameObject.FindGameObjectsWithTag( tag ) )
			Destroy( obj );
	}


	// Update is called once per frame
	void Update () {
	
	}
}
