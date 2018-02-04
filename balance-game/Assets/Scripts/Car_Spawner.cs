using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Spawner : MonoBehaviour {

	public GameObject BoxPrefab;

	// Use this for initialization
	void Start () {
		CreateObject();
		
    }

	void CreateObject()
	{
		var box = Instantiate(BoxPrefab);
		box.transform.parent = transform;
		box.transform.localPosition = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(0, 40));
	}

	// Update is called once per frame
	void Update () {
		
	}
}
