using UnityEngine;
using System.Collections;

public class AsteroidMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * 2;
        GetComponent<Rigidbody>().velocity = 25 * transform.forward;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
