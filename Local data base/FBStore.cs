using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using Firebase.Extensions;
using UnityEngine.UI;
using TMPro;
using DigitsNFCToolkit.Samples;
using System;
using Firebase.Database;
using Query = Firebase.Firestore.Query;
using System.Threading;


public class FBStore : MonoBehaviour
{

    

    public string fbScannedTagID;
    public string fbTagScreenName;


    public NFC_Scanner readScreenControl;
    public FBStorage fbStorage;
   // public ReadScreenControl readScreenControl;
    public ScreenController screenController;
    public FBAuth fbAuth;
    public TestLockAndKey testLockAndKey;
    public OffLineLocalDataBase offLineLocalDataBase;



    FirebaseFirestore db;
    public string varfbScannedTagID;

    public string F;

    // AS
    public TextMeshProUGUI PlaceASTMP;
    public TextMeshProUGUI TextASTMP;
    public string VarTextASTMP;
    public string VarPlaceASTMP;
    public string VarTagIDASTMP;
    public string TestBoi = ("adfas;lkdfj;a");

    public TMP_InputField ASEscanTagID;

    //RCSE
    public TMP_InputField RCSEscanTagID;


    //RCS
    public TextMeshProUGUI PlaceTMP;
    public TextMeshProUGUI AreaTMP;
    public TextMeshProUGUI RouteTMP;
    public TextMeshProUGUI DifficultyTMP;
    public TextMeshProUGUI TypeTMP;
    public TextMeshProUGUI TagIDTMP;
    public string VarNameTMP;
    public string VarPlaceTMP;
    public string VarAreaTMP;
    public string VarRouteTMP;
    public string VarDifficultyTMP;
    public string VarTypeTMP;
    public string VarTagIDTMP;



    //Group Tags
    public string nameofTagGroup;
    public string GTDocName;
    public string LastGT_For_ATS;

    public string downLoadedPinNamefromfbStore1;
    public string downLoadedPinNamefromfbStore2;
    public string downLoadedPinNamefromfbStore3;

    public string aTagUnlocked;

    public List<string> NameofGroupTagList = new List<String>();
    public List<string> GroupTagList = new List<String>();
    public List<string> GroupTagTimeList = new List<String>();

    public List<string> 
        Dyn_LDB_GT_list = new List<String>();

   

    //AB Adventer Board
    public string ABDocName;

    //Adventures
    public string onLineAllGood;

    public string adventureQued;

    public string VarAdventureName1ABTMP;
  

    public string VarInfoABTMP;
    

    public TextMeshProUGUI AdventureNameABTMP;
    public TextMeshProUGUI InfoABTMP;
   
    //ASA

    
    public TextMeshProUGUI Task1butTMP;
   
    /*
      public TextMeshProUGUI abButton1;
      public TextMeshProUGUI abButton2;
      public TextMeshProUGUI abButton3;
      public TextMeshProUGUI abButton4;
    */
   

    //  public List<TextMeshProUGUI> abButtonsTMPList = new List<TextMeshProUGUI>();
    public List<String> abButtonsList = new List<String>();
    public List<String> CategoryButtonsList = new List<String>();

    //task
    public string downLoadedCompeledTask1NamefbStore;
    public string downLoadedCompeledTask2NamefbStore;
    public string downLoadedCompeledTask3NamefbStore;
    public string downLoadedCompeledTask4NamefbStore;

    public string downLoadedCompeledTask1TimefbStore;
    public string downLoadedCompeledTask2TimefbStore;
    public string downLoadedCompeledTask3TimefbStore;
    public string downLoadedCompeledTask4TimefbStore;

    public List<string> TaskInfoList = new List<String>();
    public List<string> TaskNameList = new List<String>();
    public List<string> GroupTagTaskGroupList = new List<String>();
    public List<string> GroupTag_Key_Value_List;

    //ABS
    public int adventureIntList;



    public object Button1 { get; set; }




    public void findingfbTagNameWithTagID()
    {
        Debug.Log("findingfbTagNameWithTagID()");
        // readScreenControl.Gbug.text = ("\n") + readScreenControl.Gbug.text + ("findingfbTagNameWithTagID()");
        fbScannedTagID = readScreenControl.scanedTagID;


        liamsQueryFBStore();

    }

    ABbutton abbutton;



