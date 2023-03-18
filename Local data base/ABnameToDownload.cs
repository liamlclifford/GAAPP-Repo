using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Firebase.Auth;
public class LocalDataBase : MonoBehaviour
{

    public ScreenController screenController;
    public UIManager uIManager;
    public FBStore fbStore;
    public TestLockAndKey testLockAndKey;
    public FBAuth fbAuth;
    public FirebaseUser User;


    public string connectionStatus = ("OffLine");
    public string offLineScandTagID = ("27");
    public string offLineQueryATPlace;
    public string offLineQueryATText;
    public string offLineQueryATName;

    public string ATqueryNameMain;
    public string ATqueryIDMain;

    public string ATqueryID1;
    public string ATqueryID2;
    public string ATqueryID3;
    public string ATqueryID4;
    public string ATqueryID5;
    public string ATqueryID6;

    public string ATqueryName1;
    public string ATqueryName2;
    public string ATqueryName3;
    public string ATqueryName4;
    public string ATqueryName5;
    public string ATqueryName6;

    //sync
    public string LDBNameunloader;
    public string LDBTimeunloader;
    public GameObject SyncButton;

    //local data base name
    public string LDBName;
    public int LDBunloader = 1;
    public int intNCap = 1;
    public int nextsNumberLocalStore = 1;

    public string userDisplayName;
    public int ldbHasDatetoSycn;
    public List<string> LDBTagIDlist = new List<string>() { };
    public List<string> shopingList = new List<string>() { ("clifford home1"), ("clifford home2"), ("clifford home3") };

    public int saveLDBTagIDlistNubpp = 1;

    private void Start()
    {
        GetLDBprefs();
        LoadLDBTagIDlistpp();
        nextsNumberLocalStore = PlayerPrefs.GetInt(("intOffLineN"));
        Debug.Log(nextsNumberLocalStore);
        StartConnectionStatuschecker();




    }



    public void StartConnectionStatuschecker()
    {
        StartCoroutine(checkInternetConnection((isConnected) => {
            // handle connection status here
        }));
    }

    IEnumerator checkInternetConnection(Action<bool> action)
    {
        WWW www = new WWW("http://google.com");
        yield return www;
        if (www.error != null)
        {
            action(false);
            connectionStatus = ("OffLine");
            Debug.Log(connectionStatus);
        }
        else
        {
            action(true);
            connectionStatus = ("OnLine");
            Debug.Log(connectionStatus);
        }
    }





    //ConnectionStatus checker and setter
    public void ConnectionStatusDiverter()
    {
        if (connectionStatus == ("OffLine"))
        {
            if (userDisplayName != (""))
            {
                //for sycn button
                userDisplayName = ("");
            }
            Debug.Log("Diverter to OffLine");
            SetScanedTagsOffLine();

            QueryOffLineATSDataBase();

        }

        if (connectionStatus == ("OnLine"))
        {
            Debug.Log("Diverter to OnLine");
            fbStore.GAAPPQureyStarter();
        }
    }

    public void setOnlineConnectionStatus()
    {
        connectionStatus = ("OnLine");
        Debug.Log(connectionStatus);
    }
    public void setOfflineConnectionStatus()
    {
        connectionStatus = ("OffLine");
        Debug.Log(connectionStatus);
    }







    //fbAuth scink tag time name save and load
    //still need time set up better

    public void StartSyncToUserAuth()
    {

        Debug.Log("SyncASQueryFBStore()");

        int g = 1;
        for (; g < intNCap; g++)
        {
            string ATnamevar = ("User-db-Name-" + g);
            string ATTimevar = ("User-db-Time-" + g);
            LDBNameunloader = PlayerPrefs.GetString(ATnamevar);
            LDBTimeunloader = PlayerPrefs.GetString(ATTimevar);

            fbStore.fbTagScreenName = LDBNameunloader;
            fbAuth.time = LDBTimeunloader;
            fbAuth.SaveDataButton();

            Debug.Log(ATnamevar + (" ") + "Sync");


            Debug.Log("done");
        }

        g = 1;
        Debug.Log("nothing left to sync");
        ClearRTLDB();

    }

