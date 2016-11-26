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
        
		listOfLevels.Add( () => this.createFirst() );
		listOfLevels.Add( () => this.createSecond() );
		listOfLevels.Add( () => this.createThird() );
		listOfLevels.Add( () => this.createFourth() );
		listOfLevels.Add( () => this.createFifth() );
		listOfLevels.Add( () => this.createSixth() );
        listOfLevels.Add(() => this.K1());
    }

	public bool createNextLevel()
	{
		if( listOfLevels.Count <= nextLevel )
			return false; //TODO start end of game
		listOfLevels.ElementAt( nextLevel ).Invoke();
		nextLevel++;
		return true;
	}

	public bool recreateCurrentLevel()
	{
		try
		{
			listOfLevels.ElementAt( nextLevel - 1 ).Invoke();
			return true;
		}
		catch
		{
			return false;
		}
	}

	private void init()
	{
		boundaryGenerator = GetComponent<GenerateBoundaryWall>();
	}

	private void createFirst()
	{
		//initiate
		init();
		boundaryGenerator.xBoundary = 20;
		boundaryGenerator.yBoundary = 15;


		boundaryGenerator.generate();

		//right walls
		boundaryGenerator.generateWall( 1, 5, 16, 16 );
		boundaryGenerator.generateWall( 9, 13, 16, 16 );

		boundaryGenerator.generateWall( 1, 5, 5, 5 );
		boundaryGenerator.generateWall( 9, 13, 5, 5 );

		boundaryGenerator.generateGrave( 9, 7 );
		boundaryGenerator.generateTombstone( 9, 8 );
		boundaryGenerator.generateGrave( 9, 11 );
		boundaryGenerator.generateTombstone( 9, 12 );
		boundaryGenerator.generateGrave( 9, 3 );
		boundaryGenerator.generateTombstone( 9, 4 );

		boundaryGenerator.generateGrave( 12, 7 );
		boundaryGenerator.generateGrave( 12, 11 );
		boundaryGenerator.generateGrave( 12, 3 );

		boundaryGenerator.generateBody( 1, 7 );
		boundaryGenerator.generateSoul( 1, 1 );
	}

	private void createSecond()
	{
		//initiate
		init();
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
		boundaryGenerator.generateTombstone( 12, 8 );
		boundaryGenerator.generateGrave( 12, 11 );
		boundaryGenerator.generateTombstone( 12, 12 );
		boundaryGenerator.generateGrave( 12, 3 );
		boundaryGenerator.generateTombstone( 12, 4 );

		boundaryGenerator.generateBody( 1, 7 );
		boundaryGenerator.generateSoul( 1, 1 );
	}

	private void createThird()
	{
		//initiate
		init();
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

	private void createFourth()
	{
		init();
		boundaryGenerator.xBoundary = 20;
		boundaryGenerator.yBoundary = 15;

		boundaryGenerator.generate();

		for( int i = 1; i < 7; i++ )
		{
			boundaryGenerator.generateTombstone( i * 3, 12 );
			boundaryGenerator.generateTombstone( i * 3, 7 );
			if( UnityEngine.Random.Range( 0, 2 ) >= 1f ) boundaryGenerator.generateGrave( i * 3, 11 );
			if( UnityEngine.Random.Range( 0, 2 ) >= 1f ) boundaryGenerator.generateGrave( i * 3, 6 );
		}

		for( int i = 1; i < 4; i++ )
		{
			boundaryGenerator.generateTombstone( i * 5, 3 );
		}
		boundaryGenerator.generateBody( 19, 13 );
		boundaryGenerator.generateSoul( 1, 1 );
	}

	private void createFifth()
	{
		init();
		boundaryGenerator.xBoundary = 20;
		boundaryGenerator.yBoundary = 20;

		boundaryGenerator.generate();

		for(int i = 1; i <= 17; i++ )
		{
			boundaryGenerator.generateGrave( i, 18 );
			boundaryGenerator.generateGrave( i, 1 );
		}
		
		for(int i = 2; i <= 17; i++ )
		{
			boundaryGenerator.generateGrave( 1, i );
		}

		boundaryGenerator.generateWall( 17, 17, 2, 17 );
		boundaryGenerator.generateWall( 2, 2, 2, 17 );
		boundaryGenerator.generateWall( 3, 16, 2, 2 );

		boundaryGenerator.generateWall( 14, 13, 6, 7 );
		boundaryGenerator.generateWall( 5, 6, 6, 7 );

		boundaryGenerator.generateWall( 14, 13, 14, 13 );
		boundaryGenerator.generateWall( 5, 6, 14, 13 );

		boundaryGenerator.generateWall( 11, 11, 8, 12 );
		boundaryGenerator.generateWall( 8, 8, 8, 12 );
		boundaryGenerator.generateWall( 9, 10, 8, 8 );

		boundaryGenerator.generateSoul( -1, 3 );
		boundaryGenerator.generateBody( 9, 9 );
	}

	public void createSixth()
	{
		init();
		boundaryGenerator.xBoundary = 40;
		boundaryGenerator.yBoundary = 20;

		boundaryGenerator.generate();

		boundaryGenerator.generateWall( 3, 6, 3, 3 );
		boundaryGenerator.generateWall( 3, 3, 3, 5 );
		boundaryGenerator.generateWall( 3, 6, 6, 6 );

		boundaryGenerator.generateWall( 3, 6, 12, 12 );
		boundaryGenerator.generateWall( 3, 3, 12, 14 );
		boundaryGenerator.generateWall( 3, 6, 15, 15 );

		boundaryGenerator.generateWall( 16, 13, 3, 3 );
		boundaryGenerator.generateWall( 16, 16, 3, 5 );
		boundaryGenerator.generateWall( 16, 13, 6, 6 );

		boundaryGenerator.generateWall( 16, 13, 12, 12 );
		boundaryGenerator.generateWall( 16, 16, 12, 14 );
		boundaryGenerator.generateWall( 16, 13, 15, 15 );

		boundaryGenerator.generateWall( 1, 7, 19, 19 );
		boundaryGenerator.generateWall( 7, 7, 19, 30 );
		boundaryGenerator.generateWall( 1, 7, 30, 30 );

		boundaryGenerator.generateWall( 18, 12, 19, 19 );
		boundaryGenerator.generateWall( 12, 12, 19, 30 );
		boundaryGenerator.generateWall( 12, 18, 30, 30 );

		boundaryGenerator.generateGrave( 9, 4 );
		boundaryGenerator.generateGrave( 9, 5 );
		boundaryGenerator.generateGrave( 9, 6 );

		boundaryGenerator.generateGrave( 9, 14 );
		boundaryGenerator.generateGrave( 9, 15 );
		boundaryGenerator.generateGrave( 9, 16 );

		for( int x = 32; x < 40; x += 3 )
			for( int y = 2; y < 20; y += 3 )
			{
				if( UnityEngine.Random.Range( 0, 2 ) >= 1f ) boundaryGenerator.generateGrave( x, y );
			}

		boundaryGenerator.generateBody( 4, 4 );
		boundaryGenerator.generateSoul( 1, 18 );
	}


	// Update is called once per frame
	void Update () {
	
	}
}
