using UnityEngine;
using System.Collections;

public class Catalejo : MonoBehaviour
{
	public Transform m_main_cam;
	CameraManager cameraManager;
	
	public Vector3 m_pos_cola_bisonte;
	public Vector3 m_pos_marinero;
	
	public bool isCatalejo;
	bool cambiar=false;
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		cameraManager = GameObject.Find("_CameraTarget").GetComponent<CameraManager>();
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Update ()
	{
		if(PlatformManager.CheckInput())
		{
			RaycastHit hit = new RaycastHit();
			Ray ray = PlatformManager.GetScreenRay();
			
			if(collider.Raycast(ray, out hit, Mathf.Infinity))
			{
				cambiar=true;
			}
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void LateUpdate()
	{
		if(cambiar)
		{
			if(isCatalejo)
			{
				m_main_cam.position = m_pos_cola_bisonte;
				m_main_cam.GetChild(0).camera.orthographicSize=8.0f;
				cameraManager.enabled=false;
				
			}
			else
			{
				m_main_cam.position = m_pos_marinero;
				cameraManager.enabled=true;
				m_main_cam.GetChild(0).camera.orthographicSize=14.9f;
			}
			
			cambiar=false;
		}
	}
}