    //when loged in Sync button will aper 
    public void LogedInDiverterChecker()
    {
        Debug.Log("LogedInDiverterChecker()");
        Debug.Log(connectionStatus);
        Debug.Log(userDisplayName);
        if (ldbHasDatetoSycn == 1)
        {
            Debug.Log("ldbHasDatetoSycn == true");
            if (connectionStatus == ("OnLine"))
            {
                Debug.Log("Divertered OnLine ");
                if (userDisplayName != (""))
                {
                    Debug.Log("Divertered to loged IN ");
                    ActivateSyncButton();
                }

                if (userDisplayName == (""))
                {
                    Debug.Log("Divertered to NOT loged in");
                    DeactivateSyncButton();

                }
            }

            if (connectionStatus == ("OffLine"))
            {
                Debug.Log("LogedIn Divertered to OffLine");
                DeactivateSyncButton();

            }
        }
        if (ldbHasDatetoSycn == 0)
        {
            Debug.Log("ldbHasDatetoSycn = false");
            DeactivateSyncButton();
        }
    }



    public void SavePPldbHasDatetoSycn()
    {
        PlayerPrefs.SetInt(("PPldbHasDatetoSycn"), (ldbHasDatetoSycn));

    }
    public void DeactivateSyncButton()
    {
        Debug.Log("DeactivateSyncButton()");
        SyncButton.SetActive(false);
    }
    public void ActivateSyncButton()
    {
        Debug.Log("ActivateSyncButton()");
        SyncButton.SetActive(true);
    }









    // like the Real time db but  local 
    public void DLCtoRTLDBSetter()
    {
        Debug.Log("DLCtoRTLDBSetter()");

        string n = nextsNumberLocalStore.ToString();

        string nameSn = ("User-db-Name-" + n);
        string TimeSn = ("User-db-Time-" + n);

        Debug.Log(nameSn + ("  ") + TimeSn);
       
        fbAuth.setSystemTime();
        PlayerPrefs.SetString(nameSn, (fbStore.fbTagScreenName));
        PlayerPrefs.SetString(TimeSn, (fbAuth.time));





        Debug.Log(nextsNumberLocalStore + "  has been Saved");
        nextsNumberLocalStore = nextsNumberLocalStore + 1;
        intNCap = intNCap + 1;
        setLDBprefs();
        PlayerPrefs.SetInt(("intOffLineN"), (nextsNumberLocalStore));
        Debug.Log(nextsNumberLocalStore + "  has been set");
        if (ldbHasDatetoSycn == 0)
        {
            ldbHasDatetoSycn = 1;
            SavePPldbHasDatetoSycn();
        }


    }


    // tag time name save and load / set and get in the Auth / Real Time Data base
    public void SetScanedTagsOffLine()
    {
        PlayerPrefs.SetString(("tagName1"), fbStore.fbScannedTagID);
        Debug.Log("ScanedTagsOffLine Set");
    }


    /*  public void GetScanedTagsOffLine()
      {
          fbStore.fbScannedTagID = PlayerPrefs.GetString("tagName1");
          Debug.Log(fbStore.fbScannedTagID);
          fbStore.SinkASQueryFBStore();

      }
    */

    public void ClearRTLDB()
    {
        Debug.Log("ClearRTLDB()");
        for (int n = 1; n <= intNCap; n++)
        {
            string nameSn = ("User-db-Name-" + n);
            string TimeSn = ("User-db-Time-" + n);




            Debug.Log(nameSn + ("  ") + TimeSn + ("") + ("has been cleared"));

            PlayerPrefs.SetString(nameSn, (null));
            PlayerPrefs.SetString(TimeSn, (null));



        }


        Debug.Log("brake loop");
        intNCap = 1;
        nextsNumberLocalStore = 1;
        ResetLDBPerf();
        ldbHasDatetoSycn = 0;
        SavePPldbHasDatetoSycn();
        DeactivateSyncButton();


    }
    public void ResetLDBPerf()
    {
        setLDBprefs();
    }

