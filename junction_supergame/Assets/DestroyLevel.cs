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
		destroyObjectsWithTag( "Tile" );

		GameObject.FindObjectOfType<ArrowGenerator>().destroyArrows();
		GameObject.FindObjectOfType<Camera>().transform.position = new Vector3( 5.33f, 4.46f, -1f );
		GameObject.FindObjectOfType<Camera>().orthographicSize = 5;
		GameObject.FindGameObjectWithTag( "NextSign" ).transform.position = new Vector3( 13.58f, 9.03f, 0 );
		//GameObject.FindObjectOfType<ArrowGenerator>().transform.position = new Vector3( 13.58f, 8.53f, 0 );
		GameObject.FindObjectOfType<ArrowGenerator>().Displayed.transform.position = new Vector3( 13.58f, 8.53f, 0 );
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
