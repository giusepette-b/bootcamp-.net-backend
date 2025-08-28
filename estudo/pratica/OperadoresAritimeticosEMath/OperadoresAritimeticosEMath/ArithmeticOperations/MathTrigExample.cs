using System;

namespace OperadoresAritmeticosEMath.ArithmeticOperations
{
    public static class MathTrigExample
    {
        public static void DemonstrarFuncoesTrigonometricas()
        {
            Console.WriteLine("🧮 FUNÇÕES TRIGONOMÉTRICAS DO MATH");
            Console.WriteLine("==================================\n");

            DemonstrarFuncoesBasicas();
            Console.WriteLine();

            DemonstrarConversoesAngulo();
            Console.WriteLine();

            DemonstrarAplicacoesMundoReal();
            Console.WriteLine();

            DemonstrarFuncoesHiperbolicas();
            Console.WriteLine();

            TestarValoresComuns();
        }

        public static void DemonstrarFuncoesBasicas()
        {
            Console.WriteLine("📊 FUNÇÕES BÁSICAS");
            Console.WriteLine("==================");

            double anguloGraus = 45;
            double anguloRadianos = anguloGraus * Math.PI / 180;

            Console.WriteLine($"Ângulo: {anguloGraus}° = {anguloRadianos:F4} rad\n");

            // Funções trigonométricas básicas
            double seno = Math.Sin(anguloRadianos);
            double cosseno = Math.Cos(anguloRadianos);
            double tangente = Math.Tan(anguloRadianos);

            Console.WriteLine($"Seno de {anguloGraus}° = {seno:F4}");
            Console.WriteLine($"Cosseno de {anguloGraus}° = {cosseno:F4}");
            Console.WriteLine($"Tangente de {anguloGraus}° = {tangente:F4}");

            // Funções inversas
            double arcoSeno = Math.Asin(seno) * 180 / Math.PI;
            double arcoCosseno = Math.Acos(cosseno) * 180 / Math.PI;
            double arcoTangente = Math.Atan(tangente) * 180 / Math.PI;

            Console.WriteLine($"\nArco seno de {seno:F4} = {arcoSeno:F2}°");
            Console.WriteLine($"Arco cosseno de {cosseno:F4} = {arcoCosseno:F2}°");
            Console.WriteLine($"Arco tangente de {tangente:F4} = {arcoTangente:F2}°");
        }

        public static void DemonstrarConversoesAngulo()
        {
            Console.WriteLine("🔄 CONVERSÕES DE ÂNGULO");
            Console.WriteLine("======================");

            // Graus para radianos e vice-versa
            double graus = 180;
            double radianos = graus * Math.PI / 180;
            double voltaCompleta = 2 * Math.PI;

            Console.WriteLine($"{graus}° = {radianos:F4} rad");
            Console.WriteLine($"2π rad = {voltaCompleta:F4} rad = 360°");
            Console.WriteLine($"π rad = {Math.PI:F4} rad = 180°");
            Console.WriteLine($"π/2 rad = {Math.PI / 2:F4} rad = 90°");
        }

        public static void DemonstrarAplicacoesMundoReal()
        {
            Console.WriteLine("🌍 APLICAÇÕES NO MUNDO REAL");
            Console.WriteLine("===========================");

            // 1. CÁLCULO DE ALTURAS (Triangulação)
            Console.WriteLine("1. 📐 CÁLCULO DE ALTURAS (Triangulação)");
            double distancia = 50; // metros
            double anguloElevacao = 30; // graus
            double altura = distancia * Math.Tan(anguloElevacao * Math.PI / 180);
            Console.WriteLine($"   Distância: {distancia}m, Ângulo: {anguloElevacao}°");
            Console.WriteLine($"   Altura calculada: {altura:F2}m\n");

            // 2. NAVEGAÇÃO E GPS
            Console.WriteLine("2. 🧭 NAVEGAÇÃO E GPS");
            double lat1 = -23.5505, lon1 = -46.6333; // São Paulo
            double lat2 = -22.9068, lon2 = -43.1729; // Rio de Janeiro
            double distanciaKm = CalcularDistanciaGPS(lat1, lon1, lat2, lon2);
            Console.WriteLine($"   Distância SP → RJ: {distanciaKm:F2} km\n");

            // 3. ANIMAÇÕES E JOGOS (Movimento circular)
            Console.WriteLine("3. 🎮 ANIMAÇÕES E JOGOS (Movimento circular)");
            double raio = 10;
            double tempo = DateTime.Now.Second;
            double x = raio * Math.Cos(tempo * Math.PI / 30);
            double y = raio * Math.Sin(tempo * Math.PI / 30);
            Console.WriteLine($"   Posição circular (raio {raio}): X={x:F2}, Y={y:F2}\n");

            // 4. ENGENHARIA CIVIL (Cálculo de forças)
            Console.WriteLine("4. 🏗️ ENGENHARIA CIVIL (Cálculo de forças)");
            double forcaTotal = 1000; // Newtons
            double anguloForca = 45; // graus
            double forcaHorizontal = forcaTotal * Math.Cos(anguloForca * Math.PI / 180);
            double forcaVertical = forcaTotal * Math.Sin(anguloForca * Math.PI / 180);
            Console.WriteLine($"   Força {forcaTotal}N em {anguloForca}°:");
            Console.WriteLine($"   → Horizontal: {forcaHorizontal:F2}N");
            Console.WriteLine($"   → Vertical: {forcaVertical:F2}N\n");

            // 5. PROCESSAMENTO DE SINAIS
            Console.WriteLine("5. 📡 PROCESSAMENTO DE SINAIS");
            double frequencia = 1; // Hz
            double amplitude = 1;
            double sinal = amplitude * Math.Sin(2 * Math.PI * frequencia * tempo);
            Console.WriteLine($"   Sinal senoidal: {sinal:F4} (tempo = {tempo}s)");
        }

