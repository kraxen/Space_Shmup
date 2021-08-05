using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ��� �������� � ������������ ����
using static Weapon;

public class Main : MonoBehaviour
{
    static public Main S;   // ������ ��������
    static Dictionary<WeaponType, WeaponDefinition> WEAP_DICT;

    [Header("Set in Inspector")]
    public GameObject[] prefabEnemies;  //������ �������� Enemy
    public float enemySpawnPerSecond = 0.5f; // ��������� �������� � �������

    public float enemyDefaultPadding = .5f; // ������ ��� ����������������

    public WeaponDefinition[] weaponDefinition;

    private BoundsCheck bndCheck;

    private void Awake()
    {
        S = this;
        bndCheck = GetComponent<BoundsCheck>();
        // �������� SpawnEnemy() ���� ��� � 2 ������� ��� ��������� �� ���������
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);

        // ������� � ������� ���� WeaponType
        WEAP_DICT = new Dictionary<WeaponType, WeaponDefinition>();
        foreach(WeaponDefinition def in weaponDefinition)
        {
            WEAP_DICT[def.type] = def;
        }
    }

    public void SpawnEnemy()
    {
        // ������� ��������� ������ Enemy ��� ��������
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

        // ���������� ��������� ������� ��� ������� � ��������� ������� x
        float enemyPadding = enemyDefaultPadding;
        if(go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        // ���������� ��������� ���������� ���������� ���������� �������
        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax = bndCheck.camWidth - enemyPadding;
        pos.x = Random.Range(xMin, xMax);
        pos.y = bndCheck.camHeight + enemyPadding;
        go.transform.position = pos;

        // ����� ������� SpawnEnemy()
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }
    /// <summary>
    /// ����� ����������� ���� ����� delay �����
    /// </summary>
    public void DelayedRestart(float delay)
    {
        Invoke("Restart", delay);
    }

    /// <summary>
    /// ����� ����������� ����
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene("_Scene_0");
    }

    /// <summary>
    /// ����������� �������, ������������ WeaponDefinition �� WEAP_DICT 
    /// </summary>
    /// <returns>
    /// ��������� WeaponDefinition �� WeaponType, ���� ���, �� ����� ���������
    /// </returns>
    /// <param name="wt">��� ������, ��� �������� ��������� �������� WeaponDefinition</param>
    /// <returns></returns>
    static public WeaponDefinition GetWeaponDefinition(WeaponType wt)
    {
        // ��������� ������� ��������� ����� � �������, ���� ������, �� ������� WeaponDefinition � ����� none
        if (WEAP_DICT.ContainsKey(wt))
        {
            return WEAP_DICT[wt];
        }

        return new WeaponDefinition();
    }

    //    // Start is called before the first frame update
    //    void Start()
    //    {

    //    }

    //    // Update is called once per frame
    //    void Update()
    //    {
    //}
}
