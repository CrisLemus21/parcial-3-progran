create database veterinaria
 create table mascotas(
 id int identity not null,
 nombre varchar(max) not null,
 raza varchar(max) not null, 
 edad varchar(max) not null,
 due�o varchar(max) not null);