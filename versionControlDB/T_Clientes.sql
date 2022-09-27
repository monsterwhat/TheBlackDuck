CREATE TABLE clientes (
  idCliente INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
  clienteHijo TEXT  NOT NULL,
  clientePadre TEXT  NOT NULL,
  idClientePagos INTEGER NOT NULL,
  clienteNumero INTEGER NOT NULL,
  clienteContrasenna TEXT NOT NULL,
  CONSTRAINT tblCliente_tblPagos FOREIGN KEY (idClientePagos) REFERENCES clientespagos (idClientePagos)
);