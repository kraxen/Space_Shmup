using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс, в котором описано поведение кораблей противников
/// </summary>
public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    public float speed = 10f; // Скорость в м/с
    public float fireRate = 0.3f; // Секунд между выстрелами (не используется)
    public float health = 10; // Здоровье
    public int score = 100; // Очки за уничтожение этого корабля

    private BoundsCheck bndCheck;

    /// <summary>
    /// Свойство для доступа к позиции
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
            // Корабль за нижней границей экрана, поэтому его нужно уничтожить
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Реализация смерти кораблей от выстрелов
    /// </summary>
    /// <param name="coll">снаряд</param>
    private void OnCollisionEnter(Collision coll)
    {
        GameObject otherGo = coll.gameObject;
        if(otherGo.tag == "ProjectileHero")
        {
            Destroy(gameObject); // Уничтожить корабль противника
            Destroy(otherGo);   // Уничтожить снаряд
        }
        else
        {
            print("Enemy hit by non-ProjectileHero: " + otherGo.name);
        }
    }
}
