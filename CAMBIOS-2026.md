# Cambios de la rama `update-2026`

> Esta rama es el mismo curso, preparada para abrirse con **Unity 6** en vez de con Unity 2020.1, que
> es con el que se grabaron los vídeos. La rama `master` sigue exactamente como en el vídeo.
> Comprobado abriendo los seis proyectos en Unity 6 (septiembre de 2026): todos funcionan.

## Cómo usarla

1. Instala **Unity 6** (la versión LTS que te ofrezca Unity Hub).
2. Descarga esta rama, y solo esta rama: `git clone --depth 1 -b update-2026 https://github.com/joanby/cursos-unity-2020`
   (o, en GitHub, cambia a la rama `update-2026` y *Code → Download ZIP*). El `--depth 1` importa:
   sin él, git se trae también el historial de `master`, con la caché antigua dentro.
3. En Unity Hub, **Add → Add project from disk** y elige la carpeta de un juego (`01_Cars`,
   `02_Wildlife`, `03_Jump`, `04_Balls`, `05_QuickClick` o `John Lemmon`), no la raíz del repositorio.
4. Unity te avisará de que el proyecto es de una versión anterior: acepta la actualización. La
   primera vez tarda unos minutos, porque reconstruye su caché.

## Qué ha cambiado y por qué

### 1. La caché de Unity ya no está en el repositorio

La rama `master` guarda en git la carpeta `Library/` de cada proyecto (y `Logs/`, `obj/`,
`UserSettings/`, `.idea/`, `*.csproj`, `*.sln`): **73.296 de los 75.836 ficheros** del repositorio.
Es la caché que Unity genera él solo al abrir un proyecto, depende de la versión del editor que la
creó y con Unity 6 se reconstruye entera, así que no servía para nada más que para hacer la descarga
enorme. En esta rama no está, y el nuevo `.gitignore` evita que vuelva a entrar.

**No cambia nada de lo que ves en el vídeo:** todas las escenas, scripts, modelos, materiales,
ajustes del proyecto y los paquetes de `External Assets/` siguen ahí.

### 2. Cuatro paquetes de servicios que el curso no usaba

`Ads`, `Analytics`, `Purchasing` y `Collab` venían instalados con la plantilla del proyecto
(`01_Cars` y `John Lemmon` los tenían todos; `Collab`, los seis). Ningún script, escena ni asset del
curso los usa —comprobado componente a componente—, y en Unity 6 son servicios que han cambiado de
producto o se han retirado. Se han quitado de `Packages/manifest.json`.

`Post Processing` **no** se ha quitado: `02_Wildlife` y `John Lemmon` lo usan en sus escenas.

### 3. El código C# no se ha tocado

Los 50 scripts del curso funcionan en Unity 6 tal y como los escribimos en el vídeo. Lo único que
vas a notar:

- En `04_Balls`, `rb.velocity` aparecerá como `rb.linearVelocity`: Unity 6 lo renombró y su
  *API Updater* lo cambia solo al abrir el proyecto. Es la misma propiedad.
- En `04_Balls` y `05_QuickClick`, `FindObjectOfType` sale como **aviso** (amarillo) en la consola:
  Unity recomienda ahora `FindFirstObjectByType`. Funciona igual; si quieres quitar el aviso, cámbialo.

## Lo que se ve distinto al vídeo

La interfaz del editor: Unity 6 ha movido y rediseñado paneles y menús respecto a Unity 2020. Lo que
aprendes en el curso (componentes, físicas, scripts, escenas) es exactamente lo mismo.
