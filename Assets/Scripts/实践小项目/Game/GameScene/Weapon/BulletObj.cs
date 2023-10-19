using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    //�ƶ��ٶ�
    public float moveSpeed = 50;
    //˭�������
    public TankBaseObj fatherObj;
    //��Ч����
    public GameObject effObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
    //�ͱ�����ײ����
    private void OnTriggerEnter(Collider other)
    {
        //�ӵ������������ᱬը
        //�ӵ��������ͬ��Ӫ��̹��ҲӦ�ñ�ը
        if (other.CompareTag("Cube")||
            other.CompareTag("Player")&&fatherObj.CompareTag("Monster")||
            other.CompareTag("Monster")&& fatherObj.CompareTag("Player"))
        {
            //�ж��Ƿ�����
            //�õ���������ϵ���ؽű� �����滻 
            //ͨ�������ȡ
            TankBaseObj obj = other.GetComponent<TankBaseObj>();
            if (obj != null)
                obj.Wound(fatherObj);
            //���ӵ�����ʱ ���Դ��� һ����ը��Ч
            if (effObj != null)
            {
                //������ը��Ч
                GameObject eff = Instantiate(effObj, this.transform.position, this.transform.rotation);
                //������Ч��С ����״̬
                AudioSource audioS = eff.GetComponent<AudioSource>();
                audioS.volume = GameDataMgr.Instance.musicData.soundValue;
                audioS.mute = !GameDataMgr.Instance.musicData.isOpenSound;

            }
            Destroy(this.gameObject);
        }
        
    }
    //����ӵ����
    public void SetFather(TankBaseObj obj)
    {
        fatherObj = obj;
    }
}
