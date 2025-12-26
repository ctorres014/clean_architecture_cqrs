# poc_ddd
Estructura de una solución para implementar clean architecture y DDD

# Poco Acoplamiento en al Core de la aplicacion

- Definiciona de los contratos en la capa de aplicaicon
	- Aplicacion del Patron Repositorio para 
		*Separar el acceso a datos de la aplicacion
		*Mantener repositorios genericos
		*Mantener repositorios especificos
		*Construccion en base a innterfaces
	 
- Gestion de mensajes entre componentes usando mediatR
**Note:** Cuando necesitamos que varios objetos trabajen juntos creamos referencia entre los objetos.
Si bien no hay nada malo en eso, se crea un alto acoplamiento entre estos objetos lo que disminuye la
capacidad de probarlos individualmente de forma aislada.
Cuando introducimos mediator estamos agregando un intermediario que encapsula como se comunican
los objetos entre ellos. 
Nuestros objetos conocen al mediador, entonces cuando necesitan comunicarse con un objeto, hablar con
el mediador que se encargara de transmitir el mensaje al objeto correspondiente.

Las ventajas de usar mediator
- Los cambios son manejados facilmente
- Objetos facilmente testeables
**Agregando MediatR:** install-package MediatR
Como se menciono necesitamos un mensaje (IRequest) y un manejador (IRequestHandler) que contendra la logica
para manejar ese mensaje.

### Usando Automapper
- Instalacion desde nuget package
- Registracion de DI
- Creacion del profile para gestionar los tipos que van a ser manejados

# CQRS Implementation
Creamos clases que manejan consultas (querys) y comandos que son acciones de escritura.
Esta patron nos permite en aplicacions grandes:
	- Separar preocupacion
	- Escalar funcionalmente
	- Seguridad
	- Implementar cambios con poco impacto

# Fluent Validation
Es un package de codigo abierto que nos permite generar codigo de validacion.
Utiliza expresiones lambda para definir las reglas de validacion que se aislan de las 
entidades de negocio.
**Manejo de Erroes:** Gestion de exceptions generales. Podemos manejarlas o transformarlas
para el consumidor. Exceptions usadas:
	- NotFoundException
	- BadRequestException
	- ValidationExeption
install-package FluentValidation
install-package FluentValidation.DependencyInjectionExtensions

**Note:** En la implementacion de una arquitectura CQRS es importante tener en cuenta
que las clases de validacion se agregar dentro de los commands para mantener un orden.

# Adding EF Core

install-package Microsoft.EntityFrameworkCore.SqlServer
				Microsoft.Extensions.Options.ConfigurationExtensions
Implementamos el correspondiente dbcontext, generamos una semilla con informacion
y realizamos la configuracion (IEntityTypeConfiguration) para las entidades para 
que nuestro codigo se mantenga limpio.

# Application API

Agregarmos un startupextension class para que nos sirva como contenedor de Gestion
de servicios, middleware, etc. La idea es descomprimir el contenido de configuracion
de la clase program.

Crearemos 2 metodos ConfigureServices para gestionar el registro de los servicios
y ConfigurePipeLine para registrar los middleware.

**Note:** Es importante antes de aplicar la migracion tener el proyecto de api seteado
como proyecto inicial y agregar el package Microsoft.EntityFrameworkCore.Design
en el startup proyect y el Microsoft.EntityFrameworkCore.Tools en el que tiene 
el dbcontext.
Este paquete es necesario para crear la migracion desde la consola.

### Migrations

Abrimos Packate Manager Console y selecionamos el proyecto de persistencia
	- Generamos una migracion `add-migration` + el nombre de la migracion
		ejemplo `add-migration InitialMigration`

### Swagger

Swagger nos permite agregar una description de la API y sus metodos.
Nos permite generar especificaciones en formato Json o XML.
Usamos swashbuckle para generar los endpoints de swagger y la documentacion.
En nuestro proyecto de Api agregamos 2 paquetes
	- `Swashbuckle.AspNetCore`
	- `Swashbuckle.AspNetCore.Swagger`
	
# Application Test

Podemos escribir distintos tipos de pruebas.
### Unit Test: 
Es codigo que de forma automatica invocara al codigo que se va a probar. 
Verificara una suposicion (assumption) sobre el compotamiento del codigo 
que se prueba y eso definira si la prueba tiene	exito o no.
Porque hacemos pruebas unitaria?
	- Para encontrar bugs
	- Para asegurar que nuestros cambios no rompan otra seccion de codigo
	- Mejorar la calidad.
	- Una bateria de pruebas puede verse como documentacion de codigo.
### Integration Test
Las pruebas de integracion, como su nombre lo indica, sob pruebas que 
se realizan End to End.
Al crear nuestro codigo de manera independiente de la capa de infraestructura
no se sealiza el unitetest con lo cual necesitamos probarla.
Necesitamos probar las interacciones entre las distintas capas.
Estas pruebas requieren mas trabjo y dedicacion.
Al probar el sistema como un todo necesitamos acceder a una Bd.
### Functional Test 
Se usa para verificar desde el punto de vista del usuario final si el sistema cumple con el comportamiento esperado.

### Setting Up Unit Test

**Test Project:** XUnit
**Mock Data:** Manual o usando un framework
**DI**: El codigo se probara en base al Dependency Injection impelementado
Usaremos Moq para simular las dependencias, shouldly para las assertions y XUnit
para los unit test.

# Handling exceptions

1- Custom Exceptions definidas en el proyecto core (application project).
2- Convertir las exception en mensajes amigables al cliente para que pueda interpretar que paso (middleware in API).
Mediante el middleware manejaremos las exceptions y las ejecutaremos en orden dentro del pipeline
de ejecucion de un request o en la response.
Un componente de middleware es simplemente una clase que debe tener un constructor con un delegate como parametro.

# Logging

Necesitamos habilitar el manejo de log en nuestro servicio para conocer que problemas ocurren:
1- Configure Logging in program.cs
2- Podemos log integrado a .net core, `ilogger<T>` en el codigo.
3- Implementaremos Serilog (configure in program, and appsetting.json)
La implementacion de serilog nos permite escribir log en fuentes diferentes como un archivo
o incluso una BD. Tambien nos ofrence una definicion de log estructurado que nos permite
definir como escribir el log.
**Note:** Serilog package 
	- serilog.Aspnetcore
	- serilog
	- serilog.extension.Logging
	- serilog.sinks.file
	- serilog.settings.configuration