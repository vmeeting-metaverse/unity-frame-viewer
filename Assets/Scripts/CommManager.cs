using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;

public class CommManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
