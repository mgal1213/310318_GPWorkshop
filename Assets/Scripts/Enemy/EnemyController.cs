using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private SoldierController m_soldierPrefab;

    [SerializeField]
    private int m_count;

    [SerializeField]
    private float m_radius = 15;

    private List<SoldierController> m_soldiers = new List<SoldierController>();

    private void Start()
    {
        for (int i = 0; i < m_count; i++)
        {
            var soldier = GameObject.Instantiate(m_soldierPrefab);
            soldier.transform.parent = transform;

            var x = Random.Range(-m_radius, m_radius);
            var y = Random.Range(-m_radius, m_radius);

            var targetPosition = transform.localPosition + new Vector3(x, 0, y);
            targetPosition.y = -2.81135f;
            soldier.transform.localPosition = targetPosition;
            m_soldiers.Add(soldier);
        }
    }
}

