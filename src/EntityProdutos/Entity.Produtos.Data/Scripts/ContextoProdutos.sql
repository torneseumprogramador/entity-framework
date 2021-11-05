ALTER DATABASE CHARACTER SET utf8mb4;


CREATE TABLE `categorias` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Descricao` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    CONSTRAINT `PK_categorias` PRIMARY KEY (`Id`)
) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;


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


CREATE TABLE `fornecedores` (
    `id` int NOT NULL AUTO_INCREMENT,
    `nome` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `documento_identificacao` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `tipo_fornecedor` int NOT NULL,
    `ativo` tinyint(1) NOT NULL,
    `endereco_id` int NULL,
    CONSTRAINT `PK_fornecedores` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_fornecedores_enderecos_endereco_id` FOREIGN KEY (`endereco_id`) REFERENCES `enderecos` (`id`) ON DELETE RESTRICT
) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;


CREATE TABLE `produtos` (
    `id` int NOT NULL AUTO_INCREMENT,
    `nome` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `url_imagem` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `descricao` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `valor` double NOT NULL,
    `categoria_id` int NULL,
    `fornecedor_id` int NULL,
    CONSTRAINT `PK_produtos` PRIMARY KEY (`id`),
    CONSTRAINT `FK_produtos_categorias_categoria_id` FOREIGN KEY (`categoria_id`) REFERENCES `categorias` (`id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_produtos_fornecedores_FornecedorId` FOREIGN KEY (`fornecedor_id`) REFERENCES `fornecedores` (`id`) ON DELETE RESTRICT
) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;


CREATE INDEX `IX_fornecedores_endereco_id` ON `fornecedores` (`endereco_id`);


CREATE INDEX `IX_produtos_categoria_id` ON `produtos` (`categoria_id`);


CREATE INDEX `IX_produtos_fornecedor_id` ON `produtos` (`fornecedor_id`);


