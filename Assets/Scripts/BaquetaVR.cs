using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BaquetaVR : MonoBehaviour
{
    [Header("🥢 Configuración de Baqueta")]
    public float fuerzaMinima = 2.0f; // Velocidad mínima para hacer sonido
    public string ladoBaqueta = "Derecha"; // "Izquierda" o "Derecha"
    
    [Header("🎯 Detección")]
    public LayerMask capaTambor = -1; // Qué objetos puede golpear
    
    private Rigidbody rb;
    private TaikoVR tambor;
    private bool puedeGolpear = true;
    private float cooldownGolpe = 0.1f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        
        Debug.Log($"🥢 Baqueta {ladoBaqueta} inicializada");
    }
    
    void OnCollisionEnter(Collision collision)
    {
        // Verificar si golpeó el tambor
        if (collision.gameObject.name.Contains("taiko") && puedeGolpear)
        {
            // Calcular intensidad del golpe basado en velocidad
            float velocidad = rb.linearVelocity.magnitude;
            
            if (velocidad >= fuerzaMinima)
            {
                // Buscar el script del tambor
                TaikoVR scriptTambor = collision.gameObject.GetComponent<TaikoVR>();
                
                if (scriptTambor != null)
                {
                    // Golpear el tambor con intensidad variable
                    float intensidad = Mathf.Clamp01(velocidad / 10f);
                    string tipoGolpe = $"Baqueta_{ladoBaqueta}";
                    
                    scriptTambor.GolpearTambor(tipoGolpe, intensidad);
                    
                    Debug.Log($"🥢 ¡{tipoGolpe} golpeó el tambor! Velocidad: {velocidad:F2}, Intensidad: {intensidad:F2}");
                    
                    // Cooldown para evitar múltiples golpes
                    StartCoroutine(CooldownGolpe());
                }
            }
        }
    }
    
    System.Collections.IEnumerator CooldownGolpe()
    {
        puedeGolpear = false;
        yield return new WaitForSeconds(cooldownGolpe);
        puedeGolpear = true;
    }
    
    // Métodos para XR Interaction Toolkit
    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log($"👋 ¡Baqueta {ladoBaqueta} agarrada!");
    }
    
    public void OnSelectExited(SelectExitEventArgs args)
    {
        Debug.Log($"🤲 ¡Baqueta {ladoBaqueta} soltada!");
    }
    
    // Vibración del controlador cuando golpeas (opcional)
    public void VibrarControlador()
    {
        // Aquí puedes añadir vibración del controlador VR
        Debug.Log($"📳 Vibrar controlador - baqueta {ladoBaqueta}");
    }
}