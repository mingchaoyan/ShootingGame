using UnityEngine;
using System.Collections;

public class TitleScene : MonoBehaviour
{

	void OnGUI ()
	{
		GUI.skin.label.fontSize = 58;
		GUI.skin.label.alignment = TextAnchor.LowerCenter;
		GUI.skin.button.fontSize = 45;
		GUI.Label (new Rect (Screen.width / 3f, Screen.height / 20f, 
		                     Screen.width / 3f, Screen.height / 10f), "太空大战");

		if (GUI.Button (new Rect (Screen.width / 3f, Screen.height * 8 / 10f, 
		                          Screen.width / 3f, Screen.height / 15f), "开始游戏")) {
			Application.LoadLevel ("level1");
		}
	}
}
