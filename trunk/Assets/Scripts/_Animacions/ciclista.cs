using UnityEngine;
using System.Collections;

public class ciclista : MonoBehaviour
{
	string estado = "parado";
	
	GameObject objCameraManager;
	CameraManager cameraManager;
	
	public Transform[] hijos;
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		objCameraManager = GameObject.Find("_CameraTarget");
		cameraManager = objCameraManager.GetComponent<CameraManager>();
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Update()
	{
		if(PlatformManager.CheckInput())
		{
			RaycastHit hit = new RaycastHit();
			Ray ray = PlatformManager.GetScreenRay();
			
			if(collider.Raycast(ray, out hit, Mathf.Infinity))
			{
				if(estado=="parado")
				{
					ActivarHijos(true);
					
					estado="moviendo";
					if(audio)
						audio.Play();
				}
				else
				{
					ActivarHijos(false);
					
					estado="parado";
					if(audio)
						audio.Stop();
				}
			}
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void ActivarHijos(bool bActivar)
	{
		foreach(Transform child in hijos)
		{
			child.GetComponent<MegaPointCache>().animated = bActivar;
			child.GetComponent<MegaPointCache>().time = 0.0f;
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void LateUpdate()
	{
		if(audio && audio.isPlaying && cameraManager.bChangingPage)
			audio.Stop();
		
		if(estado=="moviendo" && cameraManager.bChangingPage)
		{
			ActivarHijos(false);
			estado="parado";
		}
	}
}








