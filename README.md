# OperationQuasarFire
**Prueba Técnica Marcado Libre Operación Fuego de Quasar**

**Lenguaje de programación .Net Core 5.0 c#.**

**Configuración**
1. Abrir solución del proyecto en Visual Studio 2019.
2. Establecer proyecto de inicio **OperationQuasarFire.API** para funcionamiento correcto.

**EndPoints**

A continuación se podrá encontrar los endpoints implementados en un app services de azure para el respectivo consumo:

1. https://operationquasarfire.azurewebsites.net/Authentication/GetToken : Método **POST**, requiere Autenticación básica con los siguientes Datos:

**Usuario**: DiegoAlape 
**Constraseña**: MercadoLibre123

 Su función es obtener el token de autorización para la ejecución del API, retorna el token y la fecha de expiración del token generado, con este token se podrá hacer uso de los Endpoints para triangular y guardar información de los satélites.
 
2. https://operationquasarfire.azurewebsites.net/Communication/Topsecret : Método **POST**, requiere Autenticación **Bearer Token** el token se puede generar teniendo en cuenta el endpoint número 1 y su respectivo instructivo, Cuerpo de la petición con formato Json con la respectiva información de los tres satélites. Su función es triangular la posición de la nave y decifrar el mensaje enviado a los tres satélites, retorna las coordenadas **X** y **Y** de la nave y el mensaje decifrado de ser posible, en caso de falta de información o que no se pueda triangular la posición responde con un mensaje de error. para realizar la prueba del endpoint se puede utilizar el siguiente objeto Json: 

[
  {
    "name": "kenobi",
    "distance": 100.0,
    "message": ["este", "", "", "mensaje", ""]
  },
  {
    "name": "skywalker",
    "distance": 115.5,
    "message": ["", "es", "", "", "secreto"]
  },
  {
    "name": "sato",
    "distance": 142.7,
    "message": ["este", "", "un", "", ""]
  }
]

3. https://operationquasarfire.azurewebsites.net/Communication/TopSecretSplit/{{satelliteName}} : Método **POST**, requiere Autenticación **Bearer Token** el token se puede generar teniendo en cuenta el endpoint número 1 y su respectivo instructivo, Cuerpo de la petición con formato Json con la respectiva información del satélite y en la URL en el espacio {{satelliteName}} definir el nombre del satélite. Su función es validar la existencia del satélite y almacenar la respectiva información de este en un archivo plano, en caso de que no exista el satélite retorna un mensaje indicando que no existe el satélite si se almacena la información correctamente retorna un mensaje indicando que se almaceno la información para el satélite, en caso de que ya exista información registrada para ese satélite lo informará con un respectivo mensaje, para realizar la prueba del endpoint se pueden utilizar los siguientes objetos Json:

* Kenobi

{
    "distance": 100.0,
    "message": ["este", "", "", "mensaje", ""]
}

* skywalker

{
    "distance": 115.5,
    "message": ["", "es", "", "", "secreto"]
}

* sato

{
    "distance": 142.7,
    "message": ["este", "", "un", "", ""]
}

4. https://operationquasarfire.azurewebsites.net/Communication/TopSecretSplit : Método **GET**, requiere Autenticación **Bearer Token** el token se puede generar teniendo en cuenta el endpoint número 1 y su respectivo instructivo. Su función es triangular la posición de la nave y decifrar el mensaje enviado a los tres satélites obtendrá la información de los datos almacenados en el archivo plano que se puede llenar desde el endpoint 3, retorna las coordenadas **X** y **Y** de la nave y el mensaje decifrado de ser posible, en caso de falta de información o que no se pueda triangular la posición responde con un mensaje de error.

**NOTA**: En caso de dudas consultar la carpeta Documents del proyecto donde se podrá encontrar un manual de ejecución para cada endpoint.

**Fórmulas matemáticas para triangulación de la posición de la nave**
**Variables**
Coordenadas de cada satelite **Si=(Six, Siy)**
Distancia a cada satelite **Di**

**Fórmulas**
Una vez sabemos las variables a considerar, se realizan los siguientes cálculos
* **U=**-2S1x + 2S2x : Halla coordena en x entre el satélite 1 y 2
* **V=**-2S1y + 2S2y : Halla coordena en y entre el satélite 1 y 2
* **W=** D1^2 - D2^2 - S1x^2 + S2x^2 - S1y^2 + S2y^2 : Calculo de diferencia de distancias en coordenadas X y Y entre los satélites 1 y 2
* **X=**-2S2x + 2S3x : Halla coordena en x entre el satélite 2 y 3
* **Y=**-2S2y + 2S3y : Halla coordena en y entre el satélite 2 y 3
* **Z=** D2^2 - D3^2 - S2x^2 + S3x^2 - S2y^2 + S3y^2 : Calculo de diferencia de distancias en coordenadas X y Y entre los satélites 2 y 3

#### Cálculo de coordenadas
Para el cálculo de las coordenadas de la nave se toman las formulas anteriores y se aplican en las siguientes ecuaciones:
* **X=** (WY - ZV) / (YU - VX)
* **Y=** (WX - UZ) / (VX - UY)
