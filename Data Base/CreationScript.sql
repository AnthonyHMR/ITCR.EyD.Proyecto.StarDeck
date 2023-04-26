CREATE DATABASE StarDeckDB;
GO

USE StarDeckDB;
GO

CREATE TABLE CARTA
(
	id_carta		NVARCHAR(14)	NOT NULL,
	nombre			NVARCHAR(30)	NOT NULL,
	descripcion		NVARCHAR(1000)	NOT NULL,
	energia			INT				NOT NULL,
	costo			INT				NOT	NULL,
	tipo			NVARCHAR(10)	NOT NULL,
	raza			NVARCHAR(25)	NOT NULL,
	imagen			NVARCHAR(100)	NOT NULL,
	estado			NVARCHAR(10)	NOT NULL	DEFAULT 'Activa',
	PRIMARY KEY(id_carta)
);

CREATE TABLE USUARIO
(
	id_usuario		NVARCHAR(14)	NOT NULL,
	nombre_usuario	NVARCHAR(30)	NOT NULL,
	nombre_completo	NVARCHAR(100)	NOT NULL,
	nacionalidad	NVARCHAR(14)	NOT NULL,
	contrasena		NVARCHAR(8)		NOT NULL,
	imagen			NVARCHAR(100)			,
	estado			NVARCHAR(10)	NOT NULL	DEFAULT 'Activa',
	ranking			INT				NOT NULL	DEFAULT 0,
	monedas			INT				NOT NULL	DEFAULT 20,
	PRIMARY KEY(id_usuario)
);

CREATE TABLE USUARIO_TIENE_CARTA
(
	id_usuario		NVARCHAR(14)	NOT NULL,
	id_carta		NVARCHAR(14)	NOT NULL,
	PRIMARY KEY(id_usuario, id_carta)
);

----------------------------------------------
--				FOREIGN KEYS				--
----------------------------------------------


ALTER TABLE USUARIO_TIENE_CARTA
ADD CONSTRAINT FK_ID_Usuario FOREIGN KEY (id_usuario)
REFERENCES USUARIO(id_usuario);

ALTER TABLE USUARIO_TIENE_CARTA
ADD CONSTRAINT FK_ID_Carta FOREIGN KEY (id_carta)
REFERENCES CARTA(id_carta);

----------------------------------------------
--                PROCEDURES                --
----------------------------------------------

/*CONSULTA PARA OBTENER TODOS LOS USUARIOS*/
CREATE PROCEDURE sp_consultar_usuarios
AS
SELECT * FROM USUARIO

CREATE PROCEDURE sp_crear_usuario
@_id_usuario		NVARCHAR(14),
@_nombre_usuario	NVARCHAR(30),
@_nombre_completo	NVARCHAR(100),
@_nacionalidad		NVARCHAR(14),
@_contrasena		NVARCHAR(8),
@_imagen			NVARCHAR(100),
@_estado			NVARCHAR(10),
@_ranking			INT,
@_monedas			INT
AS
INSERT INTO USUARIO
(
id_usuario,
nombre_usuario,
nombre_completo,
nacionalidad,
contrasena,
imagen,
estado,
ranking,
monedas
) VALUES(
@_id_usuario,
@_nombre_usuario,
@_nombre_completo,
@_nacionalidad,
@_contrasena,
@_imagen,
@_estado,
@_ranking,
@_monedas
);

/*CONSULTA PARA OBTENER USUARIO POR PRIMARY KEY*/
CREATE PROCEDURE sp_consultar_usuario
@_id_usuario NVARCHAR(14)
AS
SELECT * FROM StarDeckDB.dbo.USUARIO
WHERE id_usuario=@_id_usuario;

/*CONSULTA PARA OBTENER TODOS LOS USUARIOS*/
CREATE PROCEDURE sp_consultar_usuarios
AS
SELECT * FROM USUARIO

-------------------------------/*CREAR CARTAS*/
CREATE PROCEDURE sp_crear_carta
@_id_carta		NVARCHAR(14),
@_nombre		NVARCHAR(30),
@_descripcion	NVARCHAR(1000),
@_energia		INT,
@_costo			INT,
@_tipo			NVARCHAR(10),
@_raza			NVARCHAR(25),
@_imagen		NVARCHAR(100),
@_estado		NVARCHAR(10)
AS
INSERT INTO CARTA
(
id_carta,
nombre,
descripcion,
energia,
costo,
tipo,
raza,
imagen,
estado
) VALUES(
@_id_carta,
@_nombre,
@_descripcion,
@_energia,
@_costo,
@_tipo,
@_raza,
@_imagen,
@_estado
);

/*CONSULTA PARA OBTENER CARTA POR PRIMARY KEY*/
CREATE PROCEDURE sp_consultar_carta
@_id_carta NVARCHAR(14)
AS
SELECT * FROM StarDeckDB.dbo.CARTA
WHERE id_carta=@_id_carta;

/*CONSULTA PARA OBTENER TODAS LAS CARTAS*/
CREATE PROCEDURE sp_consultar_cartas
AS
SELECT * FROM CARTA

-------------------------------/*CREAR CONEXION ENTRE CARTAS Y USUARIOS*/
CREATE PROCEDURE sp_crear_usuario_tiene_carta
@_id_usuario	NVARCHAR(14),
@_id_carta		NVARCHAR(14)
AS
INSERT INTO USUARIO_TIENE_CARTA
(
id_usuario,
id_carta
) VALUES(
@_id_usuario,
@_id_carta
);

/*CONSULTA PARA OBTENER CARTAS DE UN USUARIO POR PRIMARY KEY*/
CREATE PROCEDURE sp_consultar_usuario_tiene_carta
@_id_usuario NVARCHAR(14)
AS
SELECT * FROM StarDeckDB.dbo.USUARIO_TIENE_CARTA
WHERE id_usuario=@_id_usuario;

/*CONSULTA PARA OBTENER TODAS LAS CONEXIONES ENTRE USUARIOS Y CARTAS*/
CREATE PROCEDURE sp_consultar_usuario_tiene_cartas
AS
SELECT * FROM USUARIO_TIENE_CARTA

/*CONSULTAR CARTAS DE UN USUARIO*/
CREATE PROCEDURE sp_consultar_cartas_de_usuario
@_id_usuario NVARCHAR(14)
AS
SELECT * FROM USUARIO AS U
JOIN USUARIO_TIENE_CARTA AS USU
ON USU.id_carta = U.id_usuario
WHERE USU.id_usuario = @_id_usuario
