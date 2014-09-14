using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/Player")]
public class Player : MonoBehaviour {
    public float m_speed = 1;
    public Transform m_rocket;
    protected Transform m_transform;
    float m_rocketRate = 0;
    public float m_life = 3;

	// Use this for initialization
	void Start () {
        m_transform = this.transform;
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
            }
        }
	}

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag.CompareTo("Enemy") == 0)
        {
            m_life -= 1;

            if (m_life <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
