using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitsNFCToolkit.Samples;
using UnityEngine.UI;


namespace DigitsNFCToolkit.Samples
{
    public class LiamIDTagScript : MonoBehaviour
    {
        public string nfcId;
        public GameObject readScreenController;
       

        public Text liamTextLegacy;
        // Start is called before the first frame update
        void Start()
        {
            // DigitsNFCToolkit.NFCTag();
            //GameObject thisTest = GameObject.Find("ReadScreen").GetComponent(ReadScreenControl);
        }

        // Update is called once per frame
        void Update()
        {
           //liamTextDebug.text = ("Ready for tag...");
          
        }
        public void PassAlongNfc(string nfcPassalong)
        {

        }

        public void OnNDEFReadFinished(NDEFReadResult result)
        {
            string readResultString = string.Empty;
            if (result.Success)
            {
                readResultString = string.Format("NDEF Message was read successfully from tag {0}", result.TagID);
                //view.UpdateNDEFMessage(result.Message);
                //	liamTextBox.text = "Liam, A tag has been detected... Here is the information: " + result.TagID;
               // liamTextDebug.text = ("tag : " + result + "end"+ result.ToString());
            }
            else
            {
                readResultString = string.Format("Failed to read NDEF Message from tag {0}\nError: {1}", result.TagID, result.Error);
            }
            Debug.Log(readResultString);
        }

    }
}
