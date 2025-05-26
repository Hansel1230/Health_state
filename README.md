# Health_state

🏥 Sistema de Gestión Hospitalaria


Este proyecto tiene como objetivo desarrollar una aplicación web para la gestión integral de un hospital. La solución está construida utilizando tecnologías modernas como .NET, SQL Server y una arquitectura RESTful, siguiendo principios de diseño como la Arquitectura (Clean Architecture) y el patrón Repository.

🛠 Tecnologías y Herramientas
Backend Framework: ASP.NET Core Web API

Base de Datos: SQL Server con Entity Framework Core

Patrón de Diseño: Arquitectura Limpia (Clean Architecture) y MediatR

Documentación de API: Swagger/OpenAPI

Otros: AutoMapper, UnitOfWork, Repository Pattern

📂 Estructura del Proyecto
La solución está organizada en las siguientes capas:

Health_state.API: Contiene los controladores de la API y la configuración de inicio.

Health_state.Application: Incluye DTOs, interfaces, implementaciones de servicios, hubs de SignalR y perfiles de mapeo.

Health_state.Domain: Define las entidades del dominio.

Health_state.Infrastructure: Contiene el DbContext de Entity Framework, implementaciones de repositorios, unidad de trabajo y clases de configuración.

Health_state.Presentacion: Ionic.
