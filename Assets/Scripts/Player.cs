using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/Player")]
public class Player : MonoBehaviour {
    public float m_speed = 1;
    public Transform m_rocket;
    protected Transform m_transform;
    float m_rocketRate = 0;
    public float m_life = 3;
	
	public AudioClip m_shootClip;
	protected AudioSource m_audio;
	public Transform m_explosionFx;
	

	// Use this for initialization
	void Start () {
        m_transform = this.transform;
		m_audio = this.audio;
	}
	
	// Update is called once per frame
	void Update () {
        float movez = 0;
        float movex = 0;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            movez -= m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            movez += m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            movex += m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            movex -= m_speed * Time.deltaTime;
        }

        this.transform.Translate(new Vector3(movex, 0, movez));

        m_rocketRate -= Time.deltaTime;
        if (m_rocketRate <= 0)
        {
            m_rocketRate = 0.1f;
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) || Input.GetKey(KeyCode.Return))
            {
                Instantiate( m_rocket, m_transform.position, m_transform.rotation);
				m_audio.PlayOneShot(m_shootClip);
            }
        }
	}

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag.CompareTo("Enemy") == 0 
            || other.tag.CompareTo("SuperEnemy") == 0 
            || other.tag.CompareTo("EnemyRocket") == 0)
        {
            Debug.Log("OnTriggerEnter");
            m_life -= 1;

            if (m_life <= 0)
            {
				Instantiate(m_explosionFx, m_transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        } 
    }
}
