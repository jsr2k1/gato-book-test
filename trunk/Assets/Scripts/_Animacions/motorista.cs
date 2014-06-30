using UnityEngine;
using System.Collections;

public class motorista : MonoBehaviour
{
	CameraManager cameraManager;
	string estado="entrar";
	
	public AudioClip audio_entra;
	public AudioClip audio_surt;
	
	//////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		cameraManager = GameObject.Find("_CameraTarget").GetComponent<CameraManager>();
		//SetHijos(false);
	}
	
	//////////////////////////////////////////////////////////////////////////////////////
	
	void Update()
	{
		if(cameraManager.currentPage.name == "pagina_03_06")
		{
			if(estado=="entrar")
			{
				//SetHijos(true);
				
				ActivarAnimacion("entrar");
				estado="bucle";
				
				if(!audio.isPlaying)
				{	
					audio.clip = audio_entra;
					audio.Play();
				}
			}
		}
		else
		{
			estado="entrar";
			
			if(audio.isPlaying)
				audio.Stop();
		}
		
		if(!transform.GetChild(0).animation.isPlaying && estado=="bucle")
		{
			ActivarAnimacion("bucle");
			estado="salir";
		}
		
		if(estado=="salir")
		{
			if(PlatformManager.CheckInput())
			{
				RaycastHit hit = new RaycastHit();
				Ray ray = PlatformManager.GetScreenRay();
				
				if(collider.Raycast(ray, out hit, Mathf.Infinity))
				{
					ActivarAnimacion("salir");
					estado="fin";
					
					audio.Stop();
					audio.clip = audio_surt;
					audio.Play();
				}
			}
		}
		
		if(estado=="fin" && !transform.GetChild(0).animation.isPlaying)
		{
			//SetHijos(false);
			estado="entrar";
			audio.Stop();
			PararAnimacion();
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////
	
	void PararAnimacion()
	{
		foreach(Transform child in transform)
		{
			child.animation.Stop();
		}
	}

	//////////////////////////////////////////////////////////////////////////////////////
	
	void ActivarAnimacion(string anim)
	{
		foreach(Transform child in transform)
		{
			child.animation.Play(anim);
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////
	
	void SetHijos(bool b)
	{
		foreach(Transform child in transform)
		{
			child.gameObject.SetActive(b);
		}
	}
}











