using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SantaControl : MonoBehaviour
{

    private Rigidbody rigid;
    private bool IsGround = false;
    private bool IsPlatForm = false;

    //public float MoveSpeed;
    //public int MoveSpeed;
    public float JumpPower;
    public int JumpCount = 2;

    int count = 0;

    public Text countText;

    new private AudioSource audio;
    public AudioClip PresentSound;



    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        JumpCount = 0;

        countText.text = "Present: " + count.ToString(); ;

        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.PresentSound;
        this.audio.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        //SantaMove();
        SantaJump();

        if (GameObject.FindGameObjectsWithTag("Present").Length == 0)
        {
            SceneManager.LoadScene("Success");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Present")
        {
            Destroy(other.gameObject);
            this.audio.Play();
        }

        if (other.gameObject.CompareTag("Present"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            countText.text = "Present: " + count.ToString(); ;
        }
    }

    void SantaJump()
    {
        if (IsGround || IsPlatForm)
        {
            if (JumpCount > 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))   //�Է�Ű�� ��ȭ��ǥ�� ����
                {
                    rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse); //���������� �ö󰡰���

                    JumpCount--;    //�����Ҷ� ���� ����Ƚ�� ����
                }
            }
        }
    }


    /*void SantaMove()
   {
       float h = Input.GetAxis("Horizontal");
       float v = Input.GetAxis("Vertical");

       transform.Translate((new Vector3(h, 0, v) * MoveSpeed) * Time.deltaTime);
   }
   */

    /*
    void Santamove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
        }


        //��Ű ������ ������(������) �̵�, �Ʒ�Ű ������ �ڷ�(����) �̵�
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * MoveSpeed * Time.deltaTime);
        }
        
    }
    */

    private void OnCollisionEnter(Collision collision)
    {
        //CompareTag�� ���� ����Ƽ �۾�ȯ�濡�� Tag�� ��ũ��Ʈ ����� ������ �������� �ٲ� ���������� �Ѵ�.
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("PlatForm"))
        {
            IsGround = true;
            IsPlatForm = true;
            JumpCount = 2;
        }


        if(collision.gameObject.CompareTag("Present"))
        {
            GetComponent<ParticleSystem>().Play();
            TimerControl.selectCountdown += 7.0f;
        }



        if (collision.gameObject.CompareTag("Goblin"))
        {
            TimerControl.selectCountdown -= 10.0f;
        }
        else if(collision.gameObject.CompareTag("Rabbit"))
        {
            TimerControl.selectCountdown -= 5.0f;
        }
    }
}
