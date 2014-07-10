using UnityEngine;
using System.Collections;

public class Caratula : MonoBehaviour
{
	public string m_level_name;
	
	public Texture2D m_creditos_01;
	public Texture2D m_creditos_02;
	public Texture2D m_share;
	
	string estado="inicio";
	
	public GUIStyle dummy_style;
	
	float screenWidth = 1024;
	float screenHeight = 768;

	public Diffusion diffusion;
	
	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	void Start()
	{
		diffusion.eventReceiver = gameObject;
	}

	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	void OnGUI()
	{
		//Reescalamos el GUI para que se adapte a las diferentes resoluciones de pantalla
		Vector3 scale;
		scale.x = Screen.width/screenWidth;
	    scale.y = Screen.height/screenHeight;
		scale.z = 1;
		
		Matrix4x4 svMat = GUI.matrix; // save current matrix
		
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
		
		if(estado=="inicio")
		{
			if(GUI.Button(new Rect(60,360,270,70), "", dummy_style))
				Application.LoadLevel(m_level_name);
			
			if(GUI.Button(new Rect(60,490,270,70), "", dummy_style))
				estado="creditos1";

			if(GUI.Button(new Rect(20, Screen.height-60, 40, 40), m_share, dummy_style))
				diffusion.Share();
		}
		
		if(estado=="creditos1")
		{
			GUI.DrawTexture(new Rect(0,0,screenWidth,screenHeight), m_creditos_01);
			
			if(GUI.Button(new Rect(70,60,200,200), "", dummy_style))
				estado="inicio";
			
			if(GUI.Button(new Rect(780,60,200,200), "", dummy_style))
				estado="creditos2";
		}
		
		if(estado=="creditos2")
		{
			GUI.DrawTexture(new Rect(0,0,screenWidth,screenHeight), m_creditos_02);
			
			if(GUI.Button(new Rect(60,40,130,70), "", dummy_style))
				estado="creditos1";
		}
		
		GUI.matrix = svMat; // restore matrix
	}
}
