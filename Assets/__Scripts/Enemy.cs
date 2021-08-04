using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����, � ������� ������� ��������� �������� �����������
/// </summary>
public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    public float speed = 10f; // �������� � �/�
    public float fireRate = 0.3f; // ������ ����� ���������� (�� ������������)
    public float health = 10; // ��������
    public int score = 100; // ���� �� ����������� ����� �������

    private BoundsCheck bndCheck;

    /// <summary>
    /// �������� ��� ������� � �������
    /// </summary>
    public Vector3 pos
    {
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }

    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }

    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if(bndCheck != null && bndCheck.offDown)
        {
            // ������� �� ������ �������� ������, ������� ��� ����� ����������
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// ���������� ������ �������� �� ���������
    /// </summary>
    /// <param name="coll">������</param>
    private void OnCollisionEnter(Collision coll)
    {
        GameObject otherGo = coll.gameObject;
        if(otherGo.tag == "ProjectileHero")
        {
            Destroy(gameObject); // ���������� ������� ����������
            Destroy(otherGo);   // ���������� ������
        }
        else
        {
            print("Enemy hit by non-ProjectileHero: " + otherGo.name);
        }
    }
}
