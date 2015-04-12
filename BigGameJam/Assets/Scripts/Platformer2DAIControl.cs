using UnityEngine;
using InControl;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets._2D;


    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DAIControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool m_Punch;

        public bool lostControl = false;
        private float h;

        private bool nextAttackIsPunch = true;

        private float timerUntilChange = 0f;
        private float timerUntilJump = 2f;

        public float damageTaken = 50f;
        public float life = 100f;

        public enum states {
            approach,
            attack,
            retreat,
        }

        public states state = states.approach;

        public void TakeDamage() {
            life -= damageTaken;
            if (life <= 0f) {
                gameObject.GetComponent<Animator>().SetBool("Die", true);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Retreat() {
            if (timerUntilJump > 0f)
                timerUntilJump -= Time.deltaTime;

            if (timerUntilChange > 0f)
                timerUntilChange -= Time.deltaTime;
            else
                state = states.approach;
            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
            if (Mathf.Abs(player.transform.position.x - transform.position.x) > 1.4f) {
                h = -0.5f * Mathf.Sign(player.transform.position.x - transform.position.x);
            }
            if (Random.Range(0f, 100f) < 50f && timerUntilJump <= 0f)
                m_Jump = true;
            else
                m_Jump = false;
        }

        private void Approach() {
            if (timerUntilChange > 0f)
                timerUntilChange -= Time.deltaTime;
            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
            if (Mathf.Abs(player.transform.position.x - transform.position.x) > 1.2f) {
                h = 0.3f * Mathf.Sign(player.transform.position.x - transform.position.x);
            } else {
                if (timerUntilChange <= 0f)
                    state = states.attack;
                else
                    h = 0f;
            }
        }

        private void Attack() {
            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
            if (nextAttackIsPunch) {
                m_Punch = true;
                if (player.transform.position.y - transform.position.y > 1.0)
                    m_Jump = true;
            }
            else {
                m_Jump = true;
                m_Punch = true;
            }
            nextAttackIsPunch = true;
            if (Random.Range(0f,100f) < 5f) {
                nextAttackIsPunch = false;
            }
            timerUntilChange = Random.Range(1f,3f);
            state = states.retreat;
        }

        private void Die()  {
            Destroy(gameObject);
        }

        private void Update()
        {

            if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("CharacterHurt") ) {
                lostControl = true;
            } else {
                lostControl = false;
            }
            if (life <= 0f) {
                lostControl = true;

            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = false;

            // Choose if we move horizontally
            h = 0.0f;
            if (!lostControl) {
                //float h = Random.Range(-1.0F, 1.0F);
                switch(state) {
                    case (states.approach):
                        Approach();
                        break;
                    case (states.attack):
                        Attack();
                        break;
                    case (states.retreat):
                        Retreat();
                        break;
                }

                // Pass all parameters to the character control script.
                m_Character.Move(h, crouch, m_Punch, m_Jump);
            }

            if (timerUntilJump <= 0f)
                timerUntilJump = 2f;
            m_Punch = false;
            m_Jump = false;
        }
    }
