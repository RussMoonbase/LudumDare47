using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
   public static UIManager instance;
   public TMP_Text currentLapText;
   public TMP_Text maxLapsText;
   public TMP_Text countdownTimerText;

   private void Awake()
   {
      instance = this;
   }
}
