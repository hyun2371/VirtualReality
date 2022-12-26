using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimonGame : MonoBehaviour
{
    List<string> SimonsSequence, PlayersSequence;
    string[] Colors;
    bool isActive = true;
    public GameObject guideTmp;

    
    private void Update()
    {
        if (Input.GetKey(KeyCode.X)&&isActive|| OVRInput.GetDown(OVRInput.Button.Three) && isActive)
        {
            isActive = false;
            getStart();
        }
    }
    public void getStart()
    {
        getIntro();
        Invoke("getIntro2", 2f);
        Invoke("realStart", 4f);
    }

    public void realStart()
    {
        Init(); //�ʱ�ȭ
        PlaySimonsTurn(); //���̸� ���ʺ���
    }

    public void Restart()
    {
        Init();
        PlaySimonsTurn();
    }

    void Init()
    {
        SimonsSequence = new List<string>();
        PlayersSequence = new List<string>();
        Colors = new string[] { "Green", "Red", "Blue", "Yellow" };

        DisplayScore(0);
        //저장한 최대값 가져옴
        GameObject.Find("MaxScoreValue").GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("maxScore").ToString();
    }

    void DisplayScore(int score)
    {
        int maxScore = int.Parse(GameObject.Find("MaxScoreValue").GetComponent<TMP_Text>().text);
        //최고 기록 갱신
        if (score > maxScore)
        {
            maxScore = score; 
            PlayerPrefs.SetInt("maxScore", maxScore); 
        }
        GameObject.Find("ScoreValue").GetComponent<TMP_Text>().text = score.ToString();
        GameObject.Find("MaxScoreValue").GetComponent<TMP_Text>().text = maxScore.ToString();
    }


    //4���� ������Ʈ Ȱ��ȭ ���� ����
    void SetColorsInteractableTo(bool isInteractive)
    {
        foreach (string color in Colors)
        {
            GameObject.Find(color).GetComponent<Simon_2A_Colors>().SetColorsInteractableTo(isInteractive);
        }
    }

    void EndGame()
    {
        guideTmp.GetComponent <TMP_Text>().text = "Your Failed: Click x button to Restart.";
        print("Your Failed: Click x button to Restart.");
        SetColorsInteractableTo(false);
        isActive = true;
    }

    public void PlaySimonsTurn()
    {
        StartCoroutine(IPlaySimonsTurn());
    }


    IEnumerator IPlaySimonsTurn() //���̸� ����
    {
        SetColorsInteractableTo(false); //누를 수 없게

        string RandomColor = Colors[Random.Range(0, Colors.Length)]; 
        SimonsSequence.Add(RandomColor); 

        yield return new WaitForSeconds(1f); //wait for GameObject to be Active 

        for (int i = 0; i < SimonsSequence.Count; i++) //�ϳ��� ������
        {
            GameObject.Find(SimonsSequence[i]).GetComponent<Simon_2A_Colors>().Blink(0.2f, 0.3f); //0.2�� ������ 0.3�� ����
            yield return new WaitForSeconds(0.5f); 
        }
        SetColorsInteractableTo(true);
    }


    //시작 시 하나씩 불 밝힘
    void getIntro()
    {
        string[] cg = new string[] { "Blue", "Yellow", "Red", "Green" };
        for (int i = 0; i < 4; i++)
        {
            GameObject.Find(cg[i]).GetComponent<Simon_2A_Colors>().Brighten();

        }

    }
    //하나씩 불 밝힌 후 어둡게
    void getIntro2()
    {
        Debug.Log("Get ready for it!");
        string[] cg = new string[] { "Blue", "Yellow", "Red", "Green" };
        for (int i = 0; i < 4; i++)
        {
            GameObject.Find(cg[i]).GetComponent<Simon_2A_Colors>().Darken();

        }

    }


    public void AddColorToPlayersSequence(string PlayersColor)
    {
        StartCoroutine(IAddColorToPlayersSequence(PlayersColor));

    }

    IEnumerator IAddColorToPlayersSequence(string PlayersColor)
    {
        if (HasPlayerPressedTheRightColor(PlayersColor)) //�°� ��������
        {
            PlayersSequence.Add(PlayersColor);

            if (PlayersSequence.Count == SimonsSequence.Count) //�÷��̾ ���̸��� ������ ��ư ��� ����
            {
                DisplayScore(SimonsSequence.Count);
                PlayersSequence.Clear(); //���� ����� ���� ���� ����� �Է� �ʱ�ȭ
                PlaySimonsTurn(); //���̸��� ���ʷ� �ѱ�
            }
            yield return new WaitForSeconds(1f); //�� ���� ������ 1�ʰ� �����
        }

        else //�÷��̾ Ʋ���� ��
        {
            DisplayScore(SimonsSequence.Count - 1); //���� ���� ǥ��
            EndGame(); //���� ����
            getIntro();
            Invoke("getIntro2", 2);
            yield return new WaitForSeconds(1f);
        }
    }

    bool HasPlayerPressedTheRightColor(string PlayersColor) //������ ��ư�� ��������
    {
        if (PlayersColor == SimonsSequence[PlayersSequence.Count]) //�� ��
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
