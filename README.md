# OperationQuasarFire
**Prueba Técnica Marcado Libre Operación Fuego de Quasar**

**Lenguaje de programación .Net Core 5.0 c#.**

**Configuración**
1. Abrir solución del proyecto en Visual Studio 2019.
2. Establecer proyecto de inicio **OperationQuasarFire.API** para funcionamiento correcto.

**EndPoints**

A continuación se podrá encontrar los endpoints implementados en un app services de azure para el respectivo consumo:

1. https://operationquasarfire.azurewebsites.net/Authentication/GetToken : Método **POST**, requiere Autehnticación básica con los siguientes Datos:

**Usuario**: DiegoAlape 
**Constraseña**: MercadoLibre123

 Su función es obtener el token de autorización para la ejecución del API, retorna el token y la fecha de expiración del token generado, con este token se podrá hacer uso de los Endpoints para triangular y guardar información de los satélites.
 
 
