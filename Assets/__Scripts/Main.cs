using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Для загрузки и перезагрузки сцен
using static Weapon;

public class Main : MonoBehaviour
{
    static public Main S;   // Объект одиночка
    static Dictionary<WeaponType, WeaponDefinition> WEAP_DICT;

    [Header("Set in Inspector")]
    public GameObject[] prefabEnemies;  //Массив шаблонов Enemy
    public float enemySpawnPerSecond = 0.5f; // Вражеских кораблей в секунду

    public float enemyDefaultPadding = .5f; // Отступ для позиционирования

    public WeaponDefinition[] weaponDefinition;

    private BoundsCheck bndCheck;

    private void Awake()
    {
        S = this;
        bndCheck = GetComponent<BoundsCheck>();
        // Вызывать SpawnEnemy() один раз в 2 секунды при значениях по умолчанию
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);

        // Словарь с ключами типа WeaponType
        WEAP_DICT = new Dictionary<WeaponType, WeaponDefinition>();
        foreach(WeaponDefinition def in weaponDefinition)
        {
            WEAP_DICT[def.type] = def;
        }
    }

    public void SpawnEnemy()
    {
        // Выбрать случайный шаблон Enemy для создания
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

        // Разместить вражеский корабль над экраном в случайной позиции x
        float enemyPadding = enemyDefaultPadding;
        if(go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        // Установить начальные координаты созданного вражеского корабля
        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax = bndCheck.camWidth - enemyPadding;
        pos.x = Random.Range(xMin, xMax);
        pos.y = bndCheck.camHeight + enemyPadding;
        go.transform.position = pos;

        // Снова вызвать SpawnEnemy()
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }
    /// <summary>
    /// Метод перезапуска игры через delay секуд
    /// </summary>
    public void DelayedRestart(float delay)
    {
        Invoke("Restart", delay);
    }

    /// <summary>
    /// Метод перезапуска игры
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene("_Scene_0");
    }

    /// <summary>
    /// Статическая функция, возвращающая WeaponDefinition из WEAP_DICT 
    /// </summary>
    /// <returns>
    /// Экземпляр WeaponDefinition по WeaponType, если нет, то новый экземпляр
    /// </returns>
    /// <param name="wt">Тип оружия, для которого требуется получить WeaponDefinition</param>
    /// <returns></returns>
    static public WeaponDefinition GetWeaponDefinition(WeaponType wt)
    {
        // Проверить наличие указнного ключа в словаре, если ошибка, то вернуть WeaponDefinition с типом none
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
