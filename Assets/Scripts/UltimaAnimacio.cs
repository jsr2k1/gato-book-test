using UnityEngine;
using System.Collections;

public class UltimaAnimacio : MonoBehaviour
{
	CameraManager cameraManager;
	
	//public Transform[] pagina_inicio;
	//public Transform[] pagina_final;
	
	public Transform gato_final_02;
	public Transform gato_final_03;
	
	public Vector3 pos_cam_02;
	public Vector3 pos_cam_03;
	
	public Transform pagina_final_01;
	public Transform pagina_final_02;
	public Transform pagina_final_03;
	
	public AudioClip so_final_02;
	public AudioClip so_final_03;
	
	public string estado="inicio";
	
	public GUIStyle dummy_style;
	
	public Transform ganso;
	
	float screenWidth = 1024;
	float screenHeight = 768;
	
	////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		cameraManager = GetComponent<CameraManager>();
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Update()
	{
		if(estado=="inicio" && cameraManager.currentPage.name == "pagina_04_09")
		//if(estado=="inicio" && cameraManager.currentPage.name == "pagina_02_03")
		{
			//DesactivarInicio();
			//ActivarFinal();
			estado="final_01_previo";
			
			//ganso.localScale = new Vector3(-ganso.localScale.x, ganso.localScale.y, ganso.localScale.z);
			//ganso.position = new Vector3(31.5f, ganso.position.y, ganso.position.z);
		}
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void OnGUI()
	{
		//Reescalamos el GUI para que se adapte a las diferentes resoluciones de pantalla
		Vector3 scale;
		scale.x = Screen.width/screenWidth;
	    scale.y = Screen.height/screenHeight;
		scale.z = 1;
		
		Matrix4x4 svMat = GUI.matrix; // save current matrix
		
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
		
		if(estado=="final_01_previo" && cameraManager.currentPage.name == "Ultima_pagina_01")
		{
			estado="final_01";
		}
		
		if(estado=="final_01")
		{			
			if(GUI.Button(new Rect(500,80,400,550), "", dummy_style))
			{
				transform.position = pos_cam_02;
				estado="final_02";
				//cameraManager.currentPage.SendMessage("StopNarration");
				cameraManager.currentPage = pagina_final_02;
				//cameraManager.currentPage.SendMessage("PlayNarration");
			}
		}
		
		if(estado=="final_02")
		{
			if(GUI.Button(new Rect(250,300,500,400), "", dummy_style))
			{
				gato_final_02.animation.Play();
				audio.clip=so_final_02;
				
				if(!audio.isPlaying)
					audio.Play();
				
				estado="final_02_animando";
			}
		}
		
		if(estado=="final_02_animando")
		{
			if(!gato_final_02.animation.isPlaying)
			{
				transform.position = pos_cam_03;
				estado="final_03";
				//cameraManager.currentPage.SendMessage("StopNarration");
				cameraManager.currentPage = pagina_final_03;
				//cameraManager.currentPage.SendMessage("PlayNarration");
			}
		}
		
		if(estado=="final_03")
		{			
			if(GUI.Button(new Rect(512,80,500,550), "", dummy_style))
			{
				gato_final_03.animation.Play();
				audio.clip=so_final_03;
				if(!audio.isPlaying)
					audio.Play();
				estado="fin";
			}
		}
		
		if(estado=="fin")
		{
			if(!gato_final_03.animation.isPlaying)
			{
				if(GUI.Button(new Rect(0,0,screenWidth,screenHeight), "", dummy_style))
				{
					Application.LoadLevel("02_CaratulaGat");
				}
			}
		}
		
		GUI.matrix = svMat; // restore matrix
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////////
	/*
	void DesactivarInicio()
	{
		foreach(Transform t in pagina_inicio)
		{
			t.gameObject.SetActiveRecursively(false);
		}
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void ActivarFinal()
	{
		foreach(Transform t in pagina_final)
		{
			t.gameObject.SetActiveRecursively(true);
		}
	}
	*/
}








