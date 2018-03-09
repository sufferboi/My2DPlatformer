using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

    //This is an array(list) of all background/foregrounds to be parallaxed.
    public Transform[] Backgrounds;
   
    //proportion of camera movement to move backgrounds by.
    private float[] ParallaxScales;

    //how smooth the parallax is going to be. Value must be above 0.
    public float smoothing = 1f;

    //this is a reference to the main cameras transform.
    private Transform Cam;

    //the position of the camera in the previous frame.
    private Vector3 PreviousCameraPosition;

    //awake function is called before start function.
    void Awake()
    {
        //sets up main camera reference.
        Cam = Camera.main.transform;
    }




    // Use this for initialization
    void Start ()
    {
        //previous frame had the current frames camera position.
        PreviousCameraPosition = Cam.position;

        //Simply assigning corresponding parallaxscales.
        ParallaxScales = new float[Backgrounds.Length];
        for (int i =0; i < Backgrounds.Length; i++)
        {
            ParallaxScales[i] = Backgrounds[i].position.z * -1;
        }
	}
	
    
	// Update is called once per frame
	void Update ()
    {
        //for each background/foreground.
		for(int i =0; i < Backgrounds.Length; i++)
        {
            //parallax is opposite to camera movement because previous movement multiplied by scale.
            float parallax = (PreviousCameraPosition.x - Cam.position.x) * ParallaxScales[i];

            //now need to set x position.
            float BackgroundTargetPosX = Backgrounds[i].position.x + parallax;

            //create target position coordinated with current target x position.
            Vector3 BackgroundTargetPos = new Vector3(BackgroundTargetPosX, Backgrounds[i].position.y, Backgrounds[i].position.z);

            //now need to fade between current position and target position. time.deltatime converts frames to seconds.
            Backgrounds[i].position = Vector3.Lerp(Backgrounds[i].position, BackgroundTargetPos, smoothing * Time.deltaTime);
        }
        //set previous camera position to the cameras position at the end of the frame.
        PreviousCameraPosition = Cam.position;
	}
}
