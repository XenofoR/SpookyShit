using UnityEngine;
using System.Collections;

public class ZoneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider p_other)
	{
		if (p_other.tag == "Player") 
		{
			p_other.transform.Translate(200, 0, 0, Space.Self);
		}
	}
}