        public static void DemonstrarFuncoesHiperbolicas()
        {
            Console.WriteLine("🔥 FUNÇÕES HIPERBÓLICAS");
            Console.WriteLine("======================");

            double valor = 1.0;

            Console.WriteLine($"Seno hiperbólico de {valor}: {Math.Sinh(valor):F4}");
            Console.WriteLine($"Cosseno hiperbólico de {valor}: {Math.Cosh(valor):F4}");
            Console.WriteLine($"Tangente hiperbólica de {valor}: {Math.Tanh(valor):F4}");

            // Aplicação: Cabos suspensos (catenária)
            Console.WriteLine("\n🏗️ APLICAÇÃO: CABOS SUSPENSOS (Catenária)");
            double comprimentoCabo = 100;
            double parametro = 20;
            double formaCatenaria = parametro * Math.Cosh(comprimentoCabo / (2 * parametro));
            Console.WriteLine($"Forma do cabo: {formaCatenaria:F4}");
        }

        public static void TestarValoresComuns()
        {
            Console.WriteLine("🧪 TESTE DE VALORES COMUNS");
            Console.WriteLine("==========================");

            double[] angulosComuns = { 0, 30, 45, 60, 90, 180 };

            foreach (double graus in angulosComuns)
            {
                double radianos = graus * Math.PI / 180;
                Console.WriteLine($"\n{graus}° = {radianos:F4} rad");
                Console.WriteLine($"Seno: {Math.Sin(radianos):F4}");
                Console.WriteLine($"Cosseno: {Math.Cos(radianos):F4}");

                if (graus != 90 && graus != 270)
                    Console.WriteLine($"Tangente: {Math.Tan(radianos):F4}");
                else
                    Console.WriteLine("Tangente: Indefinida (∞)");
            }
        }

        // 📍 Fórmula de Haversine para cálculo de distância entre coordenadas GPS
        private static double CalcularDistanciaGPS(double lat1, double lon1, double lat2, double lon2)
        {
            const double raioTerraKm = 6371;

            double dLat = (lat2 - lat1) * Math.PI / 180;
            double dLon = (lon2 - lon1) * Math.PI / 180;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                      Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) *
                      Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return raioTerraKm * c;
        }

        public static void DemonstrarMathAvancado()
        {
            Console.WriteLine("\n⚡ FUNÇÕES AVANÇADAS DO MATH");
            Console.WriteLine("============================");

            // Constantes importantes
            Console.WriteLine($"π (Pi) = {Math.PI}");
            Console.WriteLine($"e (Euler) = {Math.E}");
            Console.WriteLine();

            // Funções exponenciais e logarítmicas
            Console.WriteLine($"Exponencial e² = {Math.Exp(2):F4}");
            Console.WriteLine($"Logaritmo natural ln(10) = {Math.Log(10):F4}");
            Console.WriteLine($"Logaritmo base 10 log10(100) = {Math.Log10(100):F4}");
            Console.WriteLine();

            // Potências e raízes
            Console.WriteLine($"Potência 2³ = {Math.Pow(2, 3)}");
            Console.WriteLine($"Raiz quadrada √25 = {Math.Sqrt(25)}");
            Console.WriteLine($"Raiz cúbica ∛27 = {Math.Pow(27, 1.0 / 3):F4}");
            Console.WriteLine();

            // Arredondamentos
            Console.WriteLine($"Arredondamento Math.Round(3.75) = {Math.Round(3.75)}");
            Console.WriteLine($"Teto Math.Ceiling(3.2) = {Math.Ceiling(3.2)}");
            Console.WriteLine($"Piso Math.Floor(3.8) = {Math.Floor(3.8)}");
        }
    }
}