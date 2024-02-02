
create database GestionClientesDB;

use GestionClientesDB;

create table Clientes (
CodigoCliente int identity(1,1) primary key,
NombreCliente varchar(255),
CiudadCliente varchar(255),
Direccion varchar(255),
Telefono varchar(255)
)
