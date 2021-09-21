using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �v���C���[�X�e�[�^�X
    public float HeartBeat;
    public bool tired;
    float tiredTimer;

    // �ړ��ϐ�
    float x, z; // ���W
    [SerializeField] float initSpeed; // �������x
    float speed; // �ړ����x

    // �J�����֘A�ϐ�
    public GameObject cam; // �J�����I�u�W�F�N�g
    Quaternion cameraRot, charaRot; // �J�����ƃL�����N�^�[
    float xScensityvity = 3f, yScensityvity = 3f; // �J���������ړ����x
    float fieldViw;

    public GameObject Light; // �����d��
    bool LightFlg; // �����d���I���I�t�t���O
    public float LightBattery; // �����d���o�b�e���[

    // Start is called before the first frame update
    void Start()
    {
        // �eQuaternion��ݒ�
        cameraRot = cam.transform.localRotation;
        charaRot = transform.localRotation;

        // �����d�����I�t
        LightFlg = true;
        // �����d���̃o�b�e���[��������
        LightBattery = 100;

        // �S�����̏�����
        HeartBeat = 0;

        // ��J�t���O�̏�����
        tired = false;

    }

    // Update is called once per frame
    void Update()
    {
        // �L�[�̓��͂ɉ����Ĉړ�
        x = z = 0;
        x = Input.GetAxisRaw("Horizontal") * speed;
        z = Input.GetAxisRaw("Vertical") * speed;

        //transform.position += new Vector3(x,0,z);
        transform.position += cam.transform.forward * z + cam.transform.right * x;

        //Debug.Log("�S���� : " + HeartBeat);

        // �}�E�X�̈ړ����W�ɉ����ĕ����ϊ�
        float xRot = Input.GetAxis("Mouse X") * yScensityvity;
        float yRot = Input.GetAxis("Mouse Y") * xScensityvity;

        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        charaRot *= Quaternion.Euler(0, xRot, 0);

        cam.transform.localRotation = cameraRot;
        transform.localRotation = charaRot;
        Light.transform.localRotation = cameraRot;



        // �����d���؂�ւ�
        if (Input.GetKeyDown(KeyCode.F))
        {
            // �����d���̐؂�ւ�
            LightFlg = LightFlg ? false : true;
        }

        // �o�b�e���[����
        if (LightFlg)
        {
            LightBattery-=0.001f;
            // 0�ȉ��ɂȂ�Ȃ��悤��
            if (LightBattery < 0) LightBattery = 0;
        }

        // �o�b�e���[��0�����������
        if (LightBattery <= 0) LightFlg = false;

        Light.SetActive(LightFlg);


        /********************/


        /********************/
    }

    private void FixedUpdate()
    {



        // �_�b�V��
        // �V�t�g���������Ă��Ȃ�������
        if (Input.GetKey(KeyCode.LeftShift) && !tired)
        {
            // �ړ����x�𑬂�
            speed = initSpeed * 1.5f;
            // ����p�𒲐�
            if (fieldViw < 10) fieldViw += ( Time.deltaTime * 70);

            // �S�����̏㏸
            HeartBeat += 0.1f;
        }
        else
        {
            // �ړ����x��������
            speed = initSpeed;
            // ����p�𒲐�
            if (fieldViw > 0) fieldViw -= ( Time.deltaTime * 70);

            //�S�����̒ቺ
            HeartBeat -= 0.12f;
        }

        // ����p�𒲐�
        cam.GetComponent<Camera>().fieldOfView = 60 + fieldViw;

        // �S������10�ɒB���������
        if (HeartBeat > 120)tired = true;
        // ���Ă���5�b�o�������J��
        if (tired)
        {
            tiredTimer += Time.deltaTime;
            if (tiredTimer > 5)
            {
                tired = false;
                tiredTimer = 0;
            }
        }

        //�S������0�ȉ��ɂȂ�Ȃ��悤��
        if (HeartBeat < 0) HeartBeat = 0;


    }

    // �o�b�e���[�𑝂₷
    public void BatteryPlus(float _plus)
    {
        // �o�b�e���[�𑝂₷
        LightBattery += _plus;
        // �ő�l�ȏゾ������ő�l�ɌŒ肷��
        if (LightBattery > 100) LightBattery = 100;
    }
}
