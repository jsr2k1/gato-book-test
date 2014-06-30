using UnityEngine;
using System.Collections;

public class paracaidas : MonoBehaviour
{
	Vector3 initial_pos;
	public Transform target;
	public float speed = 1.0f;
	
	CameraManager cameraManager;
	
	//////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		initial_pos = transform.position;
		cameraManager = GameObject.Find("_CameraTarget").GetComponent<CameraManager>();
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Update()
	{
		if(cameraManager.currentPage.name == "pagina_02_05")
        	transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
		else
			transform.position = initial_pos;
	}
}
