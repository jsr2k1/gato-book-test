using UnityEngine;
using System.Collections;

public class AnimFinal : MonoBehaviour
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
		if(cameraManager.currentPage.name == "pagina_04_12")
        	animation.Play();
		else
			animation.Stop();
	}
}
