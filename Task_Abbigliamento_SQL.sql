CREATE TABLE Categoria(
	categoriaID INT PRIMARY KEY IDENTITY (1,1),
	nome_categoria VARCHAR(250)
);



CREATE TABLE Prodotto(
	prodottoID INT PRIMARY KEY IDENTITY (1,1),
	marca VARCHAR(250) NOT NULL,
	modello VARCHAR(250) NOT NULL,
	categoriaRIF INT NOT NULL,
	imgUno VARCHAR(250) NOT NULL,
	imgDue VARCHAR (250)NOT NULL,
	FOREIGN KEY (categoriaRIF) REFERENCES Categoria (categoriaID) ON DELETE CASCADE
);

CREATE TABLE Variazione (
	variazioneID INT PRIMARY KEY IDENTITY(1,1),
	colore VARCHAR(250) NOT NULL,
	taglia VARCHAR(10) NOT NULL,
	quantita INT NOT NULL,
	prodottoRIF INT NOT NULL,
	FOREIGN KEY (prodottoRIF) REFERENCES Prodotto (prodottoID) ON DELETE CASCADE 

);
CREATE TABLE Prezzo(
	prezzoID INT PRIMARY KEY IDENTITY(1,1),
	prezzo_pieno DECIMAL (6,2) NOT NULL,
	prezzo_scontato DECIMAL(6,2),
	inizio_sconto DATE,
	fine_sconto DATE,
	variazioneRIF INT NOT NULL,
	FOREIGN KEY (variazioneRIF) REFERENCES Variazione (variazioneID)
);


CREATE TABLE Utente(
	utenteID INT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR(250) NOT NULL,
	cognome VARCHAR(250) NOT NULL,
	telefono VARCHAR(250) NOT NULL,
	email VARCHAR(250) NOT NULL UNIQUE,
	nome_utente	 VARCHAR(250) NOT NULL UNIQUE,
);

CREATE TABLE Ordine (
	ordineID INT PRIMARY KEY IDENTITY (1,1),
	n_ordine INT NOT NULL UNIQUE,
	data_emissione DATE NOT NULL,
	isArrivato BIT NOT NULL DEFAULT 0,
	utenteRIF INT NOT NULL,
	FOREIGN KEY (utenteRIF) REFERENCES Utente (utenteID)
);

CREATE TABLE Variazione_Ordine(
	ordineRIF INT NOT NULL,
	variazioneRIF INT NOT NULL,
	FOREIGN KEY (variazioneRIF) REFERENCES Variazione(variazioneID),
	FOREIGN KEY (ordineRIF) REFERENCES Ordine(ordineID),
	PRIMARY KEY (ordineRIF,variazioneRIF)
);

SELECT * FROM Utente