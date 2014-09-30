using UnityEngine;
using System.Collections;


[AddComponentMenu("MyGame/Enemy")]
public class Enemy : MonoBehaviour
{
    public int m_point = 10;
    public float m_speed = 1;
    public float m_life = 10;
    public AudioClip m_explosionClip;
    protected AudioSource m_audio;
    public Transform m_exposionFX;

    protected float m_rotateSpeed = 30;

    protected float m_timer = 1.5f;

    protected Transform m_transform;

    // Use this for initialization
    void Start()
    {
        m_transform = this.transform;
        m_audio = this.audio;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMove();
    }

    protected virtual void UpdateMove()
    {
        m_timer -= Time.deltaTime;
        if (m_timer <= 0)
        {
            m_timer = 3;
            m_rotateSpeed = -m_rotateSpeed;
        }

        m_transform.Rotate(Vector3.up, m_rotateSpeed * Time.deltaTime, Space.World);

        m_transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("PlayerRocket") == 0)
        {
            Rocket rocket = other.GetComponent<Rocket>();
            if (rocket != null)
            {
                m_life -= rocket.m_power;
                if (m_life <= 0)
                {
                    GameManager.Instance.AddScore(m_point);
                    Instantiate(m_exposionFX, m_transform.position, Quaternion.identity);
                    m_audio.PlayOneShot(m_explosionClip);
                    Destroy(this.gameObject);
                }
            }
        }
        else if (other.tag.CompareTo("Player") == 0)
        {
            m_life = 0;
            Destroy(this.gameObject);
        }
        else if (other.tag.CompareTo("Bound") == 0)
        {
            m_life = 0;
            Destroy(this.gameObject);
        }
    }
}