    private void Start()
    {

        Firebase.FirebaseApp.Create();
        db = FirebaseFirestore.DefaultInstance;
        RCSEscanTagID.text = fbScannedTagID;
        ASEscanTagID.text = fbScannedTagID;
       
        BoiTESTER();
    }

    public void BoiTESTER()
    {
       
      for(int i = 1; i <= 10; i++)
       {
          
       }
       

    }




    public void FBIDSetter(string s)
    {
        varfbScannedTagID = s;

    }
    public void DeBugQureyButton()
    {
        fbScannedTagID = varfbScannedTagID;

        GAAPPQureyStarter();
    }




    public void GAAPPQureyStarter()
    {
        
        ASQueryFBStore();

    }

    //AS
    public void inputfildPlaceAS(string s)
    {
        VarPlaceASTMP = s;
    }

    public void inputfildTextAS(string s)
    {
        VarTextASTMP = s;
    }



    //RCS
    public void inputfildName(string s)
    {
        VarNameTMP = s;
        // Debug.Log(s);

    }
    public void inputfildPlace(string s)
    {
        VarPlaceTMP = s;
        // Debug.Log(s);

    }
    public void inputfildArea(string s)
    {
        VarAreaTMP = s;
        // Debug.Log(s);

    }
    public void inputfildRoute(string s)
    {
        VarRouteTMP = s;
        // Debug.Log(s);

    }
    public void inputfildDifficulty(string s)
    {
        VarDifficultyTMP = s;
        //Debug.Log(s);

    }

    public void inputfildType(string s)
    {
        VarTypeTMP = s;
        //Debug.Log(s);

    }
    public void inputfildTagID(string s)
    {
        VarTagIDTMP = s;
        //Debug.Log(s);

    }
    public void inputfildsacnnedTagID(string s)
    {
        VarTagIDTMP = s;
        // Debug.Log(s);

    }



    //queryFBStore EXample
    public void queryFBStore()
    {

        Debug.Log("QueryFBStore()");

        CollectionReference citiesRef = db.Collection("cities");
        Query query = citiesRef.WhereEqualTo("tagID", "21500000");
        query.GetSnapshotAsync().ContinueWithOnMainThread((querySnapshotTask) =>
        {
            Debug.Log("QueryFBStore()");
            foreach (DocumentSnapshot documentSnapshot in querySnapshotTask.Result.Documents)
            {
                Debug.Log("QueryFBStore()");
                Debug.Log(string.Format("Document {0} returned by query tagID=21500000", documentSnapshot.Id));
            }
        });
    }

    public void liamsQueryFBStore()
    {
        Debug.Log("liamsQueryFBStore()");

        Debug.Log(fbScannedTagID);

        CollectionReference citiesRef = db.Collection("Tag Info");
        Query query = citiesRef.WhereEqualTo("Tag ID", fbScannedTagID);
        query.GetSnapshotAsync().ContinueWithOnMainThread((querySnapshotTask) =>
        {

            foreach (DocumentSnapshot documentSnapshot in querySnapshotTask.Result.Documents)
            {
                fbTagScreenName = (string.Format(documentSnapshot.Id));
                Debug.Log(fbTagScreenName);
                Debug.Log(string.Format("Document {0} returned by query Tag ID=" + fbScannedTagID, documentSnapshot.Id));

            }






            //  Debug.Log("test");


            fbStorage.fbTagScreenNameFordonwloadScreenFab();




        });


    }






    //RCS things---------------------------
    public void RCSQueryFBStore()

    {
        Debug.Log("RCSQueryFBStore()");

        Debug.Log(fbScannedTagID);

        CollectionReference citiesRef = db.Collection("Rock Climbing Info");
        Query query = citiesRef.WhereEqualTo("Tag ID", fbScannedTagID);
        query.GetSnapshotAsync().ContinueWithOnMainThread((querySnapshotTask) =>
        {

            foreach (DocumentSnapshot documentSnapshot in querySnapshotTask.Result.Documents)
            {
                fbTagScreenName = (string.Format(documentSnapshot.Id));
                Debug.Log(fbTagScreenName);


            }

            //use fbTagScreenName witch = RCI docs /aka theB to find the Route and Type strings 

            RCSGetData();



            // Debug.Log(screenController.activeScreen);

            screenController.RCS_UI();


            Debug.Log("Done");
            fbScannedTagID = ("");


        });


    }

