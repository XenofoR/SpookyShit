using UnityEngine;
using System.Collections;

public class MistZone : MonoBehaviour {
	GameObject[] m_points;
	GameObject[] m_particleSystems;
	// Use this for initialization
	void Start () 
	{

		m_points = GameObject.FindGameObjectsWithTag("WarpPoint");
		m_particleSystems = GameObject.FindGameObjectsWithTag("MistZone");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Check time on particlesystem and pause? Thus creating a permanent mist?
	}

	void OnTriggerEnter(Collider p_other)
	{
		if(p_other.tag == "Player")
		{
			foreach(GameObject system in m_particleSystems)
			{
				system.particleSystem.Play();
			}
		}
	}
	
	void OnTriggerExit(Collider p_other)
	{
		p_other.transform.localPosition = m_points[0].transform.localPosition;
	}
}
