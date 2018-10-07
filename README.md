# Test
WebApp MVC + WebAPI


  He realizado una proyecto que consta de 3 partes:
  
    * Una WEBAPI donde se almacenan los usuarios y roles
    * Una web app MVC que consume la WEBAPI para realizar el login y el mantenimiento de usuarios.
    * Una aplicación de Test Unitarios.

Pasos a seguir para el build y run:

* Descargar el contenido del directorio WebApp_TEST y abrir con visual studio (Desarrollado con Visual Studio Community 2017).
* Examinar las propiedades del proyecto para que se inicie la web app mvc y la web api a la vez.

Los usuarios creados por defecto para pruebas son los siguientes:

  * Username / Password
  
      - Admin / Admin123 -> Role Admin : Permisos para ver todas las webs privadas + mantenimiento de usuario
      - insdrb03 / 21081988 -> Role Page_1 : Permisos para ver la Página 1
      - breich / insdrb03 -> Role Page_2 : Permisos para ver la Página 2
      - Scott / Tiger -> Role Page_3 : Permisos para ver la Página 3
      
      
      Ahora mismo, está diseñado para que cada role tenga permiso para 1 página en concreto, pero se puede añadir rango a los roles.
      Es decir, se pueden englobar los roles en conjuntos. Ejemplo: El role 3, englobaría el role 3, 2 y el 1. El role 2 englobaría el role 2 y el 1, etc.
Esto se modificaría añadiendo (separado por comas) el role en la decoración de _Authorize
 
 
 El role Admin tiene permisos para ver todas las páginas y adicionalmente tiene permisos para el mantenimiento de Usuarios como ya expliqué arriba en la definición de roles.
 
 *LOGIN
 
   - Si los usuarios que han hecho login no tienen permiso para entrar, se redirige a una web de no autorizado.
   - Si no se ha iniciado sesión y se hace click en cualquier link de página que requiera login, la app redirige automáticamente a la pantalla de login.
 
 
 Las pruebas unitarias son las siguientes:
 
  * Check Roles : Consiste en saber si la llamada a la API devuelve los roles establecidos en la app.
  * Check Login:  Consiste en hacer una petición a la API de todos los usuarios y hacer una query para ver si el usuario y la contraseña proporcionados aparecen en la lista que devuelve la API.
  * Check Edit User: Consiste en lanzar una solicitud a la API con la "id" para buscar el usuario correcto para editar.
  * Check Create User: Consiste en hacer un post a la API con el objecto usuario y crear un usuario nuevo.
