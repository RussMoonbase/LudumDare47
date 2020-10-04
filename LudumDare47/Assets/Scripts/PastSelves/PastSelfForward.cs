using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastSelfForward : MonoBehaviour
{
   public List<PastSelfRecording> forwardRecordings;
   public bool isPlaying = false;
   public Transform frontRightWheel;
   public Transform frontLeftWheel;
   public Transform backRightWheel;
   public Transform backLeftWheel;
   public bool isMovingForwardInTime;

   // Start is called before the first frame update
   void Start()
   {
      //Debug.Log("Forward Recordings Count = " + forwardRecordings.Count);
      isPlaying = true;
   }

   // Update is called once per frame
   void Update()
   {
      if (isPlaying)
      {
         PlayRecordings();
      }
   }

   void PlayRecordings()
   {
      StartCoroutine(PlayRecordingsRoutine());
      isPlaying = false;
   }

   IEnumerator PlayRecordingsRoutine()
   {

      if (isMovingForwardInTime)
      {
         foreach (PastSelfRecording recording in forwardRecordings)
         {
            this.transform.position = recording.carBodyTransform;
            this.transform.rotation = recording.carBodyRotation;
            frontRightWheel.localRotation = recording.frontRightWheelRot;
            frontLeftWheel.localRotation = recording.frontLeftWheelRot;
            backRightWheel.localRotation = recording.backRightWheelRot;
            backLeftWheel.localRotation = recording.backLeftWheelRot;
            yield return new WaitForFixedUpdate();
         }
      }
      else
      {
         for (int i = forwardRecordings.Count - 1; i > 0; i--)
         {
            this.transform.position = forwardRecordings[i].carBodyTransform;
            this.transform.rotation = forwardRecordings[i].carBodyRotation;
            frontRightWheel.localRotation = forwardRecordings[i].frontRightWheelRot;
            frontLeftWheel.localRotation = forwardRecordings[i].frontLeftWheelRot;
            backRightWheel.localRotation = forwardRecordings[i].backRightWheelRot;
            backLeftWheel.localRotation = forwardRecordings[i].backLeftWheelRot;
            yield return new WaitForFixedUpdate();
         }
      }

      isPlaying = true;
   }
}
