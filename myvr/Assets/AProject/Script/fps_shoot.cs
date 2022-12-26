using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps_shoot : MonoBehaviour
{
    public GameObject BulletPrefab; //inspector���� prefab�� drap drop
    public int bulletSpeed = 3000;
    AudioSource Audio;
    public AudioClip ShootSound;


    // Start is called before the first frame update
    void Start()
    {
        Audio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.G)|| OVRInput.GetDown(OVRInput.Button.Two)) //���� ���콺 ��ư�� ������
        {
            print("shoot");
            GameObject Bullet = InstantiateBullet(); //�Ѿ� ����

            Bullet.GetComponent<Rigidbody>().AddForce(Bullet.transform.forward * bulletSpeed); //�ش� �������� ���� ���� ������ 
            Destroy(Bullet, 1.5f);



        }

    }

    GameObject InstantiateBullet()
    {
        GameObject Shooter = gameObject; //���� ��ũ��Ʈ�� �Ҵ�Ǵ� object
        Vector3 ClonePos = Shooter.transform.position + Shooter.transform.forward * 1.4f; //��ġ ����
        Quaternion CloneRot = Shooter.transform.rotation;  //��� ������ �ٶ󺸰� �ִ���
        GameObject Clone = Instantiate(BulletPrefab, ClonePos, CloneRot);

        return Clone;
    }

    void PlayClip(AudioClip clip)
    {
        Audio.clip = clip;
        Audio.Play();
    }
}
