using UnityEngine;
using System.Collections;

public class BodyCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter2D( Collision2D coll )
    {
        if( coll.gameObject.tag == "Wall" )
        {
            GetComponent<Movement>().m_direction = Quaternion.Euler( 0, 0, -90 ) * GetComponent<Movement>().m_direction;
        }
        else if( coll.gameObject.tag == "Grave" )
        {
            Debug.Log( "You DIEDEDEDEDEDEDED!!!" );
        }
    } 
}
