using UnityEngine;
using System.Collections;

public class Ocell_electro : MonoBehaviour
{
	public Transform electro_on;
	public Transform electro_off;
	
	////////////////////////////////////////////////////////////////////////////////////
	
	void start()
	{
		electro_on.gameObject.SetActive(false);
	}
	
	////////////////////////////////////////////////////////////////////////////////////
	
	void Update()
	{
		if(PlatformManager.CheckInputDown())
		{
			RaycastHit hit = new RaycastHit();
			Ray ray = PlatformManager.GetScreenRay();
			
			if(collider.Raycast(ray, out hit, Mathf.Infinity))
			{
				electro_on.gameObject.SetActive(true);
				electro_off.gameObject.SetActive(false);
				
				if(!audio.isPlaying)
					audio.Play();
			}
		}
		else
		{
			electro_on.gameObject.SetActive(false);
			electro_off.gameObject.SetActive(true);
			
			if(audio.isPlaying)
				audio.Stop();
		}
	}
}
