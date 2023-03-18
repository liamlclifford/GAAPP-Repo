using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using Firebase.Storage;
using Firebase.Extensions;
using System;


public class ScreenController : MonoBehaviour
{

    public GameObject sceneManagerObj;

    public OffLineLocalDataBase offLineLocalDataBase;
    public FBStore fbStore;
    public TestLockAndKey testLockAndKey;
    public ABbutton abButton;
    public FBAuth fbAuth;
    public FBStorage fbStorage;



    public string urlGATPage;

    public int screenInt;
    public string activeScreen;
    public GameObject gamescreen;
    public GameObject inputField;
    public GameObject editerUI;
    public GameObject Livescreen;
    public GameObject Test_GT_Button_Lock;





    public TextMeshProUGUI input_tag_id;
    public string VarTagID;
    //GT
    public bool callFromTDL = false;

    //tasks
    public bool callFromATS = false;
    public bool calltoDownload = false;
    public string task1lock;
    public bool tasklock = false;

    public GameObject ATSContener;
    public GameObject GOTB;
    public int ATSintButtonIterationCount;
    public string ATSNameOfButtonClicked;

    //AB button
    public string abNameOfButtonClicked;
    public GameObject GOB;
    public GameObject ABConten;
    public int numberOfButtons;

    public int intButtonIterationCount;

    //Category Button
    public GameObject GOCB;
    public GameObject CategoryConten;



    public GameObject activeScreenFab;


    public static List<GameObject> gamescreenChild = new List<GameObject>();
    private GameObject livescreen;



    public RawImage rawImage;
    public RawImage rawImage2;
    public Sprite sprite2;

    FirebaseStorage storage;


    public GameObject GOB_LDB;





    List<string> shopingList;

    public void Start()
    {

        gamescreen = GameObject.Find("gamescreen");
        activeScreenFab = gamescreen.transform.Find(activeScreen).gameObject;
        FindAllScreensUnderGamescreen();
        storage = FirebaseStorage.DefaultInstance;

       
    }




    private void testingMethud()
    {


        int num = 1;
        while (num <= 5)
        {
            Debug.Log(num);
            num++;
        }

        for (int i = 1; i <= 5; i++)
        {
            Debug.Log(i);
        }


        shopingList = new List<string>() { ("eggs"), ("ham"), ("chesse"), ("bakecon") };

        foreach (string i in shopingList)
        {
            Debug.Log(i);
        }


    }






    public void inputfildstring(string s)
    {
        activeScreen = s;
        Debug.Log(s);
        updateActiveScreenToActiveScreenFab();


    }



    public void debugNavEditer()
    {
        editerUI.SetActive(true);
    }

    public void debugNavEditerOFF()
    {
        editerUI.SetActive(false);
       
    }
    public void Livescreenon()
    {
        Livescreen.SetActive(true);
    }
    public void changeLoginScreen()
    {
        Debug.Log("changeLoginScreen()");
        activeScreen = ("Login_UI");
        updateActiveScreenToActiveScreenFab();
        TurnOffAllScreensButOne();
    }
    public void changeUserDataScreen()
    {
        Debug.Log("changeUserDataScreen()");
        //home();

    }

    public void changeAdventureBoardScreen()
    {
        Debug.Log("changeRegisterScreen");
        activeScreen = ("ABS");
        updateActiveScreenToActiveScreenFab();
        TurnOffAllScreensButOne();
    }
    public void changeRegisterScreen()
    {
        Debug.Log("changeRegisterScreen");
        activeScreen = ("Register_UI");
        updateActiveScreenToActiveScreenFab();
        TurnOffAllScreensButOne();

    }
    public void changeScoreboardScreen()
    {
        Debug.Log("changeScoreboardScreen()");
    }

    public void updateActiveScreenToActiveScreenFab()
    {
        activeScreenFab = gamescreen.transform.Find(activeScreen).gameObject;
    }


    public void home()
    {

        activeScreenFab = gamescreen.transform.Find("homeScreen").gameObject;
        TurnOffAllScreensButOne();
    }

    public void Login_UI()
    {

        activeScreenFab = gamescreen.transform.Find("Login_UI").gameObject;
        TurnOffAllScreensButOne();
    }


    public void EM()
    {

        activeScreenFab = gamescreen.transform.Find("EM").gameObject;
        TurnOffAllScreensButOne();
    }






