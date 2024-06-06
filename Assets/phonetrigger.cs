using UnityEngine;

public class PhoneTrigger : MonoBehaviour
{
    private PhoneReceiver phoneReceiver;

    void Start()
    {
        // PhoneReceiver ��ũ��Ʈ ��������
        phoneReceiver = GetComponent<PhoneReceiver>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Ʈ���ſ� ���� ������Ʈ�� �÷��̾���
        if (other.CompareTag("Player"))
        {
            phoneReceiver.PickUpReceiver();
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Ʈ���ſ��� ���� ������Ʈ�� �÷��̾���
        if (other.CompareTag("Player"))
        {
            phoneReceiver.HangUpReceiver();
        }
    }
}
