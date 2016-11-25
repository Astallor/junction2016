using UnityEngine;
using System.Collections;
//using System;

public class GenerateRandomWalls : MonoBehaviour {

	public Transform wall;
	public Transform grave;
	public int wallAmount;
	public int graveAmount;

	// Use this for initialization
	void Start () {
		int xBoundary = GetComponent<GenerateBoundaryWall>().xBoundary;
		int yBoundary = GetComponent<GenerateBoundaryWall>().yBoundary;

		instantiateThings( wall, wallAmount, xBoundary, yBoundary );
		instantiateThings( grave, graveAmount, xBoundary, yBoundary );
	}

	private void instantiateThings( Transform asset, int amount, int xBoundary, int yBoundary )
	{
		for( int x = 0; x < amount; x++ )
		{
			int nextX = 0;
			int nextY = 0;

			while( true )
			{
				bool flag = false;
				nextX = (int) (Random.value * (xBoundary - 2));
				nextY = (int) (Random.value * (yBoundary - 2));
				foreach( GameObject ob in GameObject.FindGameObjectsWithTag( "Wall" ) )
				{
					if( Vector3.Distance( new Vector3( (float) nextX / 2, (float) nextY / 2, 0 ), ob.transform.position ) == 0 )
					{
						Debug.Log( "Distance: " + Vector3.Distance( new Vector3( (float) nextX / 2, (float) nextY / 2, 0 ), ob.transform.position ) );
						flag = true;
					}						
				}
				if( !flag ) break;
			}
			
			


			if( nextX == 0 ) nextX++;
			if( nextY == 0 ) nextY++;

			Instantiate( asset, new Vector3( (float) nextX / 2, (float) nextY / 2, 0 ), Quaternion.identity );
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
