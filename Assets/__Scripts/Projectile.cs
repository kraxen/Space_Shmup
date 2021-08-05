using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;

public class Projectile : MonoBehaviour
{
    private BoundsCheck bndCheck;
    private Renderer rend;

    [Header("Set Dynamicly"]
    public Rigidbody rigit;

    [SerializeField]
    private WeaponType _type;

    /// <summary>
    /// ��������, ����������� �������� �������� ����� ����� SetType()
    /// </summary>
    public WeaponType type
    {
        get
        {
            return _type;
        }
        set
        {
            SetType(value);
        }
    }

    /// <summary>
    /// �������� _type � ������������� ���� �������
    /// </summary>
    /// <param name="value"></param>
    public void SetType(WeaponType eType)
    {
        _type = eType;
        WeaponDefinition def = Main.GetWeaponDefinition(_type);
        rend.material.color = def.projectileColor;
    }

    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bndCheck.offUp)
        {
            Destroy(gameObject);
        }
    }
}
