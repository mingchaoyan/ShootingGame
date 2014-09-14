using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/Rocket")]
public class Rocket : MonoBehaviour {
    public float m_speed = 10;
    public float m_livetime = 1;
    public float m_power = 1.0f;

    protected Transform m_transform;

	// Use this for initialization
	void Start () {
        m_transform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        m_livetime -= Time.deltaTime;
        if (m_livetime <= 0)
            Destroy(this.gameObject);

        m_transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("Enemy") != 0)
            return;
        Destroy(this.gameObject);
    }
}
