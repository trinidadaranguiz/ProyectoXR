using UnityEngine;
using UnityEngine.InputSystem;

public class TaikoVR : MonoBehaviour
{
    [Header("🥁 Configuración del Tambor")]
    public AudioClip sonidoTambor;
    public float fuerzaImpacto = 1.0f;
    public GameObject efectoGolpe; // Partículas o luz cuando golpeas
    
    [Header("🎵 Sistema de Puntuación")]
    public int puntos = 0;
    public float tiempoUltimoGolpe = 0f;
    
    [Header("🎨 Efectos Visuales")]
    public Color colorGolpe = Color.yellow;
    public float duracionEfecto = 0.2f;
    
    private AudioSource audioSource;
    private Renderer tambourRenderer;
    private Color colorOriginal;
    private bool efectoActivo = false;
    
    void Start()
    {
        Debug.Log("🥁 ¡Taiko VR iniciado!");
        
        // Configurar componentes
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        
        tambourRenderer = GetComponent<Renderer>();
        if (tambourRenderer != null)
        {
            colorOriginal = tambourRenderer.material.color;
        }
        
        Debug.Log("🎌 ¡Listo para tocar el Taiko!");
    }
    
    void Update()
    {
        // Testing en desktop - ESPACIO simula golpe de baqueta
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GolpearTambor("Desktop", 1.0f);
        }
        
        // Restaurar color después del efecto
        if (efectoActivo && Time.time - tiempoUltimoGolpe > duracionEfecto)
        {
            RestaurarColorOriginal();
        }
    }
    
    // Método principal: cuando golpeas el tambor
    public void GolpearTambor(string tipoGolpe, float intensidad)
    {
        Debug.Log($"🥁 ¡PON! Golpe {tipoGolpe} con intensidad {intensidad}");
        
        // Reproducir sonido
        if (sonidoTambor != null && audioSource != null)
        {
            audioSource.PlayOneShot(sonidoTambor, intensidad);
        }
        else
        {
            Debug.Log("🔊 ¡PON! (sin audio - añade un AudioClip)");
        }
        
        // Efecto visual
        EfectoVisualGolpe();
        
        // Sistema de puntuación
        AgregarPuntos(tipoGolpe);
        
        // Efectos de partículas
        if (efectoGolpe != null)
        {
            Instantiate(efectoGolpe, transform.position, transform.rotation);
        }
        
        tiempoUltimoGolpe = Time.time;
    }
    
    void EfectoVisualGolpe()
    {
        if (tambourRenderer != null)
        {
            tambourRenderer.material.color = colorGolpe;
            efectoActivo = true;
        }
    }
    
    void RestaurarColorOriginal()
    {
        if (tambourRenderer != null)
        {
            tambourRenderer.material.color = colorOriginal;
            efectoActivo = false;
        }
    }
    
    void AgregarPuntos(string tipoGolpe)
    {
        int puntosGolpe = 10; // Puntos base
        
        // Bonus por timing o tipo de golpe
        if (tipoGolpe == "Perfect")
        {
            puntosGolpe = 50;
        }
        else if (tipoGolpe == "Good")
        {
            puntosGolpe = 30;
        }
        
        puntos += puntosGolpe;
        Debug.Log($"🎯 ¡+{puntosGolpe} puntos! Total: {puntos}");
    }
    
    // Métodos para VR - se conectan con XR Interaction Toolkit
    public void OnBaquetaImpacto()
    {
        GolpearTambor("VR_Baqueta", 1.0f);
    }
    
    public void OnControladorToque()
    {
        GolpearTambor("VR_Controlador", 0.8f);
    }
    
    public void OnManoToque()
    {
        GolpearTambor("VR_Mano", 0.6f);
    }
    
    // Método para diferentes zonas del tambor
    public void GolpearZona(string zona)
    {
        float intensidad = 1.0f;
        
        switch (zona)
        {
            case "Centro":
                intensidad = 1.0f;
                Debug.Log("🎯 ¡Golpe en el centro! ¡Perfect!");
                GolpearTambor("Perfect", intensidad);
                break;
            case "Borde":
                intensidad = 0.7f;
                Debug.Log("👌 ¡Golpe en el borde! ¡Good!");
                GolpearTambor("Good", intensidad);
                break;
            default:
                GolpearTambor("Normal", intensidad);
                break;
        }
    }
}