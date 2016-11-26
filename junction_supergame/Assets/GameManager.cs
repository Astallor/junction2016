using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public bool GameOver = false;
    public bool GameWon = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () { 

        if (GameOver)
        {
            if (!gameObject.GetComponent<SpriteRenderer>())
            {
                SpriteRenderer spriteR = gameObject.AddComponent<SpriteRenderer>();
                spriteR.sprite = Resources.Load<Sprite>("Sprites/GameOver");
                spriteR.sortingLayerName = "GUI";
            }
        }

        if (GameWon)
        {
            if (!gameObject.GetComponent<SpriteRenderer>())
            {
                SpriteRenderer spriteR = gameObject.AddComponent<SpriteRenderer>();
                spriteR.sprite = Resources.Load<Sprite>("Sprites/GameWon");
                spriteR.sortingLayerName = "GUI";
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameOver = GameWon = false;
            Destroy(gameObject.GetComponent<SpriteRenderer>());
			GameObject.FindObjectOfType<LevelHandling>().resetLevel();
            //Application.LoadLevel(0);
        }
	}
}
