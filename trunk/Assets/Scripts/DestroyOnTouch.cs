using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

class DestroyOnTouch : MonoBehaviour
{
	void Update()
	{
		if(PlatformManager.CheckInput())
		{
			RaycastHit hit = new RaycastHit();
			Ray ray = PlatformManager.GetScreenRay();
			
			if(collider.Raycast(ray, out hit, Mathf.Infinity))
			{
				AudioSource.PlayClipAtPoint(audio.clip, transform.position);
				Destroy(gameObject);
			}
		}
	}
}





