﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public bool GameOver = false;
    public bool GameWon = false;
    public bool MenuState = true;
    public Canvas RestartCanvas;
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
}
