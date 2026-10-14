# NOVA VAULT: THE HEIST

> Un juego Endless Runner 3D de alta gama, estilo elegante y profesional desarrollado en Unity 3D con una estética de neón naranja (#FF6A00), humo, bokeh y UI minimalista[span_1](start_span)[span_1](end_span)[span_2](start_span)[span_2](end_span)[span_3](start_span)[span_3](end_span).

---

## 🚀 Características del Proyecto
* **Movimiento Automático & Carriles:** El jugador avanza de forma continua mientras cambia suavemente entre 3 carriles con una interpolación fluida (`SmoothDamp`).
* **Mecánica de Dígitos:** Recolección de fragmentos numéricos gigantes (0-9) en movimiento para descifrar el código de acceso de 4 dígitos (`CODE: X X _ _`).
* **Obstáculos Dinámicos:** Sistema de láseres de seguridad mortales que activan el Game Over al menor contacto.
* **Animaciones Fluidas:** Integración con **LeanTween** para transiciones de interfaz, paneles de victoria y apertura de la bóveda principal con partículas naranjas.

---

## 🛠️ Scripts Principales (C#)
1. **`PlayerMovement.cs`**: Control de desplazamiento lateral suave entre carriles.
2. **`RoadMover.cs`**: Bucle infinito del escenario para simular velocidad constante.
3. **`DigitFragment.cs`**: Gestión de los dígitos flotantes y su recolección.
4. **`CodeCollector.cs`**: Patrón Singleton que valida el código actual en la UI.
5. **`ObstacleSpawner.cs`**: Generador procedural de obstáculos y fragmentos.
6. **`LaserObstacle.cs`**: Detección de colisiones de seguridad.
7. **`VaultDoor.cs`**: Secuencia cinemática de apertura de la bóveda y pantalla de victoria.

---

## 🎮 Controles
* **A / Flecha Izquierda:** Mover a la izquierda.
* **D / Flecha Derecha:** Mover a la derecha.

---
*Desarrollado con arquitectura modular y limpia en Unity.*
