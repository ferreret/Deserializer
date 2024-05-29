# JSON Deserializer Application

Esta aplicación demuestra cómo deserializar datos JSON desde un punto final HTTP utilizando varios métodos en C#. El código obtiene datos de pronóstico del tiempo desde una API local y proporciona tres opciones diferentes para deserializar la respuesta JSON.

### Opciones de Deserialización

1. **Opción 1**: Deserializar usando `JsonSerializer.DeserializeAsync` con un modelo `Temperature`.
   - Este método lee el flujo de respuesta y lo deserializa en un array de objetos `Temperature`.

2. **Opción 2**: Usar `HttpClient.GetFromJsonAsync` con un modelo `Temperature`.
   - Esta es la opción óptima, aprovechando el método de extensión `GetFromJsonAsync` para deserializar directamente la respuesta JSON en un array de objetos `Temperature`.

3. **Opción 3**: Deserializar sin declarar un modelo usando `JsonDocument`.
   - Este método lee la respuesta JSON como una cadena y usa `JsonDocument` para analizar y enumerar manualmente los elementos JSON.
