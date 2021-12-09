ALTER DATABASE CHARACTER SET utf8mb4;


CREATE TABLE `cupons_descontos` (
    `cupom_desconto_id` int NOT NULL AUTO_INCREMENT,
    `codigo_cupom` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `percentual_desconto` decimal(12,2) NULL,
    `valor_desconto` decimal(12,2) NULL,
    `quantidade` int NOT NULL,
    `tipo_cupom_desconto` int NOT NULL,
    `criado_em` datetime(6) NOT NULL,
    `aplicado_em` datetime(6) NOT NULL,
    `data_expiracao` datetime(6) NOT NULL,
    `ativo` tinyint NOT NULL,
    `aplicado` tinyint NOT NULL,
    CONSTRAINT `PK_cupons_descontos_id` PRIMARY KEY (`cupom_desconto_id`)
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


CREATE TABLE `pedidos` (
    `id` int NOT NULL AUTO_INCREMENT,
    `codigo` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `cliente_id` int NOT NULL,
    `endereco_id` int NOT NULL,
    `desconto` decimal(12,2) NOT NULL,
    `valor_total` decimal(12,2) NOT NULL,
    `data_pedido` datetime(6) NOT NULL,
    `cupom_desconto_id` int NULL,
    `pedido_status` int NOT NULL,
    CONSTRAINT `PK_pedidos` PRIMARY KEY (`id`),
    CONSTRAINT `FK_pedidos_cupons_descontos_cupom_desconto_id` FOREIGN KEY (`cupom_desconto_id`) REFERENCES `cupons_descontos` (`cupom_desconto_id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_pedidos_enderecos_endereco_id` FOREIGN KEY (`endereco_id`) REFERENCES `enderecos` (`id`) ON DELETE CASCADE
) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;


CREATE TABLE `pedidos_itens` (
    `pedido_item_id` int NOT NULL AUTO_INCREMENT,
    `pedido_id` int NOT NULL,
    `produto_id` int NOT NULL,
    `nome_produto` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `quantidade` int NOT NULL,
    `valor_unitario` decimal(12,2) NOT NULL,
    CONSTRAINT `PK_pedidos_itens` PRIMARY KEY (`pedido_item_id`),
    CONSTRAINT `FK_pedido_itens_pedidos_pedido_id` FOREIGN KEY (`pedido_id`) REFERENCES `pedidos` (`id`) ON DELETE CASCADE
) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;


CREATE INDEX `IX_enderecos_id` ON `enderecos` (`id`);


CREATE INDEX `IX_pedido_cupom_desconto_id` ON `pedidos` (`cupom_desconto_id`);


CREATE INDEX `IX_pedidos_cliente_id` ON `pedidos` (`cliente_id`);


CREATE INDEX `IX_pedidos_endereco_id` ON `pedidos` (`endereco_id`);


CREATE INDEX `IX_pedidos_itens_pedido_id` ON `pedidos_itens` (`pedido_id`);


CREATE INDEX `IX_pedidos_itens_produto_id` ON `pedidos_itens` (`produto_id`);


