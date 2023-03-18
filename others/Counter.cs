using Firebase.Firestore;


[FirestoreData]
public struct RCSname 
{
    
    [FirestoreProperty]
    public string Route 
    { get; set; }

    [FirestoreProperty]
    public string Type 
    { get; set; }
    
    [FirestoreProperty]
    public string Place 
    { get; set; }
    
    [FirestoreProperty]
    public string Area
    { get; set; }

    [FirestoreProperty]
    public string Difficulty
    { get; set; }
   
    [FirestoreProperty]
    public string Name
    { get; set; }





    [FirestoreProperty]
    public string UpdateBy { get; set; }

}

[FirestoreData]
public struct ASName
{
    [FirestoreProperty]
    public string Place
    { get; set; }

    [FirestoreProperty]
    public string Text
    { get; set; }

    [FirestoreProperty]
    public string TagID
    { get; set; }

    

    [FirestoreProperty]
    public string AdventureName
    { get; set; }

    [FirestoreProperty]
    public string Info
    { get; set; }



    [FirestoreProperty]
    public string Task1
    { get; set; }

    [FirestoreProperty]
    public string Task1Info
    { get; set; }


    [FirestoreProperty]
    public string Task2
    { get; set; }

    [FirestoreProperty]
    public string Task2Info
    { get; set; }

    [FirestoreProperty]
    public string Task3
    { get; set; }

    [FirestoreProperty]
    public string Task3Info
    { get; set; }


    [FirestoreProperty]
    public string Task4
    { get; set; }

    [FirestoreProperty]
    public string Task4Info
    { get; set; }




    //buttons

    [FirestoreProperty]
    public string Button1
    { get; set; }

    [FirestoreProperty]
    public string Button2
    { get; set; }


    [FirestoreProperty]
    public string Button3
    { get; set; }

    [FirestoreProperty]
    public string Button4
    { get; set; }





    [FirestoreProperty]
    public string UpdateBy { get; set; }

}

[FirestoreData]
public struct GTName
{
    [FirestoreProperty]
    public string Tag1
    { get; set; }
    
     [FirestoreProperty]
    public string Tag2
    { get; set; }

    [FirestoreProperty]
    public string Tag3
    { get; set; }

    [FirestoreProperty]
    public string Tag1Time
    { get; set; }

    [FirestoreProperty]
    public string Tag2Time
    { get; set; }

    [FirestoreProperty]
    public string Tag3Time
    { get; set; }




    [FirestoreProperty]
    public string ATagUnlocked
    { get; set; }






    [FirestoreProperty]
    public string ATag1Unlocked
    { get; set; } 

    [FirestoreProperty]
    public string ATag2Unlocked
    { get; set; }

    [FirestoreProperty]
    public string ATag3Unlocked
    { get; set; }

    [FirestoreProperty]
    public string ATag4Unlocked
    { get; set; }



    [FirestoreProperty]
    public string TaskName
    { get; set; }

    [FirestoreProperty]
    public string ATag1lockedTime
    { get; set; } 

    [FirestoreProperty]
    public string ATag2lockedTime
    { get; set; }

    [FirestoreProperty]
    public string ATag3lockedTime
    { get; set; }

    [FirestoreProperty]
    public string ATag4lockedTime
    { get; set; }




    [FirestoreProperty]
    public string UpdateBy { get; set; }




}



