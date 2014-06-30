using UnityEngine;
using System.Collections;

public class CaratulaLogo : MonoBehaviour
{
	public string m_level_name;
	public float m_time = 4.0f;
	
	float startTime;
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake ()
	{
		startTime = Time.time;
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Update()
	{
		float elapsedTime = Time.time - startTime;
		
		if(elapsedTime > m_time)
			Application.LoadLevel(m_level_name);
	}
}
