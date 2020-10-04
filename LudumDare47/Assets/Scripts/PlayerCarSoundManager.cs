using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarSoundManager : MonoBehaviour
{
   public AudioSource engineSFX;
   public WheelCollider wheelCol;
   public AudioSource hitFX;

   private Rigidbody rBody;
   public float pitch = 0f;

   // Start is called before the first frame update
   void Start()
   {
      rBody = GetComponent<Rigidbody>();
   }

   // Update is called once per frame
   void Update()
   {
      float currentSpeed = wheelCol.motorTorque;

      if (currentSpeed == 0)
      {
         engineSFX.pitch = -0.36f;
      }
      else
      {
         engineSFX.pitch = ((currentSpeed) / CarController.instance.torque) * 2f;
      }
      
   }

   private void OnCollisionEnter(Collision collision)
   {
      hitFX.Stop();
      float randomNum = Random.Range(0.6f, 1.4f);
      hitFX.pitch = randomNum;
      hitFX.Play();
   }
}
