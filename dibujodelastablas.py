import re
import os
from fpdf import FPDF

# Detectar carpeta automática
ruta_base = os.path.dirname(os.path.abspath(__file__))
ruta_sql = os.path.join(ruta_base, "db_laboratorio_pio.sql")

class PDF(FPDF):
    def header(self):
        self.set_font('Arial', 'B', 15)
        self.cell(0, 10, 'Diccionario de Datos - Laboratorios Pío', 0, 1, 'C')
        self.ln(5)

    def tabla_estructura(self, nombre_tabla, columnas):
        self.set_font('Arial', 'B', 12)
        self.set_fill_color(200, 220, 255)
        self.cell(0, 10, f"Tabla: {nombre_tabla}", 1, 1, 'L', 1)
        
        self.set_font('Arial', 'B', 10)
        self.set_fill_color(240, 240, 240)
        self.cell(95, 8, 'Columna', 1, 0, 'C', 1)
        self.cell(95, 8, 'Tipo de Dato', 1, 1, 'C', 1)
        
        self.set_font('Arial', '', 10)
        for col, tipo in columnas:
            self.cell(95, 8, col, 1, 0, 'L')
            self.cell(95, 8, tipo, 1, 1, 'L')
        self.ln(10)

def procesar_sql_a_pdf(archivo):
    if not os.path.exists(archivo):
        print(f"Error: No se encontró {archivo}")
        return

    with open(archivo, 'r', encoding='utf-8') as f:
        contenido = f.read()

    # Extraer estructuras (Nombre y Tipo de dato)
    bloques_tablas = re.findall(r"CREATE TABLE `([^`]+)` \((.*?)\) ENGINE", contenido, re.DOTALL)
    
    pdf = PDF()
    pdf.add_page()

    for nombre, cuerpo in bloques_tablas:
        columnas_info = []
        # Buscamos las líneas que definen columnas: `nombre` tipo_dato ...
        lineas = cuerpo.strip().split('\n')
        for linea in lineas:
            linea = linea.strip()
            if linea.startswith('`'):
                match = re.search(r"`([^`]+)`\s+([^,]+)", linea)
                if match:
                    col_nombre = match.group(1)
                    # Limpiamos el tipo de dato de cosas como NOT NULL o DEFAULT
                    col_tipo = match.group(2).split(' ')[0]
                    columnas_info.append((col_nombre, col_tipo))
        
        pdf.tabla_estructura(nombre, columnas_info)

    salida = os.path.join(ruta_base, "Estructura_DB_Laboratorio_Pio.pdf")
    pdf.output(salida)
    print(f"ÉXITO: PDF generado en {salida}")

# Ejecutar
procesar_sql_a_pdf(ruta_sql)