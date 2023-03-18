using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Firebase.Storage;
using System.IO;
using SystemTask = System.Threading.Tasks;
using System;
using Dummiesman;
using DigitsNFCToolkit.Samples;
using Firebase.Extensions;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FBStorage : MonoBehaviour
{

    AssetBundle myLoadedAssetBundle;
    public string path;
    public string LQ;




    public FBStore fbStore;
    public ReadScreenControl readScreenControl;
    public ScreenController screenController;
    FirebaseStorage storage;
    StorageReference reference;
        public ObjFromFile objFromFile;



    public GameObject instanGO ;
    public string prefabFolderPath ;
    public List <GameObject> prefabScreenList;

    
    public int listCaller = 0;
    public GameObject gamescreen;

    public string donwloadScreenFab;
    public string Uploadfilefab;
    public string whatbuildsuffic;

    public string buttonString;


    RawImage rawImage;

    // Start is called before the first frame update
    void Start()
    {
        storage = FirebaseStorage.DefaultInstance;

        //DownloadABSPics();

/*
 * 
 * 
        rawImage = gameObject.GetComponent<RawImage>();
        StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/gaapp-81260.appspot.com/o/(ABS)Rock%20climbing.jpg?alt=media&token=a6ea18c0-075b-4cc1-ba3b-4c7d18afe485"));
*/
       

        gamescreen = GameObject.Find("gamescreen");

        

        //Debug.Log(prefabFolderPath);
    }





    // image things 
    //and more things to come 

    public void DownloadABSPicsLoop()
    {

       


        
            string j = "s" + ".jpg";

            buttonString = j;
            donwloadScreenFab = j;
            updatePrefabFolderPath();
              DownloadABSPics();

       

       

    }

    public void lDownloadABSPics()
    {

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





    public void DownloadABSPics()
    {
        Debug.Log("DownloadABSPics()");

        string n = screenController.abNameOfButtonClicked + ".jpg";
        n = n.Replace("Button ", ""); 
      
        reference = storage.RootReference.Child(n);

        Debug.LogError("");


        string SAP = Application.streamingAssetsPath;
            //+ "/(ATS)test.jpg";
        SAP = SAP.Replace("/Assets/StreamingAssets", "/Assets/liam things/pics/Local image data base/" + n);
      bool b = File.Exists(SAP);

        if (b  == false)
        {
            reference.GetFileAsync(SAP).ContinueWithOnMainThread(task =>
            //prefabFolderPath






                  {




                      if (task.IsFaulted)
                      {
                          Debug.LogError("image not in data base " + "\n or not named correctly" + "\n should look somthing like this (ATS)test.jpg ");


                      }



                      else if (task.IsCompleted)
                      {






                          Debug.Log("downloaded  ");



                      }



                  });


        }




        Debug.Log("downloaded ");

    }



    





















    void LoadedAssetBundle()
    {
        myLoadedAssetBundle = AssetBundle.LoadFromFile(prefabFolderPath);

        Debug.Log(myLoadedAssetBundle == null ? "failed to load assestbundle  " : "assest bundle loaded");
    }


  



    public void fbTagScreenNameFordonwloadScreenFab()
        {
            Debug.Log("fbTagScreenNameFordonwloadScreenFab()");
            donwloadScreenFab = fbStore.fbTagScreenName + (whatbuildsuffic);
            Debug.Log("donwloadScreenFab:" + donwloadScreenFab);
       
        updatePrefabFolderPath();



        }

        


        public void screenFabsListUpdater()
    {
            Debug.Log("screenFabsListUpdater()");
            prefabScreenList = new List<GameObject>(Resources.LoadAll<GameObject> ("Screen Fabs"));
        GameObject newsceneclone = (GameObject)GameObject.Instantiate(prefabScreenList[listCaller]);
      //  GameObject newsceneclone = (GameObject)GameObject.Instantiate(Resources.Load, prefabFolderPath);
        newsceneclone.transform.parent = gamescreen.transform;
            Debug.Log("all done");
    }


    public void uploadfile()
    {



        reference = storage.GetReferenceFromUrl("gs://gaapp-81260.appspot.com");
            Debug.Log(donwloadScreenFab);

            string localfile = prefabFolderPath;

        reference.Child(donwloadScreenFab ).PutFileAsync(localfile)
    .ContinueWith((SystemTask.Task<StorageMetadata> task) =>
    {
        if (task.IsFaulted || task.IsCanceled)
        {
            Debug.Log(task.Exception.ToString());
           
        }
        else
        {
            
            Debug.Log("Finished uploading...");
           
        }
    });
    }




    public void updatescreen()
    {
        Uploadfilefab = (GetComponent<ScreenController>().activeScreen);
            //activeScreen.ToString()   + (".prefab")
            Debug.Log("updatescreen updated");
        
    }




    public void updatePrefabFolderPath()
    {
       
        Debug.Log("updatePrefabFolderPath()");

        // Debug.Log(Application.dataPath); 



        //string path = Directory.GetCurrentDirectory() + "/Assets/Resources/Screen Fabs/" + donwloadScreenFab;
        string path =  Application.streamingAssetsPath + ("/") + donwloadScreenFab;
        //Application.persistentDataPath 




        Debug.Log(path);
       
       // prefabFolderPath = path.Replace("GAAPP7.app/Data", "Documents"); Directory.GetCurrentDirectory();

        Debug.Log(prefabFolderPath );
       
        // InstatNewScene();
       // getfile();
            // uploadfile();

        }
        



    public void MoveFolder()
    {
     
        Debug.Log("Moving Folder" );
            //Debug.Log(Application.streamingAssetsPath + "/getfile/" + donwloadScreenFab+ "    "+ prefabFolderPath);
            File.Move("f", "C:/Users/liaml/Documents/Gateway Adventure App/Assets/Resources/Screen Fabs/Zion.prefab");
            //File.Move( Application.streamingAssetsPath + "/getfile/" + donwloadScreenFab, prefabFolderPath); "C:/Users/liaml/Documents/Gateway Adventure App /Assets/Resources/Screen Fabs/"

            Debug.Log("Moved Folder");

            InstatNewScene();


    }


       public GameObject loadedObject;


       

        
     

        public void getfile()
        {
       
        Debug.Log(" getfile()");
            Debug.Log(donwloadScreenFab);



        reference = storage.RootReference.Child(donwloadScreenFab);
        /*  if (!Directory.Exists(Application.streamingAssetsPath + "/getfile"))

          {
              Directory.CreateDirectory(Application.streamingAssetsPath + "/getfile");

          }

      */

        Debug.Log(reference);

        reference.GetFileAsync(prefabFolderPath).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("downloaded  " + donwloadScreenFab);
                   


                }

            });



        //Debug.Log("1");
        //ya this need to be changed but it works for now 

        Debug.Log("ttest()");
        Invoke("ttest", 3f);
       // Invoke("InstatNewScene", 3f);

    }


    public void ttest()
    {
        LoadedAssetBundle();
        IntantObjetFromBundle();
    }


     public void IntantObjetFromBundle()
    {

        Debug.Log("IntantObjetFromBundle");
        // lq is a sub name from the bundle this should be change some time later
        var prefab = myLoadedAssetBundle.LoadAsset("lq");
       

        GameObject a = (GameObject)Instantiate(prefab);
       a.transform.SetParent(gamescreen.transform,false);
        //transform.parent = gamescreen.transform;


       
        screenController.FindAllScreensUnderGamescreen();
       
        screenController.activeScreen = fbStore.fbTagScreenName + ("(Clone)");
       
        screenController.updateActiveScreenToActiveScreenFab();
       
        screenController.TurnOffAllScreensButOne();
        
    }




    public void InstatNewScene()
        {
  //NOT BINNING USED RN 
        Debug.Log("InstatNewScene()");
            Debug.Log(prefabFolderPath);
      


        GameObject newsceneclone = new OBJLoader().Load(prefabFolderPath);
        //newsceneclone.transform.SetParent(gamescreen.transform); 
        //newsceneclone.transform.parent = gamescreen.transform;


        //Instantiate(Resources.Load("Screen Fabs/Zion") as GameObject);
        //ativat the new screen 
    }


      

     
      


    }
