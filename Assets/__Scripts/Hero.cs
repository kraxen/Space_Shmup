using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����, � ������� ������� �������� �� ������� �������
/// </summary>
public class Hero : MonoBehaviour
{
    static public Hero S; // ��������
    [Header("Set in Inspector")]
    public float speed = 30;
    public float rollMult = -45;
    public float pichMult = 30;
    public float gameRestartDelay = 2f; // �����, ����� ������� �������������� ����
    public GameObject projectilePerfab; // Perfab �������
    public float projectileSpeed = 40;  // �������� �������

    [Header("Set Dynamiclly")]
    [SerializeField]
    public float _shildLevel = 4;

    /// <summary>
    /// �������� ��� ������� � _shieldLevel
    /// </summary>
    public float shieldLevel
    {
        get
        {
            return (_shildLevel);
        }
        set
        {
            _shildLevel = Mathf.Min(value, 4);
            if (value < 0)
            {
                Destroy(this.gameObject);
                Main.S.DelayedRestart(gameRestartDelay);
            }
        }
    }

    /// <summary>
    /// ������� �� ��������� ������ � ������� ���� ������������
    /// </summary>
    private GameObject lastTriggerGo = null;

    private void Awake()
    {
        if (S == null)
        {
            S = this; // ��������� ������ �� ��������
        }
        else
        {
            Debug.LogError("Hero.Awake() - ������� ��������� ������� Hero.S!");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ������� ���������� �� ������ Input
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        // �������� transform.position, �������� �� ���������� �� ����
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        // ��������� �������, ����� ������� �������� ��������
        transform.rotation = Quaternion.Euler(yAxis * pichMult, xAxis * rollMult,0);

        // ��������� ������� ����������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TempFire();
        }
    }

    private void TempFire()
    {
        GameObject projGo = Instantiate<GameObject>(projectilePerfab);
        projGo.transform.position = transform.position;
        Rigidbody rigitB = projGo.GetComponent<Rigidbody>();
        rigitB.velocity = Vector3.up * projectileSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {        
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        //print("Triggered: " + go.name);

        // ������������� ������������� ���������� ������������
        if(go == lastTriggerGo)
        {
            return;
        }
        lastTriggerGo = go;

        if(go.tag == "Enemy")   // ���� �������� ���� ����������� � ��������� ��������
        {                       //
            shieldLevel--;       // ��������� ������� ������ �� 1
            Destroy(go);        // � ���������� ��������� �������
        }
        else
        {
            print("Triggered by non Enemy: " + go.name);
        }
    }
}
