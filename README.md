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