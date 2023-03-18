using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TestLockAndKey : MonoBehaviour
{
    public FBAuth fbAuth;
    public FBStore fbStore;
    public ScreenController screenController;

    public string DynPin;
    public string pin1;
    public string pin2;
    public string pin3;
    public int Testkey;

    public string tagtime;
    public string tag1time;
    public string tag2time;
    public string tag3time;


    //ATS tasks
    public string userTaskTime;
    public string userTask2Time;
    public string userTask3Time;
    public string userTask4Time;

    public string tasktimeLock;
    public string task2timeLock;
    public string task3timeLock;
    public string task4timeLock;

    public List<int> unlockedTaskNubList = new List<int>();


    public string whatTheNameOfTheTagImUnlockRN;
    public string AlsoifNull_userTaskTime;




    public void getkeyAndTestLock()
    {
        fbStore.GetGroupTagsData();
    }





    public void UnlockTask()
    {
        Debug.Log("UnlockTask()");
   

           Int64 UTT = Int64.Parse(userTaskTime);
            Int64 TT = Int64.Parse(tasktimeLock);

            whatTheNameOfTheTagImUnlockRN = whatTheNameOfTheTagImUnlockRN;
      

        if (UTT >= TT)
            {
                screenController.tasklock = true;

                Debug.Log(screenController.tasklock);
                unlockedTaskNubList.Add(fbAuth.taskUserDataLoopInt);

                fbAuth.taskUserDataLoopInt = fbAuth.taskUserDataLoopInt + 1;
            }
            else if (UTT < TT)
            {
                Debug.Log(screenController.tasklock);

                fbAuth.taskUserDataLoopInt = fbAuth.taskUserDataLoopInt + 1;
            }
            else
            {
                Debug.Log("all done with cheeking task locks");
            }


       



    }

    int i = 0;
    public void DynLock()
    {Debug.Log("DynLock()");
        

        Debug.Log(DynPin);
        DynPin = DynPin.Replace(@"-", @"").Replace(@":", @"").Replace(@" ", @"");
        Debug.Log("Pin Reformated" + DynPin );
        Int64 P = Int64.Parse(DynPin);
        Debug.Log("Pins Converted" + DynPin );
        Int64 T = Int64.Parse(tagtime);
        Debug.Log("Time stamp Converted to Int");

        if (P >= T)
        {
            Testkey = Testkey + 1;
            Debug.Log("Pin "+ i + ("set"));
        }
        else
        {
            Debug.Log("Pin " + i + ("failed"));
        }
    }


    public void testLock()
    {

        Debug.Log(tag1time+("  ")+tag2time+("  ")+tag3time);
       //fbAuth.GTchecker();
       Testkey = 0;
        Debug.Log("GTchecker()Done");
        debugAllPins();
        pin1 = pin1.Replace(@"-", @"").Replace(@":", @"").Replace(@" ", @"");
        pin2 = pin2.Replace(@"-", @"").Replace(@":", @"").Replace(@" ", @"");
        pin3 = pin3.Replace(@"-", @"").Replace(@":", @"").Replace(@" ", @"");
        Debug.Log("Pins Replaced");
        Int64 P1 = Int64.Parse(pin1);
        Int64 P2 = Int64.Parse(pin2);
        Int64 P3 = Int64.Parse(pin3);
        // Debug.Log("Pins Converted to Int" + "   " + P1 + "   " + P2+ "  "+P3); 
        Int64 T1 = Int64.Parse(tag1time);
        Int64 T2 = Int64.Parse(tag2time);
        Int64 T3 = Int64.Parse(tag3time);
        Debug.Log("Time stamp Converted");
        

        if (P1 >= T1)
        {
            
            Testkey = Testkey + 1;
            //Debug.Log("test1");

        }            
        if (P2 >= T2)
        {         

            Testkey = Testkey + 1;

           // Debug.Log("test2");

        }
        if (P3 >= T3)
        {
           
            Testkey = Testkey + 1;
           // Debug.Log("test3");


        }
        
        Debug.Log(Testkey);
        Debug.Log("Lock Tested");
        if (Testkey == 3)
        {
            Debug.Log("unlocked");
        
            fbStore.GetUlockedTagsData();
        }
       
        
    }

    public void testKey()
    {
        pin1Setter();
        pin2Setter();
        pin3Setter();
    }

    public void pin1Setter()
    {
        pin1 = "1pin set";
       
    }
    public void pin2Setter()
    {
        pin2 = "2pin set";

    }
    public void pin3Setter()
    {

        //     time stamp 
        pin3 = "3pin set";

    }

    public void debugAllPins()
    {
        Debug.Log(pin1);
        Debug.Log(pin2);
        Debug.Log(pin3);
    }

}
