using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
   public static CarController instance;
   public WheelCollider[] wheelCols;
   public Transform[] wheelMeshes;
   public BrakeLights brakeLights;
   public GameObject carBodyModel;
   public Rigidbody carBodyRigidbody;

   public float torque = 200f;
   [SerializeField] private float steeringAmount = 30f;
   [SerializeField] private float brakingAmount = 600f;
   private float acceleration;
   private float steering;
   private float braking;
   private float drifting;
   private Vector3 wheelPostion;
   private Quaternion wheelRotation;

   public bool wasHit = false;
   public GameObject destructibleBody;
   public PlayerCarSoundManager carSoundManager;

   [SerializeField] private float originalFrontWheelFriction;
   [SerializeField] private float originalBackWheelFriction;

   [SerializeField] private float driftFrontWheelFriction;
   [SerializeField] private float driftBackWheelFriction;

   private void Awake()
   {
      instance = this;
   }

   // Start is called before the first frame update
   void Start()
   {
      originalFrontWheelFriction = wheelCols[0].sidewaysFriction.stiffness;
      originalBackWheelFriction = wheelCols[2].sidewaysFriction.stiffness;
   }

   // Update is called once per frame
   void Update()
   {
      acceleration = Input.GetAxis("Vertical");
      steering = Input.GetAxis("Horizontal");
      braking = Input.GetAxis("Jump");
      drifting = Input.GetAxis("Fire2");

      if (braking > 0)
      {
         brakeLights.isBraking = true;
      }

      if (braking == 0 && brakeLights.isBraking)
      {
         brakeLights.isBraking = false;
      }

      Drive(acceleration, steering, braking, drifting);

      if (wasHit)
      {
         wasHit = false;
         DestroyCar();
      }

   }

   private void FixedUpdate()
   {
      
   }

   void Drive(float accel, float steer, float brake, float drift)
   {
      accel = Mathf.Clamp(accel, -1, 1);
      steer = Mathf.Clamp(steer, -1, 1);
      brake = Mathf.Clamp(brake, 0, 1);
      //accel = accel * torque;

      for (int i = 0; i < wheelCols.Length; i++)
      {
         wheelCols[i].motorTorque = accel * torque;
         WheelFrictionCurve newWheelFriction = wheelCols[i].sidewaysFriction;

         if (i < 2)
         {
            wheelCols[i].steerAngle = steer * steeringAmount;
            if (drift > 0)
            {
               newWheelFriction.stiffness = driftFrontWheelFriction; 
            }
            else
            {
               newWheelFriction.stiffness = originalFrontWheelFriction;
            }
         }

         if ( i > 1)
         {
            wheelCols[i].brakeTorque = brake * brakingAmount;

            if (drift > 0)
            {
               newWheelFriction.stiffness = driftBackWheelFriction;
            }
            else
            {
               newWheelFriction.stiffness = originalBackWheelFriction;
            }
         }

         wheelCols[i].sidewaysFriction = newWheelFriction;
         wheelCols[i].GetWorldPose(out wheelPostion, out wheelRotation);
         wheelMeshes[i].transform.position = wheelPostion;
         wheelMeshes[i].transform.localRotation = wheelRotation;

      }
   }

   private void DestroyCar()
   {
      carBodyRigidbody.isKinematic = true;
      carBodyRigidbody.detectCollisions = false;
      carBodyModel.SetActive(false);
      carSoundManager.PlayPastSelfHitEffect();
      destructibleBody.SetActive(true);
      StartCoroutine(BeginRestartRoutine());
   }

   private void ResetCar()
   {
      carSoundManager.ResetToOrigialHitEffect();
      carBodyRigidbody.isKinematic = false;
      carBodyRigidbody.detectCollisions = true;
      destructibleBody.SetActive(false);
      carBodyModel.SetActive(true);
   }

   IEnumerator BeginRestartRoutine()
   {
      yield return new WaitForSeconds(5f);
      ResetCar();
   }

   //public float GetMotorTorque()
   //{
   //   float currentTorque = wheelCols[0].motorTorque;
   //   return currentTorque;
   //}


}
