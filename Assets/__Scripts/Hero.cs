using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero S; // Одиночка
    [Header("Set in Inspector")]
    public float speed = 30;
    public float rollMult = -45;
    public float pichMult = 30;

    [Header("Set Dynamiclly")]
    public float shildLevel = 1;

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
        pos.x = xAxis * speed * Time.deltaTime;
        pos.y = yAxis * speed * Time.deltaTime;
        transform.position = pos;

        // Повернуть корабль, чтобы придать ощущение динамики
        transform.rotation = Quaternion.Euler(yAxis * pichMult, xAxis * rollMult,0);
    }
}
