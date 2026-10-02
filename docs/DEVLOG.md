# Diario de desarrollo — ImageByView

Registro de lo que voy haciendo, los problemas que encuentro y lo que aprendo.

---

## 2026-10-02 — Paso 0: preparar el entorno y la estructura

### Qué he hecho
- Instalado el SDK de .NET 10.
- Creada la solución `ImageByView.slnx`.
- Creados los tres proyectos:
  - `ImageByView.Core` (biblioteca de clases) en `src/`: la lógica de la app.
  - `ImageByView.Sandbox` (consola) en `src/`: programa provisional para probar la lógica a mano.
  - `ImageByView.Core.Tests` (xUnit) en `tests/`: tests automáticos de la lógica.
- Añadidos los tres proyectos a la solución.

Estructura actual:

```
ImageByView/
├── ImageByView.slnx
├── docs/
│   └── DEVLOG.md
├── src/
│   ├── ImageByView.Core/
│   └── ImageByView.Sandbox/
└── tests/
    └── ImageByView.Core.Tests/
```

### Comandos usados
```powershell
# Comprobar el entorno
dotnet --list-sdks
where.exe dotnet

# Solución y proyectos (siempre desde la raíz del repositorio)
dotnet new sln -n ImageByView
dotnet new classlib -n ImageByView.Core -o src\ImageByView.Core
dotnet new console -n ImageByView.Sandbox -o src\ImageByView.Sandbox
dotnet new xunit -n ImageByView.Core.Tests -o tests\ImageByView.Core.Tests

# Añadir los proyectos a la solución
dotnet sln add src\ImageByView.Core\ImageByView.Core.csproj
dotnet sln add src\ImageByView.Sandbox\ImageByView.Sandbox.csproj tests\ImageByView.Core.Tests\ImageByView.Core.Tests.csproj

# Comprobaciones
dotnet sln list
Get-ChildItem -Recurse -Filter *.csproj

# Arreglos de carpetas
Remove-Item <carpeta> -Recurse
Rename-Item src\ImageByView.core ImageByView.Core-tmp
Rename-Item src\ImageByView.Core-tmp ImageByView.Core

# Crear este archivo
New-Item -ItemType Directory docs
New-Item docs\DEVLOG.md
```

### Problemas y cómo los resolví
- **`dotnet new sln` daba "No .NET SDKs were found".** Tenía instalado solo el runtime de .NET, no el SDK. Solución: instalar el SDK de .NET 10 y abrir una terminal nueva para que cargue el PATH actualizado.
- **La solución se creó como `image-biview-windows-explorer.slnx`.** Sin `-n`, `dotnet new` usa el nombre de la carpeta actual. Solución: usar `-n` para indicar el nombre.
- **`dotnet sln list` decía que no había proyectos.** Crear un proyecto con `dotnet new` no lo añade a la solución: son dos pasos distintos.
- **El proyecto de tests se creó dentro de `docs\src\`.** Ejecuté el comando estando en la carpeta `docs`, y `-o` es relativo a la carpeta actual. Además el nombre era `Test` en vez de `Tests` y la carpeta `src` en vez de `tests`. Solución: borrarlo y crearlo de nuevo desde la raíz.
- **La carpeta de Core se llamaba `ImageByView.core` (c minúscula).** Windows no distingue mayúsculas en las rutas, pero git, GitHub y Linux sí, así que podía romper la compilación en otros sitios. Windows no siempre deja renombrar cambiando solo mayúsculas: lo resolví en dos pasos, pasando por un nombre temporal.
- **Al intentar arreglarlo, recreé los tests como `ImageByView.core.Tests`.** Como Windows trata `Core` y `core` igual, se mezcló con la carpeta existente. Solución: borrar `tests` entera y crear el proyecto otra vez con el nombre correcto.

### Lo que he aprendido
- **Runtime vs SDK:** el runtime solo ejecuta apps .NET; el SDK permite crearlas, compilarlas y probarlas.
- **`dotnet`** es la herramienta de línea de comandos de .NET. Lo que hace depende del subcomando (`new`, `build`, `run`, `test`...). Visual Studio usa lo mismo por debajo.
- **Leer la ayuda (`--help`):** lo que va entre `[ ]` es opcional y `...` significa que se pueden poner varios valores.
- **`-n` y `-o`:** `-n` es el nombre del proyecto y `-o` la carpeta donde se crea.
- **`classlib` vs `console`:** una biblioteca es código que usan otros proyectos y no se ejecuta sola; una consola es un programa ejecutable.
- **Solución vs proyecto:** la solución (`.slnx`) agrupa proyectos; cada proyecto (`.csproj`) se compila en una `.dll` o un `.exe`. Estar en la solución no significa que los proyectos se vean entre sí: para eso hacen falta referencias.
- **Mirar siempre en qué carpeta estoy** (la ruta del prompt) antes de ejecutar un comando: todas las rutas relativas parten de ahí. Lo normal es trabajar desde la raíz del repositorio.
- **Rutas absolutas vs relativas:** la absoluta empieza en `C:\`; la relativa parte de la carpeta actual. `dotnet sln add` guarda las rutas como relativas a la solución.
- **Mayúsculas en nombres:** ser consistente siempre. Windows las ignora en las rutas, pero git y Linux no.
- **`Remove-Item -Recurse` borra sin pasar por la papelera:** comprobar dos veces la ruta antes.
- **Tab en PowerShell** autocompleta rutas y nombres; evita errores de escritura y de mayúsculas.

### Pendiente del paso 0
- [x] Crear `ImageByView.Core.Tests` (plantilla `xunit`) en `tests/`.
- [x] Añadir los tres proyectos a la solución con `dotnet sln add`.
- [ ] Referencias: Sandbox → Core y Tests → Core.
- [ ] Comprobar `dotnet build`, `dotnet test` y `dotnet run --project src\ImageByView.Sandbox`.
- [ ] Crear `.gitignore` y hacer el primer commit.

### Referencias útiles
- Herramienta `dotnet`: https://learn.microsoft.com/dotnet/core/tools/
- Descargar .NET: https://aka.ms/dotnet/download
- Guía de C#: https://learn.microsoft.com/dotnet/csharp/
- Libro Pro Git en español: https://git-scm.com/book/es/v2

---

<!--
Plantilla para nuevas entradas (copiar encima de esta línea):

## AAAA-MM-DD — Paso X: título

### Qué he hecho
-

### Comandos usados
```powershell
```

### Problemas y cómo los resolví
-

### Lo que he aprendido
-

### Referencias útiles
-
-->
