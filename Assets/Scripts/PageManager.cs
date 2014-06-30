using UnityEngine;
using System.Collections;

public class PageManager : MonoBehaviour
{
	public Transform left;
	public Transform right;
	public Transform up;
	public Transform down;
	
	GameObject objCameraManager;
	CameraManager cameraManager;
	
	
	////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		objCameraManager = GameObject.Find("_CameraTarget");
		cameraManager = objCameraManager.GetComponent<CameraManager>();
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////
	
	void PlayNarration()
	{	
		if(audio)
		{
			if(audio.isPlaying)
				audio.Stop();
			else
				audio.Play();
		}
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////
	
	void StopNarration()
	{
		if(audio.isPlaying)
			audio.Stop();
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////
	
	void LateUpdate()
	{
		if(audio && audio.isPlaying && cameraManager.bChangingPage)
			audio.Stop();
	}
}
