using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
 
class AnimateTiledTexture : MonoBehaviour
{
	public int columns = 3;
	public int rows = 3;
	public float FPS = 10;
	public bool bAnimate = true;
	public bool bAudio = false;
	
	int index;
	Vector2 offset;
	float startTime;
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 
	void Start()
	{
		Vector2 size = new Vector2(1f / columns, 1f / rows);
		renderer.sharedMaterial.SetTextureScale("_MainTex", size);
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Update()
	{
		//Touch control
		if(Input.GetMouseButtonDown(0)) 
		//if(Input.touchCount == 1)
		{
			RaycastHit hit = new RaycastHit();
	        //Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			if(collider.Raycast(ray, out hit, Mathf.Infinity))
			{
				bAnimate=true;
			}
		}
		
		//Animation
		if(bAnimate /* && !CameraManager.bTraslada*/)
		{
			StartCoroutine("Animate", 0.0f);
			bAnimate=false;
			if(bAudio)
				audio.Play();
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	IEnumerator Animate()
	{
		//Recorremos todos los frames de la animación
		float waitTime = (1.0f/FPS)*Time.deltaTime*50;
		
		for(index=0;index<rows*columns;index++)
		{
			offset = new Vector2((float)index / columns - (index / columns), (index / columns) / (float)rows);
			renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
			yield return new WaitForSeconds(waitTime);
		}
		
		//Volvemos a dejar el primer frame de la animación
		offset = new Vector2(0,0);
		renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
	}
}








