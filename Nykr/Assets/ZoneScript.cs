using UnityEngine;
using System.Collections;

public class ZoneScript : MonoBehaviour {

	bool m_linearMove;
	bool m_pointMove;
	int m_Id;
	GameObject[] m_points;
	PlayerScript m_playerScript;
	// Use this for initialization
	void Start () 
	{
		m_linearMove = true;
		m_pointMove = false;
	
		m_playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
		m_Id = int.Parse(gameObject.tag[4].ToString());

		m_points = GameObject.FindGameObjectsWithTag("WarpPoint");
	}

	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			m_linearMove = true;
			m_pointMove = false;
		}
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			m_pointMove = true;
			m_linearMove = false;
		}
		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			m_linearMove = m_pointMove = false;
		}

	}

	void OnTriggerEnter(Collider p_other)
	{
		if(p_other.tag == "Player" && !m_playerScript.JustWarped())
		{
			Terrain terra = Terrain.activeTerrain;
			Vector3 terraSize = terra.terrainData.size;
			if(m_linearMove)
				p_other.transform.Translate(terraSize.x - gameObject.renderer.bounds.size.x, 0, 0, gameObject.transform); //Space.World so that we do not use the camera direction
			else if(m_pointMove)
			{
				p_other.transform.localPosition = m_points[0].transform.localPosition;
			}

			m_playerScript.SetPlayerWarp(true);
		}
	}

	void OnTriggerExit(Collider p_other)
	{
		if (p_other.tag == "Player")
			m_playerScript.SetPlayerWarp(false);
	}
}
