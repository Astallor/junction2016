using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public bool GameOver = false;
    public bool GameWon = false;
    public bool MenuState = true;
    public bool HowToPlay = false;
    public Canvas RestartCanvas;
    public Canvas TutorialCanvas;
    public Canvas MenuCanvas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () { 

        if (GameOver)
        {
            Time.timeScale = 0;

            RestartCanvas.gameObject.SetActive(true);

            if (!gameObject.GetComponent<SpriteRenderer>())
            {
                SpriteRenderer spriteR = gameObject.AddComponent<SpriteRenderer>();
                spriteR.sprite = Resources.Load<Sprite>("Sprites/GameOver");
                spriteR.sortingLayerName = "GUI";
            }
        }

        if (GameWon)
        {
            Time.timeScale = 0;

            RestartCanvas.gameObject.SetActive(true);

            if (!gameObject.GetComponent<SpriteRenderer>())
            {
                SpriteRenderer spriteR = gameObject.AddComponent<SpriteRenderer>();
                spriteR.sprite = Resources.Load<Sprite>("Sprites/GameWon");
                spriteR.sortingLayerName = "GUI";
            }
        }

        if (MenuState)
        {
            Time.timeScale = 0;
            if (!gameObject.GetComponent<SpriteRenderer>())
            {
                SpriteRenderer spriteR = gameObject.AddComponent<SpriteRenderer>();
                spriteR.sprite = Resources.Load<Sprite>("Sprites/Menu");
                spriteR.sortingLayerName = "GUI";    
            }
        }

        

        if (Input.GetKeyDown(KeyCode.R))
        {
            Replay();
            //Application.LoadLevel(0);
        }
	}

    public void StartGame()
    {
        Replay();

        Destroy(GameObject.FindGameObjectWithTag("MenuCanvas"));
    }

    public void Replay()
    {
        Time.timeScale = 1;

        GameOver = GameWon = MenuState = false;
        Destroy(gameObject.GetComponent<SpriteRenderer>());
        GameObject.FindObjectOfType<LevelHandling>().resetLevel();

        RestartCanvas.gameObject.SetActive(false);
    }

    public void Tutorial()
    {
        Time.timeScale = 0;
        TutorialCanvas.gameObject.SetActive(true);
        if (!gameObject.GetComponent<SpriteRenderer>())
        {
            SpriteRenderer spriteR = gameObject.AddComponent<SpriteRenderer>();
            spriteR.sprite = Resources.Load<Sprite>("Sprites/HowTo");
            spriteR.sortingLayerName = "GUI";
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/HowTo");
            MenuCanvas.gameObject.SetActive(false);
        }
    }

    public void BackToMenu()
    {
        MenuState = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Menu");
        MenuCanvas.gameObject.SetActive(true);
        TutorialCanvas.gameObject.SetActive(false);
    }
}
