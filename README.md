# GRUPO 3 #
# Sistema de Reservas de Vuelos - Blazor & Supabase

## Introducción

Este sistema es una aplicación web que permite realizar búsquedas de vuelos según el origen, destino, y fechas de salida y llegada. La aplicación utiliza **Blazor** como marco de trabajo para la interfaz de usuario y **Supabase** para la gestión de datos en tiempo real.

## Descripción del Sistema

El sistema permite a los usuarios realizar reservas de vuelos entre diferentes aeropuertos. A través de una interfaz sencilla, los usuarios pueden seleccionar el origen y destino de su vuelo, así como las fechas de salida y llegada. La aplicación mostrará una lista de vuelos disponibles basados en esos parámetros.

## Objetivo

### Objetivo General
Desarrollar un sistema interactivo de búsqueda y reserva de vuelos utilizando tecnologías web modernas como Blazor y Supabase.

### Objetivos Específicos
- Implementar una interfaz de usuario en Blazor que permita seleccionar el origen, destino y fechas de vuelo.
- Integrar la base de datos de vuelos y aeropuertos con Supabase para la consulta en tiempo real.
- Optimizar la experiencia del usuario con resultados de búsqueda rápidos y precisos.

## Marco Teórico

### Blazor
Blazor es un framework de desarrollo web que permite construir aplicaciones interactivas del lado del cliente con C#. Este proyecto utiliza **Blazor Server** para la renderización dinámica de contenido.

### Supabase
Supabase es una plataforma de base de datos de código abierto que permite gestionar datos en tiempo real utilizando PostgreSQL. Se usa para almacenar y recuperar datos de aeropuertos, vuelos y reservas en este sistema.

## Metodología

Se empleó una metodología de desarrollo ágil, enfocándose en la iteración rápida y la integración continua para asegurar la estabilidad y calidad del sistema. El sistema fue desarrollado siguiendo un enfoque de diseño basado en componentes, donde cada parte de la interfaz de usuario se construye y prueba de manera independiente.

## Modelado

### Diagramas de Tablas

1. **Usuarios**: Tabla que almacena la información de los usuarios.
2. **Vuelos**: Tabla que almacena los detalles de cada vuelo.
3. **Reservas**: Tabla que vincula a los usuarios con los vuelos reservados.

### Arquitectura

La arquitectura del sistema está basada en un patrón **cliente-servidor**, donde el cliente (Blazor) realiza solicitudes a un servidor que interactúa con la base de datos (Supabase).

## Conclusiones

- La integración de Blazor con Supabase permite desarrollar aplicaciones web dinámicas con una excelente experiencia de usuario.
- El sistema es escalable y puede ser ampliado para incluir más características como pagos en línea o notificaciones.
  
## Resultados Obtenidos

- Sistema funcional que permite realizar búsquedas de vuelos y visualizar los resultados en una tabla ordenada.
- Interfaz de usuario intuitiva que facilita la selección de vuelos según parámetros específicos.

## Bibliografía

- [Blazor Documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/)
- [Supabase Documentation](https://supabase.com/docs)


### Capturas de Pantalla

[![WhatsApp Video 2025 01 31 at 5](https://s13.gifyu.com/images/b29FC.gif)](https://gifyu.com/image/b29FC)

### Código Relevante

```csharp
private async Task BuscarVuelos()
{
    if (p_idaeropuertoorigen == null || p_idaeropuertodestino == null || p_fechasalida == null)
    {
        Console.WriteLine("Faltan parámetros para realizar la búsqueda.");
        return;
    }

    try
    {
        var response = await SupabaseClient
            .Rpc("buscar_vuelos", new Dictionary<string, object>
            {
                { "p_idaeropuertoorigen", p_idaeropuertoorigen },
                { "p_idaeropuertodestino", p_idaeropuertodestino },
                { "p_fechasalida", p_fechasalida},
                { "p_fechallegada", p_fechallegada}
            });

        if (response.Content != null)
        {
            var vuelosRecibidos = JsonSerializer.Deserialize<List<Vuelo>>(response.Content);
            vuelos = vuelosRecibidos ?? new List<Vuelo>();
        }
        else
        {
            Console.WriteLine("No se encontraron vuelos.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al buscar vuelos: {ex.Message}");
    }
}
