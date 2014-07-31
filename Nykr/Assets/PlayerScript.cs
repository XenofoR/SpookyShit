using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private bool m_justWarped;
	// Use this for initialization
	void Start () 
	{
		m_justWarped = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetPlayerWarp(bool p_status)
	{
		m_justWarped = p_status;
	}

	public bool JustWarped()
	{
		return m_justWarped;
	}
}
