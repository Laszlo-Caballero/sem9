CREATE TABLE ESTUDIANTE (
    idEstudiante INT PRIMARY KEY,
    nombre VARCHAR(100),
    apellido VARCHAR(100),
    telefono VARCHAR(20),
    email VARCHAR(100),
    direccion VARCHAR(200),
    carrera VARCHAR(100)
);

CREATE TABLE ASESOR (
    idAsesor INT PRIMARY KEY,
    nombre VARCHAR(100),
    apellido VARCHAR(100),
    telefono VARCHAR(20),
    email VARCHAR(100),
    carrera VARCHAR(100)
);

CREATE TABLE JURADO (
    idJurado INT PRIMARY KEY,
    nombre VARCHAR(100),
    apellido VARCHAR(100),
    telefono VARCHAR(20),
    email VARCHAR(100),
    carrera VARCHAR(100)
);

CREATE TABLE TESIS (
    idTesis INT PRIMARY KEY,
    idEstudiante INT NOT NULL,
    tipoTesis VARCHAR(100),
    lineaInvestigacion VARCHAR(200),
    objetivo TEXT,
    fechaInicio DATE,
    estado VARCHAR(50),
    FOREIGN KEY (idEstudiante) REFERENCES ESTUDIANTE(idEstudiante)
);

CREATE TABLE ASIGNAR_ESTUDIANTE (
    idAsignacion INT PRIMARY KEY,
    idTesis INT NOT NULL,
    idEstudiante INT NOT NULL,
    FOREIGN KEY (idTesis) REFERENCES TESIS(idTesis),
    FOREIGN KEY (idEstudiante) REFERENCES ESTUDIANTE(idEstudiante)
);

CREATE TABLE ASIGNAR_ASESOR (
    idAsignar INT PRIMARY KEY,
    idTesis INT NOT NULL,
    idAsesor INT NOT NULL,
    FOREIGN KEY (idTesis) REFERENCES TESIS(idTesis),
    FOREIGN KEY (idAsesor) REFERENCES ASESOR(idAsesor)
);

CREATE TABLE PAGO_CARPETA (
    idPago INT PRIMARY KEY,
    idEstudiante INT NOT NULL,
    metodoPago VARCHAR(100),
    fecha DATE,
    estado VARCHAR(50),
    FOREIGN KEY (idEstudiante) REFERENCES ESTUDIANTE(idEstudiante)
);

CREATE TABLE SOLICITUD_TESIS (
    idSolicitud INT PRIMARY KEY,
    idPago INT NOT NULL,
    fecha DATE,
    estado VARCHAR(50),
    FOREIGN KEY (idPago) REFERENCES PAGO_CARPETA(idPago)
);

CREATE TABLE SUSTENTACION_FINAL (
    idSustentacion INT PRIMARY KEY,
    idTesis INT NOT NULL,
    fecha DATE,
    modalidad VARCHAR(100),
    calificacion VARCHAR(50),
    estado VARCHAR(50),
    FOREIGN KEY (idTesis) REFERENCES TESIS(idTesis)
);

CREATE TABLE ASIGNAR_JURADO (
    idAsignacion INT PRIMARY KEY,
    idSustentacion INT NOT NULL,
    idJurado INT NOT NULL,
    FOREIGN KEY (idSustentacion) REFERENCES SUSTENTACION_FINAL(idSustentacion),
    FOREIGN KEY (idJurado) REFERENCES JURADO(idJurado)
);
