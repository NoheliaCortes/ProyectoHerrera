💼 Sistema de Facturación e Inventario – Sorbetería Herrera
Este proyecto fue desarrollado como parte del componente curricular Integrador III por estudiantes de la carrera de Ingeniería en Sistemas de Información de la UNAN-Managua, recinto Carazo (CUR-Carazo).

🎯 Objetivo del Proyecto
Desarrollar e implementar una aplicación de escritorio para automatizar los procesos de facturación y control de inventario de Sorbetería Herrera, una empresa familiar con más de 70 años de trayectoria en Jinotepe, Nicaragua.

El sistema busca reemplazar los métodos manuales tradicionales (libretas y hojas de Excel), mejorando la eficiencia operativa, reduciendo errores humanos y proporcionando información confiable para la toma de decisiones estratégicas.

✨ Funcionalidades Principales
El sistema está diseñado para optimizar las operaciones del negocio a través de los siguientes módulos clave:

📦 Módulo de Facturación: Registro ágil y preciso de ventas, con cálculo automático de totales y generación de comprobantes para clientes.

📊 Control de Inventario en Tiempo Real: Actualización automática del stock tras cada venta, asegurando un seguimiento exacto de las existencias.

📁 Gestión Centralizada de Datos: Almacenamiento unificado de información relevante (productos, clientes, proveedores, ventas), evitando duplicados y pérdida de datos.

📈 Generación de Reportes: Creación de reportes detallados sobre ventas y niveles de inventario para apoyar la toma de decisiones estratégicas.

🔔 Alertas de Stock Bajo: Notificaciones cuando un producto alcanza su nivel mínimo de existencia, ayudando a evitar desabastecimientos.

🛠️ Tecnologías Utilizadas
Lenguaje de Programación: C#

Framework: .NET

Entorno de Desarrollo: Visual Studio

Sistema Gestor de Base de Datos: SQL Server

🚀 Puesta en Marcha
Sigue estos pasos para configurar y ejecutar el proyecto en tu entorno local:

1. Clona el repositorio
bash
Copy
Edit
git clone https://github.com/NoheliaCortes/ProyectoHerrera.git
2. Restaura la base de datos
Abre SQL Server Management Studio (SSMS).

En la carpeta /Database del proyecto, encuentra el archivo ProyectoHerrera.sql.

Ejecuta el script completo para crear la base de datos y sus respectivas tablas.

3. Configura la cadena de conexión
Abre el archivo App.config en Visual Studio.

Modifica la cadena connectionString según tu entorno:

xml
Copy
Edit
<connectionStrings>
  <add name="ProyectoHerrera.Properties.Settings.ProyectoHerreraConnectionString"
       connectionString="Data Source=TU_SERVIDOR;Initial Catalog=ProyectoHerrera;Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
4. Compila y ejecuta
Asegúrate de tener todas las dependencias instaladas (Visual Studio generalmente lo hace por ti).

Compila la solución con Ctrl + Shift + B.

Ejecuta el proyecto con F5 o haz clic en el botón ▶️ Start.

👨‍💻 Equipo de Desarrollo
Este proyecto fue realizado por:

Nohelia Michelle Cortés Peña

Fabián Enrique Arteaga Hernández

Marcelo Campos Mena

