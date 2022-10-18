using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �༺�� ������(��) ���� �ݽð� �������� ȸ���ϰ� �ʹ�.
// z ���⸦ �����ϰ� �ʹ�.
public class KJH_PlanetRotation : MonoBehaviour
{
    public Transform sunLight;      // �¾� ��
    public Transform axis;          //������
    public Transform planet;        // �༺
    public float axialTilt = 0f;    // ������ ����
    public float rotAngle = 1f;     // ���� ����

    // Start is called before the first frame update
    void Start()
    {
        axis.localRotation = Quaternion.Euler(0, 0, axialTilt);
    }

    // Update is called once per frame
    void Update()
    {
        // ������ ����
        axialTilt = Mathf.Clamp(axialTilt, 22.5f, 24.5f);
        axis.localRotation = Quaternion.Euler(-axialTilt, 0, 0);

        // �༺ ����
        planet.Rotate(0, -rotAngle, 0);

        // �¾� ���� �׻� ������ ������
        if (sunLight)
        {
            sunLight.LookAt(transform.position);
        }
    }
}
