CREATE DATABASE "SafePlus";

USE "SafePlus";

/* Empresa queda como tabla obsoleta, debido a requerimientos, desde ahora solo existira el cliente .
CREATE TABLE empresa (
    id_empresa      NUMERIC PRIMARY KEY NOT NULL,--Numero identificador de la empresa, se auto incrementa
    nombre_empresa  NVARCHAR NOT NULL,
    fecha_registro  DATE NOT NULL   --Este campo es para ver cuando se registro la empresa y calcular cobros
);

*/
--Cargo de los trabajadores de prevencion de riesgo, tabla que podria quedar fuera 

CREATE TABLE cargo (
    id_cargo    NUMERIC PRIMARY KEY NOT NULL, --Numero identificador del cargo del trabajador de prevencion.
    cargo       NVARCHAR(50)        NOT NULL, --Descripción del cargo
);

--Representante de la empresa con la que se realiza contrato, podria modificarse la logica para asociar varios clientes a una empresa.
CREATE TABLE cliente (
    rut         NUMERIC(10) PRIMARY KEY NOT NULL,
    dv_rut      CHAR                    NOT NULL,
    p_nombre    NVARCHAR(50)            NOT NULL,
    s_nombre    NVARCHAR(50)            NOT NULL,
    p_apellido  NVARCHAR(50)            NOT NULL,
    s_apellido  NVARCHAR(50)            NOT NULL,
    correo      NVARCHAR(100)           NOT NULL,
    edad        NUMERIC(3)              NOT NULL,
    direccion   NVARCHAR(100)           NOT NULL,
    telefono    NUMERIC, --Telefono como opcional, se ocupa de manera obligatoria el celular
    celular     NUMERIC                 NOT NULL,
);


--Prevencionistas de riesgo
CREATE TABLE trabajador (
    rut                    NUMERIC(10) PRIMARY KEY NOT NULL,
    dv_rut                 CHAR                    NOT NULL,
    p_nombre               NVARCHAR(50)            NOT NULL,
    s_nombre               NVARCHAR(50)            NOT NULL,
    p_apellido             NVARCHAR(50)            NOT NULL,
    s_apellido             NVARCHAR(50)            NOT NULL,
    correo                 NVARCHAR(100)           NOT NULL,
    edad                   NUMERIC(3)              NOT NULL,
    direccion              NVARCHAR(100)           NOT NULL,
    telefono               NUMERIC, --Telefono como opcional, se ocupa de manera obligatoria el celular
    celular                NUMERIC                 NOT NULL,
    habilitado             BIT                     NOT NULL,--Si el trabajador esta trabajando actualmente 
    sueldo                 NUMERIC                 NOT NULL, 
    id_cargo               NUMERIC                 NOT NULL,
    contrasena             NVARCHAR(100)           NOT NULL,
    superuser              BIT                     NOT NULL,--Si el trabajador tiene permisos de administrador
    FOREIGN KEY (id_cargo) REFERENCES cargo(id_cargo)--Relaciona al trabajador con una empresa
);


--Tabla que contiene los distintos materiales a usar en capacitaciones
CREATE TABLE material_capacitaciones(
    id_material NUMERIC PRIMARY KEY NOT NULL,
    material    NVARCHAR(50)        NOT NULL,
);


--Guarda el registro de las capacitaciones
CREATE TABLE capacitacion(
    id_capacitacion              NUMERIC PRIMARY KEY NOT NULL,
    fecha_solicitud              DATE                NOT NULL,--Fecha en que se solicita la capacitacion
    fecha_capacitacion           DATE                NOT NULL,--Fecha en la que se concreta la capacitacion
    --CONEXIONES FORANEAS
    rut_trabajador               NUMERIC(10)         NOT NULL,--Vincula al rut del prevencionista que realizara la capacitacion
    rut_cliente                  NUMERIC(10)         NOT NULL,
    FOREIGN KEY (rut_trabajador) REFERENCES trabajador(rut),--Vincula el rut al cual se le realizara la capacitacion
    FOREIGN KEY (rut_cliente)    REFERENCES cliente(rut )
    
);


--Registro del material utilizado en cada capacitacion
CREATE TABLE material_solicitado(
    id_registro                   NUMERIC PRIMARY KEY NOT NULL,
    id_material                   NUMERIC             NOT NULL,--FK
    cantidad                      NUMERIC             NOT NULL,
    id_capacitacion               NUMERIC             NOT NULL,--FK
    FOREIGN KEY (id_capacitacion) REFERENCES capacitacion(id_capacitacion),
    FOREIGN KEY (id_material)     REFERENCES material_capacitaciones(id_material),
);


CREATE TABLE tipo_contrato(
    tipo_contrato  NUMERIC PRIMARY KEY NOT NULL,--Codigo del tipo de contrato
    descripcion    NVARCHAR(30)        NOT NULL,
    costo          NUMERIC             NOT NULL,
);


CREATE TABLE contrato(
    id_contrato                 NUMERIC PRIMARY KEY NOT NULL,
    rut                         NUMERIC PRIMARY KEY NOT NULL,--FK,vincula el contrato con el cliente
    tipo_contrato               NUMERIC             NOT NULL,--FK
    fecha_contratacion          DATE                NOT NULL,--fecha en la que se firma el contrato
    FOREIGN KEY (rut)           REFERENCES cliente(rut),
    FOREIGN KEY (tipo_contrato) REFERENCES tipo_contrato(tipo_contrato),
);


