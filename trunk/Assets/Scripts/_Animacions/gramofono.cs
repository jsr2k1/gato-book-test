using UnityEngine;
using System.Collections;

public class gramofono : MonoBehaviour
{
	int estado=0;
	public AudioClip audio_planta;
	public AudioClip audio_trompeta;
	
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
				if(estado==0)
				{
					if(!animation.isPlaying)
					{
						animation.Play("move");
						audio.clip=audio_planta;
						audio.Play();
						estado=1;
					}
				}
				else
				{
					if(!animation.isPlaying)
					{
						animation.Play("idle");
						audio.clip=audio_trompeta;
						audio.Play();
					}
				}
			}
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void LateUpdate()
	{
		if(audio && audio.isPlaying && cameraManager.bChangingPage)
		{
			audio.Stop();
			estado=0;
		}
	}
}








