using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
   public WheelCollider[] wheelCols;
   public Transform[] wheelMeshes;

   [SerializeField] private float torque = 200f;
   [SerializeField] private float steeringAmount = 30f;
   private float acceleration;
   private float steering;
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
      Drive(acceleration, steering);
   }

   void Drive(float accel, float steer)
   {
      accel = Mathf.Clamp(accel, -1, 1);
      steer = Mathf.Clamp(steer, -1, 1);
      //accel = accel * torque;

      for (int i = 0; i < wheelCols.Length; i++)
      {
         wheelCols[i].motorTorque = accel * torque;

         if (i < 2)
         {
            wheelCols[i].steerAngle = steer * steeringAmount;
         }


         wheelCols[i].GetWorldPose(out wheelPostion, out wheelRotation);
         wheelMeshes[i].transform.position = wheelPostion;
         wheelMeshes[i].transform.localRotation = wheelRotation;

      }
   }
}
