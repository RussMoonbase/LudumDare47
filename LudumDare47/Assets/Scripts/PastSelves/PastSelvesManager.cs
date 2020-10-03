using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PastSelf
{
   public Vector3 transform;
   public Quaternion rotation;

   public PastSelf(Vector3 carTransform, Quaternion carRotation)
   {
      this.transform = carTransform;
      this.rotation = carRotation;
   }
}

public class PastSelvesManager : MonoBehaviour
{
   public Transform SpawnPoint;
   public GameObject pastSelfCar;

   public bool isRecording;
   public bool canSpawn;
   public Transform thePlayer;
   public List<PastSelf> pastSelves;
   private PastSelf lastPastSelfRecording;

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      if (isRecording)
      {
         if (thePlayer.position != lastPastSelfRecording.transform || thePlayer.rotation != lastPastSelfRecording.rotation)
         {
            var newPastSelf = new PastSelf(thePlayer.position, thePlayer.rotation);
            pastSelves.Add(newPastSelf);

            lastPastSelfRecording = newPastSelf;
         }
      }

      if (canSpawn)
      {
         Instantiate(pastSelfCar, SpawnPoint.position, Quaternion.identity);
         Instantiate(pastSelfCar, SpawnPoint.position, Quaternion.identity);
         canSpawn = false;
      }
   }
}
