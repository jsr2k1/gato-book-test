using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour
{
	public Texture2D m_loading;
	public string m_level;
	public GUIStyle m_style;
	
	bool pintado=false;
	
	//////////////////////////////////////////////////////////////////////////////////////////

	void Awake()
	{
		int original_w = 1024;
		float ratio = (float)Screen.width / (float)original_w;
		m_style.fontSize = (int)(40 * ratio);
	}

	//////////////////////////////////////////////////////////////////////////////////////////

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), m_loading);
		GUI.Label(new Rect(0,Screen.height-200,Screen.width,100), "Cargando...", m_style);
		pintado=true;
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////
	
	void LateUpdate()
	{
		if(pintado){
			//Application.LoadLevel(m_level);	
		}
	}	
}
