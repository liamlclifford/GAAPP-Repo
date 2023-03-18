using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;


public class CategoryButtons : MonoBehaviour
{
    public ScreenController screenController;
    public FBStore fbStore;
    public FBStorage fbStorage;
    public GameObject sceneManagerObj;


    

    public void FindCategoryButtonName()

    {
        sceneManagerObj = GameObject.Find("scene manager");


        screenController = sceneManagerObj.GetComponent<ScreenController>();
        fbStore = sceneManagerObj.GetComponent<FBStore>();
        fbStorage = sceneManagerObj.GetComponent<FBStorage>();


        screenController.abNameOfButtonClicked = EventSystem.current.currentSelectedGameObject.name;

        Debug.Log(screenController.abNameOfButtonClicked);

        Debug.Log(EventSystem.current.currentSelectedGameObject.name);



        string R = screenController.abNameOfButtonClicked.Replace("CategoryButton[", "");
        Debug.Log(R);
        fbStore.ABDocName = R;
        screenController.ABClear();
        screenController.ABinstantVenturesButton();
        


    }
}