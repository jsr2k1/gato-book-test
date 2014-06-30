using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour
{
	public Texture2D m_loading;
	public string m_level;
	public GUIStyle m_style;
	
	bool pintado=false;
	
	//////////////////////////////////////////////////////////////////////////////////////////
	
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), m_loading);
		GUI.Label(new Rect(Screen.width/2-50,Screen.height-100,200,50), "Cargando...", m_style);
		pintado=true;
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////
	
	void LateUpdate()
	{
		if(pintado)
			Application.LoadLevel(m_level);	
	}	
}
