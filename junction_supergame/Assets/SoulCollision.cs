using UnityEngine;
using System.Collections;

public class SoulCollision : MonoBehaviour {
    public Vector2 xBound = new Vector2(-5, 10);
    public Vector2 yBound = new Vector2(-1, 20);

    // Use this for initialization
    void Start () {
	
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
        }
        Debug.Log( "Collision Soul" );
    }
    
    private void OnTriggerExit2D( Collider2D collision )
    {
        if( collision.gameObject.tag == "Wall" )
        {
            //GetComponent<Movement>().m_vector.Scale( new Vector3( 4f, 4f ) );
            GetComponent<Movement>().m_velocity = Movement.defaultVelocity;
        }
    }
}
