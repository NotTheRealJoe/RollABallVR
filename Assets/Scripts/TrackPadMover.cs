using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TrackPadMover : MonoBehaviour {
    public float speed;
    private Rigidbody ballRigidBody;
    //SteamVR_TrackedObject controller;

    //Needed to use a Player object instead of a Camera Rig
    private Hand _hand;
    private SteamVR_Controller.Device controller;

    void Start() {
        //Also for getting it from the player instead of camera rig
        _hand = GetComponent<Hand>();
        controller = _hand.controller;
    }

    private void Awake() {
        //this.controller = GetComponent<SteamVR_TrackedObject>();
        this.ballRigidBody = GameObject.Find("Throwable Ball").GetComponent<Rigidbody>();
        Debug.Log("Started steam_vr tracked object");
    }

    private void FixedUpdate() {
        //var device = SteamVR_Controller.Input((int)controller.index);
        /*
        var device = controller;
        if(device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad)) {
            var model = this.transform.Find("Model");
            Transform trackpad = model.Find("trackpad").Find("attach");
            Transform touch = model.Find("trackpad_touch").Find("attach");

            Vector3 movement = (touch.position) - (trackpad.position);

            movement = new Vector3(movement.x, 0, movement.z);
            movement.Normalize();

            this.ballRigidBody.AddForce(movement * speed);
        }
        */
        if(controller.GetHairTrigger()) {
            Debug.Log("Triggered!");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
