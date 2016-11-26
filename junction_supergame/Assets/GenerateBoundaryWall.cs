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
				Instantiate( wall, new Vector3( (((float) x) / 2f), (((float) y )/ 2f), 0 ), Quaternion.identity );
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
		Instantiate( Resources.Load( "Prefabs/Grave" ), new Vector3( (((float) x) / 2f), (((float) y) / 2f), 0 ), Quaternion.identity );
	}

	// Update is called once per frame
	void Update () {
	
	}
}
