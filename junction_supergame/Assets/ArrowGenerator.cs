using UnityEngine;
using System.Collections;
using System;

using System.Collections.Generic;

public class ArrowGenerator : MonoBehaviour {
    public int ArrowNo;
    public int ArrowLimit = 2;
    public Transform Displayed;
    private int ArrowCount;
    public ArrayList Arrows = new ArrayList();

	// Use this for initialization
	void Start () {
        ArrowNo = 0;
        ArrowCount = 0;

        GameObject spawned = (GameObject)Instantiate(Resources.Load("Prefabs/ArrowUp"),
                        new Vector3(transform.position.x, transform.position.y, 0),
                        new Quaternion(0f, 0f, 0f, 0f));

        spawned.transform.Translate(new Vector3(0, -0.5f, 0));

        Displayed = spawned.transform;
    }
	
	public void NewArrow()
    {
        ArrowNo = UnityEngine.Random.Range(0, 4);
        ArrowCount++;
        

        for (int i = 0; i < Arrows.Count; i++)
        {
            KeyValuePair<Transform, int> Arr = (KeyValuePair < Transform, int> )(Arrows[i]);
            Arrows[i] = new KeyValuePair<Transform, int>(Arr.Key, Arr.Value+1);

         

            if (Arr.Value >= ArrowLimit)
            {
                Destroy(Arr.Key.gameObject);
                Arrows.Remove(Arrows[0]);
                i--;
            }
        }
       

        Destroy(Displayed.gameObject);
        GameObject spawned = new GameObject();
        switch (ArrowNo)
        {
            case 0:
                spawned = (GameObject)Instantiate(Resources.Load("Prefabs/ArrowUp"),
                        new Vector3(transform.position.x, transform.position.y, 0),
                        new Quaternion(0f, 0f, 0f, 0f));

                break;
            case 1:
                spawned = (GameObject)Instantiate(Resources.Load("Prefabs/ArrowDown"),
                        new Vector3(transform.position.x, transform.position.y, 0),
                        new Quaternion(0f, 0f, 0f, 0f));
                break;
            case 2:
                spawned = (GameObject)Instantiate(Resources.Load("Prefabs/ArrowLeft"),
                        new Vector3(transform.position.x, transform.position.y, 0),
                        new Quaternion(0f, 0f, 0f, 0f));
                break;
            case 3:
                spawned = (GameObject)Instantiate(Resources.Load("Prefabs/ArrowRight"),
                        new Vector3(transform.position.x, transform.position.y, 0),
                        new Quaternion(0f, 0f, 0f, 0f));
                break;
        }
        spawned.transform.Translate(new Vector3(0, -0.5f, 0));
        Displayed = spawned.transform;
    }

    public void RemoveFromArrows(Transform atransform)
    {
        
        foreach(var ArrStr in Arrows)
        {
            KeyValuePair<Transform, int> Arr = (KeyValuePair<Transform, int>)ArrStr;
            if (Arr.Key == atransform)
            {
                Destroy(Arr.Key.gameObject);
                Arrows.Remove(Arr);
                return;
            }
        }
    }

    public void destroyArrows()
	{
		for( int i = Arrows.Count - 1; i >= 0; i-- )
		{
            KeyValuePair<Transform, int> Arr = (KeyValuePair<Transform, int>)(Arrows[i]);
            Destroy(Arr.Key.gameObject);
            Arrows.Remove( Arrows[i] );
		}
        ArrowCount = 0;
	}
}
