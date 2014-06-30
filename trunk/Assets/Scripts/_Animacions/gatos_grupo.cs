using UnityEngine;
using System.Collections;

public class gatos_grupo : MonoBehaviour
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
		if(cameraManager.currentPage.name == "pagina_02_03")
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
