-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 17-02-2026 a las 14:38:09
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `db_laboratorio_pio`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `categorias`
--

CREATE TABLE `categorias` (
  `id_categoria` int(11) NOT NULL,
  `nombre_categoria` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `categorias`
--

INSERT INTO `categorias` (`id_categoria`, `nombre_categoria`) VALUES
(1, 'Estudios de Sangre'),
(2, 'Estudios de Orina'),
(3, 'Estudios de Heces y Otros Fluidos'),
(4, 'Estudios de Secreciones'),
(5, 'Otros Estudios Especializados y Paquetes');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estudios`
--

CREATE TABLE `estudios` (
  `id_estudio` int(11) NOT NULL,
  `nombre_estudio` varchar(150) DEFAULT NULL,
  `precio_base` decimal(10,2) DEFAULT NULL,
  `id_categoria` int(11) DEFAULT NULL,
  `id_tipo_muestra` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `estudios`
--

INSERT INTO `estudios` (`id_estudio`, `nombre_estudio`, `precio_base`, `id_categoria`, `id_tipo_muestra`) VALUES
(32, 'ACIDO URICO (Sérico)', 80.00, 1, 1),
(33, 'ANTIESTREPTOLISINAS', 200.00, 1, 1),
(34, 'ALBUMINA (Sérica)', 160.00, 1, 1),
(35, 'ALFAFETOPROTEINAS', 350.00, 1, 1),
(36, 'AMILASA (Sérica)', 180.00, 1, 1),
(37, 'ANT. CARCINOEMBRIONARIO', 400.00, 1, 1),
(38, 'ANT. HERPES VIRUS SIMPLEX (IgG e IgM)', 1000.00, 1, 1),
(39, 'ANT. Mycobacterium tuberculosis', 500.00, 1, 1),
(40, 'ANT. PROST. TOTAL Y LIBRE', 700.00, 1, 1),
(41, 'ANT. PROSTATA LIBRE', 400.00, 1, 1),
(42, 'ANT. PROSTATA ESPECIFICO', 400.00, 1, 1),
(43, 'BAAR 1 MUESTRA', 220.00, 1, 1),
(44, 'BH (Biometría Hemática)', 120.00, 1, 1),
(45, 'BILIRRUBINAS', 275.00, 1, 1),
(46, 'CA 125 \"OVARIO\"', 500.00, 1, 1),
(47, 'CA 15-3 \"MAMA\"', 500.00, 1, 1),
(48, 'CA 19-9 \"PANCREAS Y COLON\"', 500.00, 1, 1),
(49, 'CA 21.1 \"PULMON\"', 800.00, 1, 1),
(50, 'CA 27-29 (MAMA)', 2000.00, 1, 1),
(51, 'CA 72.4 \"ESTOMAGO\"', 800.00, 1, 1),
(52, 'CALCIO SERICO', 210.00, 1, 1),
(53, 'CHIKUNGUNYA (Ant. IgM y IgG)', 700.00, 1, 1),
(54, 'CINETICA DE HIERRO', 520.00, 1, 1),
(55, 'COLESTEROL (Total)', 80.00, 1, 1),
(56, 'COLESTEROL HDL (ALTA DENSIDAD)', 250.00, 1, 1),
(57, 'CK (Creatin Fosfo Kinasa Total)', 200.00, 1, 1),
(58, 'CK MB (Creatin Fosfo Kinasa Fracción MB)', 250.00, 1, 1),
(59, 'CREATININA (Sérica)', 80.00, 1, 1),
(60, 'DHL (Deshidrogenasa Láctica)', 300.00, 1, 1),
(61, 'DIMERO D', 650.00, 1, 1),
(62, 'ESTRADIOL (Serico)', 350.00, 1, 1),
(63, 'FACTOR REUMATOIDE', 85.00, 1, 1),
(64, 'FERRITNINA', 350.00, 1, 1),
(65, 'FIBRINOGENO', 500.00, 1, 1),
(66, 'FOSFATASA ALCALINA', 100.00, 1, 1),
(67, 'FROTIS EN SANGRE PERIFERIA', 150.00, 1, 1),
(68, 'FSH (Hormona Folículo Estimulante)', 300.00, 1, 1),
(69, 'GLUCOSA', 80.00, 1, 1),
(70, 'GRUPO Y RH', 80.00, 1, 1),
(71, 'Hb-A1c (Hemoglobina Glicosilada)', 350.00, 1, 1),
(72, 'HEMOCULTIVO', 1250.00, 1, 1),
(73, 'HGC (Cuan. Gonadotropina Corio. Hum)', 400.00, 1, 1),
(74, 'HIERRO SERICO', 180.00, 1, 1),
(75, 'INSULINA', 350.00, 1, 1),
(76, 'LIPASA', 180.00, 1, 1),
(77, 'PCR (Proteína \"C\" Reactiva)', 150.00, 1, 1),
(78, 'TSH (Hormona Estimulante de la Tiroides)', 250.00, 1, 1),
(79, 'VDRL', 100.00, 1, 1),
(80, 'VIH', 200.00, 1, 1),
(81, 'VSG (Velocidad Sedimentación Globular)', 100.00, 1, 1),
(82, 'EGO (Examen General de Orina)', 100.00, 2, 2),
(83, 'UROCULTIVO', 400.00, 2, 2),
(84, 'MICROALBUMINA EN ORINA', 200.00, 2, 2),
(85, 'PROTEINAS EN ORINA 24 HRS', 250.00, 2, 2),
(86, 'DEPURACIÓN DE CREATININA EN ORINA (24HR!)', 250.00, 2, 2),
(87, 'ALBUMINA EN ORINA AL AZAR', 180.00, 2, 2),
(88, 'COPROLOGICO', 250.00, 3, 3),
(89, 'COPROPARASITOSCOPICO', 80.00, 3, 3),
(90, 'COPROPARASITOSCOPICO (3 MUESTRAS)', 240.00, 3, 3),
(91, 'S.O.H (Guayaco)', 95.00, 3, 3),
(92, 'HELICOBACTER PYLORI EN MATERIA FECAL', 900.00, 3, 3),
(93, 'ESPERMATOBIOSCOPIA', 350.00, 3, 3),
(94, 'CULTIVO EX. FARINGEO', 400.00, 4, 4),
(95, 'CULTIVO EX. VAGINAL', 400.00, 4, 4),
(96, 'CULTIVO DE HERIDA', 400.00, 4, 4),
(97, 'CULTIVO CERVICO VAGINAL', 400.00, 4, 4),
(98, 'PAPANICOLAU', 550.00, 4, 4),
(99, 'PAPANICOLAU BASE LIQUIDA', 600.00, 4, 4),
(100, 'PCR PARA VPH', 2500.00, 4, 4),
(101, 'CONTROL PRENATAL (bh, grupo, VDRL, GLUCOSA)', 500.00, 5, 1),
(102, 'CONTROL PRENATAL CON VIH', 600.00, 5, 1),
(103, 'PERFIL CARDIACO', 1880.00, 5, 1),
(104, 'PERFIL DE DROGAS DE 5 ANALITOS', 600.00, 5, 1),
(105, 'PERFIL DE LÍPIDOS 1', 400.00, 5, 1),
(106, 'PERFIL FEMΜΕΝΙΝΟ', 1400.00, 5, 1),
(107, 'PERFIL GINECOLOGICO', 800.00, 5, 1),
(108, 'PERFIL REUMATICO', 350.00, 5, 1),
(109, 'PERFIL TIROIDEO COMPLETO', 1500.00, 5, 1),
(110, 'PERFIL TORCH COMPLETO (IgE e IgM)', 1700.00, 5, 1),
(111, 'TAMIZ NEONATAL AMPLIADO', 2500.00, 5, 1),
(112, 'QS24 (Química Sanguínea 24 elementos)', 945.00, 5, 1),
(113, 'QS30 (QUIMICA SANGUINEA DE 30 ELEMENTOS)', 1500.00, 5, 1),
(114, 'QS45 (QUIMICA SANGUINEA DE 45 ELEMENTOS)', 2100.00, 5, 1),
(115, 'PAQUETE 1(BH,QS6, EGO,RF)', 500.00, 5, 1),
(116, 'AMC (BH, QS6, RF, EGO)', 280.00, 5, 1),
(117, 'TRIPLEX (PCR PARA DENGUE, CHIKUNCUYA, ZIKA)', 4000.00, 5, 1),
(118, 'DENGUE (IgG, IgM, Ns1)', 500.00, 1, 1),
(119, 'AC. ANTI TRIPONEMA PALLIDUM', 400.00, 1, 1),
(120, 'ASPARTO AMINOTRASFERASA AST (TGO)', 120.00, 1, 1),
(121, 'BAAR 3 MUESTRAS', 600.00, 1, 1),
(122, 'RETICULOCITOS', 120.00, 1, 1),
(123, 'ANDROSTEDIONA', 700.00, 1, 1),
(124, 'TIROGLOBULINA', 380.00, 1, 1),
(125, 'CAPTACION DE HIERRO', 250.00, 1, 1),
(126, 'VITAMINA D', 600.00, 1, 1),
(127, 'ANTI. TIROGLOBULINA', 550.00, 1, 1),
(128, 'ANTI. PEROXIDASA TIROIDEA', 550.00, 1, 1),
(129, 'TOXOPLASMOSIS ANTIGENI', 400.00, 1, 1),
(130, 'ANT. SUPERFICIE HEPATITIS B', 400.00, 1, 1),
(131, 'ANT. HEPATITIS B', 1000.00, 1, 1),
(132, 'PERFIL DE VITAMINAS', 1500.00, 5, 1),
(133, 'ANTI. PEPTIFO CICLICO CITRULIADO', 825.00, 1, 1),
(134, 'IgF1', 950.00, 1, 1),
(135, 'IgFBP-3', 1950.00, 1, 1),
(136, 'MAGNESIO SERICO', 150.00, 1, 1),
(137, 'Ag. CARCINOEMBRIONARIO', 250.00, 1, 1),
(138, 'PERFIL DE ENFERMEDADES DE TRANSMISION SEXUAL', 1400.00, 5, 1),
(139, 'QS11 (QUIMICA SANGUINEA DE 11 ELEMENTOS)', 600.00, 1, 1),
(140, 'QS13 (QUIMICA SANGUINEA DE 13 ELEMENTOS)', 630.00, 1, 1),
(141, 'FOSFORO SERICO', 250.00, 1, 1),
(142, 'CALCIO SERICO Y IONIZADO', 250.00, 1, 1),
(143, 'NIVELES DE ACIDO VALPROICO', 350.00, 1, 1),
(144, 'PEPETIDO NATRIURETICO VENTRICULAR', 800.00, 1, 1),
(145, 'COLINESTERASA', 350.00, 1, 1),
(146, 'CAPTACION DE TRANFERRINA', 350.00, 1, 1),
(147, 'TROPONINA T', 600.00, 1, 1),
(148, 'TROPONINA I', 450.00, 1, 1),
(149, 'ALERGENO GLUTEN', 1500.00, 5, 1),
(150, 'ALERGENO JENGIBRE', 1500.00, 5, 1),
(151, 'ALERGENO KIWI', 1500.00, 5, 1),
(152, 'ALERGENO MOSQUITO', 1500.00, 5, 1),
(153, 'PERFIL DE ALERGENOS ALIMENTARIOS 35 PARA', 2000.00, 5, 1),
(154, 'PERFIL DE ALERGENOS RESPIRATORIOS 33 PARA', 2000.00, 5, 1),
(155, 'PERFIL DE ALERGENO PARA LECHE', 1800.00, 5, 1),
(156, 'ALERGENO GLUTEN', 1500.00, 5, 1),
(157, 'ALERGENO JENGIBRE', 1500.00, 5, 1),
(158, 'ALERGENO KIWI', 1500.00, 5, 1),
(159, 'ALERGENO MOSQUITO', 1500.00, 5, 1),
(160, 'CREATININA EN ORINA DE 24 HRS', 200.00, 2, 2),
(161, 'ALBUMINA EN ORINA DE 24 RS', 200.00, 2, 2),
(162, 'PROTEINAS Y ALBUMINA EN ORINA DE 24 HRS', 400.00, 2, 2),
(163, 'DEP. DE UREA EN ORINA DE 24HRS', 250.00, 2, 2),
(164, 'ESTROGENO', 550.00, 1, 1),
(165, 'CISTINA C', 650.00, 1, 1),
(166, 'COLINESTERASA', 350.00, 1, 1),
(167, 'ENZIMAS CARDEACAS 2: CK, CKMB, TGO, TGP, DH', 900.00, 5, 1),
(168, 'AMC2 (PAPANICOLAU)', 350.00, 4, 4),
(169, 'Vitamina B12', 800.00, 1, 1),
(170, 'TROPONINA T (Alta Sensibilidad)', 600.00, 1, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `expediente_clinico`
--

CREATE TABLE `expediente_clinico` (
  `id_expediente` int(11) NOT NULL,
  `folio_curp` varchar(18) DEFAULT NULL,
  `fecha_visita` datetime DEFAULT current_timestamp(),
  `notas_medicas` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `incidencias`
--

CREATE TABLE `incidencias` (
  `id_incidencia` int(11) NOT NULL,
  `folio_recibo` int(11) DEFAULT NULL,
  `descripcion` text DEFAULT NULL,
  `fecha_reporte` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inventarios`
--

CREATE TABLE `inventarios` (
  `id_insumo` int(11) NOT NULL,
  `nombre_material` varchar(100) DEFAULT NULL,
  `stock_actual` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `medicos`
--

CREATE TABLE `medicos` (
  `id_medico` int(11) NOT NULL,
  `nombre_completo` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `orden_analisis`
--

CREATE TABLE `orden_analisis` (
  `id_detalle` int(11) NOT NULL,
  `folio_recibo` int(11) DEFAULT NULL,
  `id_estudio` int(11) DEFAULT NULL,
  `precio_venta` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pacientes`
--

CREATE TABLE `pacientes` (
  `folio_curp` varchar(18) NOT NULL,
  `nombre` varchar(200) NOT NULL,
  `sexo` char(1) DEFAULT NULL,
  `edad` varchar(10) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `correo` varchar(100) DEFAULT NULL,
  `es_nuevo` tinyint(1) DEFAULT 1,
  `fecha` varchar(20) DEFAULT NULL,
  `medico` varchar(200) DEFAULT NULL,
  `costo` varchar(20) DEFAULT NULL,
  `sucursal` varchar(100) DEFAULT NULL,
  `analisis_clinicos` text DEFAULT NULL,
  `fecha_registro` varchar(20) DEFAULT NULL,
  `medico_remitente` varchar(200) DEFAULT NULL,
  `sucursal_origen` varchar(100) DEFAULT NULL,
  `analisis_acumulados` text DEFAULT NULL,
  `costo_total` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `pacientes`
--

INSERT INTO `pacientes` (`folio_curp`, `nombre`, `sexo`, `edad`, `telefono`, `correo`, `es_nuevo`, `fecha`, `medico`, `costo`, `sucursal`, `analisis_clinicos`, `fecha_registro`, `medico_remitente`, `sucursal_origen`, `analisis_acumulados`, `costo_total`) VALUES
('01', 'pascal', 'M', '20', '9', 'sss', 1, 'martes, 24 de febrer', 'A quien corresponda', '$950.00', 'Teapa', 'CULTIVO EX. VAGINAL|400.00\r\nPAPANICOLAU|550.00\r\n', NULL, NULL, NULL, NULL, NULL),
('02', 'chepe', 'H', '22', '7', '@gmaail', 1, 'lunes, 16 de febrero', 'picho', '$80.00', 'Tacotalpa', 'ACIDO URICO (Sérico)|80.00\r\n', NULL, NULL, NULL, NULL, NULL),
('04', 'cuca', 'H', '22', '92255', 'fdfef', 1, 'lunes, 16 de febrero', 'A quien corresponda', '$250.00', 'Tacotalpa', 'COPROLOGICO|250.00\r\n', NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `recibos`
--

CREATE TABLE `recibos` (
  `folio_recibo` int(11) NOT NULL,
  `folio_curp` varchar(18) DEFAULT NULL,
  `id_medico` int(11) DEFAULT NULL,
  `id_sucursal` int(11) DEFAULT NULL,
  `fecha` datetime DEFAULT current_timestamp(),
  `subtotal` decimal(10,2) DEFAULT NULL,
  `descuento_aplicado` decimal(10,2) DEFAULT 0.00,
  `total_final` decimal(10,2) DEFAULT NULL,
  `recibido` decimal(10,2) DEFAULT NULL,
  `cambio` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `reporte_mensual_medicos`
--

CREATE TABLE `reporte_mensual_medicos` (
  `id_reporte` int(11) NOT NULL,
  `id_medico` int(11) DEFAULT NULL,
  `mes_anio` varchar(7) DEFAULT NULL,
  `total_pacientes_enviados` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sucursales`
--

CREATE TABLE `sucursales` (
  `id_sucursal` int(11) NOT NULL,
  `nombre_sucursal` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `sucursales`
--

INSERT INTO `sucursales` (`id_sucursal`, `nombre_sucursal`) VALUES
(1, 'Teapa'),
(2, 'Tacotalpa');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipos_muestra`
--

CREATE TABLE `tipos_muestra` (
  `id_tipo_muestra` int(11) NOT NULL,
  `nombre_muestra` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `tipos_muestra`
--

INSERT INTO `tipos_muestra` (`id_tipo_muestra`, `nombre_muestra`) VALUES
(1, 'Extracción Venosa'),
(2, 'Frasco Clínico (Orina)'),
(3, 'Frasco Clínico (Heces)'),
(4, 'Hisopo / Raspado'),
(5, 'Toma Especial / Tejido');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `uso_material`
--

CREATE TABLE `uso_material` (
  `id_estudio` int(11) NOT NULL,
  `id_insumo` int(11) NOT NULL,
  `cantidad_requerida` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `categorias`
--
ALTER TABLE `categorias`
  ADD PRIMARY KEY (`id_categoria`);

--
-- Indices de la tabla `estudios`
--
ALTER TABLE `estudios`
  ADD PRIMARY KEY (`id_estudio`),
  ADD KEY `id_categoria` (`id_categoria`),
  ADD KEY `id_tipo_muestra` (`id_tipo_muestra`);

--
-- Indices de la tabla `expediente_clinico`
--
ALTER TABLE `expediente_clinico`
  ADD PRIMARY KEY (`id_expediente`),
  ADD KEY `folio_curp` (`folio_curp`);

--
-- Indices de la tabla `incidencias`
--
ALTER TABLE `incidencias`
  ADD PRIMARY KEY (`id_incidencia`),
  ADD KEY `folio_recibo` (`folio_recibo`);

--
-- Indices de la tabla `inventarios`
--
ALTER TABLE `inventarios`
  ADD PRIMARY KEY (`id_insumo`);

--
-- Indices de la tabla `medicos`
--
ALTER TABLE `medicos`
  ADD PRIMARY KEY (`id_medico`);

--
-- Indices de la tabla `orden_analisis`
--
ALTER TABLE `orden_analisis`
  ADD PRIMARY KEY (`id_detalle`),
  ADD KEY `folio_recibo` (`folio_recibo`),
  ADD KEY `id_estudio` (`id_estudio`);

--
-- Indices de la tabla `pacientes`
--
ALTER TABLE `pacientes`
  ADD PRIMARY KEY (`folio_curp`);

--
-- Indices de la tabla `recibos`
--
ALTER TABLE `recibos`
  ADD PRIMARY KEY (`folio_recibo`),
  ADD KEY `folio_curp` (`folio_curp`),
  ADD KEY `id_medico` (`id_medico`),
  ADD KEY `id_sucursal` (`id_sucursal`);

--
-- Indices de la tabla `reporte_mensual_medicos`
--
ALTER TABLE `reporte_mensual_medicos`
  ADD PRIMARY KEY (`id_reporte`),
  ADD KEY `id_medico` (`id_medico`);

--
-- Indices de la tabla `sucursales`
--
ALTER TABLE `sucursales`
  ADD PRIMARY KEY (`id_sucursal`);

--
-- Indices de la tabla `tipos_muestra`
--
ALTER TABLE `tipos_muestra`
  ADD PRIMARY KEY (`id_tipo_muestra`);

--
-- Indices de la tabla `uso_material`
--
ALTER TABLE `uso_material`
  ADD PRIMARY KEY (`id_estudio`,`id_insumo`),
  ADD KEY `id_insumo` (`id_insumo`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `categorias`
--
ALTER TABLE `categorias`
  MODIFY `id_categoria` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `estudios`
--
ALTER TABLE `estudios`
  MODIFY `id_estudio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=171;

--
-- AUTO_INCREMENT de la tabla `expediente_clinico`
--
ALTER TABLE `expediente_clinico`
  MODIFY `id_expediente` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `incidencias`
--
ALTER TABLE `incidencias`
  MODIFY `id_incidencia` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `inventarios`
--
ALTER TABLE `inventarios`
  MODIFY `id_insumo` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `medicos`
--
ALTER TABLE `medicos`
  MODIFY `id_medico` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `orden_analisis`
--
ALTER TABLE `orden_analisis`
  MODIFY `id_detalle` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `recibos`
--
ALTER TABLE `recibos`
  MODIFY `folio_recibo` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `reporte_mensual_medicos`
--
ALTER TABLE `reporte_mensual_medicos`
  MODIFY `id_reporte` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `sucursales`
--
ALTER TABLE `sucursales`
  MODIFY `id_sucursal` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `tipos_muestra`
--
ALTER TABLE `tipos_muestra`
  MODIFY `id_tipo_muestra` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `estudios`
--
ALTER TABLE `estudios`
  ADD CONSTRAINT `estudios_ibfk_1` FOREIGN KEY (`id_categoria`) REFERENCES `categorias` (`id_categoria`),
  ADD CONSTRAINT `estudios_ibfk_2` FOREIGN KEY (`id_tipo_muestra`) REFERENCES `tipos_muestra` (`id_tipo_muestra`);

--
-- Filtros para la tabla `expediente_clinico`
--
ALTER TABLE `expediente_clinico`
  ADD CONSTRAINT `expediente_clinico_ibfk_1` FOREIGN KEY (`folio_curp`) REFERENCES `pacientes` (`folio_curp`);

--
-- Filtros para la tabla `incidencias`
--
ALTER TABLE `incidencias`
  ADD CONSTRAINT `incidencias_ibfk_1` FOREIGN KEY (`folio_recibo`) REFERENCES `recibos` (`folio_recibo`);

--
-- Filtros para la tabla `orden_analisis`
--
ALTER TABLE `orden_analisis`
  ADD CONSTRAINT `orden_analisis_ibfk_1` FOREIGN KEY (`folio_recibo`) REFERENCES `recibos` (`folio_recibo`),
  ADD CONSTRAINT `orden_analisis_ibfk_2` FOREIGN KEY (`id_estudio`) REFERENCES `estudios` (`id_estudio`);

--
-- Filtros para la tabla `recibos`
--
ALTER TABLE `recibos`
  ADD CONSTRAINT `recibos_ibfk_1` FOREIGN KEY (`folio_curp`) REFERENCES `pacientes` (`folio_curp`),
  ADD CONSTRAINT `recibos_ibfk_2` FOREIGN KEY (`id_medico`) REFERENCES `medicos` (`id_medico`),
  ADD CONSTRAINT `recibos_ibfk_3` FOREIGN KEY (`id_sucursal`) REFERENCES `sucursales` (`id_sucursal`);

--
-- Filtros para la tabla `reporte_mensual_medicos`
--
ALTER TABLE `reporte_mensual_medicos`
  ADD CONSTRAINT `reporte_mensual_medicos_ibfk_1` FOREIGN KEY (`id_medico`) REFERENCES `medicos` (`id_medico`);

--
-- Filtros para la tabla `uso_material`
--
ALTER TABLE `uso_material`
  ADD CONSTRAINT `uso_material_ibfk_1` FOREIGN KEY (`id_estudio`) REFERENCES `estudios` (`id_estudio`),
  ADD CONSTRAINT `uso_material_ibfk_2` FOREIGN KEY (`id_insumo`) REFERENCES `inventarios` (`id_insumo`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
