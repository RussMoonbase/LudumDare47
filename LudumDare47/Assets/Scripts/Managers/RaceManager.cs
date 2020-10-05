using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class RaceManager : MonoBehaviour
{
   public static RaceManager instance;
   public Checkpoint[] checkPoints;
   public int totalcheckPoints;
   public int currentLap;
   public int maxLaps;

   public PlayableDirector startTimeline;
   public PlayableDirector finishTimeline;

   public enum PlayerPrefParameters
   {
      BestTime
   }

   public float initialStartTime = 240;
   //public bool isTimerRunning;
   private float countdownTimer;
   private float stopwatchTimer;
   private float minutes;
   private float seconds;
   private float milliseconds;

   private void Awake()
   {
      instance = this;
      PlayerPrefs.SetFloat(PlayerPrefParameters.BestTime.ToString(), initialStartTime);
   }

   // Start is called before the first frame update
   void Start()
   {
      finishTimeline.Stop();
      totalcheckPoints = checkPoints.Length;

      if (checkPoints.Length != 0)
      {
         for (int i = 0; i < checkPoints.Length; i++)
         {
            checkPoints[i].checkPointNum = i;
         }
      }

      countdownTimer = PlayerPrefs.GetFloat(PlayerPrefParameters.BestTime.ToString());
      stopwatchTimer = 0;

      currentLap = 1;
      UIManager.instance.currentLapText.text = currentLap.ToString();
      UIManager.instance.maxLapsText.text = maxLaps.ToString();
      //Debug.Log("Current Lap = " + currentLap);
   }

   // Update is called once per frame
   void Update()
   {
      if (currentLap <= maxLaps)
      {
         countdownTimer -= Time.deltaTime;
         stopwatchTimer += Time.deltaTime;

         if (countdownTimer > 0)
         {
            SetCountDownTimeDisplay(countdownTimer);
         }
         

         if (countdownTimer <= 0)
         {
            StartCoroutine(WaitToLoadLoseScene());
         }
      }

      if (currentLap > maxLaps)
      {
         finishTimeline.Play();
         StartCoroutine(WaitToLoadWinScene());
      }
   }

   void SetCountDownTimeDisplay(float theTime)
   {
      minutes = Mathf.FloorToInt(theTime / 60);
      seconds = Mathf.FloorToInt(theTime % 60);
      milliseconds = (theTime % 1) * 1000;
      UIManager.instance.countdownTimerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
   }

   IEnumerator WaitToLoadWinScene()
   {
      yield return new WaitForSeconds(4);
      SceneLoaderManager.instance.LoadWinScene();
   }

   IEnumerator WaitToLoadLoseScene()
   {
      yield return new WaitForSeconds(4);
      SceneLoaderManager.instance.LoadNextScene();
   }
}