    public void RCS_UI()
    {

        activeScreenFab = gamescreen.transform.Find("RCS").gameObject;
        TurnOffAllScreensButOne();
    }
    //AS----------------------------------
    public void AS()
    {

        activeScreenFab = gamescreen.transform.Find("AS").gameObject;
        TurnOffAllScreensButOne();
    }


    // ATS______________________
    public void ATS()
    {

        activeScreenFab = gamescreen.transform.Find("ATS").gameObject;

        TurnOffAllScreensButOne();
    }


    public void LDB_AdventureTaskLoaderandScreenChanger()
    {
        Debug.Log("LDB_AdventureTaskLoaderandScreenChanger()");
        ATS();
        //poping time

        offLineLocalDataBase.LDB_GT_getter_Name = fbStore.GTDocName;
        // offLineLocalDataBase.LoadDyn_LDB_GT_listpp();
        // offLineLocalDataBase.Dyn_LDB_GT_listSperater();
        Debug.Log("ok why is this stioping ");
        fbAuth.taskUserDataLoopInt = 0;
        testLockAndKey.unlockedTaskNubList.Clear();
        offLineLocalDataBase.AS_LDBList.Clear();
        offLineLocalDataBase.LoadAS_LDBListPP();
        offLineLocalDataBase.LoadDyn_LDB_UserTaskTime_Listpp();
        offLineLocalDataBase.SaveDyn_LDB_GT_listpp();
        offLineLocalDataBase.LDB_GTchecker();

        if (ATSintButtonIterationCount != 0)
        {
            ATSintButtonIterationCount = (int)0;
            TaskButtonOnClick();

        }
        else
        {
            fbStore.AdventureNameABTMP.GetComponent<TMPro.TextMeshProUGUI>().text = "Error";
            fbStore.InfoABTMP.GetComponent<TMPro.TextMeshProUGUI>().text = "nothing to be read or you have not unlocked this Adventure yet ";
        }

       



        // testLockAndKey.unlockedTaskNubList

        // fbStore.ATSgetInfoNMainName();
        // fbStore.AdventureNameABTMP.GetComponent<TMPro.TextMeshProUGUI>().text = fbStore.VarAdventureName1ABTMP;
        // fbStore.InfoABTMP.GetComponent<TMPro.TextMeshProUGUI>().text = fbStore.VarInfoABTMP;

    }
    public void EndofATLSC_LDB()
    {

        ATSTrigerInstantButtons();
        offLineLocalDataBase.callFromATS_LDB = false;

    }
    public void AdventureTaskLoaderandScreenChanger()
    {

        Debug.Log("AdventureTaskLoaderandScreenChanger()");
        fbStore.GetGroupTagsTaskDataToList();
        //this \/ is the order after this ^ gets called
        // ATSAGetDataToList();


        //fbAuth.GetTaskAuthchecker(); not sure if this is right 



        // offLineLocalDataBase.Foreach_GroupTagList__TO__AS_LDBList();
        //DownLoadSelectedAStoLDBS()
        //fbAuth.GetTaskAuthchecker();

        //EndofAdventureTaskLoaderandScreenChanger()
    }
    public void EndofAdventureTaskLoaderandScreenChanger()
    {

        Debug.Log(" EndofAdventureTaskLoaderandScreenChanger()");
        Test_GT_Button_Lock.SetActive(false);
        ATSTrigerInstantButtons();
        fbStore.ATSgetInfoNMainName();
   
        
        
        if (ATSintButtonIterationCount != 0)
        {
            ATSintButtonIterationCount = (int)0;
            TaskButtonOnClick();

        }
        else
        {
            fbStore.AdventureNameABTMP.GetComponent<TMPro.TextMeshProUGUI>().text = "Error";
            fbStore.InfoABTMP.GetComponent<TMPro.TextMeshProUGUI>().text = "nothing to be read or you have not unlocked this Adventure yet ";
        }

        

       
        ATS();

    }



