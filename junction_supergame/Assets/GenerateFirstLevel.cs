using UnityEngine;
using System.Collections;

public class GenerateFirstLevel : MonoBehaviour {

	private GenerateBoundaryWall boundaryGenerator;


	// Use this for initialization
	void Start () {
		boundaryGenerator = GetComponent<GenerateBoundaryWall>();
		boundaryGenerator.xBoundary = 20;
		boundaryGenerator.yBoundary = 15;
		create();
	}

	public void create()
	{
		boundaryGenerator.generate();
		boundaryGenerator.generateWall( 5, 5, 1, 6 );
		boundaryGenerator.generateWall( 9, 9, 1, 6 );
		boundaryGenerator.generateWall( 8, 8, 6, 6 );
		boundaryGenerator.generateWall( 6, 6, 6, 6 );

		boundaryGenerator.generateBody( 1, 7 );
		boundaryGenerator.generateSoul( 1, 1 );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
