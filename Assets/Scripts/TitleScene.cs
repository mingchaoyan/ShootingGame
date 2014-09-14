using UnityEngine;
using System.Collections;

public class TitleScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.skin.label.fontSize = 48;

        GUI.skin.label.alignment = TextAnchor.LowerCenter;

        GUI.Label(new Rect(0, 30, Screen.width, 100), "太空大战");

        if (GUI.Button(new Rect(Screen.width * 0.5f - 100, Screen.height * 0.7f, 200, 30), "开始游戏"))
        {
            Application.LoadLevel("level1");
        }
    }
}
