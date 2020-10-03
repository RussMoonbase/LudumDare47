using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
   public WheelCollider[] wheelCols;
   public Transform[] wheelMeshes;
   public BrakeLights brakeLights;

   [SerializeField] private float torque = 200f;
   [SerializeField] private float steeringAmount = 30f;
   [SerializeField] private float brakingAmount = 600f;
   private float acceleration;
   private float steering;
   private float braking;
   private Vector3 wheelPostion;
   private Quaternion wheelRotation;

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      acceleration = Input.GetAxis("Vertical");
      steering = Input.GetAxis("Horizontal");
      braking = Input.GetAxis("Jump");

      if (braking > 0)
      {
         brakeLights.isBraking = true;
      }

      if (braking == 0 && brakeLights.isBraking)
      {
         brakeLights.isBraking = false;
      }

      Drive(acceleration, steering, braking);
   }

   void Drive(float accel, float steer, float brake)
   {
      accel = Mathf.Clamp(accel, -1, 1);
      steer = Mathf.Clamp(steer, -1, 1);
      brake = Mathf.Clamp(brake, 0, 1);
      //accel = accel * torque;

      for (int i = 0; i < wheelCols.Length; i++)
      {
         wheelCols[i].motorTorque = accel * torque;

         if (i < 2)
         {
            wheelCols[i].steerAngle = steer * steeringAmount;
         }

         wheelCols[i].brakeTorque = brake * brakingAmount;


         wheelCols[i].GetWorldPose(out wheelPostion, out wheelRotation);
         wheelMeshes[i].transform.position = wheelPostion;
         wheelMeshes[i].transform.localRotation = wheelRotation;

      }
   }
}
