//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//ANDROID: adb.exe logcat -s Unity
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
	public Transform currentPage;
	public Transform nextPage;
	
	public float page_width;
	public float page_height;
	
	float minSwipeDist = 80;
	float maxSwipeDist = 1000;
	float maxSwipeTime = 2;
	
	public GUISkin m_skin;
	
	public float distThreshold=20.0f;
	public float speed;
	
	public bool bDebug=false;
	public Texture2D blanco;
	
	public bool bChangingPage=false;
	
	Transform m_mainCamera;
	
	bool bSwipePage=false;
	bool bSnapPage=false;
	
	float startTime;
	Vector2 startPos;
	bool couldBeSwipe;
	
	float swipeDirection;
	float swipeTime;
	float swipeDistX, swipeDistY;
	Vector2 touchDeltaPosition;
	
	float newPosX = 0.0f;
	float newPosY = 0.0f;
	
	bool upMove=false;
	bool downMove=false;
	bool leftMove=false;
	bool rightMove=false;
	
	Vector3 p_top_left = new Vector3(0,0,0);
	Vector3 p_down_left = new Vector3(0,Screen.height,0);
	Vector3 p_top_right = new Vector3(Screen.width,0,0);
	Vector3 p_down_right = new Vector3(Screen.width, Screen.height,0);
	Vector3 p_center = new Vector3(Screen.width/2, Screen.height/2,0);
	
	GUIManager guiManager;
	
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		if(Screen.width>1024)
		{
			minSwipeDist=minSwipeDist*2;
			maxSwipeDist=maxSwipeDist*2;
		}
		
		m_mainCamera = Camera.main.transform;
		
		guiManager = GetComponent<GUIManager>();
	}
	
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Start()
	{
		guiManager.SendMessage("SetPageVisited", 1-1);
	}
	
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	void Update()
	{
		if(!guiManager.show_map)
		{
	    	if(Input.touchCount == 1)
			{
	        	Touch touch = Input.touches[0];
				
				if(touch.phase == TouchPhase.Began && !bSwipePage)
				{
					couldBeSwipe = true;
	                startPos = touch.position;
	                startTime = Time.time;
					
					//CheckRects(touch.position);
					CheckTriangles(new Vector3(touch.position.x, touch.position.y, 0.0f));
				}
				
				else if(touch.phase == TouchPhase.Moved && !bSwipePage)
				{
					swipeDistX = Mathf.Abs(touch.deltaPosition.x);  
					swipeDistY = Mathf.Abs(touch.deltaPosition.y);
					
					touchDeltaPosition=touch.deltaPosition;
					MovePage();
				}
				/*
				else if(touch.phase == TouchPhase.Stationary)
				{
	                couldBeSwipe = false;
				}
				*/
				else if(touch.phase == TouchPhase.Ended && !bSwipePage)
				{
					swipeTime = Time.time - startTime;  
					swipeDistX = Mathf.Abs(touch.position.x - startPos.x);  
					swipeDistY = Mathf.Abs(touch.position.y - startPos.y);  
					
					if(couldBeSwipe && (swipeTime < maxSwipeTime))
					{	
						//Horizontal swipe page
						if((swipeDistX > minSwipeDist) && (swipeDistX < maxSwipeDist) && (leftMove || rightMove))
						{
							swipeDirection = Mathf.Sign(touchDeltaPosition.x);
							
							if(swipeDirection<0)
								nextPage = currentPage.GetComponent<PageManager>().right;
							else
								nextPage = currentPage.GetComponent<PageManager>().left;
							
							if(nextPage!=null)
								bSwipePage=true;
							else
								bSnapPage=true;
						}
						//Vertical swipe page
						else if((swipeDistY > minSwipeDist) && (swipeDistY < maxSwipeDist) && (upMove || downMove))
						{
							swipeDirection = Mathf.Sign(touchDeltaPosition.y);
							
							if(swipeDirection<0)
								nextPage = currentPage.GetComponent<PageManager>().up;
							else
								nextPage = currentPage.GetComponent<PageManager>().down;
							
							if(nextPage!=null)
								bSwipePage=true;
							else
								bSnapPage=true;
						}
						else
						{
							bSnapPage=true;
						}
					}
					else
					{
						bSnapPage=true;
					}
					
					upMove=false;
					downMove=false;
					leftMove=false;
					rightMove=false;
				}
			}
			
			KeyboardControl();
			
			if(bSwipePage)
				SnapPage(nextPage);
			
			if(bSnapPage)
				SnapPage(currentPage);

		}
	}
	
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void KeyboardControl()
	{
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			nextPage = currentPage.GetComponent<PageManager>().up;
			if(nextPage!=null) bSwipePage=true;
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			nextPage = currentPage.GetComponent<PageManager>().down;
			if(nextPage!=null) bSwipePage=true;
		}
		else if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			nextPage = currentPage.GetComponent<PageManager>().left;
			if(nextPage!=null) bSwipePage=true;
		}
		else if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			nextPage = currentPage.GetComponent<PageManager>().right;
			if(nextPage!=null) bSwipePage=true;
		}
	}
	
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void OnGUI()
	{
		if(bDebug)
		{
			int ini=50;
			GUI.skin = m_skin;
			
			GUI.DrawTexture(new Rect(50,50,200,250), blanco);
			
			GUI.Label(new Rect(50,ini+=25,200,25), "minSwipeDist: " + minSwipeDist);
			GUI.Label(new Rect(50,ini+=25,200,25), "maxSwipeDist: " + maxSwipeDist);
			GUI.Label(new Rect(50,ini+=25,200,25), "maxSwipeTime: " + maxSwipeTime);
			GUI.Label(new Rect(50,ini+=25,200,25), "swipeTime: " + swipeTime);
			GUI.Label(new Rect(50,ini+=25,200,25), "swipeDistX: " + swipeDistX);
			GUI.Label(new Rect(50,ini+=25,200,25), "swipeDistY: " + swipeDistY);
			GUI.Label(new Rect(50,ini+=25,200,25), "swipeDirection: " + swipeDirection);
			GUI.Label(new Rect(50,ini+=25,200,25), "touchDeltaPosition: " + touchDeltaPosition);
		}
	}

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void CheckTriangles(Vector3 pos)
	{
		Vector3 posCorrect = new Vector2(pos.x, Screen.height-pos.y);
		
		if(PointInTriangle(posCorrect, p_top_left, p_center, p_down_left))
			leftMove=true;
		else if(PointInTriangle(posCorrect, p_top_right, p_center, p_down_right))
			rightMove=true;
		else if(PointInTriangle(posCorrect, p_top_left, p_center, p_top_right))
			upMove=true;
		else if(PointInTriangle(posCorrect, p_down_left, p_center, p_down_right))
			downMove=true;
	}
	
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	bool PointInTriangle(Vector3 p, Vector3 a, Vector3 b, Vector3 c)
	{
    	if(SameSide(p, a, b, c) && SameSide(p, b, a, c) && SameSide(p, c, a, b))
			return true;
    	else 
			return false;
	}
	
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	bool SameSide(Vector3 p1, Vector3 p2, Vector3 a, Vector3 b)
	{
    	Vector3 cp1 = Vector3.Cross(b-a, p1-a);
    	Vector3 cp2 = Vector3.Cross(b-a, p2-a);
    	
		if(Vector3.Dot(cp1, cp2) >= 0)
			return true;
    	else 
			return false;
	}
	
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//Move camera target while finger is on the pad
	void MovePage()
	{
		float newX = transform.position.x;
		float newY = transform.position.y;
		
		//UP
		if(upMove && currentPage.GetComponent<PageManager>().up != null)
		{
			newY = transform.position.y+touchDeltaPosition.y*-(page_height/Screen.height);
		}
		//DOWN
		else if(downMove && currentPage.GetComponent<PageManager>().down != null)
		{
			newY = transform.position.y+touchDeltaPosition.y*-(page_height/Screen.height);
		}
		//LEFT
		else if(leftMove && currentPage.GetComponent<PageManager>().left != null)
		{
			newX = transform.position.x+touchDeltaPosition.x*-(page_width/Screen.width);
		}
		//RIGHT
		else if(rightMove && currentPage.GetComponent<PageManager>().right != null)
		{
			newX = transform.position.x+touchDeltaPosition.x*-(page_width/Screen.width);
		}
		
		transform.position = new Vector3(newX, newY, transform.position.z);
		
		//Update current page
		int iPagesLayer = LayerMask.NameToLayer("paginas");
		Ray ray = new Ray(m_mainCamera.position, m_mainCamera.forward);
		RaycastHit hit = new RaycastHit();
		
		//Raycast only with desired layer:
		//http://answers.unity3d.com/questions/8715/how-do-i-use-layermasks.html
		if(Physics.Raycast(ray, out hit, 10000.0f, 1<<iPagesLayer))
		{
			if(currentPage!=hit.collider.transform)
				bChangingPage=true;
			else
				bChangingPage=false;
			
			currentPage = hit.collider.transform;
		}
	}
	
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//Snap to page when finger is out of the tablet
	void SnapPage(Transform target)
	{
		if(currentPage==null)
		{
			Debug.Log("ERROR: currentPage is NULL");
			return;
		}
		
		if(target==null)
		{
			Debug.Log("ERROR: target is NULL");
			return;
		}
	
		Vector2 dir = new Vector2(target.position.x-transform.position.x, target.position.y-transform.position.y);
		dir.Normalize();
		
		newPosX = transform.position.x + dir.x*speed*Time.deltaTime;
		newPosY = transform.position.y + dir.y*speed*Time.deltaTime;
		
		transform.position = new Vector3(newPosX, newPosY, transform.position.z);
		
		float dist = Vector3.Distance(transform.position, target.position);
		
		if(dist < distThreshold)
		{
			transform.position = target.position;
			currentPage=target;
	 		bSwipePage=false;
			bSnapPage=false;
			
			int i = GetCurrentPageIndex();
			if(i>0){
				guiManager.SendMessage("SetPageVisited", i);
			}
		}
		
		if(currentPage!=target)
			bChangingPage=true;
		else
			bChangingPage=false;
	}
	
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	int GetCurrentPageIndex()
	{
		int index=-1;

		if(!currentPage.name.Contains("Ultima")){
			int i = int.Parse(currentPage.name.Substring(8,1));
			int j = int.Parse(currentPage.name.Substring(11,1));
		
			index = j+(i-2)*9-1;
		
			//Debug.Log(currentPage.name + " : " + i + " : " + j +" : " + index);
		}

		return index;
	}
}




