using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveTimeObject : MonoBehaviour {

	[SerializeField]
	float liveTime=3f;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, liveTime);		
	}

}
