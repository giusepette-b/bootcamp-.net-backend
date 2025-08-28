🚀 #Bootcamp Backend & API com .NET

📋 ##Sobre o Bootcamp
Bootcamp focado no desenvolvimento de APIs e sistemas backend utilizando .NET 8 com integração de serviços de IA como diferencial estratégico.

🎯 #Objetivos Principais
Dominar desenvolvimento de APIs com ASP.NET Core

Implementar arquiteturas modernas e escaláveis

Integrar serviços de IA em aplicações .NET

Desenvolver front-end para consumo de APIs

Gerenciar containers com Docker

🛠️ #Stack Tecnológica Inicial

Core .NET

.NET 8 - Framework principal

ASP.NET Core - APIs Web RESTful

Entity Framework Core - ORM para bancos de dados

Swagger/OpenAPI - Documentação de APIs

Ferramentas de Desenvolvimento
Visual Studio Code - Editor principal

Git - Controle de versão

Docker - Containerização

Postman - Teste de APIs

IA (Como Diferencial)
Integração com APIs de IA (OpenAI, Azure AI, etc.)

ML.NET - Machine Learning em .NET

Serviços cognitivos para funcionalidades inteligentes

🛠️ Tecnologias Principais
Backend .NET
.NET 8 - Framework principal

ASP.NET Core - APIs Web

Entity Framework Core - ORM

Dapper - Micro-ORM para performance

xUnit - Testes unitários

Moq - Mocking para testes

Serviços Python
FastAPI - Framework web moderno

Pandas/NumPy - Processamento de dados

Scikit-learn - Machine Learning

TensorFlow/PyTorch - Deep Learning

RabbitMQ - Mensageria

Infraestrutura
Docker - Containerização

Docker Compose - Orquestração local

Kubernetes - Orquestração em produção

PostgreSQL - Banco de dados principal

Redis - Cache e mensageria

Nginx - API Gateway/Reverse proxy

🔧 Configuração do Ambiente
##Pré-requisitos:

# Instalar .NET 8 SDK

wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh --version 8.0.100

# Instalar Python 3.10+

sudo apt update
sudo apt install python3.10 python3-pip python3-venv

# Instalar Docker

sudo apt install docker.io docker-compose

🚀 Como Executar
Opção 1: Docker Compose (Recomendado)

# Executar todos os serviços

docker-compose up -d

# Ver logs

docker-compose logs -f

# Parar serviços

docker-compose down

Opção 2: Execução Manual

# Terminal 1: Serviço de Autenticação

cd src/auth-service
dotnet run

# Terminal 2: Serviço de Produtos

cd src/products-service
dotnet run

# Terminal 3: Serviço de IA (Python)

cd src/ai-service
uvicorn main:app --reload --port 8000

# Terminal 4: API Gateway

cd src/api-gateway
dotnet run

🧪 Testes

# Executar testes .NET

dotnet test

# Executar testes Python

cd src/ai-service
pytest

# Testes de integração

docker-compose -f docker-compose.test.yml up --build --abort-on-container-exit

📦 Deploy
Ambiente de Produção

# Build das imagens Docker

docker build -t meuservico:latest .

# Deploy no Kubernetes

kubectl apply -f infra/kubernetes/

# Rollout update

kubectl rollout restart deployment/meuservico

<div align="center">
💡 Dica: Este README será atualizado continuamente durante o bootcamp!

</div>
