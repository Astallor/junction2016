using UnityEngine;
using System.Collections;

public class SoulCollision : MonoBehaviour {
    private Vector2 xBound = new Vector2(-5, 10);
    private Vector2 yBound = new Vector2(-1, 20);
    public float tolerance = 3;

    // Use this for initialization
    void Start () {
        //20 15
        GameObject lvlH = GameObject.FindGameObjectWithTag("LevelHandler");
        float xWall = lvlH.GetComponent<GenerateBoundaryWall>().xBoundary;
        float yWall = lvlH.GetComponent<GenerateBoundaryWall>().xBoundary; 
        xBound = new Vector2(-tolerance, tolerance + xWall/2.0f);
        yBound = new Vector2(-tolerance, tolerance + yWall/2.0f);
        GetComponent<Animator>().SetInteger( "Wall", 0 );
    }
	
	// Update is called once per frame
	void Update () {
	    if (transform.position.x < xBound.x || 
            transform.position.x > xBound.y ||
            transform.position.y < yBound.x ||
            transform.position.y > yBound.y)
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameOver = true;
        }
	}

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if( collision.gameObject.tag == "Wall" )
        {
            //GetComponent<Movement>().m_vector.Scale( new Vector3( 0.25f, 0.25f ) );
            GetComponent<Movement>().m_velocity = Movement.defaultVelocity/4;
            GetComponent<Animator>().SetInteger( "Wall", 1 );
        }
        Debug.Log( "Collision Soul" );
    }
    
    private void OnTriggerExit2D( Collider2D collision )
    {
        if( collision.gameObject.tag == "Wall" )
        {
            //GetComponent<Movement>().m_vector.Scale( new Vector3( 4f, 4f ) );
            GetComponent<Movement>().m_velocity = Movement.defaultVelocity;
            GetComponent<Animator>().SetInteger( "Wall", 0 );
        }
    }
}
