using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Firebase.Auth;
using UnityEngine.Networking;

public class OffLineLocalDataBase : MonoBehaviour
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
    public string theOBroSpotholder_pp;

    public string ATqueryNameMain;
    public string ATqueryIDMain;



    //sync
    public string LDBNameunloader;
    public string LDBTimeunloader;
    public GameObject SyncButton;

    public string theOBro;

    //local data base name
    public int MegaListNumPP = 0;



    public string LDBName;
    public int LDBunloader = 1;
    public int intNCap = 1;
    public int nextsNumberLocalStore;

    public bool callFromATS_LDB = false;

    public string userDisplayName;
    public int ldbHasDatetoSycn;
    public List<string> LDBTagIDlist = new List<string>() { };

    public List<string> LDB_MegaList;
    public List<string> AS_LDBList = new List<string>();
    public List<string> ATS_LDB_TimesList = new List<string>();

    public List<string> AST_LDBList = new List<string>();

    public int saveLDBTagIDlistNubpp = 1;
    public int AS_LDBListNumPP = 1;

    //LDB_GT
    public int LDB_GT_Nubpp;
    public int saveLDB_GT_Nubpp;
    public string LDB_GT_getter_Name;
    public List<string> GT_ListNameList;

    //LDB Tasks
    public List<string> Dyn_LDB_UserTaskTime_List;


    public int LDB_UTT_Nubpp = 0;

    //liam thigs
    public String DynNameToDownload;
    public bool ATSbool;
    public bool ASbool;
    public bool RCSbool;
    public bool ABbool;

    public List<string> Sync_AS_LDBList;
  


    public void Start()
    {
        LoadAllPP();
        LoadDyn_LDB_GT_listpp();
        nextsNumberLocalStore = PlayerPrefs.GetInt(("intOffLineN"));
        Debug.Log(nextsNumberLocalStore);
        fbStore.ABDocName = ("New");
       screenController.ABinstantVenturesButton();
        fbStore.CategoryButtonGetDataToList();
        
       




    }

    public void vokABbutton()
    {
       
    }





    public void LoadAllPP()
    {
        GetLDBprefs();
        LoadAS_LDBListPP();
        LoadLDBTagIDlistpp();
        LoadMegaListNumPP();
        Load_Sync_AS_LDBList();



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
          //  LDBTagIDlist.Add(fbStore.fbScannedTagID);
            AS_LDB_Q();

        }

        if (connectionStatus == ("OnLine"))
        { Debug.Log("Diverter to OnLine");

            
           
           
           
            fbStore.GAAPPQureyStarter();
            
               
        }
    }

    public void setOnlineConnectionStatus()
    {
        fbAuth.GT_LDB = true;
        connectionStatus = ("OnLine");
        Debug.Log(connectionStatus);
    }
    public void setOfflineConnectionStatus()
    {
       
        fbAuth.GT_LDB = false;
        connectionStatus = ("OffLine");
        Debug.Log(connectionStatus);
    }







    //fbAuth sycn tag time name save and load
    //still need time set up better

    public void StartSyncToUserAuth()
    {

        Debug.Log("SyncASQueryFBStore()");

        int g = 1;
        for (; g < intNCap; g++)
        {/*
            // int I = g + 1;


            string ATnamevar = ("User-db-Name-" + g);
            string ATTimevar = ("User-db-Time-" + g);
            LDBNameunloader = PlayerPrefs.GetString(ATnamevar);
            LDBTimeunloader = PlayerPrefs.GetString(ATTimevar);





            fbStore.fbTagScreenName = LDBNameunloader;
            fbAuth.time = LDBTimeunloader;
            fbAuth.SaveDataButton();

            Debug.Log(ATnamevar + (" ") + "Sync");


            Debug.Log("done");*/
        }

        

        foreach (string s in Sync_AS_LDBList)
        {

            fbStore.fbTagScreenName = s;
            if (s == "")
            {
                fbStore.fbTagScreenName = "bad Read";
            }
           
            fbAuth.time = PlayerPrefs.GetString("LDB_UTT_" + s);
            fbAuth.SaveDataButton();


        }




       // g = 1;
        Debug.Log("nothing left to sync");

        ClearRTLDB();
        //ClearAS_LDBListPP();
        //PlayerPrefs.SetInt("LDBTagIDlistNubpp", 0);
        Clear_Sync_AS_LDBList();


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







    // Offline mode
    //this for all the thing to play off line
    public void LBDDownloadDiverter()
    {
        Debug.Log("LBDDownloadDiverter()");
        if (ATSbool == true)
        {
            Debug.Log("Diverter to ATS-LDBS");

           fbStore.GTDocName = DynNameToDownload;
            callFromATS_LDB = true;
         
            
            LDB_GT_getter_Name = fbStore.GTDocName;
           GT_ListNameList.Add(fbStore.GTDocName);
            fbAuth.GT_LDB = true;
            
            fbStore.GetGroupTagsTaskDataToList();
            //GT checker
            //SaveDyn_LDB_GT_listpp();




/*

           
ok what i need 
 1group tag list 
2 sperated 
3 auth tag

*/





            //this is the next flow
            //fbStore.DownLoad_LDB_GT_List();
            //fbAuth.GetTaskAuthchecker();
            // fbAuth.GTchecker();




            // Foreach_GroupTagList__TO__AS_LDBList();
            //DownLoadSelectedAStoLDBS();

        }

        else if (ASbool == true)
        {
            Debug.Log("Diverter to AS-LDBS");
            AS_LDBList.Add(DynNameToDownload);
              





            //     DownLoadSelectedAStoLDBS();
        }

        else if (ABbool == true)
        {
            Debug.Log("Diverter to AB-LDBS");


        }

        else if (RCSbool == true)
        {
            Debug.Log("Diverter to RCS-LDBS");


        }
        else
        {
            Debug.Log("yo man your missing *__S lest see what your printing " + DynNameToDownload + "that might be why");
        }

        Debug.Log("clear bools");
        ATSbool = false;
        ASbool = false;
        RCSbool = false;
        ABbool = false;
    }
   
    
    // LDB_MegaList.Add(("*ATS|") + s);
    
    public void Foreach_GroupTagList__TO__AS_LDBList()
    {
        bool b = false;
       int i = 0;
        foreach (string s in fbStore.GroupTagList)
        {

        

           // LDB_MegaList.Add(("(AS)") + s);
            
            AS_LDBList.Add(s);
            if (b == false)
            {
                b = true;
            }

        }


        if (b == true)
        {
            saveMegalistpp();
            DownLoadSelectedAStoLDBS();

            b = false;
        }
        else
        {
            Debug.Log("nothing in GroupTagList. sorry Bro :(");
        }


        foreach (string s in fbStore.GroupTagTimeList)
        {
            PlayerPrefs.SetString("LDB_GT_" + fbStore.GTDocName, s);
            LDB_UTT_Nubpp = LDB_UTT_Nubpp + 1;
            PlayerPrefs.SetInt("LDB_UTT_Nubpp" + LDB_GT_getter_Name, LDB_UTT_Nubpp);
            ATS_LDB_TimesList.Add(s);
            if (b == false)
            {
                b = true;
            }
            // save to PP ATS_LDB_TimesList then on start Pop PP ATS_LDB_TimesList
        }


        if (b == true)
        {
            // DownLoadSelectedAStoLDBS();
            b = false;
        }
        else
        {
            Debug.Log("nothing in GroupTagList. sorry Bro :(");
        }


    }


 

    //LDB_GT_checkeer
    //Local Data Base checker

    public void LDB_GTchecker()
        {
       
            Debug.Log("Divered to to main on line GTchecker");
            testLockAndKey.Testkey = 0;
        int o = 1;
        foreach (string s in AS_LDBList)

        {

            testLockAndKey.tasktimeLock =  PlayerPrefs.GetString("LDB_GT_" + LDB_GT_getter_Name + o); 
            testLockAndKey.userTaskTime = PlayerPrefs.GetString("LDB_UTT_" + s);
           // PlayerPrefs.SetString("LDB_UTT_" + s,);


            if (testLockAndKey.userTaskTime == "")
            {
                testLockAndKey.userTaskTime = ("0");
                testLockAndKey.UnlockTask();
            }
            else
            {
               
                testLockAndKey.UnlockTask();
            }
            
            

            // testLockAndKey.DynLock();
            //testLockAndKey.tagtime
            //testLockAndKey.DynPin

            o++;
        }




        Debug.Log(("Testkey") + testLockAndKey.Testkey);
        Debug.Log(("GTlistCount") + fbStore.GroupTagList.Count);
        Debug.Log("Lock is");


        if (testLockAndKey.Testkey == fbStore.GroupTagList.Count)
        {
            Debug.Log("unlocked you still need to add the sycn LDB thing ");

           // fbStore.GetUlockedTagsData();
        }
        else
        {
            Debug.Log("locked");
        }
     
           screenController.EndofATLSC_LDB();
    }






    //RT_LDB
    //Real time Local Data Base
    // like the Real time db but  local 
    public void DLCtoRTLDBSetter()
    {
        Debug.Log("DLCtoRTLDBSetter()");
        Debug.Log("pp set for sync" + fbAuth.time + fbStore.fbTagScreenName);

     
        string n = nextsNumberLocalStore.ToString();
       

        string nameSn = ("User-db-Name-" + n);
        string TimeSn = ("User-db-Time-" + n);

        Debug.Log(nameSn + ("  ") + TimeSn);

        fbAuth.setSystemTime();
        PlayerPrefs.SetString(nameSn, (fbStore.fbTagScreenName));
        PlayerPrefs.SetString(TimeSn, (fbAuth.time));

       
        PlayerPrefs.SetString("LDB_UTT_" + fbStore.fbTagScreenName , fbAuth.time);

        

        Debug.Log(nextsNumberLocalStore + "  has been Saved");
        nextsNumberLocalStore = nextsNumberLocalStore + 1;
        intNCap = intNCap + 1;
        setLDBprefs();
        PlayerPrefs.SetInt(("intOffLineN"), (nextsNumberLocalStore));
        Debug.Log(nextsNumberLocalStore + "  has been set");

        Sync_AS_LDBList.Add(fbStore.fbTagScreenName);
        int i  = PlayerPrefs.GetInt("Sync_AS_num_PP");
     
        
        i = i + 1;
        PlayerPrefs.SetString("Sync_AS_LDBListPP_" + i ,fbStore.fbTagScreenName);
        
           
        PlayerPrefs.SetInt("Sync_AS_num_PP", i );
       



        if (ldbHasDatetoSycn == 0)
        {
            ldbHasDatetoSycn = 1;
            SavePPldbHasDatetoSycn();
        }


    }
   
   
    
    public void saveMegalistpp()
    {
       

        Debug.Log("saveLDBTagIDlistpp()");
        foreach (string s in LDB_MegaList)
        {
            PlayerPrefs.SetString("MegaListPP" + MegaListNumPP, s);
            MegaListNumPP = MegaListNumPP + 1;
            PlayerPrefs.SetInt("MegaListNumPP", MegaListNumPP);
        }

    }
    public void LoadMegaListNumPP()
    {
        Debug.Log("LoadLDBTagIDlistpp()");
        MegaListNumPP = PlayerPrefs.GetInt("MegaListNumPP");
        int o = 2;
        while (o < MegaListNumPP)
        {
            string l = PlayerPrefs.GetString("MegaListPP" + o);
            LDB_MegaList.Add(l);
            o = o + 1;
            Debug.Log("added" + l);
        }
        Debug.Log("LDB_MegaList Loaded");

    }

    public void Load_Sync_AS_LDBList_nums()
    {
        
    }



    public void Load_Sync_AS_LDBList()
    {
        int i = PlayerPrefs.GetInt("Sync_AS_num_PP");
        for (int j = 0; j < i;)
        {
            j++;
            string o = PlayerPrefs.GetString("Sync_AS_LDBListPP_" + j);
            Sync_AS_LDBList.Add(o);
        }
    }

    public void Clear_Sync_AS_LDBList()
    {
        int i = PlayerPrefs.GetInt("Sync_AS_num_PP");
        for (int j = 0; j < i; j++)
        {
            PlayerPrefs.SetString("Sync_AS_LDBListPP_" + i , null);
            
        } 
        Sync_AS_LDBList.Clear();
        PlayerPrefs.SetInt("Sync_AS_num_PP", 0);
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

    //ATS_LDB---------------------------------------
    //Adventure Task screen _ Local Data Base


    



    public void thisCanBeDeleted()
    {
        //see nothing in here
    }




    //Dyn GT list 
    //Dyn amic Group Tag list 

    public void Dyn_LDB_GT_listSperater()
    {

        int i = 0;
        foreach (string j in fbStore.Dyn_LDB_GT_list)
        {



            Debug.Log(("j") + j);

            Debug.Log(("i-") + i);
/*
            if (i <= 0)
            {
                Debug.Log("yo im Triped and i add " + j + (" too the list"));
                fbStore.NameofGroupTagList.Add(j);

            }
            */
           
            
                Debug.Log("yo me too ");
                if (i % 2 == 0)
                {
                    Debug.Log(("Even-i-") + i);
                    //Evens
                    Debug.Log(("Adding  ") + j + ("  GroupTagTimeList"));
                    fbStore.GroupTagTimeList.Add(j);
                }


                if (i % 2 != 0)
                {

                    Debug.Log(("Odd-i-") + i);
                    //Odds
                    Debug.Log(("Adding  ") + j + (" GroupTagList"));
                    fbStore.GroupTagList.Add(j);




                }




            


            i = i + 1;
            Debug.Log("just changed i too  " + i);



        }




    }

    public void SaveDyn_LDB_GT_listpp()
    {
     
        //fbStore.Dyn_LDB_GT_list
        Debug.Log("SaveDyn_LDB_GT_listpp()");
        int o = 1;
        foreach (string s in fbStore.GroupTagTimeList)
        {
            PlayerPrefs.SetString("LDB_GT_" + fbStore.GTDocName + o, s );
           

            o++;
           
            
           LDB_GT_Nubpp = LDB_GT_Nubpp + 1;
            PlayerPrefs.SetInt("LDB_GT_Nubpp" + fbStore.GTDocName, LDB_GT_Nubpp);

           
        }
      
    }

    public void LoadDyn_LDB_GT_listpp()
    {
        Debug.Log("LoadDyn_LDB_GT_listpp()");
        saveLDB_GT_Nubpp = PlayerPrefs.GetInt("LDB_GT_Nubpp"+ LDB_GT_getter_Name);
        int o = 1;
        while (o < saveLDB_GT_Nubpp)
        {
            string l = PlayerPrefs.GetString("LDB_GT_" + LDB_GT_getter_Name + o);
            fbStore.Dyn_LDB_GT_list.Add(l);
            o = o + 1;
            Debug.Log("added" + l);
        }
        Debug.Log("done and Loaded");

    }

   

    // LDB_UTTpp
    public void SaveDyn_LDB_UserTaskTime_Listpp()
    {
        LDB_UTT_Nubpp = 0;
       
        Debug.Log("SaveDyn_LDB_UserTaskTime_Listpp()");

       foreach (string s in Dyn_LDB_UserTaskTime_List)
        //    for (int i = 0; i == fbAuth.taskUserDataLoopInt; i++)
            {

            PlayerPrefs.SetString("AS_LDBListPP" + AS_LDBListNumPP, AS_LDBList[0]);

            

            PlayerPrefs.SetString("LDB_UTT_"  + AS_LDBList[LDB_UTT_Nubpp], s);
            LDB_UTT_Nubpp = LDB_UTT_Nubpp + 1;
            PlayerPrefs.SetInt("LDB_UTT_Nubpp" + LDB_GT_getter_Name, LDB_UTT_Nubpp);
           
//+ AS_LDBList[LDB_UTT_Nubpp]

        }

    }
    public void LoadDyn_LDB_UserTaskTime_Listpp()
    {
           if (AS_LDBList.Count != 0)
        {
 Debug.Log("LoadDyn_LDB_GT_listpp()");
            LDB_UTT_Nubpp = PlayerPrefs.GetInt("LDB_UTT_Nubpp" + LDB_GT_getter_Name);
            int o = 0;
            Dyn_LDB_UserTaskTime_List.Clear();
            while (o < 2 - LDB_UTT_Nubpp)
            {
                string Time = PlayerPrefs.GetString("LDB_UTT_" + AS_LDBList[o]);
                Time = Time.Replace("-", "");
                Time = Time.Replace(":", "");
                Time = Time.Replace(" ", "");



               
                Dyn_LDB_UserTaskTime_List.Add(Time);
                o = o + 1;
                Debug.Log("added" + Time);
            }
            Debug.Log("done and Loaded");
        
        }
           
        

    }

   


    // Dyn_LDB_UserTaskTime_List do the same with this ^


    //AS_LDB----------------------------------------------------
    //Adventure screen _ Local Data Base


    public int AS_LDBListMaxint;
    public int intAS_LDBListlooper;



    public void DownLoadSelectedAStoLDBS()
    {
        Debug.Log(" DownLoadSelectedAStoLDBS()");
        AS_LDBListMaxint = AS_LDBList.Count-1;
        screenController.calltoDownload = true;
        AS_LDBListMaxint = AS_LDBListMaxint + 1;
        intAS_LDBListlooper = 0;
             fbAuth.GetTaskAuthchecker();
        Step2DownLoadSelectedAStoLDBS();
       


    }

    public void Step2DownLoadSelectedAStoLDBS()
    {
        Debug.Log(" Step2DownLoadSelectedAStoLDBS()");

       
        if (intAS_LDBListlooper <=  AS_LDBListMaxint)
        {
            LDBName = AS_LDBList[intAS_LDBListlooper];
            fbStore.ASGetDataForLocalDBS();
          
        }
        
       else
        {
            Debug.Log("LDBName " + LDBName);
            AS_LDBListMaxint = 0;
            
            saveLDBTagIDlistpp();
            
        }

       

    }

    public int kok = 0;

    public void LDBTagIDlistAddfbStoreVarTagIDASTMP()
    {
        Debug.Log("var boi" + fbStore.VarTagIDASTMP);
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
        intAS_LDBListlooper = intAS_LDBListlooper + 1;

        Step2DownLoadSelectedAStoLDBS();

    }


    public void save1AS_LDBListpp()
    {
        AS_LDBListNumPP = PlayerPrefs.GetInt("LDBTagIDlistNubpp");
        PlayerPrefs.SetString("AS_LDBListPP" + AS_LDBListNumPP, fbStore.fbTagScreenName);
        AS_LDBListNumPP = AS_LDBListNumPP + 1;
        PlayerPrefs.SetInt("LDBTagIDlistNubpp", AS_LDBListNumPP);
       

        if (ldbHasDatetoSycn == 0)
        {
            ldbHasDatetoSycn = 1;
            SavePPldbHasDatetoSycn();
        }



    }
    public void saveAS_LDBListpp()
    {

       
        Debug.Log("saveLDBTagIDlistpp()");
        foreach (string s in AS_LDBList)
        {
            
           PlayerPrefs.SetString("AS_LDBListPP" + AS_LDBListNumPP, s);
            AS_LDBListNumPP = AS_LDBListNumPP + 1;
            PlayerPrefs.SetInt("LDBTagIDlistNubpp", AS_LDBListNumPP);
        }
     
    }

    public void saveLDBTagIDlistpp()
    {
        Debug.Log("saveLDBTagIDlistpp()");
        foreach (string s in LDBTagIDlist)
        {
            PlayerPrefs.SetString("LDBTagIDlistpp" + saveLDBTagIDlistNubpp,s); 
            saveLDBTagIDlistNubpp = saveLDBTagIDlistNubpp + 1;
            PlayerPrefs.SetInt("LDBTagIDlistNubpp", saveLDBTagIDlistNubpp);
        }
       
    }
    //AB_LDB---------------------------------------

    //RCS_LDB------------------------------------------------






    //down load Tag info and store it.
    //this is like the AS fire base store
    // the data base is real just Player Prefs for now this will need to be changed 







    //LDBTagIDlist




    // -------------Local DateBase Queryer or LDBQ----------------------------

    public void AST_LDB_Q()
    {
        
       
        int o = 1;

        foreach (string s in LDBTagIDlist)
        {

            Debug.Log("s" + s + LDBTagIDlist);
            Debug.Log("if ( " + s + " == " + fbStore.fbScannedTagID + " )");
            Debug.Log(o);
            if (s == fbStore.fbScannedTagID)
            {
                Debug.Log("tag found in local db");
                Debug.Log(o);
                offLineQueryATPlace = ("AT-Place-" + o);
                offLineQueryATText = ("AT-Text-" + o);
                offLineQueryATName = ("AT-Name-" + o);
                OffLineATSDataBaseGetter();
                screenController.AS();
                break;
            }


            o = o + 1;


        }


        Debug.Log(" Not in Local DataBase");
       


    }


    //----------AS_LDBQ---------------------------------------------------

    
    public void AS_LDB_Q()
    {
        //IDGetterForAS_LDB_Q();
       // NameGetterForAS_LDB_Q();
        Debug.Log("Getters Done");
        int o = 1;

        foreach (string s in LDBTagIDlist)
        {



            Debug.Log("s" + s + LDBTagIDlist);
            Debug.Log("if ( " + s + " == " + fbStore.fbScannedTagID + " )");
            Debug.Log(o);
            if (s == fbStore.fbScannedTagID)
            {
                Debug.Log("tag found in local db");
                Debug.Log(o);
                offLineQueryATPlace = ("AT-Place-" + o.ToString());
                offLineQueryATText = ("AT-Text-" + o.ToString());
                offLineQueryATName = ("AT-Name-" + o.ToString());


                OffLineATSDataBaseGetter();
               


               
                screenController.AS();
                break;
            }


            o = o + 1;


        }

       // LDBTagIDlist.Remove(fbStore.fbScannedTagID);
        Debug.Log(" Not in Local DataBase");
       


    }

   

    public void LoadLDBTagIDlistpp()
    {
        Debug.Log("LoadLDBTagIDlistpp()");
       
        foreach (string s in AS_LDBList)
        {
            //LDBTagIDlistpp
            
            string l = PlayerPrefs.GetString("LDBTagIDlistpp" + s);
            LDBTagIDlist.Add(l);
        //    Debug.Log("added" + l + " to LDBTaglist");
        }



    }

    public void LoadAS_LDBListPP()
    {
        Debug.Log("LoadAS_LDBListPP()");
        saveLDBTagIDlistNubpp =  PlayerPrefs.GetInt("LDBTagIDlistNubpp");
        int o = 1;
        while (o <= saveLDBTagIDlistNubpp)
        {
            
            string l = PlayerPrefs.GetString("AS_LDBListPP" + o);
            AS_LDBList.Add(l);
            o = o + 1;
            Debug.Log("added" + l);
        }
        Debug.Log("done and Loaded");

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
        // fbStore.fbScannedTagID = (null);
        // fbStore.fbTagScreenName = (null);

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


    //Clear Down Loads 

   public void ClearLDB()
    {
        int n = 1;
        for (; n <= nextsNumberLocalStore; n++)
        {
            Debug.Log("loop" + n);
            string nameSn = ("AT-Name-" + n);
            string placeSn = ("AT-Place-" + n);
            string idSn = ("AT-Tag ID-" + n);
            string testSn = ("AT-Text-" + n);



            Debug.Log(nameSn + placeSn + idSn + testSn);

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
        ClearLDBTagID();
        ClearDyn_LDB_UserTaskTime_Listpp();
        ClearLDBTagIDlistpp();
        ClearMegaListNumPP();
        screenController.ClearLDBImage();


        PlayerPrefs.SetInt("Sync_AS_num_PP" , 0);


    }


    public void ClearLDBTagID()
    {
        foreach (string s in AS_LDBList)
        {
            PlayerPrefs.SetString("LDBTagIDlistpp" + s, null);
        }
    }

    

    public void ClearMdegaListNumPP()

    {



        // foreach (string s in LDB_MegaList)
        for (int i = 0; i >= MegaListNumPP; i++)
        {
            PlayerPrefs.SetString("MegaListPP" + i, null);

        }
        MegaListNumPP = 1;
        PlayerPrefs.SetInt("MegaListNumPP", MegaListNumPP);
        LDB_MegaList.Clear();
        Debug.Log("megalist cleared");
    }

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


    public void ClearDyn_LDB_GT_listpp()
    {
        int o = 1;
        foreach (string s in LDBTagIDlist)
        {
            PlayerPrefs.SetString("LDB_GT_" + LDB_GT_getter_Name + saveLDB_GT_Nubpp, null);
            saveLDB_GT_Nubpp = saveLDB_GT_Nubpp + 1;
            PlayerPrefs.SetInt("LDB_GT_Nubpp" + LDB_GT_getter_Name, saveLDB_GT_Nubpp);
        }
        saveLDB_GT_Nubpp = 1;
        PlayerPrefs.SetInt("LDBTagIDlistNubpp", saveLDB_GT_Nubpp);
        Debug.Log("list cleared");
    }

    public void ClearDyn_LDB_UserTaskTime_Listpp()
    {
        int i2 = AS_LDBList.Count - 1;
        int o = 0;
        for (int i = 0; i <= i2; i++)
        {

            PlayerPrefs.SetString("LDB_UTT_" + AS_LDBList[i], null);
        }
        LDB_UTT_Nubpp = 1;
        PlayerPrefs.SetInt("LDB_UTT_Nubpp", LDB_UTT_Nubpp);
        // PlayerPrefs.SetInt("LDB_UTT_Nubpp" + LDB_GT_getter_Name, LDB_UTT_Nubpp);


        Debug.Log("list cleared");
    }

    public void ClearLDBTagIDlistpp()
    {
        int o = 1;
        foreach (string s in LDBTagIDlist)
        {
            PlayerPrefs.SetString("LDBTagIDlistpp" + saveLDBTagIDlistNubpp, null);
            saveLDBTagIDlistNubpp = saveLDBTagIDlistNubpp + 1;
            PlayerPrefs.SetInt("LDBTagIDlistNubpp", saveLDBTagIDlistNubpp);
        }
        saveLDBTagIDlistNubpp = 0;
        PlayerPrefs.SetInt("LDBTagIDlistNubpp", saveLDBTagIDlistNubpp);
        LDBTagIDlist.Clear();
        AS_LDBList.Clear();
        Debug.Log("list cleared");
    }
 public void ClearAS_LDBListPP()
    {
     
        foreach (string s in AS_LDBList)
        {
            PlayerPrefs.SetString("AS_LDBListPP" + AS_LDBListNumPP, null);
            AS_LDBListNumPP = AS_LDBListNumPP + 1;
            PlayerPrefs.SetInt("LDBTagIDlistNubpp", AS_LDBListNumPP);
       
        }

        AS_LDBListNumPP = 1;

        AS_LDBList.Clear();
    }

    public void ClearMegaListNumPP()
    {
        Debug.Log("LoadLDBTagIDlistpp()");
        MegaListNumPP = PlayerPrefs.GetInt("MegaListNumPP");
        int o = 1;
        while (o < MegaListNumPP)
        {
            PlayerPrefs.SetString("MegaListPP" + o, null);
            LDB_MegaList.Clear();
            o = o + 1;

        }
        MegaListNumPP = 1;
        PlayerPrefs.SetInt("MegaListNumPP", MegaListNumPP);


    }
}
