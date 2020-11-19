using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDogObjectScript : MonoBehaviour
{
    private float m_Speed = 0;
    private Vector3 m_moveDir = Vector3.zero;

    private int m_maxCollisionTimes = 0;
    private int m_nowCollisionTimes = 0;

    private bool m_isFlying = false;

    public CDogController m_dogController;
    public int DogNum;

    private float m_specialCollisionMoveRatio = 0.4f;

    public void StartMove(Vector3 moveDir, float speed, int maxCollisionTimes)
    {
        m_maxCollisionTimes = maxCollisionTimes;
        m_nowCollisionTimes = 0;

        m_Speed = speed;
        m_moveDir = moveDir;

        m_isFlying = true;
    }

    private void FixedUpdate()
    {
        if (m_isFlying)
        {
            transform.Translate(m_moveDir * m_Speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (m_isFlying)
        {
            Vector3 collNormal = collision.GetContact(0).normal;
            Vector3 newMoveDir = Vector3.Reflect(m_moveDir, collNormal);

            newMoveDir = new Vector3(newMoveDir.x, 0, newMoveDir.z).normalized;

            m_moveDir = newMoveDir;

            m_nowCollisionTimes++;
            if (m_nowCollisionTimes >= m_maxCollisionTimes)
            {
                m_isFlying = false;
                m_dogController.ShootingEnded(DogNum);

                transform.Translate(collNormal * m_specialCollisionMoveRatio);
            }
        }
    }
}
