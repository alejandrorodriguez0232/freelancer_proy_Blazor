# freelancer_proy_Blazor
Blazor User Management PDF

Necesito un módulo web en ASP .NET Core con Blazor Server (C#) que cubra, de principio a fin, el flujo de registro de usuarios “registradores” y la emisión de reportes en PDF.

Flujo y reglas
• Un usuario registrador debe poder iniciar sesión para acceder al sistema.
• Desde el rol administrador voy a dar de alta a cada registrador y almacenar exactamente estos campos: nro de documento (12 caracteres obligatorios), nombres, apellidos, correo, clave, trabaja (sí/no), activo (sí/no) y permiso.
• El administrador no puede editar esos datos una vez guardados; sólo necesita un listado para visualizar todos los registrados.
• Desde ese mismo listado debo poder generar y descargar el reporte completo en PDF.

Entregables mínimos
• Proyecto Blazor Server (.NET 8 o superior) listo para compilar.
• Páginas y componentes para login, formulario de alta, listado con filtros básicos y botón “Descargar PDF”.
• Validaciones frontend y backend que garanticen los 12 caracteres del documento y correos válidos.
• Generación de PDF con iTextSharp, QuestPDF o biblioteca similar, sin exigir licencias de pago.
• Código claro, comentado y entregado en un repositorio Git.

Acepto sugerencias sobre arquitectura, patron de inyección de dependencias o librerías siempre que no comprometan la simplicidad del requerimiento. Quiero una solución funcional, limpia y fácil de extender.

tecnologias:

.NET
C# Programming
ASP.NET
Microsoft SQL Server
Web Development
ASP.NET MVC
.NET Core
Blazor
