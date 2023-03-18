using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ATSButton : MonoBehaviour
{
    public ScreenController screenController;
   // public FBStore fbStore;

    public GameObject sceneManagerObj;
   // public GameObject fbStoreObj;

   
    public int i;

    public void ATSFindButtonName()

    {
        sceneManagerObj = GameObject.Find("scene manager");
       // fbStoreObj = GameObject.Find("scene manager");

        screenController = sceneManagerObj.GetComponent<ScreenController>();
       // fbStore = fbStoreObj.GetComponent<FBStore>();

        screenController.ATSNameOfButtonClicked = EventSystem.current.currentSelectedGameObject.name;

        Debug.Log(screenController.ATSNameOfButtonClicked);

        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
      
         string s = screenController.ATSNameOfButtonClicked.Replace("TaskButton", "");

        Debug.Log("s  " + s);

       
        Int64 i = Int64.Parse(s);
      
     

        screenController.ATSintButtonIterationCount = (int)i;
        screenController.TaskButtonOnClick();

        /*  
         
         bool ATSbool;

        s = s.Replace("Button", "");
         Debug.Log(("s  ") + s);
        int i1 = s.LastIndexOf("*");
         Debug.Log(("i1  ") + i1);

       
        if (i1 > 0) ;
        {

            string s1 = s.Substring(0, i1);
            //  Debug.Log(("s1  ")+s1);
            Int64 i2 = Int64.Parse(s1);
            //  Debug.Log(("i2  ") + i2);
            butInt = (int)i2;

        }
        Debug.Log(("butInt  ") + butInt);

        // butInt  =  screenController.intButtonIterationCount;


        ATSbool = screenController.abNameOfButtonClicked.StartsWith("Button" + butInt);
      
        //fbStore.adventureIntList = butInt;


        if (ATSbool == true)
        {
            Debug.Log("ATS");
            screenController.AdventureTaskLoaderandScreenChanger();

        }

       */


    }
}

