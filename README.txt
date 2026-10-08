# Eventos Web

Aplicación web desarrollada con ASP.NET Core MVC para gestionar eventos.

## Tecnologías

- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Razor Views
- Repository Pattern

## Funcionalidades

- Listar eventos
- Crear eventos
- Ver detalles
- Editar eventos
- Eliminar eventos
- Persistencia de datos en SQL Server

## Estructura

- `Eventos.Web`: aplicación MVC
- `Eventos.Data`: acceso a datos, entidades, repositorios y migraciones

## Base de datos

El proyecto utiliza Entity Framework Core con SQL Server.

Para crear o actualizar la base de datos:

```powershell
Update-Database -Project Eventos.Data -StartupProject Eventos.Web -Context EventosContext