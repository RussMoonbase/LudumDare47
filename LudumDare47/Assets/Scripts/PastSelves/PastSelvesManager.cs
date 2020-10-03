﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PastSelfRecording
{
   public Vector3 carBodyTransform;
   public Quaternion carBodyRotation;
   public Quaternion frontRightWheelRot;
   public Quaternion frontLeftWheelRot;
   public Quaternion backRightWheelRot;
   public Quaternion backLeftWheelRot;

   public PastSelfRecording(Vector3 carTransform, Quaternion carRotation, 
      Quaternion fRWheelRot, Quaternion fLWheelRot, Quaternion bRWheelRot, Quaternion bLWheelRot)
   {
      this.carBodyTransform = carTransform;
      this.carBodyRotation = carRotation;
      this.frontRightWheelRot = fRWheelRot;
      this.frontLeftWheelRot = fLWheelRot;
      this.backRightWheelRot = bRWheelRot;
      this.backLeftWheelRot = bLWheelRot;
   }
}

public class PastSelvesManager : MonoBehaviour
{
   public Transform SpawnPoint;
   public GameObject pastSelfCarForward;
   //public GameObject pastSelfCarBackward;

   public bool isRecording;
   public bool canSpawn = false;
   public Transform thePlayer;
   public Transform frontRightWheel;
   public Transform frontLeftWheel;
   public Transform backRightWheel;
   public Transform backLeftWheel;

   public List<PastSelfRecording> pastSelves = new List<PastSelfRecording>();
   private PastSelfRecording lastPastSelfRecording;

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      if (isRecording)
      {
         if (thePlayer.position != lastPastSelfRecording.carBodyTransform || thePlayer.rotation != lastPastSelfRecording.carBodyRotation)
         {
            var newPastSelf = new PastSelfRecording(thePlayer.position, thePlayer.rotation, 
               frontRightWheel.rotation, frontLeftWheel.rotation, backRightWheel.rotation, backLeftWheel.rotation);
            pastSelves.Add(newPastSelf);

            lastPastSelfRecording = newPastSelf;
         }
      }



      if (canSpawn)
      {
         canSpawn = false;
         var forwardCar = Instantiate(pastSelfCarForward, SpawnPoint.position, Quaternion.identity);
         //var backwardCar = Instantiate(pastSelfCarBackward, SpawnPoint.position, Quaternion.identity);
         forwardCar.GetComponent<PastSelfForward>().forwardRecordings = new List<PastSelfRecording>(pastSelves);
      }
   }
}
