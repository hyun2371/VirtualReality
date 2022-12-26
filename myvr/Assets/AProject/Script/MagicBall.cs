using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MagicBall : MonoBehaviour
{
    bool isShake = false;
    //��鸱 ���� x,y,z ������ ���� �ٲ�
    //�ʱ� ��ġ ���� ����
    Vector3 DefaultPosition;

    float shakeMultiplier = 0.1f;
    float shakeDuration = 1f;
    public GameObject Ball_Number, Ball_Answer;
    public AudioSource displaySound;

    string[] Answers =
    {   "예상치 못한 행운이 찾아오는 날입니다.",
        "오늘 힘든 시간만 버티면\n 큰 보상이 따를거에요",
        "타인으로부터 성취를\n 인정받을 수 있는 날입니다.",
        "새로운 것을 시작했지만 실익이 없어 아쉬울 수 있어요.\n 크게 얻으려면 시간이 필요하니\n 기다리세요.",
        "미뤄왔던 일을 시작하면\n 큰 성과를 낼 수 있는 날이에요."
    };

    // Start is called before the first frame update
    void Start()
    {
        DefaultPosition = transform.position;
        DisplayNumberBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L)|| OVRInput.GetDown(OVRInput.Button.Four))
            ShakeBall();
        ShakeOnCondition();
    }

    void ShakeOnCondition()
    {
        if (isShake)
        {   
            Vector3 RandomOffset = Random.insideUnitSphere;

            Vector3 RandomPosition = DefaultPosition + RandomOffset * shakeMultiplier;
            RandomPosition.z = DefaultPosition.z;
            transform.position = RandomPosition;
        }
    }

    void DisplayNumberBall()
    {
        Ball_Answer.SetActive(false);
        Ball_Number.SetActive(true);
    }

    void DisplayAnswerBall()
    {
        Ball_Answer.SetActive(true);
        Ball_Number.SetActive(false);
    }

    void DisplayAnswer()
    {
        string answer = Answers[Random.Range(0, Answers.Length)];
        GameObject Answer = GameObject.Find("Answer");
        Answer.GetComponent<TMP_Text>().text = answer;
        displaySound.Play();
    }

    public void ShakeBall()
    {
        StartCoroutine(IShakeUntil(shakeDuration));
    }
    //����
    IEnumerator IShakeUntil(float duration)
    {
        DisplayNumberBall();
        isShake = true;
        yield return new WaitForSeconds(duration);
        DisplayAnswer();
        isShake = false;
        DisplayAnswerBall();
    }

    
}
