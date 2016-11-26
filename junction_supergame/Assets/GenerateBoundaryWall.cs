using UnityEngine;
using System.Collections;

public class GenerateBoundaryWall : MonoBehaviour {

	public Transform wall;
	public int xBoundary;
	public int yBoundary;

	// Use this for initialization
	void Start () {
        
    }

	public void generate()
	{
        for( int x = -3; x <= xBoundary + 3; x++ )
        {
            for( int y = -3; y <= yBoundary + 3; y++ )
                Instantiate( Resources.Load( "Prefabs/Tile" ), new Vector3( (((float) x) / 2f), (((float) y) / 2f), 0 ), Quaternion.identity );
        }

        for( int x = 0; x < xBoundary; x++ )
		{
			if( x == 0 || x == (xBoundary - 1) )
				for( int y = 0; y < yBoundary; y++ )
				{
					Instantiate( wall, new Vector3( ((float) x / 2), ((float) y / 2), 0 ), Quaternion.identity );
				}
			else
			{
				Instantiate( wall, new Vector3( ((float) x / 2), 0, 0 ), Quaternion.identity );
				Instantiate( wall, new Vector3( ((float) x / 2), ((float) (yBoundary - 1)) / 2f, 0 ), Quaternion.identity );
			}

		}
		GameObject.FindObjectOfType<Camera>().transform.position = new Vector3( xBoundary/4f, yBoundary/4f, -1f );
		if( xBoundary > 35 ) GameObject.FindObjectOfType<Camera>().orthographicSize = 7f;
		else GameObject.FindObjectOfType<Camera>().orthographicSize = 6f;
		GameObject.FindGameObjectWithTag( "NextSign" ).transform.position = new Vector3( xBoundary/2f + 1.5f, yBoundary/2f - 1f, 0 );
		//GameObject.FindObjectOfType<ArrowGenerator>().transform.position = new Vector3( xBoundary / 2f + 4, yBoundary / 2f - 1, 0 );
		GameObject.FindObjectOfType<ArrowGenerator>().Displayed.transform.position = new Vector3( xBoundary / 2f + 1.5f, yBoundary / 2f - 1.5f, 0 );

		GameObject.FindGameObjectWithTag( "Background" ).transform.position = new Vector3( xBoundary / 4f, yBoundary / 4f, 0 );
		GameObject.FindGameObjectWithTag("Background").transform.localScale = new Vector3( xBoundary * 10, yBoundary * 10, 0 );
	}

	public void generateWall(int fromY, int toY, int fromX, int toX )
	{
		int yFrom, yTo, xFrom, xTo;
		if( fromY > toY )
		{
			yFrom = toY;
			yTo = fromY;
		}
		else
		{
			yFrom = fromY;
			yTo = toY;
		}
		if( fromX > toX )
		{
			xFrom = toX;
			xTo = fromX;
		}
		else
		{
			xFrom = fromX;
			xTo = toX;
		}

		for( int x = xFrom; x <= xTo ; x++ )
		{
			for( int y = yFrom; y <= yTo; y++ )
			{
				bool flag = false;
				foreach( GameObject ob in GameObject.FindGameObjectsWithTag( "Wall" ) )
				{
					if( Vector3.Distance( new Vector3( (((float) x) / 2f), (((float) y) / 2f), 0 ), ob.transform.position ) == 0 )
					{
						flag = true;
					}
				}
				if( !flag )
					Instantiate( wall, new Vector3( (((float) x) / 2f), (((float) y )/ 2f), 0 ), Quaternion.identity );
			}
				
		}
	}

	public void generateBody(int x, int y )
	{
		Instantiate( Resources.Load( "Prefabs/Body" ), new Vector3( (((float) x) / 2f), (((float) y) / 2f), 0 ), Quaternion.identity );
	}

	public void generateSoul( int x, int y )
	{
		Instantiate( Resources.Load( "Prefabs/Soul" ), new Vector3( (((float) x) / 2f), (((float) y) / 2f), 0 ), Quaternion.identity );
		Movement.defaultVelocity = 0.05f;
	}

	public void generateGrave( int x, int y )
	{
		Instantiate( Resources.Load( "Prefabs/Grave" ), new Vector3( (((float) x) / 2f), (((float) y) / 2f - 0.25f), 0 ), Quaternion.identity );
	}

	public void generateTombstone( int x, int y )
	{
		Instantiate( Resources.Load( "Prefabs/Tombstone" ), new Vector3( (((float) x) / 2f), (((float) y) / 2f), 0 ), Quaternion.identity );
	}

	// Update is called once per frame
	void Update () {
	
	}
}
