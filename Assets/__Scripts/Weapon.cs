using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    /// <summary>
    /// Видо орудий
    /// </summary>
    public enum WeaponType
    {
        none,       // По умолчанию нет оружия
        blaster,    // Простой бластер
        spread,     // Веерная пушка, стреляющая несколькими снарядами
        phaser,     // [HP] Волновой лазер
        missile,    // [HP] Самонаводящиеся ракеты
        laser,      // [HP] Наносит повреждения при долговременном воздействии
        shield      // Увеличивает прочность щита shieldLevel
    }
    /// <summary>
    /// Класс WeaponDefinition позволяет настраивать свойства конкретного видо оружия в инспекторе. Для этого класс Main
    /// будет хранить массив элементов типа WeaponDefinition.
    /// </summary>
    [System.Serializable]
    public class WeaponDefinition
    {
        public WeaponType type = WeaponType.none;
        public string letter;                       // Буква на кубике, изображающем бонус
        public Color color = Color.white;           // Цвет ствола оружия и кубика бонуса
        public GameObject projectilePerfab;         // Шаблон снарядов
        public Color projectileColor = Color.white; // Цвет снарядов
        public float damageOnHit = 0;               // Разрушающая мощность
        public float continuousDamage = 0;          // Степерь разрушения в секунду (для laser)
        public float dalayBetweenShots = 0;         // Время между снарядами
        public float velocity = 20;                 // Скорость полета снарядов
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
