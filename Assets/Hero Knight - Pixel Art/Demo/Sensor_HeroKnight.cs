using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sensor_HeroKnight : MonoBehaviour {

    private int m_ColCount = 0;

    private float m_DisableTimer;

    List<GameObject> m_collided;

    private void OnEnable()
    {
        m_ColCount = 0;
        m_collided = new List<GameObject>();
    }

    public bool State()
    {
        if (m_DisableTimer > 0)
            return false;
        return m_ColCount > 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        m_ColCount++;
        m_collided.Add(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        m_ColCount--;
        m_collided.Remove(other.gameObject);
    }

    void Update()
    {
        m_DisableTimer -= Time.deltaTime;
    }

    public void Disable(float duration)
    {
        m_DisableTimer = duration;
    }

    public GameObject[] GetAllColliders()
    {
        return m_collided.ToArray();
    }

    public void ClearColliders()
    {
        m_collided.Clear();
    }
}
