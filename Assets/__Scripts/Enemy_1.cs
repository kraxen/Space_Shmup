using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    /// <summary>
    /// Класс-наследник корабля противника от Enemy, враг движется по синусоиде
    /// </summary>
    public class Enemy_1 : Enemy
    {
        [Header("Set in Inspector: Enemy_1")]
        // число секунд полного цикла синусоиды
        public float waveFrequency = 2;
        // Ширина синусоиды в метрах
        public float waveWidth = 4;
        public float waveRotY = 45;

        private float x0; // Начальное положение координаты x
        private float birthTime;

        // Используем метод Start(), т.к. он не используется в родителе Enemy и не будет конфликтов
        void Start()
        {
            // Установить начальную координату X объекта Enemt_1
            x0 = pos.x;

            birthTime = Time.time;
        }

        // Переопределить функцию Move() суперкласса Enemy
        public override void Move()
        {
            // Т.к. pos это свойство, которое нельзя менять напрямую, получим его с помощью Vector3
            Vector3 tempPos = pos;

            // Значение theta изменяется с течением времени
            float age = Time.time - birthTime;
            // Функция синусоиды
            float theta = Mathf.PI * 2 * age / waveFrequency;
            float sin = Mathf.Sin(theta);
            tempPos.x = x0 + waveWidth * sin;
            // Изменить позицию
            pos = tempPos;

            // Повернуть немного относительно оси y
            Vector3 rot = new Vector3(0, sin * waveRotY, 0);
            this.transform.rotation = Quaternion.Euler(rot);

            // Обеспечивает движение вниз вдоль оси Y
            base.Move();
        }
    }
