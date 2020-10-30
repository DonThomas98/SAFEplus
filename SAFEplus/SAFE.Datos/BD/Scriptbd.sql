CREATE DATABASE "SafePlus";

USE "SafePlus";

/* Empresa queda como tabla obsoleta, debido a requerimientos, desde ahora solo existira el cliente .
CREATE TABLE empresa (
    id_empresa      NUMERIC PRIMARY KEY NOT NULL,--Numero identificador de la empresa, se auto incrementa
    nombre_empresa  VARCHAR2 NOT NULL,
    fecha_registro  DATE NOT NULL   --Este campo es para ver cuando se registro la empresa y calcular cobros
);

*/
--Cargo de los trabajadores de prevencion de riesgo, tabla que podria quedar fuera 

CREATE TABLE cargo (
    id_cargo    NUMERIC PRIMARY KEY NOT NULL, --Numero identificador del cargo del trabajador de prevencion.
    cargo       VARCHAR2(50)        NOT NULL, --Descripción del cargo
);

--Representante de la empresa con la que se realiza contrato, podria modificarse la logica para asociar varios clientes a una empresa.
CREATE TABLE cliente (
    rut         NUMERIC(10) PRIMARY KEY NOT NULL,
    dv_rut      CHAR                    NOT NULL,
    p_nombre    VARCHAR2(50)            NOT NULL,
    s_nombre    VARCHAR2(50)            NOT NULL,
    p_apellido  VARCHAR2(50)            NOT NULL,
    s_apellido  VARCHAR2(50)            NOT NULL,
    correo      VARCHAR2(100)           NOT NULL,
    edad        NUMERIC(3)              NOT NULL,
    direccion   VARCHAR2(100)           NOT NULL,
    telefono    NUMERIC, --Telefono como opcional, se ocupa de manera obligatoria el celular
    celular     NUMERIC                 NOT NULL,
);


--Prevencionistas de riesgo
CREATE TABLE trabajador (
    rut                    NUMERIC(10) PRIMARY KEY NOT NULL,
    dv_rut                 CHAR                    NOT NULL,
    p_nombre               VARCHAR2(50)            NOT NULL,
    s_nombre               VARCHAR2(50)            NOT NULL,
    p_apellido             VARCHAR2(50)            NOT NULL,
    s_apellido             VARCHAR2(50)            NOT NULL,
    correo                 VARCHAR2(100)           NOT NULL,
    edad                   NUMERIC(3)              NOT NULL,
    direccion              VARCHAR2(100)           NOT NULL,
    telefono               NUMERIC, --Telefono como opcional, se ocupa de manera obligatoria el celular
    celular                NUMERIC                 NOT NULL,
    habilitado             CHAR                     NOT NULL,--Si el trabajador esta trabajando actualmente 
    sueldo                 NUMERIC                 NOT NULL, 
    id_cargo               NUMERIC                 NOT NULL,
    contrasena             VARCHAR2(100)           NOT NULL,
    superuser              CHAR                     NOT NULL,--Si el trabajador tiene permisos de administrador
    FOREIGN KEY (id_cargo) REFERENCES cargo(id_cargo)--Relaciona al trabajador con una empresa
);


--Tabla que contiene los distintos materiales a usar en capacitaciones
CREATE TABLE material_capacitaciones(
    id_material NUMERIC PRIMARY KEY NOT NULL,
    material    VARCHAR2(50)        NOT NULL,
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
    descripcion    VARCHAR2(30)        NOT NULL,
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
    descripcion       VARCHAR2(15)        NOT NULL,--Aca se describe el tipo de accidente
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
    descripcion         VARCHAR2(10)           NOT NULL,--cliente  trabajador
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


--Los estados del informe pueden nulo , en caso de no aplicar el campo , falso si no cumple el requisito y verdadero en caso de cumplirlo, seran para los informes customizados.
--N = NULO o no aplica
--V = verdadero o al dia
--F = Falso o no al dia

CREATE TABLE informe_visita(
    id_informe            NUMERIC PRIMARY KEY NOT NULL,
    introduccion          VARCHAR2(250)       NOT NULL,--longitud provisional, sujeto a cambios
    resultados_evaluacion VARCHAR2(500)       NOT NULL,--longitud provisional, sujeto a cambios
    autoevaluacion        CHAR                 NOT NULL,--el cliente se autoevalua de manera que dice rapidamente si cumple las normas, pregunta cerrada.
    doc_actualizados      CHAR                 NOT NULL,--el cliente tiene sus documentos al dia
    reg_interno           CHAR                 NOT NULL,--el cliente posee un reglamento interno
    doc_seremi_trabajo    CHAR                 NOT NULL,--el cliente tiene sus docs timbrados por seremi/direccion de trabajo, pregunta cerrada.
    copia_documentos      CHAR                 NOT NULL,--el cliente entrega copias a los trabajadores, reglamento interno
    informa_riesgos       CHAR                 NOT NULL,--el cliente informa de los riesgos a sus trabajadores
    informa_medidas       CHAR                 NOT NULL,--el cliente informa de medidas de prevencion de riesgos a sus trabajadores
    programa_orden        CHAR                 NOT NULL,--el cliente posee programa de limpieza y orden
    reg_interno           CHAR                 NOT NULL,--el cliente posee un reglamento interno
    extintores            CHAR                         ,--el cliente posee extintores al dia.
    capacitacion_extintor CHAR                         ,--el cliente capacita a sus empleados en como usar el extintor
    epp_inventario        CHAR                         ,--el cliente posee elementos de proteccion personal actualmente.
    epp_certificados      CHAR                         ,--el cliente posee elementos de proteccion personal certificados

);


CREATE TABLE multa(
    id_multa                  NUMERIC PRIMARY KEY NOT NULL,
    monto_multa               NUMERIC             NOT NULL,
    descripcion               VARCHAR2(50)        NOT NULL,--se pone el campo de la tabla informe visita que este en falso.
    rut_cliente               NUMERIC(10)         NOT NULL,--FK a cliente.
    FOREIGN KEY (rut_cliente) REFERENCES cliente(rut),
);


CREATE TABLE asesoria(
    id_asesoria                  NUMERIC PRIMARY KEY NOT NULL,
    evento                       VARCHAR2(25)        NOT NULL,--Visita fiscalizadores, juicio 
    propuesta_mejora             VARCHAR2(500)       NOT NULL,--asesoria 
    rut_cliente                  NUMERIC(10)         NOT NULL,--FK a cliente.
    rut_trabajador               NUMERIC(10)         NOT NULL,--FK Trabajador
    FOREIGN KEY (rut_cliente)    REFERENCES cliente(rut),
    FOREIGN KEY (rut_trabajador) REFERENCES trabajador(rut),
);





