using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;
using Firebase.Storage;
using Firebase.Extensions;

public class ABbutton : MonoBehaviour
{
    public ScreenController screenController;
    public FBStore fbStore;
    public OffLineLocalDataBase offLineLocalDataBase;

    public GameObject sceneManagerObj;
    

    public int butInt;
    public int i2;
  

    bool ATSbool;
    bool ASbool;
    bool RCSbool;
    bool ABSbool;


 

    public void ABFindButtonName()

    {


        sceneManagerObj = GameObject.Find("scene manager");


        screenController = sceneManagerObj.GetComponent<ScreenController>();
        fbStore = sceneManagerObj.GetComponent<FBStore>();
        offLineLocalDataBase = sceneManagerObj.GetComponent<OffLineLocalDataBase>();


        screenController.abNameOfButtonClicked = EventSystem.current.currentSelectedGameObject.name;

        Debug.Log(screenController.abNameOfButtonClicked);

        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
      
        /*
        string s1;
        string s = screenController.abNameOfButtonClicked.Replace("Button", "");
       // s = s.Replace("Button", "");
        // Debug.Log(("s  ") + s);
       int i1 = s.LastIndexOf("(");
       //  Debug.Log(("i1  ") + i1);
       if (i1 > 0) ;
        {

             s1 = s.Substring(0, i1);
            // Debug.Log(("s1  ")+s1);
            Int64 i2 = Int64.Parse(s1);
            //  Debug.Log(("i2  ") + i2);
            butInt = (int)i2;

        }
        Debug.Log(("butInt  ") + butInt);

        // butInt  =  screenController.intButtonIterationCount;

        */

        ATSbool = screenController.abNameOfButtonClicked.StartsWith("Button"+" (ATS)");
        ASbool = screenController.abNameOfButtonClicked.StartsWith("Button"+" (AS)");
        ABSbool = screenController.abNameOfButtonClicked.StartsWith("Button"+" (ABS)");
        RCSbool = screenController.abNameOfButtonClicked.StartsWith("Button"+" (RCS)");


        string  R = screenController.abNameOfButtonClicked.Replace("Button ", "");

        R = R.Replace("(ATS)", "");
        R = R.Replace("(AS)", "");
        R = R.Replace("(ABS)", "");
        R = R.Replace("(RCS)", "");


        /*
        R = R.Replace("*ATS|", "");
        R = R.Replace("*AS|", "");
        R = R.Replace("*ABS|", "");
        R = R.Replace("*RCS|", "");

        */


        //fbStore.adventureIntList = butInt;

        fbStore.GTDocName = (R);
        fbStore.LastGT_For_ATS = (R);

        fbStore.nameofTagGroup = R;
        Debug.Log(("Ok this will happ find me  |") + R);










        screenController.callFromATS = true;

        if (ATSbool == true)
        {
            fbStore.TaskNameList.Clear();
            Debug.Log("ATS");
            if (offLineLocalDataBase.connectionStatus == "OffLine")
            {
                screenController.calltoDownload = true;
                screenController.LDB_AdventureTaskLoaderandScreenChanger();
                screenController.calltoDownload = false;
            }
            else
            {
                screenController.AdventureTaskLoaderandScreenChanger();
            }

        }

        else if (ASbool == true)
        {
           
            Debug.Log("AS");
            fbStore.fbTagScreenName = R;
            fbStore.ASGetData();
            screenController.AS();
           
           
        }

        else if (ABSbool == true)
        {
            Debug.Log("ABS");
            fbStore.ABDocName = R;
            screenController.ABClearAndReload();

        }

        else if (RCSbool == true)
        {
            Debug.Log("RCS");
            screenController.RCS_UI();
        }
        else
        {
            Debug.Log("my dude your missing lest see what your pulling." + screenController.abNameOfButtonClicked + ": oh thats why  it should look like sominting like this  Button0*ATS|test");
        }





    }

    String Download_URL;
    RawImage rawImage;

   

    FirebaseStorage storage;

    StorageReference reference;
    StorageReference jojo;





    private void Start()
    { 

        
        //jojo = storage.GetReferenceFromUrl("gs://gaapp-81260.appspot.com/");

       // reference = jojo.Child("(ATS)test.jpg");

       
       // GetDownloadUrlAsyncABPic();


       // Download_URL = ("https://firebasestorage.googleapis.com/v0/b/gaapp-81260.appspot.com/o/(ABS)Rock%20climbing.jpg?alt=media&token=a6ea18c0-075b-4cc1-ba3b-4c7d18afe485")

        
    }
   
    
    
    public void GetDownloadUrlAsyncABPic()
    {


        


        reference.GetDownloadUrlAsync().ContinueWithOnMainThread(task => {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                Debug.Log("Download URL: " + task.Result);
                Download_URL = task.Result.ToString();
                StartCoroutine(LoadImage(Download_URL));
            }
        });
    }


    








    IEnumerator LoadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl); //Create a request
        yield return request.SendWebRequest(); //Wait for the request to complete
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            rawImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            // setting the loaded image to our object
        }
    }

}