    public void ATSTrigerInstantButtons()
    {
        ATSClearButtons();
        Debug.Log("ATSTrigerInstantButtons()");
        ATSintButtonIterationCount = 0;
        fbAuth.taskUserDataLoopInt = 0;


        foreach (int s in testLockAndKey.unlockedTaskNubList)
        {

            GameObject a = (GameObject)Instantiate(GOTB);
            a.name = a.name.Replace("(Clone)", ("") + s);
            a.transform.SetParent(ATSContener.transform, false);

            if (offLineLocalDataBase.connectionStatus == "OffLine")
            {
                int o = s * 2 + 1;


                string s2 = PlayerPrefs.GetString("Task_Namepp_" + o);
                s2 = s2.Replace("GT(", "");

                a.GetComponentInChildren<TextMeshProUGUI>().text = s2;
                    
                   


            }
            else
            {
                bool b;
                string s3 = fbStore.TaskNameList[s];
                string s2;
                b = s3.StartsWith("GT(");
                if (b == true)
                {

                    s3 = s3.Replace("GT(", "");

                    int i1 = s3.LastIndexOf(")");
                     s2 = s3.Substring(0, i1);

                    s3 = s3.Replace(s2 + ")", "");





                   
                }
                   
               
                a.GetComponentInChildren<TextMeshProUGUI>().text = s3;
            }

            ATSintButtonIterationCount = ATSintButtonIterationCount + 1;
        }

    }
    //pop task button in screen view
    //task button 

    public void TaskButtonOnClick()
    {
        //cheek and set Tasklock

        Debug.Log("TaskButtonOnClick()");


        string s4 = "";

        if (tasklock == true) ;
        {




            if (offLineLocalDataBase.connectionStatus == "OffLine")
            {

                int A = ATSintButtonIterationCount;

                int i = (A * 2) + 1;
                int E = (A * 2) + 2;

                Test_GT_Button_Lock.SetActive(true);

                fbStore.VarAdventureName1ABTMP = PlayerPrefs.GetString("Task_Namepp_" + i);
                fbStore.VarInfoABTMP = PlayerPrefs.GetString("Task_Infopp_" + E);
            }
            else
            {
                fbStore.ATSGetData();
            }


            string s3 = fbStore.VarAdventureName1ABTMP;
            bool b;

            b = s3.StartsWith("GT(");

            if (b == true)
            {


                s3 = s3.Replace("GT(", "");

                int i1 = s3.LastIndexOf(")");
                string s2 = s3.Substring(0, i1);

                s4 = s3.Replace(s2 + ")", "");



                fbStore.GTDocName = s2;
                Test_GT_Button_Lock.SetActive(true);

            }
            else
            {
                s4 = fbStore.VarAdventureName1ABTMP;

                Test_GT_Button_Lock.SetActive(false);

                if (fbStore.GTDocName != "")
                {
                    fbStore.GTDocName = "";
                }


            }







            fbStore.AdventureNameABTMP.GetComponent<TMPro.TextMeshProUGUI>().text = s4;
            fbStore.InfoABTMP.GetComponent<TMPro.TextMeshProUGUI>().text = fbStore.VarInfoABTMP;
        }

    }


    public Texture2D myTexture;
    public void Task0ButtonOnClick()
    {

        fbStore.AdventureNameABTMP.GetComponent<TMPro.TextMeshProUGUI>().text = fbStore.VarAdventureName1ABTMP;
        fbStore.InfoABTMP.GetComponent<TMPro.TextMeshProUGUI>().text = fbStore.VarInfoABTMP;
    }