    public void RCSGetData()
    {


        db.Collection("Rock Climbing Info").Document(fbTagScreenName).GetSnapshotAsync().ContinueWithOnMainThread(task =>
    {
        RCSname rcsname = task.Result.ConvertTo<RCSname>();

        VarPlaceTMP = rcsname.Place.ToString();
        VarAreaTMP = rcsname.Area.ToString();
        VarRouteTMP = rcsname.Route.ToString();
        VarDifficultyTMP = rcsname.Difficulty.ToString();
        VarTypeTMP = rcsname.Type.ToString();
        VarNameTMP = rcsname.Name.ToString();


        Debug.Log(VarPlaceTMP + ("\n") + VarRouteTMP + ("\n") + VarTypeTMP);
        RCSTMPfild();

        screenController.activeScreen = ("RCS");
        screenController.updateActiveScreenToActiveScreenFab();
        screenController.TurnOffAllScreensButOne();
        fbScannedTagID = ("ClearedScreen");


    });

    }

    public void RCSTMPfild()
    {
        Debug.Log("RCSTMPfild()");
        PlaceTMP.GetComponent<TMPro.TextMeshProUGUI>().text = VarPlaceTMP;
        AreaTMP.GetComponent<TMPro.TextMeshProUGUI>().text = VarAreaTMP;
        RouteTMP.GetComponent<TMPro.TextMeshProUGUI>().text = VarRouteTMP;
        DifficultyTMP.GetComponent<TMPro.TextMeshProUGUI>().text = VarDifficultyTMP;
        TypeTMP.GetComponent<TMPro.TextMeshProUGUI>().text = VarTypeTMP;
        TagIDTMP.GetComponent<TMPro.TextMeshProUGUI>().text = VarTagIDTMP;

    }


    public void uploadFBstoreTagInfo()
    {
        CollectionReference citiesRef = db.Collection("Rock Climbing Info");
        citiesRef.Document(VarNameTMP).SetAsync(new Dictionary<string, object>(){
              { "Place", VarPlaceTMP },
              { "Area", VarAreaTMP },
              { "Route", VarRouteTMP },
              { "Difficulty", VarDifficultyTMP },
              { "Type",  VarTypeTMP  },
              { "Tag ID", VarTagIDTMP },

           });

        Debug.Log("creataed climb route");
    }


    //AS things -------------------------
    public void ASConSatCheeker()
    {
       fbAuth.StartConnectionStatuschecker();
    }


    public void ASQueryFBStore()

    {
        Debug.Log("ASQueryFBStore()");

        Debug.Log(fbScannedTagID);


        CollectionReference citiesRef = db.Collection("Adventure Tags");
        Query query = citiesRef.WhereEqualTo("TagID", fbScannedTagID);
        query.GetSnapshotAsync().ContinueWithOnMainThread((querySnapshotTask) =>
        {
            foreach (DocumentSnapshot documentSnapshot in querySnapshotTask.Result.Documents)
            {
                F = (string.Format(documentSnapshot.Id));
                Debug.Log("fbTagScreenName" + fbTagScreenName);
                Debug.Log(F);
                fbTagScreenName = F;

                fbScannedTagID = "";
            }



            //use fbTagScreenName witch = RCI docs /aka theB to find the Route and Type strings 
            ASGetData();
            // Debug.Log(screenController.activeScreen);



            Debug.Log("Done");
           
            if (offLineLocalDataBase.userDisplayName == (""))
            {
                fbAuth.setSystemTime();
             // string  UTT = fbAuth.time.Replace(@"-", @"").Replace(@":", @"").Replace(@" ", @"");
                PlayerPrefs.SetString("LDB_UTT_" + F, fbAuth.time);
                offLineLocalDataBase.AS_LDBList.Add(F);
                offLineLocalDataBase.save1AS_LDBListpp();
            }
            else
            {
                fbAuth.setSystemTime();
                fbAuth.SaveDataButton();

            }
               




        });


    }

