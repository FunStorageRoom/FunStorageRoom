using UnityEngine;

public class PhoneTrigger : MonoBehaviour
{
    private PhoneReceiver phoneReceiver;

    void Start()
    {
        // PhoneReceiver 스크립트 가져오기
        phoneReceiver = GetComponent<PhoneReceiver>();
    }

    void OnTriggerEnter(Collider other)
    {
        // 트리거에 들어온 오브젝트가 플레이어라면
        if (other.CompareTag("Player"))
        {
            phoneReceiver.PickUpReceiver();
        }
    }

    void OnTriggerExit(Collider other)
    {
        // 트리거에서 나간 오브젝트가 플레이어라면
        if (other.CompareTag("Player"))
        {
            phoneReceiver.HangUpReceiver();
        }
    }
}
