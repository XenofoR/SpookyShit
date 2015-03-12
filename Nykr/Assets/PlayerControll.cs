using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControll : MonoBehaviour 
{
	Dictionary<string, KeyCode> m_keys;
	GameObject m_player;
	float m_normalSpeed;
	float m_sprintSpeed;
	float m_sprintLength;
	Vector2 m_movement;
	// Use this for initialization
	void Start () 
	{
		m_player = GameObject.FindGameObjectWithTag("Player");
		m_keys = new Dictionary<string, KeyCode>();
		m_keys.Add ("forward", KeyCode.W);
		m_keys.Add ("backward", KeyCode.S);
		m_keys.Add ("strafe_left", KeyCode.A);
		m_keys.Add ("strafe_right", KeyCode.D);

		m_keys.Add ("jump", KeyCode.Space);
		m_keys.Add ("sprint", KeyCode.LeftShift);
		m_keys.Add ("crouch", KeyCode.C);

		m_normalSpeed = 500;
		m_sprintSpeed = 750;
		m_sprintLength = 0;
		m_movement = new Vector2(0,0);
	}

	void setKeyValue(string p_key, KeyCode p_value)
	{
		m_keys[p_key] = p_value;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(Input.GetKeyDown(m_keys["forward"]))
			m_movement.y = 1;
		if(Input.GetKeyDown(m_keys["backward"]))
			m_movement.y = -1;
		if(Input.GetKeyDown(m_keys["strafe_left"]))
			m_movement.x = -1;
		if(Input.GetKeyDown(m_keys["strafe_right"]))
			m_movement.x = 1;

		if(Input.GetKeyUp(m_keys["forward"]))
			m_movement.y = 0;
		if(Input.GetKeyUp(m_keys["backward"]))
			m_movement.y = 0;
		if(Input.GetKeyUp(m_keys["strafe_left"]))
			m_movement.x = 0;
		if(Input.GetKeyUp(m_keys["strafe_right"]))
			m_movement.x = 0;

		m_player.rigidbody.AddForce (new Vector3 (m_movement.x * m_normalSpeed, 0, m_movement.y * m_normalSpeed));
	}
}
