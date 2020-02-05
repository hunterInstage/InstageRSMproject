using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
#if(UNITY_2018_3_OR_NEWER)
using UnityEngine.Android;
#endif
using agora_gaming_rtc;

public class TestHome : MonoBehaviour {
   
	// Use this for initialization
    private ArrayList permissionList = new ArrayList();

    public static bool isHost = false;
    public RawImage InSceneTex;
    public void setIsHost(bool val)
    {
        isHost = val;
    }
	void Start ()
	{         
		#if(UNITY_2018_3_OR_NEWER)
		permissionList.Add(Permission.Microphone);         
		permissionList.Add(Permission.Camera);               
		#endif     
	}
	
    private void CheckPermission()
    {
        #if(UNITY_2018_3_OR_NEWER)
        foreach(string permission in permissionList)
        {
            if (Permission.HasUserAuthorizedPermission(permission))
            {             

			}
            else
            {                 
				Permission.RequestUserPermission(permission);
			}
        }
        #endif
    }

    // Update is called once per frame
    void Update ()
	{         
		#if(UNITY_2018_3_OR_NEWER)
		CheckPermission();
#endif

        if (isHost == true && SceneManager.GetActiveScene().name == "TestSceneHelloVideo")
        {
            //Debug.Log(".");
            ExternalVideoFrame frame = new ExternalVideoFrame();

            Texture2D tex2d = TextureToTexture2D(InSceneTex.texture);


            frame.stride = tex2d.width;
            frame.height = tex2d.height;
           
            frame.buffer = tex2d.GetRawTextureData();
            frame.format = ExternalVideoFrame.VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_BGRA;
            frame.type = ExternalVideoFrame.VIDEO_BUFFER_TYPE.VIDEO_BUFFER_RAW_DATA;

            app.mRtcEngine.PushExternVideoFrame(frame);


        }

    }
    private Texture2D TextureToTexture2D(Texture texture)
    {
        Texture2D texture2D = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture renderTexture = RenderTexture.GetTemporary(texture.width, texture.height, 32);
        Graphics.Blit(texture, renderTexture);

        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();

        RenderTexture.active = currentRT;
        RenderTexture.ReleaseTemporary(renderTexture);
        return texture2D;
    }
    static TestHelloUnityVideo app = null;

	private void onJoinButtonClicked() {
		// get parameters (channel name, channel profile, etc.)
		GameObject go = GameObject.Find ("ChannelName");
		InputField field = go.GetComponent<InputField>();

		// create app if nonexistent
		if (ReferenceEquals (app, null)) {
			app = new TestHelloUnityVideo (); // create app
			//app = new GameObject().AddComponent<TestHelloUnityVideo>();
			app.loadEngine (); // load engine

            if (isHost)
            {
                app.useCamVideo = true;
            }
            else
            {
                app.useCamVideo = false;

            }
        }

		// join channel and jump to next scene
		app.join (field.text);
		SceneManager.sceneLoaded += OnLevelFinishedLoading; // configure GameObject after scene is loaded
		SceneManager.LoadScene ("TestSceneHelloVideo", LoadSceneMode.Single);
	}

	private void onLeaveButtonClicked() {
		if (!ReferenceEquals (app, null)) {
			app.leave (); // leave channel
			app.unloadEngine (); // delete engine
			app = null; // delete app
			SceneManager.LoadScene ("TestSceneHome", LoadSceneMode.Single);
		}
	}

	public void onButtonClicked() {
		// which GameObject?
		if (name.CompareTo ("JoinButton") == 0) {
			onJoinButtonClicked ();
		}
		else if(name.CompareTo ("LeaveButton") == 0) {
			onLeaveButtonClicked ();
		}
	}

	public void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
		if (scene.name.CompareTo("TestSceneHelloVideo") == 0) {
			if (!ReferenceEquals (app, null)) {
				app.onSceneHelloVideoLoaded (); // call this after scene is loaded
			}
			SceneManager.sceneLoaded -= OnLevelFinishedLoading;
		}
	}

	void OnApplicationPause(bool paused)
	{
		if (paused)
		{
			if(IRtcEngine.QueryEngine() != null)
			{
				IRtcEngine.QueryEngine().DisableVideo();
			}
		}
		else
		{
			if(IRtcEngine.QueryEngine() != null)
			{
				IRtcEngine.QueryEngine().EnableVideo();
			}
		}
	}

	void OnApplicationQuit()
	{
		IRtcEngine.Destroy();
	}
}
