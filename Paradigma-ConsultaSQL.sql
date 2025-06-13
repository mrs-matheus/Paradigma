/*
	Execute esse código antes da Consulta do teste

	CREATE DATABASE Paradigma
	USE Paradigma

	CREATE TABLE Departamento (
	    Id INT PRIMARY KEY,
	    Nome VARCHAR(50)
	);

	CREATE TABLE Pessoa (
		Id INT IDENTITY(1,1) PRIMARY KEY,
		Nome VARCHAR(100) NULL,
		Salario INT NULL,
		DepartamentoId INT NOT NULL,
		FOREIGN KEY (DepartamentoId) REFERENCES Departamento(Id)
	);
	
	INSERT INTO Departamento (Id, Nome) VALUES
	(1, 'TI'),
	(2, 'Vendas');
	
	SET IDENTITY_INSERT Pessoa ON;
	
	INSERT INTO Pessoa (Id, Nome, Salario, DepartamentoId) VALUES
	(1, 'Joe', 70000, 1),
	(2, 'Henry', 80000, 2),
	(3, 'Sam', 60000, 2),
	(4, 'Max', 90000, 1);
	
	SET IDENTITY_INSERT Pessoa OFF;
*/

WITH RankedSalarios AS (
    SELECT 
        p.Nome AS Pessoa,
        p.Salario,
        d.Nome AS Departamento,
        ROW_NUMBER() OVER (PARTITION BY p.DepartamentoId ORDER BY p.Salario DESC) AS rn
    FROM Pessoa p
    JOIN Departamento d ON d.Id = p.DepartamentoId
)
SELECT Departamento, Pessoa, Salario
FROM RankedSalarios
WHERE rn = 1;