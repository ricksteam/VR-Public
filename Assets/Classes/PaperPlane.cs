using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPlane : MonoBehaviour, IGrabEvent
{
    private bool thrown = false;
    private Rigidbody rb;
    private ConstantForce engine;
    private PlaneGameplayManager manager;

    void Start()
    {
        engine = gameObject.GetComponent<ConstantForce>();
        rb = gameObject.GetComponent<Rigidbody>();
        manager = (PlaneGameplayManager)GameplayManager.getManager();
    }

    //Called by Grabber
    public void onGrab(GameObject hand){
        manager.onPlaneGrabbed( gameObject );
    }
    public void onRelease(GameObject hand){
        Rigidbody handRb = hand.GetComponent<Rigidbody>();
        thrown = true;
        engine.force = rb.velocity * 20;
        //rb.AddRelativeForce(0, Vector3.Distance(handRb.velocity, Vector3.zero), 0);
        //rb.angularVelocity = Vector3.zero;
        //rb.velocity *= 10;
        //engine.relativeForce = new Vector3(0, 0, 10);
        //rb.AddForce(handRb.velocity * 10);
        //engine.torque = Vector3.zero;
        
        rb.freezeRotation = true;
        manager.onPlaneReleased( gameObject );
    }
}