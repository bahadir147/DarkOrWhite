//using Facebook.Unity;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FacebookScript : MonoBehaviour
//{

//    private void Awake()
//    {
//        if (!FB.IsInitialized)
//        {
//            FB.Init(() =>
//            {
//                if (FB.IsInitialized)
//                    FB.ActivateApp();
//                else
//                    Debug.LogError("Coluld't initialize");

//            },
//            isGameShow =>
//            {
//                if (!isGameShow)
//                    Time.timeScale = 0;
//                else
//                    Time.timeScale = 1;
//            });
//        }
//        else
//            FB.ActivateApp();
//    }
   
//}
