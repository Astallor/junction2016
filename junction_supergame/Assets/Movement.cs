using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public Vector3 m_direction;
    public float m_velocity = 0.05f;
    public static float defaultVelocity = 0.05f;
    public const float Speed = 1.0f;
    private bool m_arrowInteract;
    private Animator m_anim;

    // Use this for initialization
    void Start () {
        m_velocity = 0.05f;
        m_direction = new Vector3( 1.0f, 0.0f );
        m_arrowInteract = true;
        m_anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        userInput();
        //transform.Translate( m_direction * m_velocity );
        GetComponent<Rigidbody2D>().velocity = m_direction * m_velocity * 30;
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
            if( m_arrowInteract && Vector3.Distance(collision.transform.position, transform.position) < 3*m_velocity  )
            {
                m_arrowInteract = false;
                setVectorByArrow( collision.gameObject.tag );
                transform.position = new Vector3( collision.transform.position.x + m_direction.x * 3 * m_velocity, collision.transform.position.y + m_direction.y * 3 * m_velocity, 0.0f );
                Debug.Log( "Trigger" );
            }
    }

    private void OnTriggerExit2D( Collider2D collision )
    {
        if( collision.gameObject.tag.Contains( "Arrow" ) )
            m_arrowInteract = true;
    }

    private void setVectorByArrow( string tag )
    {
        switch(tag)
        {
            case "UpArrow":
                m_direction.Set( 0.0f, Speed, 0.0f );
                m_anim.SetInteger( "Direction", 2 );
                break;
            case "DownArrow":
                m_direction.Set( 0.0f, -Speed, 0.0f );
                m_anim.SetInteger( "Direction", -2 );
                break;
            case "RightArrow":
                m_direction.Set( Speed, 0.0f, 0.0f );
                m_anim.SetInteger( "Direction", 1 );
                break;
            case "LeftArrow":
                m_direction.Set( -Speed, 0.0f, 0.0f );
                m_anim.SetInteger( "Direction", -1 );
                break;


        }
        
        
    }
}