--Tabla que guarda el registro de pagos 
CREATE TABLE registro_pagos (
    id_pago                   NUMERIC PRIMARY KEY NOT NULL,
    monto_pago                NUMERIC             NOT NULL,  
    fecha_pago                DATE                NOT NULL,
    id_contrato               NUMERIC             NOT NULL,--FK
    FOREIGN KEY (id_contrato) REFERENCES contrato(id_contrato),
);


--Esta tabla es para identificar el tipo de accidente 
CREATE TABLE tipo_accidente (
    id_tipo_accidente NUMERIC PRIMARY KEY NOT NULL,--1 Laboral, 2 Revision, 3 Capacitacion, 4 Visita.
    descripcion       NVARCHAR(15)        NOT NULL,--Aca se describe el tipo de accidente
);


CREATE TABLE accidente(
    id_accidente                    NUMERIC PRIMARY KEY NOT NULL,
    fecha_accidente                 DATE                NOT NULL,
    id_tipo_accidente               NUMERIC             NOT NULL,--FK
    FOREIGN KEY (id_tipo_accidente) REFERENCES tipo_accidente(id_tipo_accidente)
);


--Esta tabla es para identificar si el accidentado es un trabajador de prevencion o un cliente.
CREATE TABLE tipo_accidentado(
    id_tipo_accidentado NUMERIC(2) PRIMARY KEY NOT NULL,--1 para cliente y 2 para trabajador de prevencion de riesgo.
    descripcion         NVARCHAR(10)           NOT NULL,--cliente  trabajador
);


--Esta tabla registra los afectados en un accidente, se guardan los datos sin asociarlos a las tablas de trabajador cliente.
CREATE TABLE accidentados ( 
    id_accidentados                   NUMERIC PRIMARY KEY NOT NULL,--Numero identificador de accidentado, se auto incrementa
    id_accidente                      NUMERIC             NOT NULL,--FK
    rut                               NUMERIC(10)         NOT NULL,--FK, vincula al accidentado con un trabajador
    id_tipo_accidentado               NUMERIC(2)          NOT NULL,--FK para vincular el rut para el tipo de trabajador, el que sufrio un accidente puede ser de la aseguradora o empleado de la empresa que contrato servicios.
    FOREIGN KEY (id_accidente)        REFERENCES accidente(id_accidente),
    FOREIGN KEY (id_tipo_accidentado) REFERENCES tipo_accidentados(id_tipo_accidentado),
    FOREIGN KEY (rut)                 REFERENCES cliente(rut),                                                
);


--Tabla que guarda los registros de la visita a a terreno, 2 por mes sin costo adicional
CREATE TABLE visita_terreno(
    id_visita                 NUMERIC PRIMARY KEY NOT NULL,
    fecha_visita              DATE                NOT NULL,
    rut                       NUMERIC(10)         NOT NULL, --FK, rut del trabajador que realizara la visita a terreno
    rut_cliente               NUMERIC(10)         NOT NULL, --Fk, conecta la visita con la empresa a realizar la visita.
    FOREIGN KEY (rut)         REFERENCES trabajador(rut),
    FOREIGN KEY (rut_cliente) REFERENCES cliente(rut),
);


CREATE TABLE informe_visita(
    id_informe            NUMERIC PRIMARY KEY NOT NULL,
    introduccion          NVARCHAR(250)       NOT NULL,--longitud provisional, sujeto a cambios
    resultados_evaluacion NVARCHAR(500)       NOT NULL,--longitud provisional, sujeto a cambios
    autoevaluacion        BIT                 NOT NULL,--el cliente se autoevalua de manera que dice rapidamente si cumple las normas, pregunta cerrada.
    doc_actualizados      BIT                 NOT NULL,--el cliente tiene sus documentos al dia
    doc_seremi_trabajo    BIT                 NOT NULL,--el cliente tiene sus docs timbrados por seremi/direccion de trabajo, pregunta cerrada.
    copia_documentos      BIT                 NOT NULL,--el cliente entrega copias a los trabajadores, reglamento
    reg_informa           BIT                 NOT NULL,--el cliente posee un reglamento interno
    reg_interno           BIT                 NOT NULL,--el cliente posee un reglamento interno
    reg_interno           BIT                 NOT NULL,--el cliente posee un reglamento interno
    reg_interno           BIT                 NOT NULL,--el cliente posee un reglamento interno
    reg_interno           BIT                 NOT NULL,--el cliente posee un reglamento interno

);


CREATE TABLE multa(
    id_multa                  NUMERIC PRIMARY KEY NOT NULL,
    monto_multa               NUMERIC             NOT NULL,
    descripcion               NVARCHAR(50)        NOT NULL,--se pone el campo de la tabla informe visita que este en falso.
    rut_cliente               NUMERIC(10)         NOT NULL,--FK a cliente.
    FOREIGN KEY (rut_cliente) REFERENCES cliente(rut),
);


CREATE TABLE asesoria(
    id_asesoria                  NUMERIC PRIMARY KEY NOT NULL,
    evento                       NVARCHAR(25)        NOT NULL,--Visita fiscalizadores, juicio 
    propuesta_mejora             NVARCHAR(500)       NOT NULL,--asesoria 
    rut_cliente                  NUMERIC(10)         NOT NULL,--FK a cliente.
    rut_trabajador               NUMERIC(10)         NOT NULL,--FK Trabajador
    FOREIGN KEY (rut_cliente)    REFERENCES cliente(rut),
    FOREIGN KEY (rut_trabajador) REFERENCES trabajador(rut),
);