    public void ASGetData()
    {


        db.Collection("Adventure Tags").Document(fbTagScreenName).GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            ASName ASname = task.Result.ConvertTo<ASName>();

            VarPlaceASTMP = ASname.Place.ToString();
            VarTextASTMP = ASname.Text.ToString();


 

            ASTMPfild();

            screenController.activeScreen = ("AS");
            screenController.updateActiveScreenToActiveScreenFab();
            screenController.TurnOffAllScreensButOne();
            fbScannedTagID = ("ClearedScreen");


        });

    }

    public void ASuploadFBstoreTagInfo()
    {
        CollectionReference citiesRef = db.Collection("Adventure Tags");
        citiesRef.Document(VarPlaceASTMP).SetAsync(new Dictionary<string, object>(){
              { "Place", VarPlaceASTMP },
              { "Text", VarTextASTMP },
               { "Tag ID", VarTagIDTMP },

           });

        Debug.Log("creataed AvTag");
    }


    public void ASTMPfild()
    {
        Debug.Log("ASTMPfild()");
        PlaceASTMP.GetComponent<TMPro.TextMeshProUGUI>().text = VarPlaceASTMP;
        TextASTMP.GetComponent<TMPro.TextMeshProUGUI>().text = VarTextASTMP;


    }



    //AS-LDB-S
    //Adventure screen getting from FB.store and set to Local Data Base

    public  void ASGetDataForLocalDBS()
    {
        Debug.Log("ASGetDataForLocalDBS()");
        Debug.Log("offLineLocalDataBase.LDBName__"+ offLineLocalDataBase.LDBName);


         db.Collection("Adventure Tags").Document(offLineLocalDataBase.LDBName).GetSnapshotAsync().ContinueWithOnMainThread(task =>
{
    if (task.Result.Exists)
    {
        ASName ASname = task.Result.ConvertTo<ASName>();

        VarPlaceASTMP = ASname.Place.ToString();
        Debug.Log(("vars-") + VarPlaceASTMP + VarTextASTMP + VarTagIDASTMP);
        VarTextASTMP = ASname.Text.ToString();
        Debug.Log(("vars-") + VarPlaceASTMP + VarTextASTMP + VarTagIDASTMP);
        VarTagIDASTMP = ASname.TagID.ToString();


        offLineLocalDataBase.LDBTagIDlistAddfbStoreVarTagIDASTMP();
    }
    else
    {
        offLineLocalDataBase.intAS_LDBListlooper = offLineLocalDataBase.intAS_LDBListlooper + 1;
        offLineLocalDataBase.Step2DownLoadSelectedAStoLDBS();
    }
   
});

        



    }







    //ATS-LDB-S
    //Adventure task screen getting from FB.store and set to Local Data Base
    // this will be used to find many AS and...
    public async void ATSGetDataForLocalDBS()
    {
        Debug.Log("ASTGetDataForLocalDBS()");
       


        await db.Collection("Adventure Tags").Document(offLineLocalDataBase.LDBName).GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {


            ASName ASname = task.Result.ConvertTo<ASName>();

            VarPlaceASTMP = ASname.Place.ToString();
           
            VarTextASTMP = ASname.Text.ToString();
           
            VarTagIDASTMP = ASname.TagID.ToString();


            Debug.Log(("vars-") + VarPlaceASTMP + VarTextASTMP + VarTagIDASTMP);



        });





    }

    string GT_List_for_task;
    public void ATSAGetDataToList()
    {
        Debug.Log("ATSAGetDataToList()");




        DocumentReference docRef = db.Collection("Adventures").Document(nameofTagGroup);
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            int i = 1;
            DocumentSnapshot snapshot = task.Result;
            if (snapshot.Exists)
            {

                if (offLineLocalDataBase.callFromATS_LDB == true)
                {
                    //offLineLocalDataBase.LDB_MegaList.Add(("*ATS|") + nameofTagGroup);
                }

                    



                Dictionary<string, object> GroupTagInfoSanp = snapshot.ToDictionary();



                foreach (KeyValuePair<string, object> pair in GroupTagInfoSanp)
                {

                    string k = (pair.Key).ToString();
                    Int64 K = Int64.Parse(k);
                    string V = (pair.Value).ToString();
                    
                   

                    Debug.Log("yo me too ");
                        if (K % 2 == 0)
                        {
                            if (offLineLocalDataBase.callFromATS_LDB == true)
                            {
                                PlayerPrefs.SetString("Task_Infopp_" + K, V);
                            }
                            else
                            {
                                Debug.Log(("Even-K-") + K);
                                //Evens
                                Debug.Log(("Adding  ") + V + ("  task info list "));
                                TaskInfoList.Add(V);

                            }

                        }


                        if (K % 2 != 0)
                        {
                            if (offLineLocalDataBase.callFromATS_LDB == true)
                            {
                                PlayerPrefs.SetString("Task_Namepp_" + K, V);
                            }
                            else
                            {
                                Debug.Log(("Odd-i-") + K);
                                //Odds
                                Debug.Log(("Adding  ") + V + ("  TaskNameList"));
                                TaskNameList.Add(V);
                            }


                        }


                }

                //screenController.ATSTrigerInstantButtons();
                fbAuth.GetTaskAuthchecker(); 
                
            }

            else
            {
                Debug.Log(String.Format("Document {0} does not exist!", snapshot.Id));
            }

        });

        offLineLocalDataBase.callFromATS_LDB = false;

    }
    


    public void GetATSButtonData()
    {
        Debug.Log("GetATSButtonData()");


        Debug.Log("adventureIntList" + adventureIntList.ToString());

        string s = abButtonsList[adventureIntList].Replace("(ATS)", "");
        s = s.Replace("(AS)", "");
        s = s.Replace("(ABS)", "");
        s = s.Replace("(RCS)", "");

        Debug.Log(("adventureQued") + s);
        adventureQued = s;
        screenController.ATSTrigerInstantButtons();
        //ATSGetData();




    }
    
         public void ATSgetInfoNMainName()
    {
        VarAdventureName1ABTMP = TaskNameList[0];
        VarInfoABTMP = TaskInfoList[0];
    }
    public void ATSGetData()
    {
        Debug.Log("ATSGetData()");
        VarAdventureName1ABTMP = TaskNameList[screenController.ATSintButtonIterationCount];

        VarInfoABTMP = TaskInfoList[screenController.ATSintButtonIterationCount];




        /*



        db.Collection("Adventures").Document(adventureQued).GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            ASName ASname = task.Result.ConvertTo<ASName>();

            VarAdventureName1ABTMP = ASname.AdventureName.ToString();
            Debug.Log(("var A Name") + ("  ") + VarAdventureName1ABTMP);
            VarInfoABTMP = ASname.Info.ToString();
            VarTask1ABTMP = ASname.Task1.ToString();
            VarTask1InfoABTMP = ASname.Task1Info.ToString();
            VarTask2ABTMP = ASname.Task2.ToString();
            VarTask2InfoABTMP = ASname.Task2Info.ToString();
            VarTask3ABTMP = ASname.Task3.ToString();
            VarTask3InfoABTMP = ASname.Task3Info.ToString();
            VarTask4ABTMP = ASname.Task4.ToString();
            VarTask4InfoABTMP = ASname.Task4Info.ToString();

            ABTMPfild();

        });
        */

    }
    /*
    public void ABuploadFBstoreTagInfo()
    {
        CollectionReference citiesRef = db.Collection("Adventure Tags");
        citiesRef.Document(VarPlaceASTMP).SetAsync(new Dictionary<string, object>(){
              { "Place", VarPlaceASTMP },
              { "Text", VarTextASTMP },
               { "Tag ID", VarTagIDTMP },

           });

        Debug.Log("creataed AvTag");
    }

*/


    //AB----------------------------------

    public void popdatatest()
    {
        Debug.Log("pop stared");
        CollectionReference citiesRef = db.Collection("cities");
        citiesRef.Document("SF").SetAsync(new Dictionary<string, object>(){
        { "Name", "San Francisco" },
        { "State", "CA" },
        { "Country", "USA" },
        { "Capital", false },
        { "Population", 860000 }
    }).ContinueWithOnMainThread(task =>
        citiesRef.Document("LA").SetAsync(new Dictionary<string, object>(){
            { "Name", "Los Angeles" },
            { "State", "CA" },
            { "Country", "USA" },
            { "Capital", false },
            { "Population", 3900000 }
        })
        ).ContinueWithOnMainThread(task =>
            citiesRef.Document("DC").SetAsync(new Dictionary<string, object>(){
            { "Name", "Washington D.C." },
            { "State", null },
            { "Country", "USA" },
            { "Capital", true },
            { "Population", 680000 }
            })
        ).ContinueWithOnMainThread(task =>
            citiesRef.Document("TOK").SetAsync(new Dictionary<string, object>(){
            { "Name", "Tokyo" },
            { "State", null },
            { "Country", "Japan" },
            { "Capital", true },
            { "Population", 9000000 }
            })
        ).ContinueWithOnMainThread(task =>
            citiesRef.Document("BJ").SetAsync(new Dictionary<string, object>(){
            { "Name", "Beijing" },
            { "State", null },
            { "Country", "China" },
            { "Capital", true },
            { "Population", 21500000 }
            })
        );
        Debug.Log("poped");
    }

    
    public void CategoryButtonGetDataToList()
    {
        Debug.Log("CategoryButtonGetDataToList()");

        DocumentReference docRef = db.Collection("Category Buttons").Document("Category Buttons");
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {

            DocumentSnapshot snapshot = task.Result;
            if (snapshot.Exists)
            {
                // Debug.Log(String.Format("Document data for {0} document:", snapshot.Id));
                Dictionary<string, object> buttonSanp = snapshot.ToDictionary();


                CategoryButtonsList.Clear();
                foreach (KeyValuePair<string, object> pair in buttonSanp)
                {


                    String j = (pair.Value).ToString();
                    Debug.Log(("j") + j);
                    Debug.Log(("city") + pair);

                    CategoryButtonsList.Add(j);


                }

                screenController.instantCategoryButtons();

            }


            else
            {
                Debug.Log(String.Format("Document {0} does not exist!", snapshot.Id));
            }

        });
    }






    public void ABAGetDataToList()
    {
        Debug.Log("ABAGetDataToList()");
     
        DocumentReference docRef = db.Collection("Categorized Adventures").Document(ABDocName);
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {

            DocumentSnapshot snapshot = task.Result;
            if (snapshot.Exists)
            {
                // Debug.Log(String.Format("Document data for {0} document:", snapshot.Id));
                Dictionary<string, object> buttonSanp = snapshot.ToDictionary();

                Debug.Log(("Count") +buttonSanp.Count);
                screenController.numberOfButtons = buttonSanp.Count;

                abButtonsList.Clear();
                foreach (KeyValuePair<string, object> pair in buttonSanp)
                {


                    String j = (pair.Value).ToString();
                    Debug.Log(("j")+j);
                    Debug.Log(("city") + pair);

                    abButtonsList.Add(j);


                }

                screenController.ABTrigerInstantButtons();

            }


            else
            {
                Debug.Log(String.Format("Document {0} does not exist!", snapshot.Id));
            }

        });
    }

    public void testBoi()
    {
        /*
        string s = ("Button1");
        Debug.Log("ABAGetDataToList()");
        db.Collection("Categorized Adventures").Document("New").GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {




            string r;

            ABbutton abbutton = task.Result.ConvertTo<ABbutton>();

            VarAdventureName1ABTMP = abbutton.Button1.ToString();

            //f = task.Result.ConvertTo<f>();


            // VarAdventureName1ABTMP = Button1.ToString();

            Debug.Log(Button1);

            foreach (GameObject button in abButtonsList)
            {

                button.GetComponent<TMPro.TextMeshProUGUI>().text = VarAdventureName1ABTMP;
                VarAdventureName1ABTMP = abbutton.Button1.ToString();

            }


                        abButton1.GetComponent<TMPro.TextMeshProUGUI>().text = VarAdventureName1ABTMP;








                        VarAdventureName2ABTMP = abbutton.Button1.ToString();
                        abButton2.GetComponent<TMPro.TextMeshProUGUI>().text = VarAdventureName2ABTMP;

                        VarAdventureName3ABTMP = abbutton.Button1.ToString();
                        abButton3.GetComponent<TMPro.TextMeshProUGUI>().text = VarAdventureName3ABTMP;

                        VarAdventureName4ABTMP = abbutton.Button1.ToString();
                        abButton4.GetComponent<TMPro.TextMeshProUGUI>().text = VarAdventureName4ABTMP;
            

            // VarInfoABTMP = ASname.Info.ToString();



            // InfoABTMP.GetComponent<TMPro.TextMeshProUGUI>().text = VarInfoABTMP;
            Debug.Log("setf");


        });
    */
    }

   
   

   


    public void uploadFB()
    {


    }
    public void GetGroupTagsData()
    {
        Debug.Log("GetGroupTagsData()");









        /*
        db.Collection("Grouped Tags").Document(nameofTagGroup).GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {

            GTName GTname = task.Result.ConvertTo<GTName>();

            downLoadedPinNamefromfbStore1 = GTname.Tag1.ToString();
            downLoadedPinNamefromfbStore2 = GTname.Tag2.ToString();
            downLoadedPinNamefromfbStore3 = GTname.Tag3.ToString();

            testLockAndKey.tag1time = GTname.Tag1Time.ToString();
            testLockAndKey.tag2time = GTname.Tag2Time.ToString();
            testLockAndKey.tag3time = GTname.Tag3Time.ToString();

            Debug.Log("test");


            checkGroupTags();


            fbAuth.GTchecker();



        });

        */

    }

    public void GetUlockedTagsData()
    {
        Debug.Log("GetUlockedTagsData()");


        aTagUnlocked = NameofGroupTagList[0];
        Debug.Log( NameofGroupTagList[0] + " saving to user db");
        fbAuth.saveUnlockedTagToUserAuth();



        /*
                db.Collection("Grouped Tags").Document(nameofTagGroup).GetSnapshotAsync().ContinueWithOnMainThread(task =>
                {

                    GTName GTname = task.Result.ConvertTo<GTName>();

                    aTagUnlocked = GTname.ATagUnlocked.ToString();


                    Debug.Log(aTagUnlocked);

                    fbAuth.saveUnlockedTagToUserAuth();


                });

                */

    }

   public bool CallFrom_GT_UnlockButton = false;
    public void checkGroupTags()
    {
        Debug.Log("checkGroupTags()");
        Debug.Log(downLoadedPinNamefromfbStore1);
        Debug.Log(downLoadedPinNamefromfbStore2);
        Debug.Log(downLoadedPinNamefromfbStore3);
        Debug.Log(testLockAndKey.tag1time);
        Debug.Log(testLockAndKey.tag2time);
        Debug.Log(testLockAndKey.tag3time);
    }

    

        public void run_GTDocName_formUnlockButton()
    {
        GetGroupTagsTaskDataToList();
       
        CallFrom_GT_UnlockButton = true;

      
       
    }

    //this get Date from if you compleded a task and send the name and time
    public void GetGroupTagsTaskDataToList()
    {
        Debug.Log("GetGroupTagsTaskDataToList()");


        //nameofTagGroup

        DocumentReference docRef = db.Collection("Grouped Tags").Document(GTDocName);
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
        // int i = 0;
        DocumentSnapshot snapshot = task.Result;
            if (snapshot.Exists)
            {

                Dictionary<string, object> GroupTagInfoSanp = snapshot.ToDictionary();
                
                    if (callfrom_DupLoop == true)
                {
                    callfrom_DupLoop = false;
                }
                else
                {
                    GroupTagList.Clear();
                    OOO = 0;
                }


                offLineLocalDataBase.Dyn_LDB_UserTaskTime_List.Clear();
                NameofGroupTagList.Clear();
                GroupTagTimeList.Clear();
              


                foreach (KeyValuePair<string, object> pair in GroupTagInfoSanp)
                {

                    string k = (pair.Key).ToString();
                    Int64 K = Int64.Parse(k);
                    string V = (pair.Value).ToString();

                  


                    if (K <= 0)
                    {
                        Debug.Log("yo im Triped and i add " + V + (" too the list"));
                        NameofGroupTagList.Add(V);


                    }

                    if (K > 0)
                    {
                        Debug.Log("yo me too ");
                        if (K % 2 == 0)
                        {
                            Debug.Log(("Even-i-") + K);
                            //Evens
                            Debug.Log(("Adding  ") + V + ("  GroupTagTimeList"));
                            GroupTagTimeList.Add(V);
                        }


                        if (K % 2 != 0)
                        {

                            Debug.Log(("Odd-i-") + K);
                            //Odds
                            Debug.Log(("Adding  ") + V + (" GroupTagList"));
                            GroupTagList.Add(V);


                        }




                    }

                    
                }
            }
            else
            {
                Debug.Log(String.Format("Document {0} does not exist!", snapshot.Id));
            }
               
                if (screenController.callFromATS == true)
                {

                    ATSAGetDataToList();
                }
                if (screenController.callFromTDL == true)
                {
                    screenController.callFromTDL = false;
                    fbAuth.GTchecker();
                }
               

            

          
            IDtoPPLoop();

            

            
        });


       

        /*
        if (offLineLocalDataBase.callFromATS_LDB == true)
        {

            ATSAGetDataToList();
            // it sett this after this ^ is called callFromATS_LDB = false;

            offLineLocalDataBase.Foreach_GroupTagList__TO__AS_LDBList();
            offLineLocalDataBase.callFromATS_LDB = true;
            //      fbAuth.GetTaskAuthchecker();
        }
        */
    }


    public string DupLoop_name ;

    public void notDupLoop()
    {
        if (GroupTagList.Contains(DupLoop_name))
        {

            
            GroupTagList.Remove(DupLoop_name);
            notDupLoop();
        }
        else
        {
            DupLoop_name = "";
        }
       
    }

    public bool GT_inList;
    public int OOO = 0;
    public bool callfrom_DupLoop = false;
   public void IDtoPPLoop()
    {

        string G;

        foreach (string s in GroupTagList)
        {
            GT_inList = s.StartsWith("(GT)");
            if (GT_inList)
            {
                break;
            }
        }



        G =  GroupTagList[OOO];
        bool GT = G.StartsWith("(GT)");
        if (GT)
        {

           
            DupLoop_name = G;
            G = G.Replace("(GT)", "");
            notDupLoop();

            GTDocName = G;
           
            callfrom_DupLoop = true;
            GetGroupTagsTaskDataToList();
          

        }
       
        
        
        
        else
        {

            db.Collection("Adventure Tags").Document(G).GetSnapshotAsync().ContinueWithOnMainThread(task =>
            {

                bool b = task.Result.Exists;

                if (b)
                {

                    ASName ASname = task.Result.ConvertTo<ASName>();
                    string ID = ASname.TagID.ToString();


                    if (OOO <= GroupTagList.Count)
                    {
                        if (offLineLocalDataBase.callFromATS_LDB == true)
                        {
                            offLineLocalDataBase.LDBTagIDlist.Add(ID);
                            PlayerPrefs.SetString("LDBTagIDlistpp" + G, ID);


                            offLineLocalDataBase.AS_LDBListNumPP = PlayerPrefs.GetInt("LDBTagIDlistNubpp");
                            offLineLocalDataBase.AS_LDBListNumPP = offLineLocalDataBase.AS_LDBListNumPP + 1;
                            PlayerPrefs.SetInt("LDBTagIDlistNubpp", offLineLocalDataBase.AS_LDBListNumPP);

                            PlayerPrefs.SetString("AS_LDBListPP" + offLineLocalDataBase.AS_LDBListNumPP, G);



                            offLineLocalDataBase.saveLDBTagIDlistNubpp = PlayerPrefs.GetInt("LDBTagIDlistNubpp");

                        }


                        Debug.Log(offLineLocalDataBase.AS_LDBList);

                        OOO++;
                        IDtoPPLoop();



                    }
                }
                else
                {
                    OOO++;
                    IDtoPPLoop();
                }//3


                

                if (GT_inList)

                {
                    Debug.Log("not done yet run it again");
                }
                else
                {
                    Debug.Log("done with all");
                }

            });//4

            Debug.Log("donewith all");


        } //1 
       
       

    }//2






















    //DownLoad_LDB_GT_List

    public void DownLoad_LDB_GT_List()
    {
        DocumentReference docRef = db.Collection("Grouped Tags").Document(GTDocName);
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            int i = 0;
            DocumentSnapshot snapshot = task.Result;
            if (snapshot.Exists)
            {

                Dictionary<string, object> GroupTagInfoSanp = snapshot.ToDictionary();


                foreach (KeyValuePair<string, object> pair in GroupTagInfoSanp)
                {
                    string j = (pair.Value).ToString();
                    Dyn_LDB_GT_list.Add(j);
                }
                offLineLocalDataBase.SaveDyn_LDB_GT_listpp();
            }
        });
    }

   






    public void FakeIDTestNFCTagRead()
    {
        readScreenControl.scanedTagID = varfbScannedTagID;
        TestNFCTagRead();
    }


    public void TestNFCTagRead()
    {
        Debug.Log("TestNFCTagRead()");
        Debug.Log("scanedTagID:_" + readScreenControl.scanedTagID);
        fbScannedTagID = readScreenControl.scanedTagID;
        //Invoke("ASConSatCheeker", 1f);
       
            offLineLocalDataBase.ConnectionStatusDiverter();
        
    }









}

