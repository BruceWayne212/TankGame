using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_PropType
{
    //�����Ե�4������
    Atk,
    Def,
    MaxHp,
    Hp,
}
public class PropRewardWeapon : MonoBehaviour
{
    public E_PropType type = E_PropType.Atk;
    //Ĭ����ӵ�ֵ ��ȡ���ߺ�
    public int changeValue = 2;
    //��ȡ��Ч
    public GameObject getEff;
    private void OnTriggerEnter(Collider other)
    {
        //ֻ����Ҳ���ʰȡ
        if (other.CompareTag("Player")) {
            //�õ���Ӧ����ҽű�
            PlayerObj playerObj = other.GetComponent<PlayerObj>();
            //�����������������
            switch (type)
            {
                case E_PropType.Atk:
                    playerObj.atk += changeValue;
                    break;
                case E_PropType.Def:
                    playerObj.def += changeValue;
                    break;
                case E_PropType.Hp:
                    playerObj.hp += changeValue;
                    //��Ѫ���ܳ�������
                    if (playerObj.hp > playerObj.maxHp)
                        playerObj.hp = playerObj.maxHp;
                    //����Ѫ��
                    GamePanel.Instance.UpdateHP(playerObj.maxHp, playerObj.hp);
                    break;
                case E_PropType.MaxHp:
                    playerObj.maxHp += changeValue;
                    //����Ѫ��
                    GamePanel.Instance.UpdateHP(playerObj.maxHp, playerObj.hp);
                    break;
            }
            //����һ��������Ч
            GameObject eff = Instantiate(getEff, this.transform.position, this.transform.rotation);
            //���ƻ�ȡ��Ч
            AudioSource audioS = eff.GetComponent<AudioSource>();
            //��С�Ϳ���״̬
            audioS.volume = GameDataMgr.Instance.musicData.soundValue;
            audioS.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            Destroy(this.gameObject);
        }

    }

}
