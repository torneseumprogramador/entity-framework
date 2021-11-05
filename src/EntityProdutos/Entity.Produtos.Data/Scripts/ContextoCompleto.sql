CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET utf8mb4;

START TRANSACTION;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20211015020318_ContextoCompleto') THEN

    ALTER DATABASE CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `categorias`) THEN

    CREATE TABLE `categorias` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Descricao` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
        CONSTRAINT `PK_categorias` PRIMARY KEY (`Id`)
    ) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20211015020318_ContextoCompleto') THEN

    CREATE TABLE `enderecos` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Logradouro` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
        `Cep` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
        `Bairro` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
        `Numero` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
        `Complemento` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
        `Cidade` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
        `Estado` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
        CONSTRAINT `PK_enderecos` PRIMARY KEY (`Id`)
    ) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20211015020318_ContextoCompleto') THEN

    CREATE TABLE `fornecedores` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Nome` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
        `DocumentoIdentificacao` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
        `TipoFornecedor` int NOT NULL,
        `Ativo` tinyint(1) NOT NULL,
        `EnderecoId` int NULL,
        CONSTRAINT `PK_fornecedores` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_fornecedores_enderecos_EnderecoId` FOREIGN KEY (`EnderecoId`) REFERENCES `enderecos` (`Id`) ON DELETE RESTRICT
    ) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20211015020318_ContextoCompleto') THEN

    CREATE TABLE `produtos` (
        `id` int NOT NULL AUTO_INCREMENT,
        `nome` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
        `url_imagem` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
        `descricao` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
        `valor` double NOT NULL,
        `CategoriaId` int NOT NULL,
        `FornecedorId` int NULL,
        CONSTRAINT `PK_produtos` PRIMARY KEY (`id`),
        CONSTRAINT `FK_produtos_categorias_CategoriaId` FOREIGN KEY (`CategoriaId`) REFERENCES `categorias` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_produtos_fornecedores_FornecedorId` FOREIGN KEY (`FornecedorId`) REFERENCES `fornecedores` (`Id`) ON DELETE RESTRICT
    ) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20211015020318_ContextoCompleto') THEN

    CREATE INDEX `IX_fornecedores_EnderecoId` ON `fornecedores` (`EnderecoId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20211015020318_ContextoCompleto') THEN

    CREATE INDEX `IX_produtos_CategoriaId` ON `produtos` (`CategoriaId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20211015020318_ContextoCompleto') THEN

    CREATE INDEX `IX_produtos_FornecedorId` ON `produtos` (`FornecedorId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20211015020318_ContextoCompleto') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20211015020318_ContextoCompleto', '5.0.8');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

