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