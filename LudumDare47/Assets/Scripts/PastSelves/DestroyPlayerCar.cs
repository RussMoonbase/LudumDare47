using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayerCar : MonoBehaviour
{
   public float forcePower;
   public bool canHitPlayer = false;
   public float waitTime;

   // Start is called before the first frame update
   void Start()
   {
      StartCoroutine(TurnOnCanHitPlayer());
   }

   // Update is called once per frame
   void Update()
   {

   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Player")
      {
         if (canHitPlayer)
         {
            Debug.Log("Hit Player");
            Rigidbody rBody = other.GetComponent<Rigidbody>();

            if (rBody)
            {
               Debug.Log("RigidBody Found");
               rBody.AddForce((other.transform.up) * forcePower, ForceMode.Impulse);
               rBody.AddForce((other.transform.right) * 30000f, ForceMode.Impulse);
            }
         }

      }
   }

   IEnumerator TurnOnCanHitPlayer()
   {
      yield return new WaitForSeconds(waitTime);
      canHitPlayer = true;
   }
}
