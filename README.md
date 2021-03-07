#.NET Core 3.1, Selenium with Gherkin & SpecFlow 

>Para hacer este proyecto he utilizado el lenguaje C# con el Framework de .NetCore y la libreria SpecFlow

Para poder ejecutar proyectos de .NetCore:
```
https://dotnet.microsoft.com/download
```
Una vez instalado .NetCore, dirigirse hacia el directorio del Proyecto y ejecutar:
```
dotnet test   
```
Se podra ver algo similar a cuando se lanze el test:

![alt text](MdasFdpPractica3/Images/chrome-driver.png)

Aquí deberia lanzarse chrome, importante tener la ultima versión.

A continuación, una vez acabe se vera el resultado de los test:

![alt text](MdasFdpPractica3/Images/test-results.png)

Para ver el documento Html del resultados de los test a modo de DashBoard, he utiliado la libreria:

```
SpecFlow.Plus.LivingDocPlugin
```

Esta libreria pertenece a SpecFlow y genera en el directorio de ejecución un fichero Json a partir del cual se generara el Report.

Para instalar el CLI de la libreria: 

```
https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Installing-the-command-line-tool.html
```

Importante: livingdoc se encuentra instalado en la carpeta de nuget tools:

En el caso de mac en: 

```
$HOME/.dotnet/tools
```

Para generar el report Ejecutar el siguiente comando reemplazando {pathHaciaElDirectorioDelProyecto} por la ruta hacia el proyecto:
Importante ejecutarlo desde la carpeta de nuget tools o exportarlo al path.

```
./livingdoc test-assembly {pathHaciaElDirectorioDelProyecto}/MdasFdpPractica3/bin/Debug/netcoreapp3.1/MdasFdpPractica3.dll -t {pathHaciaElDirectorioDelProyecto}/MdasFdpPractica3/bin/Debug/netcoreapp3.1/TestExecution.json
```

Una vez ejecutado se generara en: 

```
{pathHaciaElDirectorioDelProyecto}/MdasFdpPractica3/bin/Debug/netcoreapp3.1/
```
El siguiente fichero : 

```
LivingDoc.html
```

Al abrirlo se mostraran los resultados de la ultima ejecución:

![alt text](MdasFdpPractica3/Images/living-doc2.png)

![alt text](MdasFdpPractica3/Images/living-doc1.png)

