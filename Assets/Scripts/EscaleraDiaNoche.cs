using UnityEngine;
using System.Collections;

public class EscaleraDiaNoche : MonoBehaviour
{
	public Texture2D m_tex_noche;
	
	public Transform m_lluvia;
	public Transform m_estrellas;
	
	bool bPrepararNoche=false;
	bool bNoche=false;
	
	CameraManager cameraManager;
	
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	void Awake()
	{
		cameraManager = GameObject.Find("_CameraTarget").GetComponent<CameraManager>();
	}
	
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Update()
	{
		if(cameraManager.currentPage.name == "pagina_02_11")
		{
			if(!bPrepararNoche)
				bPrepararNoche=true;
		}
		
		if(cameraManager.currentPage.name != "pagina_02_11" && cameraManager.currentPage.name != "pagina_01_11")
		{
			if(bPrepararNoche)
				bNoche=true;
		}
		
		if(bNoche)
		{
			renderer.material.mainTexture = m_tex_noche;
			
			if(m_lluvia)
				m_lluvia.gameObject.SetActive(false);
			
			if(m_estrellas)
				m_estrellas.gameObject.SetActive(true);
		}
	}
}
