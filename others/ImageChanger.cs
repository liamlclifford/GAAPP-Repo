using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Image oldImage;
    public Sprite newImage;


    private void Start()
    {
        Debug.Log("ImageChanger____ start");


        ABChangePic();



    }

    public void ABChangePic()
    {
        Debug.Log("ABChangePic()");
        oldImage.sprite = newImage;
    }









}
