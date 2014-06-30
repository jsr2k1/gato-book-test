using UnityEngine;
using System.Collections;

public class Help : MonoBehaviour
{
	public string m_level_name;
	
	public Texture2D m_ayuda_01;
	public Texture2D m_ayuda_02;
	
	public GUIStyle dummy_style;
	
	string estado="ayuda_01";
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void OnGUI()
	{
		if(estado=="ayuda_01")
		{
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), m_ayuda_01);
			
			if(GUI.Button(new Rect(0,0,Screen.width,Screen.height), "", dummy_style))
				estado="ayuda_02";
		}
		
		if(estado=="ayuda_02")
		{
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), m_ayuda_02);
			
			if(GUI.Button(new Rect(0,0,Screen.width,Screen.height), "", dummy_style))
				Application.LoadLevel(m_level_name);
		}
	}
}
