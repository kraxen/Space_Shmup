using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    /// <summary>
    /// �����-��������� ������� ���������� �� Enemy, ���� �������� �� ���������
    /// </summary>
    public class Enemy_1 : Enemy
    {
        [Header("Set in Inspector: Enemy_1")]
        // ����� ������ ������� ����� ���������
        public float waveFrequency = 2;
        // ������ ��������� � ������
        public float waveWidth = 4;
        public float waveRotY = 45;

        private float x0; // ��������� ��������� ���������� x
        private float birthTime;

        // ���������� ����� Start(), �.�. �� �� ������������ � �������� Enemy � �� ����� ����������
        void Start()
        {
            // ���������� ��������� ���������� X ������� Enemt_1
            x0 = pos.x;

            birthTime = Time.time;
        }

        // �������������� ������� Move() ����������� Enemy
        public override void Move()
        {
            // �.�. pos ��� ��������, ������� ������ ������ ��������, ������� ��� � ������� Vector3
            Vector3 tempPos = pos;

            // �������� theta ���������� � �������� �������
            float age = Time.time - birthTime;
            // ������� ���������
            float theta = Mathf.PI * 2 * age / waveFrequency;
            float sin = Mathf.Sin(theta);
            tempPos.x = x0 + waveWidth * sin;
            // �������� �������
            pos = tempPos;

            // ��������� ������� ������������ ��� y
            Vector3 rot = new Vector3(0, sin * waveRotY, 0);
            this.transform.rotation = Quaternion.Euler(rot);

            // ������������ �������� ���� ����� ��� Y
            base.Move();
        }
    }
