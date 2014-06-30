using UnityEngine;
using System.Collections;

public class ocell_branques : MonoBehaviour
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
		if(cameraManager.currentPage.name == "pagina_02_06")
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
