using UnityEngine;
using System.Collections;

public class loro : MonoBehaviour
{
	GameObject objCameraManager;
	CameraManager cameraManager;
	
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
				if(!animation.isPlaying)
					animation.Play("move");
					
				if(audio && !audio.isPlaying)
					audio.Play();
			}
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void LateUpdate()
	{
		if(audio && audio.isPlaying && cameraManager.bChangingPage)
			audio.Stop();
		
		if(animation && animation.isPlaying && cameraManager.bChangingPage)
		{
			animation.Stop();
		}
	}
}








