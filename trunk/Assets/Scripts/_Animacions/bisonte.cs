using UnityEngine;
using System.Collections;

public class bisonte : MonoBehaviour
{
	CameraManager cameraManager;
	
	//////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		cameraManager = GameObject.Find("_CameraTarget").GetComponent<CameraManager>();
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Update()
	{
		if(cameraManager.currentPage.name == "pagina_03_09")
		{
			if(!animation.isPlaying)
				animation.Play();
			
			if(!audio.isPlaying)
				audio.Play();
		}
		else
		{
			if(animation.isPlaying)
				animation.Stop();
			
			if(audio.isPlaying)
				audio.Stop();
		}	
	}
}
