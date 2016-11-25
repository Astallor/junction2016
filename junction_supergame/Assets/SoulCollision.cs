using UnityEngine;
using System.Collections;

public class SoulCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
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
