-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 13-Jul-2022 às 03:17
-- Versão do servidor: 10.4.24-MariaDB
-- versão do PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `dbshoplist`
--
CREATE DATABASE IF NOT EXISTS `dbshoplist` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `dbshoplist`;

-- --------------------------------------------------------

--
-- Estrutura da tabela `lista`
--

CREATE TABLE `lista` (
  `idproduto` int(11) NOT NULL,
  `email` varchar(45) DEFAULT NULL,
  `produto` varchar(45) DEFAULT NULL,
  `preco` double DEFAULT NULL,
  `quantidade` int(11) DEFAULT NULL,
  `total` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `lista`
--

INSERT INTO `lista` (`idproduto`, `email`, `produto`, `preco`, `quantidade`, `total`) VALUES
(1, 'admin@admin.com', 'pão suiço', 3, 15, 45),
(2, 'admin@admin.com', 'leite', 3, 10, 30),
(4, 'admin@admin.com', 'arroz', 13, 4, 52),
(5, 'admin@admin.com', 'feijão', 6, 13, 78),
(7, 'lc@lc.com', 'Nescau', 9, 4, 45),
(18, 'lc@lc.com', 'leite', 5, 9, 45);

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuario`
--

CREATE TABLE `usuario` (
  `idusuario` int(11) NOT NULL,
  `nome` varchar(50) DEFAULT NULL,
  `email` varchar(60) DEFAULT NULL,
  `senha` varchar(30) DEFAULT NULL,
  `datadenascimento` varchar(20) DEFAULT NULL,
  `cpf` varchar(20) DEFAULT NULL,
  `telefone` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `usuario`
--

INSERT INTO `usuario` (`idusuario`, `nome`, `email`, `senha`, `datadenascimento`, `cpf`, `telefone`) VALUES
(1, 'admin', 'admin@admin.com', '123', NULL, NULL, NULL),
(2, 'Lucas', 'lc@lc.com', '123', '03/04/2003', '123,135,213-21', '(21) 99968-0746');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `lista`
--
ALTER TABLE `lista`
  ADD PRIMARY KEY (`idproduto`);

--
-- Índices para tabela `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`idusuario`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `lista`
--
ALTER TABLE `lista`
  MODIFY `idproduto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT de tabela `usuario`
--
ALTER TABLE `usuario`
  MODIFY `idusuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
