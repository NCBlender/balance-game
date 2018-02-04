using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

	
    public GameObject[] SpawnObject;
    public float startPosition = 2f;
    public float endPosition = 50f;
    public float width = 2.5f;
    public int numberOfObjects = 10;



    // Use this for initialization
    void Start () {
        
        StartCoroutine(CreateObject(numberOfObjects));      
    }

    IEnumerator CreateObject(int number)
	{
        int i = 0;
        while (i < number)
        {
            yield return 0;
            int SpawnObjectInstance = Random.Range(0, SpawnObject.Length);
            var newThing = Instantiate(SpawnObject[SpawnObjectInstance]);
            newThing.transform.parent = transform;
            newThing.transform.localPosition = new Vector3(Random.Range(-width, width), 0, Random.Range(startPosition, endPosition));
            i++;
        }
	}

    
}



