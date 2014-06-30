using UnityEngine;
using System.Collections;

public class Semaforo : MonoBehaviour
{
	public Transform m_vermell;
	public Transform m_groc;
	public Transform m_verd;
	
	public float wait_time=1.0f;
	
	string estat="nul";
	
	CameraManager cameraManager;
	float start_time;
	float elapsed_time;
	
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	void Awake()
	{
		cameraManager = GameObject.Find("_CameraTarget").GetComponent<CameraManager>();
		
		m_groc.gameObject.SetActive(false);
		m_verd.gameObject.SetActive(false);
	}
	
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Update()
	{
		if(cameraManager.currentPage.name == "pagina_03_06")
		{
			if(estat=="nul")
			{
				start_time = Time.time;
				estat = "vermell";
			}
			
			else if(estat=="vermell")
			{
				elapsed_time = Time.time - start_time;
				if(elapsed_time > wait_time)
				{
					estat="groc";
					start_time=Time.time;
					m_vermell.gameObject.SetActive(false);
					m_groc.gameObject.SetActive(true);
				}
			}
			
			else if(estat=="groc")
			{
				elapsed_time = Time.time - start_time;
				if(elapsed_time > wait_time)
				{
					estat="verd";
					m_groc.gameObject.SetActive(false);
					m_verd.gameObject.SetActive(true);
				}
			}
		}
		
		if(cameraManager.currentPage.name != "pagina_03_06")
		{
			estat="nul";
			
			m_vermell.gameObject.SetActive(true);
			m_groc.gameObject.SetActive(false);
			m_verd.gameObject.SetActive(false);
		}
	}
}
