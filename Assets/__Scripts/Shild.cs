using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����, � ������� ������� ��������� ���� ������ �������
/// </summary>
public class Shild : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float rotationsPerSecond = 0.1f;

    [Header("Set Dynamiclly")]
    public int levelShown = 0;

    // ������� ����������, �� ������� � ����������
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // ��������� ������� �������� ��������� ���� �� �������-�������� Hero
        int currLevel = Mathf.FloorToInt(Hero.S.shieldLevel);
        // ���� ��� ���������� �� levelShown...
        if(levelShown != currLevel)
        {
            levelShown = currLevel;
            // ��������������� �������� � ��������, ����� ���������� ���� � ������ ���������
            mat.mainTextureOffset = new Vector2(0.2f * levelShown, 0);
        }
        // ������������ ���� � ������ ����� � ���������� ���������
        float rZ = -(rotationsPerSecond * Time.time * 360);
        transform.rotation = Quaternion.Euler(0, 0, rZ);
    }
}
