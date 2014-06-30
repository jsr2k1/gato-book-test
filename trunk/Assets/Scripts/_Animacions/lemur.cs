using UnityEngine;
using System.Collections;

public class lemur : MonoBehaviour
{
	string estado="right";
	public Transform ulls;
	
	GameObject objCameraManager;
	CameraManager cameraManager;
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		objCameraManager = GameObject.Find("_CameraTarget");
		cameraManager = objCameraManager.GetComponent<CameraManager>();
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
				if(!animation.isPlaying)
				{
					if(estado=="right")
					{
						animation.Play("right");
						ulls.animation.Play("right");
						estado="left";
					}
				
					else
					{
						animation.Play("left");
						ulls.animation.Play("left");
						estado="right";
					}
					
					if(audio && !audio.isPlaying)
							audio.Play();
				}
			}
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void LateUpdate()
	{
		if(audio && audio.isPlaying && cameraManager.bChangingPage)
			audio.Stop();
	}
}
