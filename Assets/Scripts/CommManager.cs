using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;

using System.Runtime.InteropServices;

public class CommManager : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void VmeetingRequest (string status);

    void Awake(){
        #if (!UNITY_EDITOR && UNITY_WEBGL)
        // disable WebGLInput.captureAllKeyboardInput so elements in web page can handle keyboard inputs
        WebGLInput.captureAllKeyboardInput = false;
        #endif
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickJoin (){
        Debug.Log("Join Clicked!");
        #if UNITY_WEBGL == true && UNITY_EDITOR == false
        int roomId = 0;
        string status = System.String.Format("{{\"id\": {0}, \"state\": \"ENTER\"}}", roomId);
        VmeetingRequest(status);
        #endif
    }

    public void onClickExit (){
        Debug.Log("Exit Clicked!");
        #if UNITY_WEBGL == true && UNITY_EDITOR == false
        int roomId = 0;
        string status = System.String.Format("{{\"id\": {0}, \"state\": \"EXIT\"}}", roomId);
        VmeetingRequest(status);
        #endif
    }

    public void comm_setImage (string param){
        JObject o = JObject.Parse(param);
        string id = o["id"].ToString();
        string base64str = o["data"].ToString();

        byte[]  imageBytes = Convert.FromBase64String(base64str);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage( imageBytes );
        Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        
        if(String.Compare(id, "1") == 0){
            GameObject.Find("VideoCanvas").gameObject.transform.Find("Image-1").gameObject.GetComponent<Image>().sprite = sprite;
        }
        else if(String.Compare(id, "2") == 0){
            GameObject.Find("VideoCanvas").gameObject.transform.Find("Image-2").gameObject.GetComponent<Image>().sprite = sprite;
        }
        else {
            Debug.Log("Invalid");
        }
    }
}
