using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour
{
	public static GUIManager guiManager;
	
	void Awake()
	{
		guiManager = GameObject.Find("_CameraTarget").GetComponent<GUIManager>();
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		
	public static bool CheckInput()
	{	
		if(guiManager.show_map) return false;
		
		if(Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			return (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began);
		}
		else
		{
			return (Input.GetMouseButtonDown(0));
		}
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	public static bool CheckInputDown()
	{	
		if(guiManager.show_map) return false;
		
		if(Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			return (Input.touchCount == 1 && (Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved));
		}
		else
		{
			return (Input.GetMouseButton(0));
		}
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public static Ray GetScreenRay()
	{
		Ray ray;
		
		if(Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
			ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
		
		else
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				
		return ray;
	}
}








