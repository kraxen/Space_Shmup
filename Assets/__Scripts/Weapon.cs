using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    /// <summary>
    /// ���� ������
    /// </summary>
    public enum WeaponType
    {
        none,       // �� ��������� ��� ������
        blaster,    // ������� �������
        spread,     // ������� �����, ���������� ����������� ���������
        phaser,     // [HP] �������� �����
        missile,    // [HP] ��������������� ������
        laser,      // [HP] ������� ����������� ��� �������������� �����������
        shield      // ����������� ��������� ���� shieldLevel
    }
    /// <summary>
    /// ����� WeaponDefinition ��������� ����������� �������� ����������� ���� ������ � ����������. ��� ����� ����� Main
    /// ����� ������� ������ ��������� ���� WeaponDefinition.
    /// </summary>
    [System.Serializable]
    public class WeaponDefinition
    {
        public WeaponType type = WeaponType.none;
        public string letter;                       // ����� �� ������, ������������ �����
        public Color color = Color.white;           // ���� ������ ������ � ������ ������
        public GameObject projectilePerfab;         // ������ ��������
        public Color projectileColor = Color.white; // ���� ��������
        public float damageOnHit = 0;               // ����������� ��������
        public float continuousDamage = 0;          // ������� ���������� � ������� (��� laser)
        public float dalayBetweenShots = 0;         // ����� ����� ���������
        public float velocity = 20;                 // �������� ������ ��������
    }


    [Header("Set Dynamicly")]
    [SerializeField]
    private WeaponType _type = WeaponType.none;
    public WeaponDefinition def;
    public GameObject collar;
    public float lastShotTime;
    private Renderer collarRend;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
