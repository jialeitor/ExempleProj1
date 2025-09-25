using UnityEngine;

public class naujugador : MonoBehaviour
{
    public float vel = 10f;

    private Camera camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ControlLimitsPantalla();
        MovimentNau();
    }
    void MovimentNau()
    {
        //Control límits pantalla.
        Vector3 limitInferiorEsquerra = camera.ViewportToWorldPoint(new Vector2(0, 0));
        Vector3 limitSuperiorDret = camera.ViewportToWorldPoint(new Vector2(1, 1));
        //Moviment nau.
        float direccioHorizontal = Input.GetAxisRaw("Horizontal");
        float direccioVertical = Input.GetAxisRaw("Vertical");
        Vector3 direccio = new Vector3(direccioHorizontal, direccioVertical, 0).normalized;//(x, y, z)
        //Debug.Log("direccio=" + direccio);

        Vector3 nouDesplacament = new Vector3(
            vel * direccio.x * Time.deltaTime,
            vel * direccio.y * Time.deltaTime,
            vel * direccio.z * Time.deltaTime
        );
        //Debug.Log("Time.deltaTime=" + Time.deltaTime);

        //Control dels límits de la pantalla.
        //El mètodo Math.Clamp, ens retorna el primer paràmetre.
        //      Però, si aquest primer paràmetre, té un valor més petit que el segon paràmetre,
        //          retornarà el segon paràmetre. I, si té un valor més gran que el tercer
        //          paràmetre, ens retornarà el tercer paràmetre.
        nouDesplacament.x = Math.Clamp(nouDesplacament.x, limitInferiorEsquerra.x, limitSuperiorDret.x);
        nouDesplacament.y = Math.Clamp(nouDesplacament.y, limitInferiorEsquerra.y, limitSuperiorDret.y);
        //Apliquem el vector desplaçament a l'objecte.
        transform.position += nouDesplacament;
    }
}
