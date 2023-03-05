create database Gestao;

use Gestao;
  

create table Usuario(
id_usuario int primary key not null,
Nome varchar(50) not null,
NomeUsuario varchar(50) not null,
CPF varchar(15),
Email varchar(30) not null,
Senha varchar(20) not null,
Ativo bit	not null
);

create table Permissao(
id_permissao int primary key not null,
descricao varchar(200)
);

create table GrupoUsuario(
id_GrupoUsuario int primary key not null,
GrupoUsuario varchar(100) not null
);

create table PermissaoGrupousuario(
cod_permissao int,
cod_GrupoUsuario int 
);

create table UsuariogrupoUsuario(
cod_Usuario int,
cod_GrupoUsuario int
);

alter table PermissaoGrupoUsuario
add constraint fk_cod_PermissaoGrupoUsuario
foreign key (cod_GrupoUsuario)
references GrupoUsuario(id_GrupoUsuario);

alter table PermissaoGrupoUsuario
add constraint fk_cod_Permissao
foreign key (Cod_Permissao)
references  Permissao(id_Permissao);

alter table UsuarioGrupoUsuario
add constraint fk_cod_Usuario
foreign key (cod_Usuario)
references Usuario(id_Usuario);

alter table UsuarioGrupoUsuario
add constraint fk_cod_GrupoUsuario
foreign key (cod_GrupoUsuario)
references GrupoUsuario(id_GrupoUsuario);