CREATE TABLE empresa (
    id_empresa      NUMERIC primary KEY NOT NULL,
    nombre_empresa  VARCHAR2 NOT NULL,
    fecha_registro  DATE NOT NULL   ##Este campo es para ver cuando se registro la empresa y calcular cobros
);

CREATE TABLE cargo (
    id_cargo   NUMBER   primary KEY NOT NULL,
    cargo      VARCHAR2 NOT NULL,
);

CREATE TABLE cliente (
    rut         NUMBER   primary KEY NOT NULL,
    dv_rut      NUMBER   NOT NULL,
    p_nombre    VARCHAR2 NOT NULL,
    s_nombre    VARCHAR2 NOT NULL,
    p_apellido  VARCHAR2 NOT NULL,
    s_apellido  VARCHAR2 NOT NULL,
    direccion   VARCHAR2 NOT NULL,
    telefono    NUMBER           ,
    celular     NUMBER   NOT NULL,
    id_empresa  NUMBER   NOT NULL,
    FOREIGN KEY (id_empresa) REFERENCES empresa(id_empresa)
);

CREATE TABLE trabajador (
    rut         NUMBER   primary KEY NOT NULL,
    dv_rut      NUMBER   NOT NULL,
    p_nombre    VARCHAR2 NOT NULL,
    s_nombre    VARCHAR2 NOT NULL,
    p_apellido  VARCHAR2 NOT NULL,
    s_apellido  VARCHAR2 NOT NULL,
    edad        NUMBER   NOT NULL,
    direccion   VARCHAR2 NOT NULL,
    telefono    NUMBER           ,##Telefono como opcional , se ocupa de manera obligatoria el celular
    celular     NUMBER   NOT NULL,
    id_cargo   NUMBER   NOT NULL ,
    FOREIGN KEY (id_cargo ) REFERENCES empresa(id_cargo )##Relaciona al trabajador con una empresa

);


CREATE TABLE registro_pagos (
    id_pago numeric primary key ,
    monto_pago numeric NOT NULL ,  


);

##Guarda el registro de las capacitaciones y material usado

CREATE TABLE material_capacitaciones(
    id_material NUMERIC PRIMARY KEY NOT NULL ,
    material    VARCHAR2 NOT NULL            ,
);


CREATE TABLE capacitaciones(
    id_capacitacion NUMERIC PRIMARY KEY NOT NULL ,
    fecha_solicitud DATE NOT NULL                ,##Fecha en que se solicita la capacitacion
    fecha_capacitacion DATE NOT NULL             ,##Fecha en la que se concreta la capacitacion
    ##CONEXIONES FORANEAS
    rut            NUMERIC primary KEY NOT NULL ,##Vincula al rut del empleado
    id_empresa     NUMERIC primary KEY NOT NULL ,
    FOREIGN KEY (rut) REFERENCES trabajador(rut),
    FOREIGN KEY (id_empresa ) REFERENCES empresa(id_empresa )
    
);



CREATE TABLE material_solicitado(
    id_registro     NUMERIC PRIMARY KEY NOT NULL ,
    id_material     NUMERIC NOT NULL             ,##FK
    cantidad        NUMERIC NOT NULL             ,
    id_capacitacion NUMERIC NOT NULL             ,##FK
    FOREIGN KEY (id_capacitacion ) REFERENCES capacitaciones(id_capacitacion),
    FOREIGN KEY (id_material )     REFERENCES material_capacitaciones(id_material)
);


CREATE TABLE tipo_contrato(
    tipo_contrato  NUMERIC PRIMARY KEY NOT NULL,##Codigo del tipo de contrato
    descripcion    VARCHAR2            NOT NULL,

);

CREATE TABLE contrato(
    id_contrato   NUMERIC PRIMARY KEY NOT NULL ,
    tipo_contrato        NUMERIC      NOT NULL ,##FK
    fecha_contratacion   DATE         NOT NULL ,##fecha en la que se firma el contrato
    id_empresa    NUMERIC primary KEY NOT NULL ,##FK ,vincula el contrato con la empresa
    FOREIGN KEY (id_empresa ) REFERENCES empresa(id_empresa),
    FOREIGN KEY (tipo_contrato ) REFERENCES tipo_contrato(tipo_contrato),
);

