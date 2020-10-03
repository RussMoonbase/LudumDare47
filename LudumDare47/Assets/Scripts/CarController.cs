using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
   public WheelCollider[] wheelCols;
   public Transform[] wheelMeshes;

   [SerializeField] private float torque = 200f;
   [SerializeField] private float acceleration;

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      acceleration = Input.GetAxis("Vertical");
      Drive(acceleration);
   }

   void Drive(float accel)
   {
      accel = Mathf.Clamp(accel, -1, 1);
      //accel = accel * torque;

      for (int i = 0; i < wheelCols.Length; i++)
      {
         wheelCols[i].motorTorque = accel * torque;
      }
   }
}
