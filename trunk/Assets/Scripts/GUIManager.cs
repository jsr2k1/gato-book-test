using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour
{
	public GUISkin m_skin;
	public Texture2D m_iconos;
	public Texture2D m_back;
	
	public Rect rectLeft;
	public Rect rectRight;
	public Rect rectUp;
	public Rect rectDown;
	
	public float speed=1.0f;
	public int offset=100;
	public bool m_debug;
	
	CameraManager cameraManager;
	
	float screenWidth = 1024;
	float screenHeight = 768;
	
	public Texture2D[] m_mapa_on;
	public Texture2D[] m_mapa_off;
	bool[] page_visited;
	
	public bool show_map=false;
	int current_index=0;
	
	public Texture2D m_current_page;
	public Transform m_plano_mapa;

	public GUIStyle m_dummy_style;
	
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		if(Screen.width>1024)
			offset=offset*2;
		
		rectUp = new Rect(offset,0,Screen.width-offset*2,offset);
		rectDown = new Rect(offset,Screen.height-offset,Screen.width-offset*2,offset);
		rectLeft = new Rect(0,offset,offset,Screen.height-offset*2);
		rectRight = new Rect(Screen.width-offset,offset,offset,Screen.height-offset*2);
		
		cameraManager = GetComponent<CameraManager>();
		
		page_visited = new bool[27];
	}
	
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/*
	void Update()
	{

		if(bAudio && !cameraManager.audio.isPlaying)
		{
			cameraManager.audio.Play();
		}
		else if(!bAudio && cameraManager.audio.isPlaying)
		{
			cameraManager.audio.Pause();
		}
	}
	*/
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void OnGUI()
	{	
		GUI.skin = m_skin;
		
		//Reescalamos el GUI para que se adapte a las diferentes resoluciones de pantalla
		Vector3 scale;
		scale.x = Screen.width/screenWidth; 
		scale.y = Screen.height/screenHeight;
		scale.z = 1;
		
		Matrix4x4 svMat = GUI.matrix; // save current matrix
		
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
		
		if(!show_map)
		{
			if(GUI.Button(new Rect(10,15,50,50), "", "boton_home"))
				Application.LoadLevel("02_CaratulaGat");
		
			if(GUI.Button(new Rect(screenWidth-80,15,70,50), "", "boton_narrador"))
				cameraManager.currentPage.SendMessage("PlayNarration");
		
			/*if(GUI.Button(new Rect(65,15,50,50), "", "boton_mapa"))
			{
				show_map=true;
				m_plano_mapa.gameObject.SetActive(true);
			}*/
		}
		else
			OnGUIMap();
		
		if(m_debug)
		{
			GUI.Box(rectLeft,"");
			GUI.Box(rectRight,"");
			GUI.Box(rectUp,"");
			GUI.Box(rectDown,"");
		}
		
		GUI.matrix = svMat; // restore matrix
	}
	
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void OnGUIMap()
	{
		int x=0;
		int y=0;
		int index=0;
		
		for(int i=0;i<9;i++)
		{
			for(int j=0;j<3;j++)
			{
				x=114*i;
				y=256*j;
				index=i+j*9;
				
				if(page_visited[index])
					GUI.DrawTexture(new Rect(x,y,114,256), m_mapa_on[index]);	
				else
					GUI.DrawTexture(new Rect(x,y,114,256), m_mapa_off[index]);	
				
				if(current_index==index)
					GUI.DrawTexture(new Rect(x,y,114,256), m_current_page);
			}
		}
		
		if(GUI.Button(new Rect(40, Screen.height-90,100,40), m_back, m_dummy_style))
		{
			show_map=false;
			m_plano_mapa.gameObject.SetActive(false);
		}
	}
	
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void SetPageVisited(int i)
	{
		if(i>=0){
			page_visited[i] = true;
			current_index = i;
		}
	}
}













