using UnityEngine;
using UnityEngine.InputSystem;

public class MiPrimerScriptVR : MonoBehaviour
{
    [Header("🎮 Configuración General VR")]
    public string mensajeBienvenida = "¡Bienvenido al Taiko VR!";
    
    [Header("🥁 Referencias del Juego")]
    public GameObject tambor;
    public TaikoVR scriptTambor;
    
    void Start()
    {
        Debug.Log("🎮 " + mensajeBienvenida);
        Debug.Log("🥁 Sistema Taiko VR iniciado correctamente");
        
        // Buscar el tambor automáticamente si no está asignado
        if (tambor == null)
        {
            tambor = GameObject.Find("taikosoloi");
        }
        
        // Buscar el script del tambor
        if (tambor != null && scriptTambor == null)
        {
            scriptTambor = tambor.GetComponent<TaikoVR>();
        }
        
        // Verificar configuración
        if (tambor != null)
        {
            Debug.Log("✅ Tambor encontrado: " + tambor.name);
        }
        else
        {
            Debug.Log("⚠️ No se encontró el tambor. Asegúrate de tener un objeto llamado 'tai' o 'Tambor_Taiko'");
        }
        
        if (scriptTambor != null)
        {
            Debug.Log("✅ Script TaikoVR conectado correctamente");
        }
    }
    
    void Update()
    {
        // Testing en desktop - ESPACIO hace sonar el tambor
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            TocarTambor();
        }
        
        // En VR real, esto se ejecutaría con los controladores
        // El script TaikoVR maneja las interacciones específicas del tambor
    }
    
    public void TocarTambor()
    {
        Debug.Log("🥁 ¡Intentando tocar el tambor!");
        
        if (scriptTambor != null)
        {
            // Usar el script específico del tambor
            scriptTambor.GolpearTambor("Controlador", 1.0f);
        }
        else if (tambor != null)
        {
            // Fallback: cambiar color del tambor sin script
            Renderer renderer = tambor.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Random.ColorHSV();
                Debug.Log("🎨 ¡Color del tambor cambiado!");
            }
        }
        else
        {
            Debug.Log("⚠️ No se puede tocar el tambor - no está configurado");
        }
    }
    
    // Método que se puede llamar desde eventos de XR Interaction Toolkit
    public void OnObjetoAgarrado()
    {
        Debug.Log("👋 ¡Objeto agarrado con el controlador VR!");
        TocarTambor(); // Tocar tambor al agarrar
    }
    
    public void OnObjetoSoltado()
    {
        Debug.Log("🤲 ¡Objeto soltado!");
    }
    
    // NUEVOS: Métodos para tocar el objeto (más realista en VR)
    public void OnObjetoTocado()
    {
        Debug.Log("👆 ¡Objeto tocado con el controlador VR!");
        TocarTambor(); // Tocar tambor al tocar
    }
    
    public void OnObjetoDejarDeTocar()
    {
        Debug.Log("🤚 ¡Dejaste de tocar el objeto!");
    }
}