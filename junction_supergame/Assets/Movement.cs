using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public Vector3 m_direction;
    public float m_velocity = 0.05f;
    public const float defaultVelocity = 0.05f;
    public const float Speed = 1.0f;

    // Use this for initialization
    void Start () {
        m_direction = new Vector3( 1.0f, 0.0f );
    }
	
	// Update is called once per frame
	void Update () {
        userInput();
		transform.Translate( m_direction * m_velocity );
	}

	void userInput()
    {
        if( Input.GetKey( KeyCode.RightArrow ) )
            m_direction.Set( Speed, 0.0f, 0.0f );
        else if( Input.GetKey( KeyCode.LeftArrow ) )
            m_direction.Set( -Speed, 0.0f, 0.0f );
        else if( Input.GetKey( KeyCode.UpArrow ) )
            m_direction.Set( 0.0f, Speed, 0.0f );
        else if( Input.GetKey( KeyCode.DownArrow ) )
            m_direction.Set( 0.0f, -Speed, 0.0f );
    }

    private void OnTriggerStay2D( Collider2D collision )
    {
        if( collision.gameObject.tag.Contains("Arrow") )
            if( Vector3.Distance(collision.transform.position, this.transform.position) < 2*m_velocity  )
            {
                setVectorByArrow( collision.gameObject.tag );
                transform.position = new Vector3( collision.transform.position.x, collision.transform.position.y + m_direction.y*m_velocity, 0.0f );
                Debug.Log( "Trigger" );
            }
    }

    private void setVectorByArrow( string tag )
    {
        switch(tag)
        {
            case "UpArrow":
                m_direction.Set( 0.0f, Speed, 0.0f );
                break;
            case "DownArrow":
                m_direction.Set( 0.0f, -Speed, 0.0f );
                break;
            case "RightArrow":
                m_direction.Set( Speed, 0.0f, 0.0f );
                break;
            case "LeftArrow":
                m_direction.Set( -Speed, 0.0f, 0.0f );
                break;


        }
        
        
    }
}
