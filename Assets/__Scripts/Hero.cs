using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс, в котором описано движение по поворот корабля
/// </summary>
public class Hero : MonoBehaviour
{
    static public Hero S; // Одиночка
    [Header("Set in Inspector")]
    public float speed = 30;
    public float rollMult = -45;
    public float pichMult = 30;

    [Header("Set Dynamiclly")]
    [SerializeField]
    public float _shildLevel = 4;

    /// <summary>
    /// Ссыллка на последний объект с которым было столкновение
    /// </summary>
    private GameObject lastTriggerGo = null;

    private void Awake()
    {
        if (S == null)
        {
            S = this; // Сохранить ссылку на одиночку
        }
        else
        {
            Debug.LogError("Hero.Awake() - Попытка назначить второго Hero.S!");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Извлечь информацию из класса Input
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        // Изменить transform.position, опираясь на информацию по осям
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        // Повернуть корабль, чтобы придать ощущение динамики
        transform.rotation = Quaternion.Euler(yAxis * pichMult, xAxis * rollMult,0);
    }

    private void OnTriggerEnter(Collider other)
    {        
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        //print("Triggered: " + go.name);

        // Гарантировать невозможность повторного столкновения
        if(go == lastTriggerGo)
        {
            return;
        }
        lastTriggerGo = go;

        if(go.tag == "Enemy")   // Если защитное поле столкнулось с вражеским кораблем
        {                       //
            shieldLevel--;       // Уменьшить уровень защиты на 1
            Destroy(go);        // И уничтожить вражеский корабль
        }
        else
        {
            print("Triggered by non Enemy: " + go.name);
        }
    }

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
            }
        }
    }
}
