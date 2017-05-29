using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour {
    Vector3 position;
	// Use this for initialization
	void Start () {
        position = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        position = transform.localPosition;
        position.x += Random.Range(0.003f, 0.007f);
        position.y += 0.0006f + Random.Range(-0.0001f, 0.0004f);
        position.z += Random.Range(0.0003f, 0.0007f);

        transform.localPosition = position;
	}
}
