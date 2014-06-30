using UnityEngine;
using System.Collections;

public class Gat_rrr : MonoBehaviour
{
	public Transform ull_obert;
	public Transform ull_tancat;
	public Transform mascara;
	
	////////////////////////////////////////////////////////////////////////////////////////
	
	void Start()
	{
		ull_obert.animation.Play("parpadejar");
		ull_tancat.animation.Play("parpadejar");
	}
	
	////////////////////////////////////////////////////////////////////////////////////////
	
	void Update()
	{
		if(PlatformManager.CheckInputDown())
		{
			RaycastHit hit = new RaycastHit();
			Ray ray = PlatformManager.GetScreenRay();
			
			if(collider.Raycast(ray, out hit, Mathf.Infinity))
			{
				if(!mascara.animation.IsPlaying("move"))
				{
					ull_obert.animation.Play("tancar");
					ull_tancat.animation.Play("tancar");
					mascara.animation.Play("move");
				}
				
				if(!audio.isPlaying)
					audio.Play();
			}
		}
		else
		{
			if(mascara.animation.IsPlaying("move"))
			{
				ull_obert.animation.Play("parpadejar");
				ull_tancat.animation.Play("parpadejar");
				mascara.animation.Play("idle");
			}
			
			if(audio.isPlaying)
				audio.Stop();
		}
	}
}
