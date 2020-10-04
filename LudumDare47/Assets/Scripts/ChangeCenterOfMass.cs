using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCenterOfMass : MonoBehaviour
{
   public Vector3 theCenterOfMass;
   public Rigidbody rB;

   // Start is called before the first frame update
   void Start()
   {
      rB = GetComponent<Rigidbody>();
      
   }

   // Update is called once per frame
   void Update()
   {
      rB.centerOfMass = theCenterOfMass;
   }

   private void OnDrawGizmos()
   {
      Gizmos.color = Color.red;
      Gizmos.DrawSphere(transform.position + transform.rotation * theCenterOfMass, 0.4f);
   }
}
