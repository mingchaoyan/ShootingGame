using UnityEngine;
using System.Collections;

public class TitleScene : MonoBehaviour
{

	void OnGUI ()
	{
		float ratioW = System.Convert.ToSingle (Screen.width) / 540f;
		float ratioH = System.Convert.ToSingle (Screen.height) / 960f;
		GUI.matrix = Matrix4x4.TRS (new Vector3 (0, 0, 0), 
		                           Quaternion.identity, new Vector3 (ratioW, ratioH, 1));

		GUI.skin.label.fontSize = 40;
		GUI.skin.label.alignment = TextAnchor.LowerCenter;
		GUI.Label (new Rect (540f / 3f, 960f / 20f, 
		                     540f / 3f, 960f / 10f), "太空大战");

		GUI.skin.button.fontSize = 40;
		if (GUI.Button (new Rect (540f / 3f, 960f * 8 / 10f, 
		                          540f / 3f, 960f / 15f), "开始游戏")) {
			Application.LoadLevel ("level1");
		}

		GUI.matrix = Matrix4x4.identity;
	}
}
