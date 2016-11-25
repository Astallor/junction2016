using UnityEngine;
using System.Collections;

public class GenerateBoundaryWall : MonoBehaviour {

	public Transform wall;
	public int xBoundary;
	public int yBoundary;

	// Use this for initialization
	void Start () {
		for( int x = 0; x < xBoundary; x++ )
		{
			if( x == 0 || x == (xBoundary - 1) )
				for( int y = 0; y < yBoundary; y++ )
				{
					Instantiate( wall, new Vector3( ((float)x/2), ((float) y / 2), 0 ), Quaternion.identity );
				}
			else
			{
				Instantiate( wall, new Vector3( ((float) x / 2), 0, 0 ), Quaternion.identity );
				Instantiate( wall, new Vector3( ((float) x / 2), ((float)(yBoundary - 1))/2f, 0 ), Quaternion.identity );
			}
				
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