    public void setLDBprefs()
    {
        PlayerPrefs.SetInt("intNCapPP", (intNCap));
        PlayerPrefs.SetInt("LDBunloaderPP", (LDBunloader));
        PlayerPrefs.SetInt(("intOffLineN"), (nextsNumberLocalStore));
       
    }

    public void GetLDBprefs()
    {
        ldbHasDatetoSycn = PlayerPrefs.GetInt("PPldbHasDatetoSycn");
        intNCap = PlayerPrefs.GetInt("intNCapPP");
        LDBunloader = PlayerPrefs.GetInt("LDBunloaderPP");
        nextsNumberLocalStore = PlayerPrefs.GetInt("intOffLineN");
    }










    //down load Tag info and store it.
    //this is like the AS fire base store
    // the data base is real just Player Prefs for now this will need to be changed 

    public void DownLoadSelectedATtoLDBS()
    {
        StartCoroutine(DLCtoLDBSetter());
    }

   IEnumerator DLCtoLDBSetter()
    {
        Debug.Log("DLCtoLDBSetter()");

       

        foreach (string s in shopingList)
        {
            Debug.Log(s);
            LDBName = s;

            fbStore.ASGetDataForLocalDBS();
            yield return new WaitForSeconds(1);
            LDBTagIDlist.Add(fbStore.VarTagIDASTMP);
            

            string i = nextsNumberLocalStore.ToString();
            Debug.Log("i = " + i);
            string nameSn = ("AT-Name-" + i);
            string placeSn = ("AT-Place-" + i);
            string idSn = ("AT-Tag ID-" + i);
            string testSn = ("AT-Text-" + i);

            

            Debug.Log(nameSn + ("  ") + placeSn + ("  ") + idSn + ("  ") + testSn);

            PlayerPrefs.SetString(nameSn, LDBName);
            PlayerPrefs.SetString(placeSn, fbStore.VarPlaceASTMP);
            PlayerPrefs.SetString(idSn, fbStore.VarTagIDASTMP);
            PlayerPrefs.SetString(testSn, fbStore.VarTextASTMP);

            
            Debug.Log(("VarASTMP") + ("  ") + LDBName + ("  ") + fbStore.VarPlaceASTMP + ("  ") + fbStore.VarTagIDASTMP + ("  ") + fbStore.VarTextASTMP);


            Debug.Log(nextsNumberLocalStore);

            nextsNumberLocalStore = nextsNumberLocalStore + 1;
            setLDBprefs();
            


        }

        saveLDBTagIDlistpp();

    }
    public void ClearLDB()
    {
        int n = 1;
        for (; n <= nextsNumberLocalStore; n++)
        {
            Debug.Log("loop"+ n);
            string nameSn = ("AT-Name-" + n);
            string placeSn = ("AT-Place-" + n);
            string idSn = ("AT-Tag ID-" + n);
            string testSn = ("AT-Text-" + n);



            Debug.Log(nameSn + placeSn + idSn+testSn);

            PlayerPrefs.SetString(nameSn, (null));
            PlayerPrefs.SetString(placeSn, (null));
            PlayerPrefs.SetString(idSn, (null));
            PlayerPrefs.SetString(testSn, (null));

            if (n >= nextsNumberLocalStore)
            {
                Debug.Log("maybe done on loop" + n);
                nextsNumberLocalStore = 1;
                setLDBprefs();
            }
           
        }
        n = 1;
        ClearLDBTagIDlistpp();
    }




    //LDBTagIDlist



    // Local DateBase Queryer or LDBQ