    //ABS---------------------------------------------
    public void ABTrigerInstantButtons()
    {
        intButtonIterationCount = 0;
        Debug.Log("ABTrigerInstantButtons()");
        // int i = 1; i <= numberOfButtons; i++
        foreach (string buttonString in fbStore.abButtonsList)
        {

            GameObject a = (GameObject)Instantiate(GOB);

            a.name = a.name.Replace("(Clone)", " " + buttonString);
            //intButtonIterationCount +

            a.transform.SetParent(ABConten.transform, false);


            string buttonStringText = buttonString.Replace("(RCS)", "");
            buttonStringText = buttonStringText.Replace("(ABS)", "");
            buttonStringText = buttonStringText.Replace("(AS)", "");
            buttonStringText = buttonStringText.Replace("(ATS)", "");



            a.GetComponentInChildren<TextMeshProUGUI>().text = buttonStringText;
            intButtonIterationCount = intButtonIterationCount + 1;

            //  string g = a.ToString();
            // fbStore.abButton1 = a.GetComponentInChildren<TextMeshProUGUI>();
            // a.GetComponentsInChildren<TextMeshProUGUI>(false, fbStore.abButtonsTMPList);
            // fbStore.abButtonsList.Add(a);
            jojo = storage.GetReferenceFromUrl("gs://gaapp-81260.appspot.com/");
            reference = jojo.Child(buttonString + ".jpg");



            string exp = "C:/Users/liaml/Documents/Gateway Adventure App (2)/Assets/liam things/pics/(ATS)test.jpg";
            bool exp_b = File.Exists(exp);


            string SAP = Application.streamingAssetsPath;
            SAP = SAP.Replace("/Assets/StreamingAssets", "/Assets/liam things/pics/Local image data base/" + buttonString + ".jpg");
            bool b = File.Exists(SAP);

            if (b == true)
            {
                GameObject B = GameObject.Find("Button" + " " + buttonString);

                rawImage = B.GetComponentInChildren<RawImage>();


                byte[] bytes = File.ReadAllBytes(SAP);
                myTexture = new Texture2D(1, 1); //mock size 1x1
                myTexture.LoadImage(bytes);

                rawImage.texture = myTexture;

            }

            else
            {
                Get_ABbutton_URL();
            }



            // string Downloaded_URL = ("https://firebasestorage.googleapis.com/v0/b/gaapp-81260.appspot.com/o/(ABS)Rock%20climbing.jpg?alt=media&token=a6ea18c0-075b-4cc1-ba3b-4c7d18afe485");
            //  StartCoroutine(LoadImage(Downloaded_URL));


        }



    }


    StorageReference reference;
    StorageReference jojo;

