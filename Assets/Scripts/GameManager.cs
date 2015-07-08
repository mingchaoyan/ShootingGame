using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/GameManager")]
public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	public int m_score = 0;
	protected Player m_player;
	public AudioClip m_musicClip;
	protected AudioSource m_Audio;

	void Awake ()
	{
		Instance = this;
	}

	void Start ()
	{
		m_Audio = this.audio;
		GameObject obj = GameObject.FindGameObjectWithTag ("Player");
		if (obj != null) {
			m_player = obj.GetComponent<Player> ();
		}
	}
	
	void Update ()
	{
		if (!m_Audio.isPlaying) {
			m_Audio.clip = m_musicClip;
			m_Audio.Play ();
           
		}

		if (Time.timeScale > 0 && Input.GetKeyDown (KeyCode.Escape)) {
			Time.timeScale = 0;
		}
	}

	void OnGUI ()
	{
		float ratioW = System.Convert.ToSingle (Screen.width) / 540f;
		float ratioH = System.Convert.ToSingle (Screen.height) / 960f;
		GUI.matrix = Matrix4x4.TRS (new Vector3 (0, 0, 0), 
		                           Quaternion.identity, new Vector3 (ratioW, ratioH, 1));

		if (Time.timeScale == 0) {
			GUI.skin.button.fontSize = 40;
			if (GUI.Button (new Rect (540 * 0.5f - 540f / 3 / 2, 960 * 0.4f, 540f / 3f, 960f / 15f), 
			                "继续游戏")) {
				Time.timeScale = 1;
			}

			GUI.skin.button.fontSize = 40;
			if (GUI.Button (new Rect (540 * 0.5f - 540f / 3 / 2, 960 * 0.6f, 540f / 3f, 960f / 15f), 
			                "退出游戏")) {
				Application.Quit ();
			}
		}
        
		int life = 0;
		if (m_player != null) {
			life = (int)m_player.m_life;
		} else { 
			GUI.skin.label.fontSize = 50;
			GUI.skin.label.alignment = TextAnchor.LowerCenter;
			GUI.Label (new Rect (0, 960 * 0.5f, 540, 100), "游戏失败");

			GUI.skin.button.fontSize = 40;
			if (GUI.Button (new Rect (540f / 3f, 960f * 8 / 10f, 540f / 3f, 960f / 15f), 
			                "再试一次")) {
				Application.LoadLevel (Application.loadedLevelName);
			}
		}

		GUI.skin.label.fontSize = 40;
		GUI.Label (new Rect (5, 5, 100, 100), "装甲 " + life);

		GUI.skin.label.fontSize = 40;
		GUI.Label (new Rect (540f / 2f - 50, 5, 100, 100), "得分 " + m_score);

		GUI.matrix = Matrix4x4.identity;
	}

	public void AddScore (int point)
	{
		m_score += point;
	}
}
