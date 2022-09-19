# PagosPruebaTuya
Proyecto para realizar prueba de selección.

Guía del Funcionamiento de la API de PagosPruebaTuya

Para el proceso de construcción del api, se definió utilizar la herramienta de trabajo visual studio 2022, bajo .Net Core, en la versión 6.0 y con el lenguaje C#. Se utilizo arquitecturas limpias para la estructura del api, se implementó Code first para la creación de la base de datos con el ORM Entity Framework 6 (EF6), se utilizó SQLServer 2019 como motor de base de datos como requerimiento del cliente.

Aprovisionamiento de la API
Para iniciar el proceso debe cumplir los siguientes pasos:

1.	Configuración Base de datos.
•	Crear Base de datos
-	Para configurar la base de datos se debe tener instalado Microsoft® SQL Server® 2019 Express.
-	Se puede utilizar una herramienta de trabajo para la gestión de la base de datos, en este caso se utilizó “microsoft sql server management studio”.
-	Se debe crear la base de datos con el siguiente nombre “TuyaPagosPruebaTecnica”.
•	Code First
-	Se debe agregar la cadena de conexión en el archivo “appsettings.json” en la variable “CONNECTIONSTRINSG_TUYAPAGOSPRUEBATECNICA” en el proyecto de la API con el nombre de la solución (PagosPruebaTuya.Api).
-	Después se debe ejecutar el siguiente comando para cargar la base de datos, en el proyecto se debe ingresar en la opción Herramientas -> Administrador de paquetes NuGet-> Consola del administrador de paquetes. 
-	En la consola seleccionar proyecto predeterminado (PagosPruebaTuya.Data). 
-	Agregar el siguiente comando “Add-Migration InitDB” y oprimir enter.
-	Ejecutar el proyecto para ejecutar comandos.


2.	Data de prueba 
•	Cargar data de prueba
-	Para cagar la data debe ejecutar el endpoint “/api/DataTest/v1/GetLoadData”, en el cual cargara unos datos en un Json incluido en el proyecto “DataTest.json”.
-	El servicio cargará los datos a la base de datos solo una única vez, las próximas ejecuciones solo traerá los datos que están almacenados.

3.	Realizar las respectivas pruebas, de los endpoint requeridos en la prueba técnica 
•	/api/ProductOrder/v1/CreateOrden
Este servicio es el encargado de crear las ordenes o pedidos de los productos seleccionados por un cliente.
•	/api/ProductOrder/v1/PagarOrden
Este servicio es el encargado de realizar el pago y él envió de los pedidos o órdenes del cliente.

4.    Nota más información en la guía de consumo, en el documento de Word. 
