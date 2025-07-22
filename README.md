
# 📚 Book Review API (.NET Web API)

Este proyecto es una Web API construida con .NET 8 para gestionar reseñas de libros. Expone endpoints para interactuar con libros, autores, categorías y reseñas. Se conecta a una base de datos SQL Server.

---

## ✅ Requisitos

- [.NET SDK 8](https://dotnet.microsoft.com/download)
- Visual Studio 2022 **o** Visual Studio Code
- SQL Server (instalado localmente o en la nube)

---

## 🔧 Configuración y ejecución local

Puedes ejecutar el proyecto de dos formas:

---

### 🧩 Opción 1: Visual Studio (con LocalDB o SQL Server)

1. **Clona el repositorio**

```bash
git clone https://github.com/Seiked/BookReviewBackend
cd BookReviewAPI
```

2. **Configura la conexión a base de datos** en `appsettings.json`

#### Usando LocalDB (por defecto en Visual Studio):

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\MSSQLLocalDB;Database=BookReviewDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

#### Usando SQL Server instalado:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=BookReviewDB;User Id=TU_USUARIO;Password=TU_CONTRASEÑA;"
}
```

3. **Aplica las migraciones**

En la consola del administrador de paquetes o terminal:

```bash
dotnet ef database update
```

4. **Ejecuta el proyecto**

Presiona `F5` o haz clic en **Iniciar** en Visual Studio.

---

### 💻 Opción 2: Visual Studio Code + CLI (con SQL Server)

1. **Clona el repositorio**

```bash
git clone https://github.com/Seiked/BookReviewBackend
cd BookReview.API
```

2. **Asegúrate de tener SQL Server en ejecución localmente**

3. **Configura la cadena de conexión** en `appsettings.json` como se mostró arriba

4. **Restaura los paquetes**

```bash
dotnet restore
```

5. **Aplica migraciones y crea la base de datos**

```bash
dotnet ef database update
```

6. **Ejecuta el servidor**

```bash
dotnet run
```

Por defecto, la API estará en `https://localhost:7160`

---

## 🌐 Acceder al Frontend

Una vez la API esté corriendo, puedes acceder al frontend:

👉 [https://book-review-frontend-hazel.vercel.app/index.html](https://book-review-frontend-hazel.vercel.app/index.html)

> Asegúrate de que el backend (`localhost:5001` o `localhost:7160`) esté activo para que el frontend pueda comunicarse correctamente.

---

## ☁️ Despliegue en la nube 

Puedes desplegar esta API en servicios como:

- [Railway](https://railway.app/)
- [Render](https://render.com/)
- [Azure App Service](https://portal.azure.com/)
- Heroku

### Pasos generales:

1. Publica la API desde Visual Studio o terminal:
```bash
dotnet publish -c Release
```

2. Crea una base de datos en la nube y configura la cadena de conexión

3. Establece la variable de entorno `ConnectionStrings__DefaultConnection` en la plataforma

4. Sube los archivos publicados o enlaza el repositorio para despliegue continuo

5. Actualiza el frontend para que use la nueva URL pública de la API si es necesario

---

## 🧪 Pruebas de la API

Puedes usar Swagger en `https://localhost:7160/swagger` o herramientas como [Postman] para probar los endpoints.

---