    public void QueryOffLineATSDataBase()
    {
        IDGetterForQueryOffLineATSDataBase();
        NameGetterForQueryOffLineATSDataBase();
        Debug.Log("Getters Done");
        int o = 1;
        foreach (string s in LDBTagIDlist)
        {
            Debug.Log(s);
           
            Debug.Log(o);
            if (s == fbStore.fbScannedTagID)
            {
                Debug.Log("tag found in local db");
                Debug.Log(o);
                offLineQueryATPlace = ("AT-Place-"+o);
                offLineQueryATText = ("AT-Text-"+o);
                offLineQueryATName = ("AT-Name-"+o);
                OffLineATSDataBaseGetter();
                screenController.ATS();
                break;
            }


            o = o + 1;


        }


        Debug.Log(" Not in Local DataBase");
        Debug.Log(("fbScannedTagID") + fbStore.fbScannedTagID + ("  ") + ATqueryID1 + ("  ") + ATqueryID2 + ("  ") + ATqueryID3);


    }

    public void saveLDBTagIDlistpp()
    {
        Debug.Log("saveLDBTagIDlistpp()");
        foreach (string s in LDBTagIDlist)
        {
            PlayerPrefs.SetString("LDBTagIDlistpp"+ saveLDBTagIDlistNubpp, s);
            saveLDBTagIDlistNubpp = saveLDBTagIDlistNubpp + 1;
            PlayerPrefs.SetInt("LDBTagIDlistNubpp",saveLDBTagIDlistNubpp);
        }
    }

    public void LoadLDBTagIDlistpp()
    {
        Debug.Log("LoadLDBTagIDlistpp()");
       saveLDBTagIDlistNubpp = PlayerPrefs.GetInt("LDBTagIDlistNubpp");
        int o = 1;
        while ( o < saveLDBTagIDlistNubpp)
        {
        string l = PlayerPrefs.GetString("LDBTagIDlistpp" + o);
           LDBTagIDlist.Add(l);
            o = o + 1;
            Debug.Log("added"+ l);
        }
        Debug.Log("done and Loaded");
        
    }


    public void ClearLDBTagIDlistpp()
    {
        int o = 1;
        foreach (string s in LDBTagIDlist)
        {
            PlayerPrefs.SetString("LDBTagIDlistpp" + saveLDBTagIDlistNubpp,null);
            saveLDBTagIDlistNubpp = saveLDBTagIDlistNubpp + 1;
            PlayerPrefs.SetInt("LDBTagIDlistNubpp", saveLDBTagIDlistNubpp);
        }
        saveLDBTagIDlistNubpp = 1;
        PlayerPrefs.SetInt("LDBTagIDlistNubpp", saveLDBTagIDlistNubpp);
        Debug.Log("list cleared");
    }



    public void IDGetterForQueryOffLineATSDataBase()
    {
        Debug.Log("ID Getter");
        ATqueryID1 = PlayerPrefs.GetString("AT-Tag ID-1");
        ATqueryID2 = PlayerPrefs.GetString("AT-Tag ID-2");
        ATqueryID3 = PlayerPrefs.GetString("AT-Tag ID-3");
        ATqueryID4 = PlayerPrefs.GetString("AT-Tag ID-4");
        ATqueryID5 = PlayerPrefs.GetString("AT-Tag ID-5");
        ATqueryID6 = PlayerPrefs.GetString("AT-Tag ID-6");
    }
    public void NameGetterForQueryOffLineATSDataBase()
    {
        Debug.Log("Name Getter");
        ATqueryName1 = PlayerPrefs.GetString("AT-Name-1");
        ATqueryName2 = PlayerPrefs.GetString("AT-Name-2");
        ATqueryName3 = PlayerPrefs.GetString("AT-Name-3");
        ATqueryName4 = PlayerPrefs.GetString("AT-Name-4");
        ATqueryName5 = PlayerPrefs.GetString("AT-Name-5");
        ATqueryName6 = PlayerPrefs.GetString("AT-Name-6");
    }


