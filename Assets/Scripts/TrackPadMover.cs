using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TrackPadMover : MonoBehaviour {
    public float speed;
    private Rigidbody ballRigidBody;
    //SteamVR_TrackedObject controller;

    //Needed to use a Player object instead of a Camera Rig\
    //private Valve.VR.InteractionSystem.Hand hand;
    //private SteamVR_Controller.Device controller;

    //Get the instance of the player prefab
    Player player;

    Vector2 touchPos;
    Vector3 trackPos;
    Vector3 movement;
    

    void Start() {
        player = GameObject.Find("Player").GetComponent<Player>();
        //Also for getting it from the player instead of camera rig
        //hand = GetComponent<Valve.VR.InteractionSystem.Hand>();

        if (player == null) Debug.Log("No player");
        if (player.rightHand == null) Debug.Log("No rightHand");
        if (player.rightController == null) Debug.Log("No controller");

        this.ballRigidBody = GameObject.Find("Throwable Ball").GetComponent<Rigidbody>();
    }

    private void Awake() {
        //this.controller = GetComponent<SteamVR_TrackedObject>();
        this.ballRigidBody = GameObject.Find("Throwable Ball").GetComponent<Rigidbody>();
        Debug.Log("Started steam_vr tracked object");
    }

    private void FixedUpdate() {
        var device = SteamVR_Controller.Input((int)player.rightController.index);

        if (player.rightController.GetTouch(SteamVR_Controller.ButtonMask.Touchpad)) {

            //https://answers.unity.com/questions/823090/equivalent-of-degree-to-vector2-in-unity.html
            //https://stackoverflow.com/questions/18851761/convert-an-angle-in-degrees-to-a-vector
            float rad = player.rightHand.transform.rotation.y * (Mathf.PI / 180);
            //new Vector2((float)Math.Cos(radians), (float)Math.Sin(radians))
            //Vector3 trackPos = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad));
            //trackPos.Normalize();

            //GameObject.Find("Throwable Ball").transform.Rotate(0, player.rightHand.transform.rotation.y, 0);

            //trackPos = new Vector3(player.rightHand.transform.rotation.x, player.rightHand.transform.rotation.y,
            touchPos = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);

            //Get the intensity of the trackpad with no directional information
            //float touchIntensity = Mathf.Max(Mathf.Abs(touchPos.x), Mathf.Abs(touchPos.y));

            //movement = new Vector3(touchPos.x * speed, 0, touchPos.y * speed);
            //movement = new Vector3(trackPos.x * touchIntensity, 0, trackPos.y * touchIntensity);

            //movement = touchpos - trackpos
            movement = new Vector3(touchPos.x, 0, touchPos.y);

            movement.Normalize();

            //this.ballRigidBody.AddForce(movement * speed);

            this.ballRigidBody.AddForce(movement);

            //Debug.Log("Touchpad " + touchPos);
            //Debug.Log("Rotation: " + rad);
        }
        
        /*
        if(controller.GetHairTrigger()) {
            Debug.Log("Triggered!");
        }
        */
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if(hand.controllerPrefab == null) {
            Debug.Log("Controller prefab not found either.");
        }

        if (hand.controllerPrefab.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
            Debug.Log("Trigger down");
        }
        */
    }
}
