using UnityEngine;
using UnityEngine.SceneManagement;

public class Collsionhandler : MonoBehaviour
{
    [SerializeField] float lvlspd = 0.5f;
    [SerializeField] AudioClip boom;
    [SerializeField] AudioClip success;

    [SerializeField] ParticleSystem crasheff;
    [SerializeField] ParticleSystem successeff;

    AudioSource ads;

    bool isTransitioning = false;
    bool collisionDisable = false;
    
    void Start() 
    {
        ads = GetComponent<AudioSource>();
    }

    void Update()
    {
        Debugkeys();
    }

    void Debugkeys()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            nxtlvl();
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            collisionDisable = !collisionDisable; //toggle collision
        }
        
    }

    void OnCollisionEnter(Collision other) 
    {
       if(isTransitioning || collisionDisable ){ return ;}

       switch(other.gameObject.tag)
       {
        case "AI":
        break;

        case "Friendly":
        break;

        case "Finish":
        scsseq();
        break;

        default:
        crashseq();
        break;
        }

    }

    void scsseq()
    {
        isTransitioning = true;
         
        ads.Stop();

        successeff.Play();

        ads.PlayOneShot(success);
        GetComponent<Movement>().enabled = false;
        Invoke("nxtlvl" , lvlspd*2 );
    }

    void crashseq()
    {
        isTransitioning = true;

        ads.Stop();  

        crasheff.Play();

        ads.PlayOneShot(boom);    
        GetComponent<Movement>().enabled = false;
        Invoke("Reloadlvl" , lvlspd);
    }


    void Reloadlvl()
    {
        int currentsceneinx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentsceneinx);

    }

    void nxtlvl()
    {   
        int currentsceneinx = SceneManager.GetActiveScene().buildIndex;
        int nxtscene = currentsceneinx + 1 ;
        

        if(nxtscene ==  SceneManager.sceneCountInBuildSettings)
        {
            nxtscene = 0;
        }
        SceneManager.LoadScene(nxtscene);

    
    }
}