    public void Get_ABbutton_URL()
    {






        string Downloaded_URL;

        reference.GetDownloadUrlAsync().ContinueWithOnMainThread(task =>
        {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                Debug.Log("Download URL: " + task.Result);
                Downloaded_URL = task.Result.ToString();
                StartCoroutine(LoadImage(Downloaded_URL));
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




            string url_d = (request.url.ToString());

            int i1 = url_d.LastIndexOf(".jpg?");
            string s = url_d.Substring(0, i1);
            s = s.Replace("%20", " ");
            s = s.Replace("https://firebasestorage.googleapis.com/v0/b/gaapp-81260.appspot.com/o/", "");
            s = s;

            //gamescreen = GameObject.Find("gamescreen");
            GameObject B = GameObject.Find("Button" + " " + s);

            rawImage = B.GetComponentInChildren<RawImage>();
            rawImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;

            // setting the loaded image to our object
        }
    }








    public void ABClear()
    {
        Debug.Log("ABClear()");
        foreach (Transform child in ABConten.transform)
        {
            GameObject.Destroy(child.gameObject);
        }



    }

    public void ATSClearButtons()
    {
        Debug.Log("ATSClearButtons()");
        foreach (Transform child in ATSContener.transform)
        {
            GameObject.Destroy(child.gameObject);
        }



    }



    public void ABClearAndReload()
    {
        Debug.Log("ABinstantVenturesButton()");
        ABClear();
        ABinstantVenturesButton();
        //fbStore.ABAGetDataToList();

    }



    public void ABinstantVenturesButton()
    {
        Debug.Log("ABinstantVenturesButton()");
        fbStore.ABAGetDataToList();
        if (offLineLocalDataBase.connectionStatus == "OnLine")
        {
            // fbStorage.DownloadABSPicsLoop();

        }
    }

    //new stuff


    public void instantCategoryButton()
    {
        Debug.Log("instantCategoryButton()");
        fbStore.ABAGetDataToList();


    }

    public void instantCategoryButtons()
    {

        Debug.Log("instantCategoryButtons()");

        foreach (string s in fbStore.CategoryButtonsList)
        {

            GameObject a = (GameObject)Instantiate(GOCB);
            a.name = a.name.Replace("(Clone)", ("") + s);
            a.transform.SetParent(CategoryConten.transform, false);


            a.GetComponentInChildren<TextMeshProUGUI>().text = s;

        }

    }


    public void instantOfflineABDownLoadedButton()
    {
        fbStore.abButtonsList.Clear();
        ABClear();
        foreach (string s in offLineLocalDataBase.LDB_MegaList)
        {

            fbStore.abButtonsList.Add(s);

            callFrom_instantOfflineABDownLoadedButton = true;
        }
        
        instantDownLoadedButton();
    }
 
    bool callFrom_instantOfflineABDownLoadedButton = false;



    public void instantDownLoadedButton()

    {

        foreach (string buttonString in fbStore.abButtonsList)
        {

            GameObject a;

            if (callFrom_instantOfflineABDownLoadedButton == true)
            {
               a  = (GameObject)Instantiate(GOB_LDB);
                callFrom_instantOfflineABDownLoadedButton = false;
            }
            else
            {
                a = (GameObject)Instantiate(GOB);
            }

            a.name = a.name.Replace("LDB_", "");
            a.name = a.name.Replace("(Clone)", " " + buttonString);


            a.transform.SetParent(ABConten.transform, false);
            string buttonStringText = buttonString.Replace("(RCS)", "");
            buttonStringText = buttonStringText.Replace("(ABS)", "");
            buttonStringText = buttonStringText.Replace("(AS)", "");
            buttonStringText = buttonStringText.Replace("(ATS)", "");




            a.GetComponentInChildren<TextMeshProUGUI>().text = buttonStringText;



            string SAP = Application.streamingAssetsPath;
            SAP = SAP.Replace("/Assets/StreamingAssets", "/Assets/liam things/pics/Local image data base/" + buttonString + ".jpg");
            bool b = File.Exists(SAP);

            if (b == true)
            {
                // GameObject B = GameObject.Find("Button" + " " + buttonString);

                rawImage = a.GetComponentInChildren<RawImage>();


                byte[] bytes = File.ReadAllBytes(SAP);
                myTexture = new Texture2D(1, 1); //mock size 1x1
                myTexture.LoadImage(bytes);

                rawImage.texture = myTexture;

            }

            else
            {
                //  Get_ABbutton_URL();
            }


            //rawImage = gameObject.GetComponent<RawImage>();


        }
    }














    //----------------------------------------------------

    public void ClearScreens()
    {
        Debug.Log("ClearScreens()");
        FindAllScreensUnderGamescreen();
        // Debug.Log(gamescreenChild.Count);
        for (int i = 0; i < (gamescreen.transform.childCount); i++)
        {

            gamescreenChild[i].SetActive(false);
            //Debug.Log(gamescreenChild.Count);
            // Debug.Log(gamescreenChild[i]);

        }


    }

    public void TurnOffAllScreensButOne()
    {
        Debug.Log("TurnOffAllScreensButOne()");
        ClearScreens();
        activeScreenFab.SetActive(true);

    }

    public void FindAllScreensUnderGamescreen()
    {

        // screenInt = (gamescreen.transform.childCount);
        // Debug.Log(screenInt);
        gamescreenChild.Clear();


        for (int i = 0; i < (gamescreen.transform.childCount); i++)
        {

            gamescreenChild.Add(gamescreen.transform.GetChild(i).gameObject);
            //Debug.Log(gamescreenChild[i]);
        }
        //Transform[] gamescreenChild = gamescreen.GetComponentsInChildren<Transform>(true);
        // for(int i = 0; i < gamescreenChild.Length; i++)
        //{
        //   Debug.Log(gamescreenChild[i]);
        //}



    }

    public void openUrl()
    {
        Application.OpenURL(urlGATPage);
    }

    //lock things
    public void TestDynLockButton()
    {
        fbStore.GTDocName = ("test");
        callFromTDL = true;
        fbStore.GetGroupTagsTaskDataToList();
        //fbAuth.GTchecker();
        //this then go to these steps
        //LoadUserDataforGroupTags
        //testLock-testLockAndKey
        //GetUlockedTagsData-fbStore
        // saveUnlockedTagToUserAuth-fbAuth
        //UpdateUnlockedTags-fbAuth
    }








    public void ClearLDBImage()
    {
        string SAP = Application.streamingAssetsPath;
        //+ "/(ATS)test.jpg";
        SAP = SAP.Replace("/Assets/StreamingAssets", "/Assets/liam things/pics/Local image data base");
        bool b = File.Exists(SAP);

        var IDLfiles_Paths = Directory.GetFiles(SAP);

       foreach  (string s in IDLfiles_Paths)
        {
 //FileUtil.DeleteFileOrDirectory(SAP);
        File.Delete(s);
        }
       
    }
}