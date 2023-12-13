using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float moveSpeed = 1;
    public float Jumpforce;
    public Animator anim;
    public Rigidbody rbody;
    public float rotationSpeed = 1;
    public float attackSpeed = 1f;

    public Transform SkillSpawnPoint;
    public GameObject SkillPrefab;
    public float SkillSpeed = 10;
    [SerializeField]
    GameObject[]ArrayOfGameObject;
    public float interactionRange = 5f;

    private float attackCooldown = 0f;
    private float inputH;
    private float inputV;
    private bool attack;
    private int currentWeaponIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();  
        rbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        EquipWeapon(currentWeaponIndex);
    }
    
        void RotatePlayer(float horizontalInput)
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;
            currentRotation.y += horizontalInput;
            transform.rotation = Quaternion.Euler(currentRotation);
        }

        void Attack()
            {
                var skill = Instantiate(ArrayOfGameObject[currentWeaponIndex], SkillSpawnPoint.position, SkillSpawnPoint.rotation);
                skill.GetComponent<Rigidbody>().velocity = SkillSpawnPoint.forward * SkillSpeed;
            }

        void EquipWeapon(int index)
            {
                // Disable all weapons
                for (int i = 0; i < ArrayOfGameObject.Length; i++)
                {
                    ArrayOfGameObject[i].SetActive(false);
                }

                // Enable the selected weapon
                ArrayOfGameObject[index].SetActive(true);
            }

    void SwitchWeapon(int direction)
        {
           // Increment or decrement the currentWeaponIndex based on the direction
            currentWeaponIndex += direction;

            // If the currentWeaponIndex is out of bounds, wrap it around
            if (currentWeaponIndex >= ArrayOfGameObject.Length)
            {
                currentWeaponIndex = 0;
                
            }
            else if (currentWeaponIndex < 0)
            {
                currentWeaponIndex = ArrayOfGameObject.Length - 1;
            }

            // Equip the new current weapon
            EquipWeapon(currentWeaponIndex);
            Debug.Log(ArrayOfGameObject[currentWeaponIndex]);
        }


    // Update is called once per frame
    void Update()
    {
        inputH = Input.GetAxis ("Horizontal");
        inputV = Input.GetAxis ("Vertical");

        anim.SetFloat("inputH",inputH);
        anim.SetFloat("inputV",inputV);
        anim.SetBool("attack",attack);

        float moveX = -inputH*20f*Time.deltaTime;
        float moveZ = -inputV*50f*Time.deltaTime;

        
        float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;
        RotatePlayer(horizontalInput);

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            RotatePlayer(-rotationSpeed/2);
        }

        if (Input.GetKey(KeyCode.D))
        {
            RotatePlayer(rotationSpeed/2);
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("run",true);
            moveSpeed = 4;
        }
        else
        {
            anim.SetBool("run",false);
            moveSpeed = 1;
        }


        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("jump",true);
            rbody.velocity = new Vector3(0f,Jumpforce,0f);
        }
        else
        {
            anim.SetBool("jump",false);
        }
        
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            attack = true;
            anim.SetBool("attack",true);
        }
        else
        {
            attack = false;
            anim.SetBool("attack",false);
        }

        if (attackCooldown <= 0f)
            {
                attackCooldown = 0f;

                
            }  
        else if(attackCooldown > 0f)
        {
            attackCooldown -= 0.5f* Time.deltaTime;
        }

        if(attack == true)
        {
            if(attackCooldown == 0f)
            {
                Attack();
                attackCooldown = attackSpeed;
            }
            else
            {
                 Debug.Log("Skill is CoolDown :"+attackCooldown+"s");
            }
        }
        // Switch to the next weapon when the mouse wheel is scrolled up
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            SwitchWeapon(1);
            //Debug.Log(ArrayOfGameObject[currentWeaponIndex].name);
        }
        // Switch to the previous weapon when the mouse wheel is scrolled down
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            SwitchWeapon(-1);
            //Debug.Log(ArrayOfGameObject[currentWeaponIndex].name);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactionRange))
            {
                RewardScript script = hit.transform.GetComponent<RewardScript>();
                if (script != null && script.interactableType == InteractableType.Reward)
                {
                    script.ActivateReward();
                }
            }
        }

        

    }
}
    


