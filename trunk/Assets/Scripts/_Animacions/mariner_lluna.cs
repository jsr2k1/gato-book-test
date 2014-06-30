using UnityEngine;
using System.Collections;

public class mariner_lluna : MonoBehaviour
{
	public Transform m_lluna;
	public Transform m_gato;
	
	MegaPointCache megaPointCache1;
	MegaPointCache megaPointCache2;
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Start()
	{
		megaPointCache1 = m_lluna.GetComponent<MegaPointCache>();
		megaPointCache2 = m_gato.GetComponent<MegaPointCache>();
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Update()
	{
		if(PlatformManager.CheckInput())
		{
			RaycastHit hit = new RaycastHit();
			Ray ray = PlatformManager.GetScreenRay();
			
			if(collider.Raycast(ray, out hit, Mathf.Infinity))
			{
				megaPointCache1.animated=true;
				megaPointCache1.time=0.0f;
				
				megaPointCache2.animated=true;
				megaPointCache2.time=0.0f;
			}
		}
	}
}
