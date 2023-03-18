using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using Firebase.Firestore;


public class test : MonoBehaviour
{




    DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;

    protected virtual void Start()
    {


        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();

                Debug.Log("firebase initalize");
            }
            else
            {
                Debug.LogError(
                  "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    // Initialize the Firebase database:
    protected virtual void InitializeFirebase()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;


    }
    TransactionResult AddTagTransaction(MutableData mutableData)
    {


        // Now we add the new score as a new entry that contains the email address and score.
        Dictionary<string, object> newTagMap = new Dictionary<string, object>();
        newTagMap["Location"] = new GeoPoint(1.5, 2.5);
        newTagMap["ID"] = ("testID123455");
        //  leaders.Add(newTagMap);

        // You must set the Value to indicate data at that location has changed.
        mutableData.Value = newTagMap;
        return TransactionResult.Success(mutableData);
    }



    public void TestPush()
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("tags");

        reference.RunTransaction(AddTagTransaction)
       .ContinueWithOnMainThread(task => {
           if (task.Exception != null)
           {
               Debug.Log(task.Exception.ToString());
           }
           else if (task.IsCompleted)
           {
               Debug.Log("Transaction complete.");
           }
       });




    }























    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
