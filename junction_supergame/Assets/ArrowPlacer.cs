using UnityEngine;
using System.Collections;
using System;

public class ArrowPlacer : MonoBehaviour {

    public Transform ArrowGen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, new Vector3(0, 0, 1), 10);

            
            if (!hit || hit.transform.gameObject.tag.Contains("Arrow"))
            {
                if (hit && hit.transform.gameObject.tag.Contains("Arrow"))
                {
                    ArrowGen.GetComponent<ArrowGenerator>().Arrows.Remove(hit.transform);
                    Destroy(hit.transform.gameObject);
                }


                pos.x = (float)Math.Round(2.0 * pos.x) / 2.0f;
                pos.y = (float)Math.Round(2.0 * pos.y) / 2.0f;


                int arrow = GetNextArrow();
                GameObject spawned = new GameObject();
                switch (arrow)
                {
                    case 0:
                        spawned = (GameObject)Instantiate(Resources.Load("Prefabs/ArrowUp"),
                            new Vector3(pos.x, pos.y, 0),
                            new Quaternion(0f, 0f, 0f, 0f));
                        break;
                    case 1:
                        spawned = (GameObject)Instantiate(Resources.Load("Prefabs/ArrowDown"),
                            new Vector3(pos.x, pos.y, 0),
                            new Quaternion(0f, 0f, 0f, 0f));
                        break;
                    case 2:
                        spawned = (GameObject)Instantiate(Resources.Load("Prefabs/ArrowLeft"),
                            new Vector3(pos.x, pos.y, 0),
                            new Quaternion(0f, 0f, 0f, 0f));
                        break;
                    case 3:
                        spawned = (GameObject)Instantiate(Resources.Load("Prefabs/ArrowRight"),
                            new Vector3(pos.x, pos.y, 0),
                            new Quaternion(0f, 0f, 0f, 0f));
                        break;

                }

                ArrowGen.GetComponent<ArrowGenerator>().Arrows.Add(spawned.transform);

            }
        }
    }

    int GetNextArrow()
    {
        int res = ArrowGen.GetComponent<ArrowGenerator>().ArrowNo;
        ArrowGen.GetComponent<ArrowGenerator>().NewArrow();
        return res;
    }
}
