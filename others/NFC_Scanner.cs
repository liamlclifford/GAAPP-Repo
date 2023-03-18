using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;




namespace DigitsNFCToolkit.Samples
{



	public class NFC_Scanner : MonoBehaviour
	//public class ReadScreenControl : MonoBehaviour
	{
		public OffLineLocalDataBase offLineLocalDataBase;
		public FBStore fbStore;
		public FBStorage fBStorage;
		public string scanedTagID;
		public string scanedTagMessage;

		[SerializeField]
		private ReadScreenView view;

		[SerializeField]
		private MessageScreenView messageScreenView;






		public void Start()
		{

			//scanedTagID = ("500");

			//Debug.Log("fake scan");
#if (!UNITY_EDITOR)
			NativeNFCManager.AddNFCTagDetectedListener(OnNFCTagDetected);
			NativeNFCManager.AddNDEFReadFinishedListener(OnNDEFReadFinished);
			NativeNFCManager.AddNDEFMakeReadonlyFinishedListener(OnNDEFMakeReadonlyFinished);
			Debug.Log("NFC Tag Info Read Supported: " + NativeNFCManager.IsNFCTagInfoReadSupported());
			Debug.Log("NDEF Read Supported: " + NativeNFCManager.IsNDEFReadSupported());
			Debug.Log("NDEF Write Supported: " + NativeNFCManager.IsNDEFWriteSupported());
			Debug.Log("NFC Enabled: " + NativeNFCManager.IsNFCEnabled());
			Debug.Log("NDEF Push Enabled: " + NativeNFCManager.IsNDEFPushEnabled());
#endif
		}






		private void OnEnable()
		{
#if (!UNITY_EDITOR) && !UNITY_IOS
			NativeNFCManager.Enable();
#endif
			view.gameObject.SetActive(true);
		}

		private void OnDisable()
		{
#if (!UNITY_EDITOR) && !UNITY_IOS
			NativeNFCManager.Disable();
#endif
			if (view != null)
			{
				view.gameObject.SetActive(false);
			}
		}

		public void OnStartNFCReadClick()
		{


#if (!UNITY_EDITOR)
			NativeNFCManager.ResetOnTimeout = true;
			NativeNFCManager.Enable();
			
#endif
		}



		public void OnNFCTagDetected(NFCTag tag)
		{
			//scanedTagMessage = tag.
			//when scan donwload tag massage
			//then quri downloaded content if null the check data conetion if true the if null read tag message
			//if true quri fire base .   


			//view.UpdateTagInfo(tag);

			
			scanedTagID = tag.ID;
			fbStore.TestNFCTagRead();
			

			//fbStore.findingfbTagNameWithTagID();


			/*
						if (tag.ID == "04cd9569100289")
						{
							// check and see if in data base.   then look and see what name it is atach to then down load the screen with that name then activeScreen = zion 
							GAAPPTextDebug.text = GAAPPTextDebug.text + ("NPC");
						}



						//door 
					/*	if (tag.ID == "042de34c100289")
						{
							SceneManager.LoadScene("CH4");
							GAAPPTextDebug.text = GAAPPTextDebug.text + ("CH4");

						}


						else
						{

							GAAPPTextDebug.text = GAAPPTextDebug.text + ("   tag not in databace ");

						} */

		}

		public void OnNDEFReadFinished(NDEFReadResult result)
		{

			string readResultString = string.Empty;
			if (result.Success)
			{
				readResultString = string.Format("NDEF Message was read successfully from tag {0}", result.TagID);
				view.UpdateNDEFMessage(result.Message);

				Debug.LogError("");

				Debug.LogError(result.Message.ToString());
				
			}
			else
			{
				readResultString = string.Format("Failed to read NDEF Message from tag {0}\nError: {1}", result.TagID, result.Error);
			}
			Debug.Log(readResultString);
		}

		public void OnMakeReadonlyClick()
		{
#if (!UNITY_EDITOR)
			NativeNFCManager.RequestNDEFMakeReadonly();
#if UNITY_ANDROID
			messageScreenView.Show();
			messageScreenView.SwitchToPendingMakeReadonly();
#endif
#endif
		}

		public void OnMakeReadonlyOKClick()
		{
			messageScreenView.Hide();
		}

		public void OnMakeReadonlyCancelClick()
		{
			messageScreenView.Hide();
#if (!UNITY_EDITOR) && UNITY_ANDROID
			NativeNFCManager.CancelNDEFMakeReadonlyRequest();
#endif
		}

		public void OnNDEFMakeReadonlyFinished(NDEFMakeReadonlyResult result)
		{
			string makeReadonlyResultString = string.Empty;
			if (result.Success)
			{
				makeReadonlyResultString = string.Format("Tag {0} was successfully made readonly", result.TagID);
			}
			else
			{
				makeReadonlyResultString = string.Format("Failed to make tag {0} readonly\nError: {1}", result.TagID, result.Error);
			}
			Debug.Log(makeReadonlyResultString);
			messageScreenView.SwitchToMakeReadonlyResult(makeReadonlyResultString);
		}
	}
}
