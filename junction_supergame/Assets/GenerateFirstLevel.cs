using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public class GenerateFirstLevel : MonoBehaviour {

	private GenerateBoundaryWall boundaryGenerator;
	private List<Action> listOfLevels;
	private int nextLevel;


	// Use this for initialization
	void Start () {
				
	}

	public void initialize()
	{
		nextLevel = 0;
		listOfLevels = new List<Action>();
        listOfLevels.Add(() => this.K1());  
		listOfLevels.Add( () => this.createFirst() );
		listOfLevels.Add( () => this.createSecond() );
		listOfLevels.Add( () => this.createThird() );
	}

	public bool createNextLevel()
	{
		if( listOfLevels.Count <= nextLevel )
			return false; //TODO start end of game
		listOfLevels.ElementAt( nextLevel ).Invoke();
		nextLevel++;
		return true;
	}

	public void recreateCurrentLevel()
	{
		listOfLevels.ElementAt( nextLevel-1 ).Invoke();
	}

	private void createFirst()
	{
		//initiate
		boundaryGenerator = GetComponent<GenerateBoundaryWall>();
		boundaryGenerator.xBoundary = 20;
		boundaryGenerator.yBoundary = 15;


		boundaryGenerator.generate();

		//right walls
		boundaryGenerator.generateWall( 1, 5, 16, 16 );
		boundaryGenerator.generateWall( 9, 13, 16, 16 );

		boundaryGenerator.generateWall( 1, 5, 5, 5 );
		boundaryGenerator.generateWall( 9, 13, 5, 5 );

		boundaryGenerator.generateGrave( 9, 7 );
		boundaryGenerator.generateGrave( 9, 11 );
		boundaryGenerator.generateGrave( 9, 3 );

		boundaryGenerator.generateGrave( 12, 7 );
		boundaryGenerator.generateGrave( 12, 11 );
		boundaryGenerator.generateGrave( 12, 3 );

		boundaryGenerator.generateBody( 1, 7 );
		boundaryGenerator.generateSoul( 1, 1 );
	}

	private void createSecond()
	{
		//initiate
		boundaryGenerator = GetComponent<GenerateBoundaryWall>();
		boundaryGenerator.xBoundary = 20;
		boundaryGenerator.yBoundary = 15;


		boundaryGenerator.generate();
		//do the left most tomb
		boundaryGenerator.generateWall( 5, 5, 1, 6 );
		boundaryGenerator.generateWall( 9, 9, 1, 6 );
		boundaryGenerator.generateWall( 8, 8, 6, 6 );
		boundaryGenerator.generateWall( 6, 6, 6, 6 );

		//right walls
		boundaryGenerator.generateWall( 1, 5, 16, 16 );
		boundaryGenerator.generateWall( 9, 13, 16, 16 );
		boundaryGenerator.generateWall( 11, 13, 14, 15 );
		boundaryGenerator.generateWall( 1, 3, 14, 15 );

		boundaryGenerator.generateGrave( 9, 7 );
		boundaryGenerator.generateGrave( 9, 11 );
		boundaryGenerator.generateGrave( 9, 3 );

		boundaryGenerator.generateGrave( 12, 7 );
		boundaryGenerator.generateGrave( 12, 11 );
		boundaryGenerator.generateGrave( 12, 3 );

		boundaryGenerator.generateBody( 1, 7 );
		boundaryGenerator.generateSoul( 1, 1 );
	}

	private void createThird()
	{
		//initiate
		boundaryGenerator = GetComponent<GenerateBoundaryWall>();
		boundaryGenerator.xBoundary = 20;
		boundaryGenerator.yBoundary = 15;


		boundaryGenerator.generate();
		//do the left most tomb
		boundaryGenerator.generateWall( 5, 5, 1, 6 );
		boundaryGenerator.generateWall( 9, 9, 1, 6 );
		boundaryGenerator.generateWall( 8, 8, 6, 6 );
		boundaryGenerator.generateWall( 6, 6, 6, 6 );

		//right walls
		boundaryGenerator.generateWall( 5, 5, 14, 19 );
		boundaryGenerator.generateWall( 9, 9, 14, 19 );
		boundaryGenerator.generateWall( 1, 5, 14, 14 );
		boundaryGenerator.generateWall( 9, 13, 14, 14 );

		boundaryGenerator.generateGrave( 9, 7 );
		boundaryGenerator.generateGrave( 9, 11 );
		boundaryGenerator.generateGrave( 9, 3 );

		boundaryGenerator.generateGrave( 12, 7 );
		boundaryGenerator.generateGrave( 12, 11 );
		boundaryGenerator.generateGrave( 12, 3 );

		boundaryGenerator.generateBody( 1, 7 );
		boundaryGenerator.generateSoul( 1, 1 );
	}

    private void K1 ()
    {
        //initiate
        boundaryGenerator = GetComponent<GenerateBoundaryWall>();
        boundaryGenerator.xBoundary = 20;
        boundaryGenerator.yBoundary = 15;


        boundaryGenerator.generate();
        //do the left most tomb
        boundaryGenerator.generateWall(2, 12, 2, 2);
        boundaryGenerator.generateWall(4, 10, 5, 5);
        boundaryGenerator.generateWall(9, 9, 6, 12);
        boundaryGenerator.generateWall(10, 13, 14, 14);

        boundaryGenerator.generateGrave(5, 13);
        boundaryGenerator.generateGrave(6, 13);
        boundaryGenerator.generateGrave(7, 13);
        boundaryGenerator.generateGrave(8, 13);
        boundaryGenerator.generateGrave(9, 13);
        boundaryGenerator.generateGrave(10, 13);
        boundaryGenerator.generateGrave(11, 13);


        boundaryGenerator.generateGrave(13, 15);

        boundaryGenerator.generateGrave(5, 1);
        boundaryGenerator.generateGrave(6, 1);
        boundaryGenerator.generateGrave(7, 1);
        boundaryGenerator.generateGrave(8, 1);
        boundaryGenerator.generateGrave(9, 1);
        boundaryGenerator.generateGrave(10, 1);
        boundaryGenerator.generateGrave(11, 1);


        boundaryGenerator.generateGrave(17, 5);
        boundaryGenerator.generateGrave(15, 3);
        boundaryGenerator.generateGrave(13, 10);

        boundaryGenerator.generateBody(1, 7);
        boundaryGenerator.generateSoul(1, 1);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
