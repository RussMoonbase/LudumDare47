﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
   public static UIManager instance;
   public TMP_Text currentLapText;
   public TMP_Text maxLapsText;

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

   }
}
