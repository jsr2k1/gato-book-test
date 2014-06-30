using UnityEngine;
using System;
using System.Collections;

class ScreenShotMovie : MonoBehaviour
{
	public string folder = "VIDEO";
	public int frameRate = 25;	
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Start ()
	{
	    // Set the playback framerate! (real time doesn't influence time anymore)
	    Time.captureFramerate = frameRate;
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Update ()
	{
	    string dir ="C:\\"+folder+"\\";
	    string name = String.Format("{0}/{1:D04} shot.png", dir, Time.frameCount );
	
	    // Capture the screenshot
	    Application.CaptureScreenshot(name);
	}
}
	