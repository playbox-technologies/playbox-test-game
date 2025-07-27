using System;
using System.Collections;
using System.Collections.Generic;
using Playbox;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class AppCrusher : MonoBehaviour
{
   public void verification()
   {
       InAppVerification.Validate("test_product_id","test_product_receipot","000", (b) =>
       {
           Debug.Log(b);
           
       });
   }
}
