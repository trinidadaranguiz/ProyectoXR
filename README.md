# ProyectoXR - Aplicación VR para Meta Quest 3

## Descripción
Proyecto de realidad virtual desarrollado en Unity para Meta Quest 3 usando el XR Interaction Toolkit. Este es un proyecto de aprendizaje para crear experiencias inmersivas en VR.

## Tecnologías Utilizadas
- **Unity 2022.3.x** - Motor de juego principal
- **XR Interaction Toolkit 3.2.1** - Sistema de interacciones VR
- **OpenXR** - Estándar abierto para VR/AR
- **Universal Render Pipeline (URP)** - Pipeline de renderizado optimizado
- **C#** - Lenguaje de programación para scripts

## Características del Proyecto
- ✅ Configuración para Meta Quest 3
- ✅ Samples y ejemplos del XR Interaction Toolkit
- ✅ Configuración OpenXR
- ✅ Prefabs de controladores VR
- ✅ Sistema de interacciones (grab, poke, teleport)
- ✅ UI adaptada para VR
- ✅ Simulador de dispositivos XR para testing

## Estructura del Proyecto
```
Assets/
├── Samples/                    # Ejemplos del XR Interaction Toolkit
│   └── XR Interaction Toolkit/
│       ├── Starter Assets/     # Assets básicos para VR
│       └── XR Device Simulator/ # Simulador para testing
├── Scenes/                     # Escenas del proyecto
├── Settings/                   # Configuraciones de renderizado
├── XR/                        # Configuraciones XR y OpenXR
└── XRI/                       # Configuraciones del XR Interaction Toolkit
```

## Requisitos de Desarrollo
- Unity 2022.3.x o superior
- Meta Quest SDK
- Android Build Support (para Quest)
- Git para control de versiones

## Configuración para Meta Quest 3
El proyecto está preconfigurado con:
- OpenXR como proveedor XR
- Android como plataforma de destino
- Universal Render Pipeline optimizado para móviles
- Input Actions para controladores VR
- Prefabs listos para Meta Quest

## Instalación y Uso
1. Clona este repositorio
2. Abre el proyecto en Unity 2022.3.x
3. Asegúrate de tener Android Build Support instalado
4. Conecta tu Meta Quest 3
5. Build and Run desde Unity

## Próximos Pasos
- [ ] Crear escena personalizada
- [ ] Implementar mecánicas de juego específicas
- [ ] Optimizar performance para Quest 3
- [ ] Añadir sistema de audio espacial
- [ ] Implementar hand tracking

## Contribución
Este es un proyecto de aprendizaje. Si encuentras mejoras o tienes sugerencias, siéntete libre de crear issues o pull requests.

## Recursos Útiles
- [Unity XR Interaction Toolkit Documentation](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@3.2/manual/index.html)
- [Meta Quest Developer Hub](https://developer.oculus.com/)
- [OpenXR Specification](https://www.khronos.org/openxr/)

---
*Proyecto creado como parte del aprendizaje de desarrollo VR con Unity*