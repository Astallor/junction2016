using UnityEngine;
using System.Collections;

public class BodyCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    //void OnCollisionEnter2D( Collision2D coll )
    //{
        
    //}

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if( collision.gameObject.tag == "Wall" )
        {
            GetComponent<Movement>().m_direction = Quaternion.Euler( 0, 0, -90 ) * GetComponent<Movement>().m_direction;
        }
        else if( collision.gameObject.tag == "Grave" )
        {
            Debug.Log( "You DIEDEDEDEDEDEDED!!!" );
        }
    }
}
