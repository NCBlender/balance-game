using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Spawner : MonoBehaviour {

    public Rigidbody projectile;
    public Transform Spawnpoint;
    private IEnumerator coroutine;
    public float waitTime;
    public float startTime;


    // Use this for initialization
    void Start () {
        InvokeRepeating("ShootProjectile", startTime, waitTime);
    }
	


    void ShootProjectile() {
        Rigidbody clone;
        clone = (Rigidbody)Instantiate(projectile, Spawnpoint.position, Quaternion.Euler(0, 0, 90));
        clone.velocity = Spawnpoint.TransformDirection(Vector3.forward * 1);
        
    }

}
