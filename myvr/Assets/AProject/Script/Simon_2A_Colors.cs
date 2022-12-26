using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simon_2A_Colors : MonoBehaviour
{
    Color DefaultColor; //����Ʈ ����
    Dictionary<string, Color> ActiveColors; //��ư ������ �� ǥ�õǴ� ����
    AudioSource Audio;
    bool isInterActive = true; //��ư ��Ȱ��ȭ
    float brightenDelay, darkenDelay; //��ư�� ���� �ִ� �ð�, ��ο� ���°� �����Ǵ� �ð�

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Init()
    {
        //����Ʈ; ���� ���� ������Ʈ���� ���� ������(������ ���)
        DefaultColor = GetComponent<Renderer>().material.color;

        //ä���� ���� ������ ��ųʸ����� ������
        ActiveColors = new Dictionary<string, Color>
        {
            {"Blue", Color.blue },
            {"Yellow", Color.yellow },
            {"Green", Color.green },
            {"Red", Color.red }
        };
        Audio = GetComponent<AudioSource>();
        isInterActive = true;
    }

    void PlayAudio()
    {
        Audio.Play();
    }

    public void Brighten()
    {
        GetComponent<Renderer>().material.color = ActiveColors[gameObject.name];
    }

    public void Darken()
    {
        GetComponent<Renderer>().material.color = DefaultColor;
    }


    IEnumerator IBlink() //������� ��ο�������
    {
        Brighten();
        yield return new WaitForSeconds(brightenDelay);

        Darken();
        yield return new WaitForSeconds(darkenDelay);
    }


    public void Blink(float brightenDelay, float darkenDelay)
    {
        PlayAudio();

        this.brightenDelay = brightenDelay;
        this.darkenDelay = darkenDelay;
        StartCoroutine(IBlink());  //�ڷ�ƾ���� ȣ��
    }

    public void SetColorsInteractableTo(bool inInteractive)
    {   //�÷� ������Ʈ�� Ȱ��ȭ/��Ȱ��ȭ
        this.isInterActive = inInteractive;
    }

    private void OnMouseDown()
    {
        if (isInterActive) //����� ����
        {   //��ư�� ��ο��
            if (GetComponent<Renderer>().material.color == DefaultColor)
            { //��ư ���� �� ����
                PlayAudio();
                Brighten();
            }
        }
    }

    private void OnMouseUp() //���콺���� ���� ���� ��
    {
        if (isInterActive) //�÷��̾���
        {
            Darken();
            AddColorToPlayersSequence();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isInterActive) //�÷��̾���
            {
                Darken();
                AddColorToPlayersSequence();
            }
        }

    }

    private void AddColorToPlayersSequence()
    {   //�÷��̾ ���� ���� ���� �°� �������� Ȯ��
        GameObject.Find("Game").GetComponent<SimonGame>().AddColorToPlayersSequence(gameObject.name);
    }
}