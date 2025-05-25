CREATE TABLE ESTUDIANTE (
    idEstudiante INT IDENTITY(1,1) PRIMARY KEY ,
    nombre VARCHAR(100),
    apellido VARCHAR(100),
    telefono VARCHAR(20),
    email VARCHAR(100),
    direccion VARCHAR(200),
    carrera VARCHAR(100)
);

CREATE TABLE ASESOR (
    idAsesor INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100),
    apellido VARCHAR(100),
    telefono VARCHAR(20),
    email VARCHAR(100),
    carrera VARCHAR(100)
);

CREATE TABLE JURADO (
    idJurado INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100),
    apellido VARCHAR(100),
    telefono VARCHAR(20),
    email VARCHAR(100),
    carrera VARCHAR(100)
);

CREATE TABLE TESIS (
    idTesis INT IDENTITY(1,1) PRIMARY KEY,
	idAsesor INT NOT NULL,
    tipoTesis VARCHAR(100),
    lineaInvestigacion VARCHAR(200),
    objetivo TEXT,
    fechaInicio DATE,
    estado VARCHAR(50),
    FOREIGN KEY (idAsesor) REFERENCES ASESOR(idAsesor)
);

CREATE TABLE ASIGNAR_ESTUDIANTE (
    idAsignacion INT IDENTITY(1,1) PRIMARY KEY,
    idTesis INT NOT NULL,
    idEstudiante INT NOT NULL,
    FOREIGN KEY (idTesis) REFERENCES TESIS(idTesis),
    FOREIGN KEY (idEstudiante) REFERENCES ESTUDIANTE(idEstudiante)
);

CREATE TABLE PAGO_CARPETA (
    idPago INT IDENTITY(1,1) PRIMARY KEY,
    idEstudiante INT NOT NULL,
    metodoPago VARCHAR(100),
    fecha DATE,
    estado VARCHAR(50),
    FOREIGN KEY (idEstudiante) REFERENCES ESTUDIANTE(idEstudiante)
);

CREATE TABLE SOLICITUD_TESIS (
    idSolicitud INT IDENTITY(1,1) PRIMARY KEY,
    idPago INT NOT NULL,
    fecha DATE,
    estado VARCHAR(50),
    FOREIGN KEY (idPago) REFERENCES PAGO_CARPETA(idPago)
);

CREATE TABLE SUSTENTACION_FINAL (
    idSustentacion INT IDENTITY(1,1) PRIMARY KEY,
    idTesis INT NOT NULL,
    fecha DATE,
    modalidad VARCHAR(100),
    calificacion VARCHAR(50),
    estado VARCHAR(50),
    FOREIGN KEY (idTesis) REFERENCES TESIS(idTesis)
);

CREATE TABLE ASIGNAR_JURADO (
    idAsignacion INT IDENTITY(1,1) PRIMARY KEY,
    idSustentacion INT NOT NULL,
    idJurado INT NOT NULL,
    FOREIGN KEY (idSustentacion) REFERENCES SUSTENTACION_FINAL(idSustentacion),
    FOREIGN KEY (idJurado) REFERENCES JURADO(idJurado)
);