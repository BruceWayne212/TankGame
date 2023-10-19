using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterObj : TankBaseObj
{
    //Ҫ��̹�� ��������֮�� �����ƶ�
    //��ǰ��Ŀ���
    private Transform targetPos;
    //����õĵ� ����ȥ����
    public Transform[] randomPos;
    //̹��Ҫһֱ�����Լ���Ŀ��
    public Transform lookTarget;
    //������һ����Χ���� ���һ��ʱ�� ����һ��Ŀ��
    public float fireDis = 5;
    //Ϊ�˱��� ���� ���� ����ʱ����
    public float fireOffsetTime = 1;
    private float nowTime = 0;

    //����� 
    public Transform[] shootPos;
    //�ӵ�Ԥ����
    public GameObject bulletObj;

    //����Ѫ��ͼ �������
    public Texture maxHpBK;
    public Texture hpBK;

    //��ʾѪ����ʱ�õ�ʱ��
    private float showTime;
    //�ṹ�岻��new ֱ�Ӹ�ֵ
    private Rect maxHpRect;
    private Rect hpRect;


    // Start is called before the first frame update
    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        #region �����֮�������ƶ�
        //�����Լ���Ŀ���
        this.transform.LookAt(targetPos);
        //��ͣ�����Լ����泯���ƶ�
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        //�������Сʱ����Ϊ����Ŀ�ĵ� ���������һ����
        if (Vector3.Distance(this.transform.position, targetPos.position) < 0.05f)
        {
            RandomPos();
        }
        #endregion

        #region �����Լ���Ŀ��
        if (lookTarget != null)
        {
            tankHead.LookAt(lookTarget);
            //���Լ���Ŀ����� С�ڵ��� ���õĿ������ʱ
            if (Vector3.Distance(this.transform.position, lookTarget.position) <= fireDis)
            {
                nowTime += Time.deltaTime;
                if (nowTime >= fireOffsetTime)
                {
                    Fire();
                    nowTime = 0;

                }
            }
        }
        #endregion


    }
    private void RandomPos()
    {
        if (randomPos.Length == 0)
            return;
        targetPos = randomPos[Random.Range(0, randomPos.Length)];
    }
    public override void Fire()
    {
       for(int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            //�����ӵ���ӵ��������֮����˺�����
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetFather(this);
        }
    }
    public override void Dead()
    {
        base.Dead();
        //�ƶ���������ʱ ��Ҫ�ӷ�
        GamePanel.Instance.AddScore(10);
    }
    //���������Ѫ��UI�Ļ���
    private void OnGUI()
    {
        if (showTime > 0)
        {
            //��ͣ��ʱ
            showTime -= Time.deltaTime;

            //����Ѫ��
            //1.�ѹ��ﵱǰλ�� ת���� ��Ļλ��
            //����������ṩ��api ����������ת������Ļ����
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            //2��Ļλ�� ת����GUI λ��
            //�õ���ǰ��Ļ�ֱ��ʵĸ�
            screenPos.y = Screen.height - screenPos.y;

            //���л��� GUI��ͼƬ����
            maxHpRect.x = screenPos.x - 50;
            maxHpRect.y = screenPos.y - 50;
            maxHpRect.width = 100;
            maxHpRect.height = 15;
            //����ͼ
            GUI.DrawTexture(maxHpRect, maxHpBK);

            hpRect.x = screenPos.x - 50;
            hpRect.y = screenPos.y - 50;
            hpRect.width = (float)hp / maxHp * 100f;
            hpRect.height = 15;
            //��Ѫ��
            GUI.DrawTexture(hpRect, hpBK);
        }


    }
    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        //����Ѫ����ʾ��ʱ��
        showTime = 3;
    }
}
