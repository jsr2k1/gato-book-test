using UnityEngine;
using System.Collections;

public class mar : MonoBehaviour
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
		if(cameraManager.currentPage.name == "pagina_04_09")
		{
			if(!audio.isPlaying)
				audio.Play();
		}
		else
		{
			if(audio.isPlaying)
				audio.Stop();
		}	
	}
}
