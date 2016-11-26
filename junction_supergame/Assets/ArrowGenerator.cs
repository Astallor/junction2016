using UnityEngine;
using System.Collections;

public class ArrowGenerator : MonoBehaviour {
    public int ArrowNo;
    public int ArrowLimit = 3;
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
        ArrowNo = Random.Range(0, 4);
        ArrowCount++;

        if (Arrows.Count >= ArrowLimit)
        {
            Destroy(((Transform)Arrows[0]).gameObject);
            Arrows.Remove(Arrows[0]);
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

	public void destroyArrows()
	{
		for( int i = Arrows.Count - 1; i >= 0; i-- )
		{
			Destroy( ((Transform) Arrows[i]).gameObject );
			Arrows.Remove( Arrows[i] );
		}	
	}
}
