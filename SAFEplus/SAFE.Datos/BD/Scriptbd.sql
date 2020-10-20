CREATE TABLE empresa (
    id_empresa      NUMERIC primary KEY NOT NULL,--Numero identificador de la empresa , se auto incrementa
    nombre_empresa  VARCHAR2 NOT NULL,
    fecha_registro  DATE NOT NULL   --Este campo es para ver cuando se registro la empresa y calcular cobros
);


--Cargo de los trabajadores de prevencion de riesgo , tabla que podria quedar fuera 
CREATE TABLE cargo (
    id_cargo   NUMBER   primary KEY NOT NULL,--Numero identificador del caargo del trabajador de prevencion .
    cargo      VARCHAR2 NOT NULL,
);


--Representante de la empresa con la que se realiza contrato , podria modificarse la logica para asociar varios clientes a una empresa.
CREATE TABLE cliente (
    rut         NUMBER   primary KEY NOT NULL,
    dv_rut      NUMBER   NOT NULL,
    p_nombre    VARCHAR2 NOT NULL,
    s_nombre    VARCHAR2 NOT NULL,
    p_apellido  VARCHAR2 NOT NULL,
    s_apellido  VARCHAR2 NOT NULL,
    correo      VARCHAR2 NOT NULL,
    edad        NUMBER   NOT NULL,
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
    correo      VARCHAR2 NOT NULL,
    edad        NUMBER   NOT NULL,
    direccion   VARCHAR2 NOT NULL,
    telefono    NUMBER           ,--Telefono como opcional , se ocupa de manera obligatoria el celular
    celular     NUMBER   NOT NULL,
    habilitado  Boolean  NOT NULL,--Si el trabajador esta trabajando actualmente 
    id_cargo    NUMBER   NOT NULL,
    FOREIGN KEY (id_cargo ) REFERENCES empresa(id_cargo )--Relaciona al trabajador con una empresa

);


--Tabla que guarda el registro de pagos 
CREATE TABLE registro_pagos (
    id_pago numeric primary key ,
    monto_pago numeric NOT NULL ,  


);




--Tabla que contiene los distintos materiales a usar en capacitaciones
CREATE TABLE material_capacitaciones(
    id_material NUMERIC PRIMARY KEY NOT NULL ,
    material    VARCHAR2 NOT NULL            ,
);



--Guarda el registro de las capacitaciones
CREATE TABLE capacitaciones(
    id_capacitacion NUMERIC PRIMARY KEY NOT NULL ,
    fecha_solicitud DATE NOT NULL                ,--Fecha en que se solicita la capacitacion
    fecha_capacitacion DATE NOT NULL             ,--Fecha en la que se concreta la capacitacion
    --CONEXIONES FORANEAS
    rut            NUMERIC primary KEY NOT NULL  , --Vincula al rut del prevencionista que realizara la capacitacion
    id_empresa     NUMERIC primary KEY NOT NULL  ,
    FOREIGN KEY (rut) REFERENCES trabajador(rut) ,
    FOREIGN KEY (id_empresa ) REFERENCES empresa(id_empresa )
    
);



--Registro del material utilizado en cada capacitacion
CREATE TABLE material_solicitado(
    id_registro     NUMERIC PRIMARY KEY NOT NULL ,
    id_material     NUMERIC NOT NULL             ,--FK
    cantidad        NUMERIC NOT NULL             ,
    id_capacitacion NUMERIC NOT NULL             ,--FK

    FOREIGN KEY (id_capacitacion ) REFERENCES capacitaciones(id_capacitacion),
    FOREIGN KEY (id_material )     REFERENCES material_capacitaciones(id_material)
);



CREATE TABLE tipo_contrato(
    tipo_contrato  NUMERIC PRIMARY KEY NOT NULL,--Codigo del tipo de contrato
    descripcion    VARCHAR2            NOT NULL,

);



CREATE TABLE contrato(
    id_contrato   NUMERIC PRIMARY KEY NOT NULL ,
    tipo_contrato        NUMERIC      NOT NULL ,--FK
    fecha_contratacion   DATE         NOT NULL ,--fecha en la que se firma el contrato
    id_empresa    NUMERIC primary KEY NOT NULL ,--FK ,vincula el contrato con la empresa
    FOREIGN KEY (id_empresa ) REFERENCES empresa(id_empresa),
    FOREIGN KEY (tipo_contrato ) REFERENCES tipo_contrato(tipo_contrato),
);


--Esta tabla es para identificar el tipo de accidente 
CREATE TABLE tipo_accidente (
    id_tipo_accidente NUMERIC PRIMARY KEY NOT NULL ,--1 Laboral ,2 Revision , 3 Capacitacion , 4 Visita.
    descripcion       VARCHAR2            NOT NULL ,--Aca se describe con una letra el tipo de accidente 
);


CREATE TABLE accidente(
    id_accidente      NUMERIC PRIMARY KEY NOT NULL ,
    fecha_accidente   DATE                NOT NULL  ,
    id_tipo_accidente NUMERIC             NOT NULL  ,--FK
    FOREIGN KEY (id_tipo_accidente ) REFERENCES tipo_accidente(id_tipo_accidente),

);


--Esta tabla es para identificar si el accidentado es un trabajador de prevencion o un cliente.
CREATE TABLE tipo_accidentados(
    id_tipo_accidentado NUMERIC PRIMARY KEY NOT NULL ,--1 para cliente y 2 para trabajador de prevencion de riesgo.
    descripcion         VARCHAR2            NOT NULL ,--cliente  trabajador

);

--Esta tabla registra los afectados en un accidente , se guardan los datos sin asociarlos a las tablas de trabajador cliente.
CREATE TABLE accidentados ( 
    id_accidentados     NUMERIC PRIMARY KEY NOT NULL ,--Numero identificador de accidentado , se auto incrementa
    id_accidente        NUMERIC             NOT NULL ,--FK
    rut                 NUMERIC             NOT NULL ,--puede ser tanto un cliente como trabajador , debera existir un buscador por rut para llenar rapidamente el formulario 
                                                      --debera aparecer la nomina de empleados de la empresa y el trabajador asignado a esta , en proceso.
    p_nombre            VARCHAR2            NOT NULL,
    s_nombre            VARCHAR2            NOT NULL,
    p_apellido          VARCHAR2            NOT NULL,
    s_apellido          VARCHAR2            NOT NULL,
    direccion           VARCHAR2            NOT NULL,
    telefono            NUMBER                      ,
    celular             NUMBER              NOT NULL,
    id_tipo_accidentado NUMERIC             NOT NULL,--FK para vincular el rut para el tipo de trabajador , el que sufrio un accidente puede ser de la aseguradora o empleado de la empresa que contrato servicios.
    FOREIGN KEY (id_accidente )        REFERENCES accidente(id_accidente),
    FOREIGN KEY (id_tipo_accidentado ) REFERENCES tipo_accidentados(id_tipo_accidentado),

                                                    
);


--Tabla que guarda los registros de la visita a a terreno , 2 por mes sin costo adicional
CREATE TABLE visita_terreno(
    id_visita       NUMERIC PRIMARY KEY NOT NULL ,
    fecha_visita    DATE                NOT NULL ,
    rut             NUMERIC             NOT NULL , --FK , rut del trabajador que realizara la visita a terreno
    id_empresa      NUMERIC             NOT NULL , --Fk , conecta la visita con la empresa a realizar la visita.
    FOREIGN KEY (rut) REFERENCES trabajador(rut),
    FOREIGN KEY (id_empresa) REFERENCES empresa(id_empresa),


);










