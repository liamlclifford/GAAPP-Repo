using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ABDownloadbutton : MonoBehaviour
{
    public ScreenController screenController;
    public FBStore fbStore;
    public OffLineLocalDataBase offLineLocalDataBase;
    public FBStorage fbStorage;

    public GameObject sceneManagerObj;
    

   // public int butInt;
   // public int i2;
    //this is the flow starts at
    // ABFindButtonName()
    //  LBDDownloadDiverter()offLineLocalDataBase.
    public void ABFindButtonName()

    {
        Debug.Log("ABFindButtonName()");
       
        sceneManagerObj = GameObject.Find("scene manager");
        

        screenController = sceneManagerObj.GetComponent<ScreenController>();
        fbStore = sceneManagerObj.GetComponent<FBStore>();
         offLineLocalDataBase = sceneManagerObj.GetComponent< OffLineLocalDataBase>();
        fbStorage = sceneManagerObj.GetComponent<FBStorage>();



        screenController.abNameOfButtonClicked = EventSystem.current.currentSelectedGameObject.transform.parent.name;
       

        string n = screenController.abNameOfButtonClicked;


        //Debug.Log(screenController.abNameOfButtonClicked);
        //Debug.Log(EventSystem.current.currentSelectedGameObject.transform.parent.name);
        /*
        string s = screenController.abNameOfButtonClicked.Replace("Button", "");
        s = s.Replace("Button", "");
        // Debug.Log(("s  ") + s);
        int i1 = s.LastIndexOf("(");
        // Debug.Log(("i1  ") + i1);
        if (i1 > 0) ;
        {

            string s1 = s.Substring(0, i1);
            //  Debug.Log(("s1  ")+s1);
            Int64 i2 = Int64.Parse(s1);
            //  Debug.Log(("i2  ") + i2);
            butInt = (int)i2;

        }
        Debug.Log(("butInt  ") + butInt);

        n = n.Replace("Button" + butInt + " ", "");


        */
        fbStorage.DownloadABSPics();
        n = n.Replace("Button ", "");
        offLineLocalDataBase.LDB_MegaList.Add(n);
        offLineLocalDataBase.MegaListNumPP = offLineLocalDataBase.MegaListNumPP + 1;
        PlayerPrefs.SetInt("MegaListNumPP", offLineLocalDataBase.MegaListNumPP);
     
        n = n.Replace("(ATS)", "");
        n = n.Replace("(AS)", "");
        n = n.Replace("(ABS)", "");
        n = n.Replace("(RCS)", "");

          offLineLocalDataBase.DynNameToDownload = n;
        Debug.Log(("DynNameToDownload set too  ") + n);

        fbStore.GTDocName = (n);
        fbStore.nameofTagGroup = n;
        offLineLocalDataBase.ATSbool = screenController.abNameOfButtonClicked.StartsWith("Button"  + " (ATS)");
        offLineLocalDataBase.ASbool = screenController.abNameOfButtonClicked.StartsWith("Button"  + " (AS)");
        offLineLocalDataBase.ABbool = screenController.abNameOfButtonClicked.StartsWith("Button" + " (ABS)");
        offLineLocalDataBase.RCSbool = screenController.abNameOfButtonClicked.StartsWith("Button"  + " (RCS)");
        
        offLineLocalDataBase.LBDDownloadDiverter();
        //this is the flow 


    }

    
}

