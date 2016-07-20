using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class HandController : MonoBehaviour
{

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);

        // TRIGGER TOUCH HANDLERS
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
 
        }

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
         
        }

        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
        
        }

        // TRIGGER PRESS HANDLERS
        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
   
        }

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            for (float i = 0; i < 5000; i += Time.deltaTime)
            {
                SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse((ushort)Mathf.Lerp(0, 3999, 1000));
            }
        }

        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
  
        }

        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {

        }
    }

    void OnTriggerStay(Collider col)
    {

        // attach grabbed object to controller
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {

            col.attachedRigidbody.isKinematic = true;
            col.gameObject.transform.SetParent(this.gameObject.transform);
        }

        // release grabbed object
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            col.gameObject.transform.SetParent(null);
            col.attachedRigidbody.isKinematic = false;

            tossObject(col.attachedRigidbody);
        }

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {

        }
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
        
        }

    }

    private void tossObject(Rigidbody rigidBody)
    {
        Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
        if (origin != null)
        {
            rigidBody.velocity = origin.TransformVector(device.velocity);
            rigidBody.angularVelocity = origin.TransformVector(device.angularVelocity);
        }
        else
        {
            rigidBody.velocity = device.velocity;
            rigidBody.angularVelocity = device.angularVelocity;

        }
    }
}
