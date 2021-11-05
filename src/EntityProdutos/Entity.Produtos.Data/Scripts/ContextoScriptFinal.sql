ALTER DATABASE CHARACTER SET utf8mb4;


CREATE TABLE `categorias` (
    `id` int NOT NULL AUTO_INCREMENT,
    `descricao` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    CONSTRAINT `PK_categorias` PRIMARY KEY (`id`)
) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;


CREATE TABLE `enderecos` (
    `id` int NOT NULL AUTO_INCREMENT,
    `logradouro` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `cep` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `bairro` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `numero` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `complemento` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `cidade` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `estado` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    CONSTRAINT `PK_enderecos` PRIMARY KEY (`id`)
) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;


CREATE TABLE `fornecedores` (
    `id` int NOT NULL AUTO_INCREMENT,
    `nome` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `documento_identificacao` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `tipo_fornecedor` int NOT NULL,
    `ativo` tinyint(1) NOT NULL,
    `endereco_id` int NOT NULL,
    CONSTRAINT `PK_fornecedores` PRIMARY KEY (`id`),
    CONSTRAINT `FK_fornecedores_enderecos_endereco_id` FOREIGN KEY (`endereco_id`) REFERENCES `enderecos` (`id`) ON DELETE RESTRICT
) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;


CREATE TABLE `produtos` (
    `id` int NOT NULL AUTO_INCREMENT,
    `nome` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `url_imagem` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `descricao` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `valor` double NOT NULL,
    `categoria_id` int NOT NULL,
    `fornecedor_id` int NOT NULL,
    CONSTRAINT `PK_produtos` PRIMARY KEY (`id`),
    CONSTRAINT `FK_produtos_categorias_categoria_id` FOREIGN KEY (`categoria_id`) REFERENCES `categorias` (`id`) ON DELETE CASCADE,
    CONSTRAINT `FK_produtos_fornecedores_fornecedor_id` FOREIGN KEY (`fornecedor_id`) REFERENCES `fornecedores` (`id`) ON DELETE CASCADE
) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;


INSERT INTO `categorias` (`id`, `descricao`)
VALUES (1, 'Alimentos');


INSERT INTO `categorias` (`id`, `descricao`)
VALUES (2, 'Bebidas');


CREATE INDEX `IX_categorias_id` ON `categorias` (`id`);


CREATE INDEX `IX_enderecos_id` ON `enderecos` (`id`);


CREATE INDEX `IX_forcedores_fornecedorid` ON `fornecedores` (`id`);


CREATE INDEX `IX_fornecedores_enderecos_id` ON `fornecedores` (`endereco_id`);


CREATE INDEX `IX_PK_produtos` ON `produtos` (`id`);


CREATE INDEX `IX_produtos_categoria_id` ON `produtos` (`categoria_id`);


CREATE INDEX `IX_produtos_fornecedor_id` ON `produtos` (`fornecedor_id`);


