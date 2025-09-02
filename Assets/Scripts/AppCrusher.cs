using Playbox;
using UnityEngine;

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
