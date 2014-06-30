using UnityEngine;
using System.Collections;

public class AnimationOnTouchMegafiers : MonoBehaviour
{
	MegaPointCache megaPointCache;
	
	GameObject objCameraManager;
	CameraManager cameraManager;
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		objCameraManager = GameObject.Find("_CameraTarget");
		cameraManager = objCameraManager.GetComponent<CameraManager>();
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Start()
	{
		megaPointCache = GetComponent<MegaPointCache>();
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
				if(megaPointCache.time==0.0f || megaPointCache.time > megaPointCache.maxtime)
				{
					megaPointCache.animated=true;
					megaPointCache.time=0.0f;
				
					if(audio && !audio.isPlaying)
						audio.Play();
				}
			}
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void LateUpdate()
	{
		if(audio && audio.isPlaying && cameraManager.bChangingPage)
			audio.Stop();
	}
}








