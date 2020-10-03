using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiRoll : MonoBehaviour
{
   public Rigidbody rBody;
   public float antiRollAmount = 5000;

   public WheelCollider frontRightWheel;
   public WheelCollider frontLeftWheel;
   public WheelCollider backRightWheel;
   public WheelCollider backLeftWheel;


   // Start is called before the first frame update
   void Start()
   {

   }

   
   void FixedUpdate()
   {
      KeepWheelsGronded(frontRightWheel, frontLeftWheel);
      KeepWheelsGronded(backRightWheel, backLeftWheel);
   }

   // original code from Unity forum post how to make a "Physically Real Stable Car with Wheel Colliders"
   void KeepWheelsGronded(WheelCollider rightWheel, WheelCollider leftWheel)
   {
      WheelHit hit;
      bool groundedLeft;
      bool groundedRight;
      float travelRight = 1f;
      float travelLeft = 1f;

      groundedLeft = leftWheel.GetGroundHit(out hit);
      if (groundedLeft)
      {
         travelLeft = (-leftWheel.transform.InverseTransformDirection(hit.point).y - leftWheel.radius) / leftWheel.suspensionDistance;
      }

      groundedRight = rightWheel.GetGroundHit(out hit);
      if (groundedRight)
      {
         travelRight = (-rightWheel.transform.InverseTransformDirection(hit.point).y - rightWheel.radius) / rightWheel.suspensionDistance;
      }

      float antiRollForce = (travelLeft - travelRight) * antiRollAmount;

      if (groundedLeft)
      {
         rBody.AddForceAtPosition(leftWheel.transform.up * -antiRollForce, leftWheel.transform.position);
      }

      if (groundedRight)
      {
         rBody.AddForceAtPosition(rightWheel.transform.up * antiRollForce, rightWheel.transform.position);
      }
   }
}