    public void OffLineATSDataBaseGetter()
    {
        // PlayerPrefs.GetString(("AT-Place-1"));
        fbStore.PlaceASTMP.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetString(offLineQueryATPlace);
        //= PlayerPrefs.GetString(("AT-Tag ID-1"));
        fbStore.TextASTMP.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetString(offLineQueryATText);
        fbStore.fbTagScreenName = PlayerPrefs.GetString(offLineQueryATName);
     
        screenController.activeScreen = ("ATS");
        screenController.updateActiveScreenToActiveScreenFab();
        screenController.TurnOffAllScreensButOne();
        Debug.Log("Right here");
        DLCtoRTLDBSetter();
        fbStore.fbScannedTagID = (null); 
        fbStore.fbTagScreenName = (null);

    }





    //other button or metheds for testing 
  
    public void seeLDB()
    {
        Debug.Log(PlayerPrefs.GetString("AT-Name-1") + ("/") + PlayerPrefs.GetString("AT-Place-1") + ("/") + PlayerPrefs.GetString("AT-Tag ID-1") + ("/") + PlayerPrefs.GetString("AT-Text-1"));
        Debug.Log(PlayerPrefs.GetString("AT-Name-2") + ("/") + PlayerPrefs.GetString("AT-Place-2") + ("/") + PlayerPrefs.GetString("AT-Tag ID-2") + ("/") + PlayerPrefs.GetString("AT-Text-2"));
        Debug.Log(PlayerPrefs.GetString("AT-Name-3") + ("/") + PlayerPrefs.GetString("AT-Place-3") + ("/") + PlayerPrefs.GetString("AT-Tag ID-3") + ("/") + PlayerPrefs.GetString("AT-Text-3"));

        Debug.Log(PlayerPrefs.GetString("User-db-Name-1") + ("/") + PlayerPrefs.GetString("User-db-Time-1"));
        Debug.Log(PlayerPrefs.GetString("User-db-Name-2") + ("/") + PlayerPrefs.GetString("User-db-Time-2"));
        Debug.Log(PlayerPrefs.GetString("User-db-Name-3") + ("/") + PlayerPrefs.GetString("User-db-Time-3"));

    }
    //fake one /tester
    public void OffLineATSDataBaseSetter()
    {
        PlayerPrefs.SetString(("User-db-Name-1"), ("Name-1"));
        PlayerPrefs.SetString(("User-db-Time-1"), ("time111"));

        PlayerPrefs.SetString(("User-db-Name-2"), ("Name-2"));
        PlayerPrefs.SetString(("User-db-Time-2"), ("time222"));

        PlayerPrefs.SetString(("User-db-Name-3"), ("Name-3"));
        PlayerPrefs.SetString(("User-db-Time-3"), ("time333"));

        LDBunloader = 1;
        LDBunloader = 1;
        intNCap = 1;
        setLDBprefs();

    }
}


/*
PlayerPrefs.SetString(("AT-Name-1"), ("Name-1"));
PlayerPrefs.SetString(("AT-Place-1"), ("Place-1"));
PlayerPrefs.SetString(("AT-Tag ID-1"), ("100"));
PlayerPrefs.SetString(("AT-Text-1"), ("Text-1"));

PlayerPrefs.SetString(("AT-Name-2"), ("Name-2"));
PlayerPrefs.SetString(("AT-Place-2"), ("Place-2"));
PlayerPrefs.SetString(("AT-Tag ID-2"), ("200"));
PlayerPrefs.SetString(("AT-Text-2"), ("Text-2"));

PlayerPrefs.SetString(("AT-Name-3"), ("Name-3"));
PlayerPrefs.SetString(("AT-Place-3"), ("Place-3"));
PlayerPrefs.SetString(("AT-Tag ID-3"), ("300"));
PlayerPrefs.SetString(("AT-Text-3"), ("Text-3"));
*/