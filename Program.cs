// Tema 2.1: Arreglo tradicional estático de tamaño fijo
Turno[] turnos = new Turno[50];
int cantidadTurnos = 0;

// Tema 2.1: Matriz bidimensional para almacenar los horarios de atención
string[,] horarios = {
    { "Lunes",     "08:00 - 16:00" },
    { "Martes",    "08:00 - 16:00" },
    { "Miercoles", "08:00 - 16:00" },
    { "Jueves",    "08:00 - 16:00" },
    { "Viernes",   "08:00 - 16:00" }
};

int opcion = 0;

while (opcion != 5)
{
    Console.WriteLine("\n===== AGENDA DE TURNOS =====");
    Console.WriteLine("1. Registrar turno");
    Console.WriteLine("2. Mostrar turnos");
    Console.WriteLine("3. Buscar turno");
    Console.WriteLine("4. Mostrar horarios de atencion");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione una opcion: ");
    
    string entradaOpcion = Console.ReadLine() ?? "";
    if (!int.TryParse(entradaOpcion, out opcion)) opcion = 0;

    switch (opcion)
    {
        case 1:
            if (cantidadTurnos >= 50)
            {
                Console.WriteLine("El registro de turnos esta lleno.");
                break;
            }

            Console.WriteLine("\n===== REGISTRAR TURNO =====");
            
            // 1. VALIDACIÓN: Número de Turno (Solo números positivos)
            int num = 0;
            while (true)
            {
                Console.Write("Numero de Turno: ");
                string entradaNum = Console.ReadLine() ?? "";
                if (int.TryParse(entradaNum, out num) && num > 0) break;
                Console.WriteLine("[ERROR] Ingrese un numero entero valido mayor a 0.");
            }
            
            // 2. VALIDACIÓN: Nombre del Paciente (Solo letras y espacios, no vacío)
            string nom = "";
            while (true)
            {
                Console.Write("Paciente (Nombre): ");
                nom = Console.ReadLine() ?? "";
                
                if (string.IsNullOrWhiteSpace(nom))
                {
                    Console.WriteLine("[ERROR] El nombre no puede quedar vacio.");
                    continue;
                }

                bool esValido = true;
                foreach (char c in nom)
                {
                    if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    {
                        esValido = false;
                        break;
                    }
                }

                if (esValido) break;
                Console.WriteLine("[ERROR] El nombre solo debe contener letras.");
            }
            
            // 3. VALIDACIÓN: Cédula (Solo números)
            string ced = "";
            while (true)
            {
                Console.Write("Cedula: ");
                ced = Console.ReadLine() ?? "";
                
                if (string.IsNullOrWhiteSpace(ced))
                {
                    Console.WriteLine("[ERROR] La cedula no puede quedar vacia.");
                    continue;
                }

                bool soloNumeros = true;
                foreach (char c in ced)
                {
                    if (!char.IsDigit(c))
                    {
                        soloNumeros = false;
                        break;
                    }
                }

                if (soloNumeros) break;
                Console.WriteLine("[ERROR] La cedula debe contener unicamente numeros.");
            }
            
            // 4. VALIDACIÓN: Teléfono (Solo números)
            string tel = "";
            while (true)
            {
                Console.Write("Telefono: ");
                tel = Console.ReadLine() ?? "";
                
                if (string.IsNullOrWhiteSpace(tel))
                {
                    Console.WriteLine("[ERROR] El telefono no puede quedar vacio.");
                    continue;
                }

                bool soloNumeros = true;
                foreach (char c in tel)
                {
                    if (!char.IsDigit(c))
                    {
                        soloNumeros = false;
                        break;
                    }
                }

                if (soloNumeros) break;
                Console.WriteLine("[ERROR] El telefono debe contener unicamente numeros.");
            }
            
            // 5. VALIDACIÓN: Fecha Real Obligatoria (Evita letras y datos corruptos)
            string fec = "";
            while (true)
            {
                Console.Write("Fecha (AAAA-MM-DD): ");
                fec = Console.ReadLine() ?? "";
                
                if (DateTime.TryParse(fec, out DateTime fechaConvertida))
                {
                    fec = fechaConvertida.ToString("yyyy-MM-dd");
                    break;
                }
                Console.WriteLine("[ERROR] Fecha invalida o formato incorrecto. Use el formato numérico AAAA-MM-DD (Ej: 2026-06-21).");
            }
            
           // 6. VALIDACIÓN: Hora Real Obligatoria y dentro del Horario de Atención (08:00 - 16:00)
            string hor = "";
            while (true)
            {
                Console.Write("Hora (HH:MM): ");
                hor = Console.ReadLine() ?? "";
                
                if (TimeSpan.TryParse(hor, out TimeSpan horaConvertida))
                {
                    // Definimos los límites de atención de la clínica
                    TimeSpan horaApertura = new TimeSpan(8, 0, 0);  // 08:00
                    TimeSpan horaCierre = new TimeSpan(16, 0, 0); // 16:00

                    // Verificamos si la hora ingresada está dentro del rango permitido
                    if (horaConvertida >= horaApertura && horaConvertida <= horaCierre)
                    {
                        hor = horaConvertida.ToString(@"hh\:mm");
                        break; // Hora perfecta, sale del bucle
                    }
                    else
                    {
                        Console.WriteLine("[ERROR] El horario de atencion es de 08:00 a 16:00. Ingrese una hora valida.");
                        continue;
                    }
                }
                Console.WriteLine("[ERROR] Hora invalida. Ingrese una hora real en formato de 24 horas HH:MM (Ej: 14:30).");
            }
            
            // 7. VALIDACIÓN: Especialidad (Solo letras)
            string esp = "";
            while (true)
            {
                Console.Write("Especialidad: ");
                esp = Console.ReadLine() ?? "";
                
                if (string.IsNullOrWhiteSpace(esp))
                {
                    Console.WriteLine("[ERROR] La especialidad no puede quedar vacia.");
                    continue;
                }

                bool esValido = true;
                foreach (char c in esp)
                {
                    if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    {
                        esValido = false;
                        break;
                    }
                }

                if (esValido) break;
                Console.WriteLine("[ERROR] La especialidad solo debe contener letras.");
            }

            // POO: Instanciación segura usando los Constructores creados
            Paciente nuevoPaciente = new Paciente(nom, ced, tel);
            Turno nuevoTurno = new Turno(num, fec, hor, esp, nuevoPaciente);

            // Almacenamos el objeto completo en el arreglo estático
            turnos[cantidadTurnos] = nuevoTurno;
            cantidadTurnos++;

            Console.WriteLine("\n[EXITO] Turno registrado correctamente sin datos corruptos.");
            break;

        case 2:
            Console.WriteLine("\n===== TURNOS REGISTRADOS =====");
            if (cantidadTurnos == 0)
            {
                Console.WriteLine("No existen turnos agendados.");
            }
            else
            {
                for (int i = 0; i < cantidadTurnos; i++)
                {
                    Console.WriteLine($"\nTurno N: {turnos[i].NumeroTurno}");
                    Console.WriteLine($"Paciente: {turnos[i].Paciente.Nombre} | Cedula: {turnos[i].Paciente.Cedula}");
                    Console.WriteLine($"Especialidad: {turnos[i].Especialidad} | Horario: {turnos[i].Fecha} a las {turnos[i].Hora}");
                    Console.WriteLine(new string('-', 40));
                }
            }
            break;

        case 3:
            Console.Write("\nIngrese la cedula a buscar: ");
            string buscarCedula = Console.ReadLine() ?? "";
            bool encontrado = false;

            for (int i = 0; i < cantidadTurnos; i++)
            {
                if (turnos[i].Paciente.Cedula == buscarCedula)
                {
                    Console.WriteLine($"\n[ENCONTRADO] Turno N: {turnos[i].NumeroTurno} - Especialidad: {turnos[i].Especialidad}");
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("No se encontraron turnos para la cedula ingresada.");
            }
            break;

        case 4:
            Console.WriteLine("\n===== HORARIOS DE ATENCION =====");
            for (int i = 0; i < horarios.GetLength(0); i++)
            {
                Console.WriteLine($"{horarios[i, 0]} - {horarios[i, 1]}");
            }
            break;

        case 5:
            Console.WriteLine("Saliendo del sistema...");
            break;

        default:
            Console.WriteLine("Opcion no valida.");
            break;
    }
}