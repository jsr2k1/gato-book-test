using UnityEngine;
using System.Collections;

public class Ocell_colors : MonoBehaviour
{
	public Transform m_mascara;
	public Transform m_colors;
	
	string estado = "mascara";
	
	MegaPointCache megaPointCache;
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		megaPointCache = m_mascara.GetComponent<MegaPointCache>();
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Update()
	{
		//Activamos la máscara la primera vez
		if(PlatformManager.CheckInput())
		{
			RaycastHit hit = new RaycastHit();
			Ray ray = PlatformManager.GetScreenRay();
			
			if(collider.Raycast(ray, out hit, Mathf.Infinity))
			{
				if(estado=="mascara")
				{
					megaPointCache.animated=true;
					megaPointCache.time=0.0f;
					estado="colors";
				}
				
				if(!audio.isPlaying)
					audio.Play();
			}
		}
		
		//Activamos los colores a partir de la segunda vez
		else if(PlatformManager.CheckInputDown())
		{
			RaycastHit hit = new RaycastHit();
			Ray ray = PlatformManager.GetScreenRay();
			
			if(collider.Raycast(ray, out hit, Mathf.Infinity))
			{
				if(estado=="colors" && !m_colors.animation.isPlaying)
				{
					m_colors.animation.Play("move");
				}
				
				if(!audio.isPlaying)
				audio.Play();
			}
		}
		
		else
		{
			if(audio.isPlaying)
				audio.Stop();
		}
	}
}




