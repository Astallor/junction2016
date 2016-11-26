using UnityEngine;
using System.Collections;

public class BodySpriteAnimations : MonoBehaviour {

	public Sprite upSprite;
	public Sprite downSprite;
	public Sprite leftSprite;
	public Sprite rightSprite;

	// Use this for initialization
	void Start () {
	
	}

	public void changeSprite(Vector3 direction )
	{
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		if( Vector3.Distance( direction, new Vector3( 0f, 1f, 0f ) ) < 0.1 )
			sr.sprite = upSprite;
		else if( Vector3.Distance( direction, new Vector3( 0f, -1f, 0f ) ) < 0.1 )
			sr.sprite = downSprite;
		else if( Vector3.Distance( direction, new Vector3( 1f, 0f, 0f ) ) < 0.1 )
			sr.sprite = rightSprite;
		else if( Vector3.Distance( direction, new Vector3( -1f, 0f, 0f ) ) < 0.1 )
			sr.sprite = leftSprite;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
