using UnityEngine;

public class ViewingCamera : MonoBehaviour
{
    private float offset= 0.1f;
    private float normal = 0.8f;
    private float ScreenQuack = 0.3f;
    public bool IsCrouched = false;
    public Player PlayerScript;
    public Enemy EnemyScript;
    // variables


  
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && IsCrouched == false) //checks if crouched and changes hieght if so.
        {
            transform.Translate(0, -(normal-offset), 0);
        }
        else if (IsCrouched == true && Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.Translate(0, offset, 0);
        }
        if (EnemyScript.DamidgingHappen == true){
            ShakeScreen();
        }
    }
    void ShakeScreen()
    {
        for (int i = 0; i < 3; i++){
            transform.Translate(-(0-ScreenQuack), -(normal-ScreenQuack), -(0-ScreenQuack));
            transform.Translate((0+ScreenQuack), (normal+ScreenQuack), (0+ScreenQuack));
        }
    }
}
