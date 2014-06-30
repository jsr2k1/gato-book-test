using UnityEngine;
using System.Collections;

public class AnimationOnTouch : MonoBehaviour
{
	int estado=0;
	public bool onlyOnce;
	public bool gramofono;
	public bool crossFade;
	public float fadeLength = 0.9f;
	
	public Transform suor_dret;
	public Transform suor_esquerra;
	
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
				if(onlyOnce)
				{
					if(!animation.isPlaying)
					{
						animation.Play("move");
						if(audio)
						{
							audio.Stop();
							audio.Play();
						}
					}
				}
				else
				{
					if(estado==0)
					{
						if(crossFade)
							animation.CrossFade("move", fadeLength);
						else
							animation.Play("move");
						estado=1;
						
						if(audio && !gramofono)
						{
							audio.Play();
						}
						
						if(suor_dret)
							suor_dret.gameObject.SetActive(true);
						
						if(suor_esquerra)
							suor_esquerra.gameObject.SetActive(true);
					}
					else
					{
						if(crossFade)
							animation.CrossFade("idle", fadeLength);
						else
							animation.Play("idle");
						
						if(!gramofono)
							estado=0;
						
						if(gramofono)
							audio.Play();
						
						if(audio && !gramofono)
							audio.Stop();
						
						if(suor_dret)
							suor_dret.gameObject.SetActive(false);
						
						if(suor_esquerra)
							suor_esquerra.gameObject.SetActive(false);
					}
				}
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
			if(animation["idle"] != null)
				animation.Play("idle");
			
			if(!gramofono)
				estado=0;
		}
	}
}








