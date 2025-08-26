# Aplicacion web de control de tareas
Aplicación web para llevar el control de tareas es un proyecto realizado para agregar tareas, marcarlas como completadas y eliminarlas.

Si la fecha de creacion de la tarea es anterior a la fecha actual, esta se mostrara en color amarillo en la lista de tareas, para que el usuario sepa que la tarea quedo atrasada en el 
tiempo

La aplicacion cuenta con un filtro para poder buscar tareas por categoria, estado y plazo. El filtro por categoria permite filtrar las tareas por tipo (Estudio, Hogar, Ocio o Trabajo),
el filtro por estado permite filtrar las tareas por estado (Completadas o Pendientes) y el filtro por plazo permite filtrar las tareas por fecha de creacion (Pasado, Presente o Futuro).

**Nota**: El proyecto fue hecho con Ef Core usando localDB. Si se descarga el repositorio de GitHub hay que ejecutar el comando Update-Database en la consola del administrador de paquetes
para crear la base de datos local. De lo contrario la aplicacion mostrara un error y no se ejecutara.

<img width="700" height="479" alt="image" src="https://github.com/user-attachments/assets/87d8ea7e-3c01-480c-ac77-474bb83bc8b5" />
 
