using UnityEngine;
using System.Collections;

public class Serp : MonoBehaviour
{
	public Transform serp01;
	public Transform serp02;
	
	public AudioClip audio_serp1;
	public AudioClip audio_serp2;
	
	string estado="serp02";
	MegaPointCache megaPointCache;
	
	GameObject objCameraManager;
	CameraManager cameraManager;
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		objCameraManager = GameObject.Find("_CameraTarget");
		cameraManager = objCameraManager.GetComponent<CameraManager>();
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Start()
	{
		serp02.gameObject.SetActive(false);
		megaPointCache = serp01.GetComponent<MegaPointCache>();
		megaPointCache.animated=false;
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Update()
	{
		if(PlatformManager.CheckInput())
		{
			RaycastHit hit = new RaycastHit();
			Ray ray = PlatformManager.GetScreenRay();
			
			if(collider.Raycast(ray, out hit, Mathf.Infinity))
			{
				if(estado=="serp01")
				{
					serp01.gameObject.SetActive(false);
					serp02.gameObject.SetActive(true);
					estado="serp02";
				
					if(!audio.isPlaying)
					{
						audio.clip=audio_serp2;
						audio.Play();
					}
				}
				else
				{
					if(megaPointCache.time==0.0f || megaPointCache.time > megaPointCache.maxtime)
					{
						serp01.gameObject.SetActive(true);
						megaPointCache.time=0.0f;
						megaPointCache.animated=true;
						serp02.gameObject.SetActive(false);
						
						if(megaPointCache.time>megaPointCache.maxtime)
							estado="serp01";
						
						if(!audio.isPlaying)
						{
							audio.clip=audio_serp1;
							audio.Play();
						}
					}
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
