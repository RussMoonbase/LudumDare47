using System.Collections;
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
   public static PastSelvesManager instance;
   public Transform SpawnPoint;
   public GameObject pastSelfCarLap1;
   public GameObject pastSelfCarLap2;
   public GameObject pastSelfCarLap3;

   public bool isRecording;
   public bool canSpawn = false;
   public Transform thePlayer;
   public Transform frontRightWheel;
   public Transform frontLeftWheel;
   public Transform backRightWheel;
   public Transform backLeftWheel;

   public List<PastSelfRecording> pastSelvesLap1 = new List<PastSelfRecording>();
   public List<PastSelfRecording> pastSelvesLap2 = new List<PastSelfRecording>();
   public List<PastSelfRecording> pastSelvesLap3 = new List<PastSelfRecording>();
   private PastSelfRecording lastPastSelfRecording;

   private void Awake()
   {
      instance = this;
   }

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      //if (isRecording)
      //{
      //   if (thePlayer.position != lastPastSelfRecording.carBodyTransform || thePlayer.rotation != lastPastSelfRecording.carBodyRotation)
      //   {
      //      var newPastSelf = new PastSelfRecording(thePlayer.position, thePlayer.rotation, 
      //         frontRightWheel.rotation, frontLeftWheel.rotation, backRightWheel.rotation, backLeftWheel.rotation);
      //      pastSelves.Add(newPastSelf);

      //      lastPastSelfRecording = newPastSelf;
      //   }
      //}



      if (canSpawn)
      {
         canSpawn = false;

         GameObject spawnCar;

         if (RaceManager.instance.currentLap == 2)
         {
            spawnCar = pastSelfCarLap1;
         }
         else if (RaceManager.instance.currentLap == 3)
         {
            spawnCar = pastSelfCarLap2;
         }
         else if (RaceManager.instance.currentLap == 4)
         {
            spawnCar = pastSelfCarLap3;
         }
         else
         {
            spawnCar = pastSelfCarLap1;
         }


         var forwardCar = Instantiate(spawnCar, SpawnPoint.position, Quaternion.identity);
         var backwardCar = Instantiate(spawnCar, SpawnPoint.position, Quaternion.identity);
         PastSelfForward pSForward = forwardCar.GetComponent<PastSelfForward>();
         PastSelfForward pSBackward = backwardCar.GetComponent<PastSelfForward>();


         if (pSForward)
         {
            pSForward.isMovingForwardInTime = true;
            //pSForward.forwardRecordings = new List<PastSelfRecording>(pastSelvesLap1);
            CopyListToSpawnedCar(pSForward);
         }

         if (pSBackward)
         {
            pSBackward.isMovingForwardInTime = false;
            //pSBackward.forwardRecordings = new List<PastSelfRecording>(pastSelvesLap1);
            CopyListToSpawnedCar(pSBackward);
         }
         
      }
   }

   private void FixedUpdate()
   {
      if (isRecording)
      {
         if (thePlayer.position != lastPastSelfRecording.carBodyTransform || thePlayer.rotation != lastPastSelfRecording.carBodyRotation)
         {
            var newPastSelf = new PastSelfRecording(thePlayer.position, thePlayer.rotation,
               frontRightWheel.rotation, frontLeftWheel.rotation, backRightWheel.rotation, backLeftWheel.rotation);

            if (RaceManager.instance.currentLap == 1)
            {
               pastSelvesLap1.Add(newPastSelf);
            }
            else if (RaceManager.instance.currentLap == 2)
            {
               pastSelvesLap2.Add(newPastSelf);
            }
            else if (RaceManager.instance.currentLap == 3)
            {
               pastSelvesLap3.Add(newPastSelf);
            }

            lastPastSelfRecording = newPastSelf;
         }
      }
   }

   void CopyListToSpawnedCar(PastSelfForward pSelfForward)
   {
      if (RaceManager.instance.currentLap == 2)
      {
         pSelfForward.forwardRecordings = new List<PastSelfRecording>(pastSelvesLap1);
      }
      else if (RaceManager.instance.currentLap == 3)
      {
         pSelfForward.forwardRecordings = new List<PastSelfRecording>(pastSelvesLap2);
      }
      else if (RaceManager.instance.currentLap == 4)
      {
         pSelfForward.forwardRecordings = new List<PastSelfRecording>(pastSelvesLap3);
      }
   }
}
