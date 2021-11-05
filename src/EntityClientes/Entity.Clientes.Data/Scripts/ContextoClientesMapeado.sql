ALTER DATABASE CHARACTER SET utf8mb4;


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


CREATE TABLE `clientes` (
    `id` int NOT NULL AUTO_INCREMENT,
    `nome` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `observacao` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    CONSTRAINT `PK_clientes` PRIMARY KEY (`id`),
    CONSTRAINT `FK_clientes_enderecos_enderecoid` FOREIGN KEY (`id`) REFERENCES `enderecos` (`id`) ON DELETE RESTRICT
) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;


CREATE INDEX `IX_clientes_id` ON `clientes` (`id`);


CREATE INDEX `enderecoid_idx` ON `enderecos` (`id`);


