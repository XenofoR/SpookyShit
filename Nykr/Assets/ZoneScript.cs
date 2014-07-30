using UnityEngine;
using System.Collections;

public class ZoneScript : MonoBehaviour {

	bool m_linearMove;
	bool m_pointMove;
	int m_Id;
	GameObject[] m_points;
	// Use this for initialization
	void Start () 
	{
		m_linearMove = true;
		m_pointMove = false;

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
		if(p_other.tag == "Player")
		{
			Terrain terra = Terrain.activeTerrain;
			Vector3 terraSize = terra.terrainData.size;
			float moveOffset = terraSize.x - p_other.transform.localPosition.x; //Offset the current camera position so that we move the length of the terrain minus what we have walked
			if(m_linearMove)
				p_other.transform.Translate(-(terraSize.x - moveOffset), 0, 0, gameObject.transform); //Space.World so that we do not use the camera direction
			else if(m_pointMove)
			{
				p_other.transform.localPosition = m_points[0].transform.localPosition;
			}
		}
	}
}
